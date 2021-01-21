#pragma checksum "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93e1fe3d3d14832b96316936bf25a23c3a0a47a3"
// <auto-generated/>
#pragma warning disable 1591
namespace SportsStore.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using SportsStore.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/products/details/{id:long}")]
    public partial class Details : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3 class=\"bg-info text-white text-center p-1\">Details</h3>\n\n");
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "class", "table table-sm table-bordered table-striped");
            __builder.OpenElement(3, "tbody");
            __builder.OpenElement(4, "tr");
            __builder.AddMarkupContent(5, "<th>ID</th>");
            __builder.OpenElement(6, "td");
            __builder.AddContent(7, 
#nullable restore
#line 7 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                            Product.ProductID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\n        ");
            __builder.OpenElement(9, "tr");
            __builder.AddMarkupContent(10, "<th>Name</th>");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 8 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                              Product.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\n        ");
            __builder.OpenElement(14, "tr");
            __builder.AddMarkupContent(15, "<th>Description</th>");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 9 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                                     Product.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\n        ");
            __builder.OpenElement(19, "tr");
            __builder.AddMarkupContent(20, "<th>Category</th>");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 10 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                                  Product.Category

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\n        ");
            __builder.OpenElement(24, "tr");
            __builder.AddMarkupContent(25, "<th>Price</th>");
            __builder.OpenElement(26, "td");
            __builder.AddContent(27, 
#nullable restore
#line 11 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                               Product.Price.ToString("C")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(29);
            __builder.AddAttribute(30, "class", "btn btn-warning");
            __builder.AddAttribute(31, "href", 
#nullable restore
#line 15 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
                                        EditUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(33, "Edit");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(34, "\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(35);
            __builder.AddAttribute(36, "class", "btn btn-secondary");
            __builder.AddAttribute(37, "href", "/admin/products");
            __builder.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(39, "Back");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\Users\Alex\SportsSln\SportsStore\Pages\Admin\Details.razor"
       

    [Inject]
    public IStoreRepository Repository { get; set; }

    [Parameter]
    public long Id { get; set; }

    public Product Product { get; set; }

    protected override void OnParametersSet() 
    {
        Product = Repository.Products.FirstOrDefault(p => p.ProductID == Id);
    }

    public string EditUrl => $"/admin/products/edit/{Product.ProductID}";

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
