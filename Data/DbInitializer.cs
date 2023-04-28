using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Catalog.Entities;

namespace eShop.Catalog.Data;

public static class DbInitializer
{
    public static void Initialize(StoreContext context)
    {
// Look for any categories.
    if(context.Products.Any()) return;
    // DB has been seeded
 
    
        var products = new Product[]
        { 
            new Product
        {
            Id=1,
            Name="Lofas",
            ShortDescription="short description",
            Description="description",
            RegularPrice=200,
            SalesPrice=100,
            SKU="20",
            StockStatus=true,
            Quantity=10,
            IsFeatured=true,
            IsTrend=true,
            IsPopular=true,
            Type="Shoe",
            Brand="Nike"
            
        },
new Product
        {
            Id=2,
            Name="Lofas",
            ShortDescription="short description",
            Description="description",
            RegularPrice=200,
            SalesPrice=100,
            SKU="20",
            StockStatus=true,
            Quantity=10,
            IsFeatured=true,
            IsTrend=true,
            IsPopular=true,
            Type="Shoe",
            Brand="Nike"
            
        },

        };
        context.Products.AddRange(products);
        context.SaveChanges();
    
}
}