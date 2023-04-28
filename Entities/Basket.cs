using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Catalog.Entities;

public class Basket
{
    public int Id {get; set; }
    public string BuyerId {get; set; } = null!;
    public List<BasketItem> Items {get; set; } = new List<BasketItem>();
}
