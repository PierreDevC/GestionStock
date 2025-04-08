using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestionStock.Entities;
public class Category
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public Category() { }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name}";
    }
}
