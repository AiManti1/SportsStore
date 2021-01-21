using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public EFOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);
        
        /* Comment:
        When the user’s cart data is de-serialized from the session store, new objects are created that are not 
        known to Entity Framework Core, which then tries to write all the objects into the database. 
        For the Product objects associated with an Order, this means that Entity Framework Core tries to 
        write objects that have already been stored, which causes an error. To avoid this problem, we notify 
        Entity Framework Core that the objects exist and shouldn’t be stored in the database unless they are modified.
        This ensures that Entity Framework Core won’t try to write the de-serialized Product objects that are 
        associated with the Order object.*/
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}