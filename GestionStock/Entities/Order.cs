using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionStock.Entities;
public class Order
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("customerName")]
    public string CustomerName { get; set; }

    [JsonProperty("orderDate")]
    public DateTime OrderDate { get; set; }

    [JsonProperty("items")]
    public List<OrderItem> Items { get; set; }

    public Order()
    {
        Items = new List<OrderItem>(); // Initialiser la liste
        OrderDate = DateTime.Now; // Date par défaut
    }

    public Order(int id, string customerName) : this() // Appelle le constructeur par défaut
    {
        Id = id;
        CustomerName = customerName;
    }

    public override string ToString()
    {
        return $"Order #{Id} - {CustomerName} ({OrderDate.ToShortDateString()}) - {Items.Count} item(s)";
    }
}
