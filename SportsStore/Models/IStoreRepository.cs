using System.Linq;

namespace SportsStore.Models
{
    // Download filtered data and store the data from DbContext.
    public interface IStoreRepository 
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
    }
}