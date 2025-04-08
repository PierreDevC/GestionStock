using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionStock.Entities;
public class Product
{
    [JsonProperty("id")] // Pour correspondre à une clé JSON potentielle
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("categoryId")]
    public int CategoryId { get; set; } // Clé étrangère vers la catégorie

    // Constructeur par défaut nécessaire pour la désérialisation JSON
    public Product() { }

    // Constructeur pratique
    public Product(int id, string name, string description, decimal price, int quantity, int categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        CategoryId = categoryId;
    }

    // Pour afficher des informations utiles dans les listes par exemple
    public override string ToString()
    {
        return $"[{Id}] {Name} ({Price:C}) - Qty: {Quantity}";
    }
}