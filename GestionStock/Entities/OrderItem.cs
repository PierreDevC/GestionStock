using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionStock.Entities;
public class OrderItem
{
    [JsonProperty("productId")]
    public int ProductId { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("priceAtOrder")] // Important de stocker le prix au moment de la commande
    public decimal PriceAtOrder { get; set; }

    public OrderItem() { }

    public OrderItem(int productId, int quantity, decimal priceAtOrder)
    {
        ProductId = productId;
        Quantity = quantity;
        PriceAtOrder = priceAtOrder;
    }
}