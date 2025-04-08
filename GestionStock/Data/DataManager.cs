using GestionStock.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestionStock.Data;

// Classe interne pour faciliter la sérialisation/désérialisation de toutes les données
internal class AllStoreData
{
    public List<Product> Products { get; set; }
    public Dictionary<int, Category> Categories { get; set; }
    // On sauvegarde les commandes comme une List car Queue n'est pas directement sérialisable en JSON standard.
    // On la convertira en Queue au chargement.
    public List<Order> Orders { get; set; }

    public AllStoreData()
    {
        Products = new List<Product>();
        Categories = new Dictionary<int, Category>();
        Orders = new List<Order>();
    }
}


public class DataManager
{
    private List<Product> products;
    private Dictionary<int, Category> categories;
    private Queue<Order> orders;

    private readonly string dataFilePath;

    // --- Initialisation et Persistance ---

    public DataManager(string storageFolderPath = "Data/Storage")
    {
        // Construire le chemin complet du fichier JSON
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string absoluteStoragePath = Path.Combine(baseDirectory, storageFolderPath);

        // Créer le dossier s'il n'existe pas
        if (!Directory.Exists(absoluteStoragePath))
        {
            Directory.CreateDirectory(absoluteStoragePath);
        }

        dataFilePath = Path.Combine(absoluteStoragePath, "store_data.json");

        // Initialiser les collections
        products = new List<Product>();
        categories = new Dictionary<int, Category>();
        orders = new Queue<Order>();

        LoadData(); // Charger les données au démarrage
    }

    private void LoadData()
    {
        try
        {
            if (File.Exists(dataFilePath))
            {
                string json = File.ReadAllText(dataFilePath);
                // Gérer le cas où le fichier est vide ou contient juste "null"
                if (string.IsNullOrWhiteSpace(json) || json.Trim() == "null")
                {
                    InitializeEmptyCollections();
                    return; // Pas besoin de désérialiser
                }

                AllStoreData loadedData = JsonConvert.DeserializeObject<AllStoreData>(json);

                if (loadedData != null)
                {
                    products = loadedData.Products ?? new List<Product>();
                    categories = loadedData.Categories ?? new Dictionary<int, Category>();

                    // Convertir la List<Order> chargée en Queue<Order>
                    orders = new Queue<Order>(loadedData.Orders ?? new List<Order>());
                }
                else
                {
                    InitializeEmptyCollections();
                }
            }
            else
            {
                InitializeEmptyCollections();
            }
        }
        catch (JsonException jsonEx)
        {
            // Gérer l'erreur de désérialisation (fichier corrompu?)
            Console.WriteLine($"Erreur de désérialisation JSON: {jsonEx.Message}");
            InitializeEmptyCollections(); // Initialiser avec des données vides en cas d'erreur
                                          // On pourrait lever une exception ici ou afficher un message à l'utilisateur
        }
        catch (IOException ioEx)
        {
            // Gérer l'erreur de lecture de fichier
            Console.WriteLine($"Erreur I/O lors du chargement: {ioEx.Message}");
            InitializeEmptyCollections();
            // On pourrait lever une exception ici ou afficher un message à l'utilisateur
        }
        catch (Exception ex) // Capturer d'autres erreurs potentielles
        {
            Console.WriteLine($"Erreur inattendue lors du chargement: {ex.Message}");
            InitializeEmptyCollections();
        }
    }

    private void InitializeEmptyCollections()
    {
        products = new List<Product>();
        categories = new Dictionary<int, Category>();
        orders = new Queue<Order>();
    }


    private void SaveData()
    {
        try
        {
            AllStoreData dataToSave = new AllStoreData
            {
                Products = this.products,
                Categories = this.categories,
                Orders = new List<Order>(this.orders) // Convertir la Queue en List pour la sauvegarde
            };

            string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }
        catch (JsonException jsonEx)
        {
            // Gérer l'erreur de sérialisation
            Console.WriteLine($"Erreur de sérialisation JSON: {jsonEx.Message}");
            // Afficher une erreur à l'utilisateur ou logger
        }
        catch (IOException ioEx)
        {
            // Gérer l'erreur d'écriture
            Console.WriteLine($"Erreur I/O lors de la sauvegarde: {ioEx.Message}");
            // Afficher une erreur à l'utilisateur ou logger
        }
        catch (Exception ex) // Capturer d'autres erreurs potentielles
        {
            Console.WriteLine($"Erreur inattendue lors de la sauvegarde: {ex.Message}");
        }
    }

    // --- Gestion des IDs (Exemple simple) ---

    private int GetNextProductId()
    {
        int maxId = 0;
        // Pas de LINQ: boucle manuelle
        foreach (Product p in products)
        {
            if (p.Id > maxId)
            {
                maxId = p.Id;
            }
        }
        return maxId + 1;
    }

    private int GetNextCategoryId()
    {
        int maxId = 0;
        // Pas de LINQ: boucle manuelle sur les clés ou valeurs
        if (categories.Count > 0)
        {
            foreach (int key in categories.Keys)
            {
                if (key > maxId) maxId = key;
            }
        }
        return maxId + 1;
    }

    private int GetNextOrderId()
    {
        int maxId = 0;
        // Pas de LINQ: boucle manuelle sur la queue (via copie ou itérateur)
        if (orders.Count > 0)
        {
            foreach (Order o in orders) // Itérer sur la queue ne la modifie pas
            {
                if (o.Id > maxId)
                {
                    maxId = o.Id;
                }
            }
        }
        // Si des commandes ont été traitées et ne sont plus dans la queue,
        // il faudrait potentiellement vérifier un historique ou une autre source
        // pour garantir l'unicité sur le long terme. Pour cet exemple, on se base sur la queue actuelle.
        return maxId + 1;
    }


    // --- Opérations CRUD pour Produits (List<Product>) ---

    public List<Product> GetAllProducts()
    {
        // Retourne une copie pour éviter les modifications externes non contrôlées
        return new List<Product>(products);
    }

    public Product GetProductById(int id)
    {
        // Pas de LINQ: boucle manuelle
        foreach (Product p in products)
        {
            if (p.Id == id)
            {
                return p;
            }
        }
        return null; // Non trouvé
    }

    public bool ProductExists(int id)
    {
        return GetProductById(id) != null;
    }


    public void AddProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));

        // Assigner un nouvel ID unique
        product.Id = GetNextProductId();

        // Vérifier si la catégorie existe
        if (!CategoryExists(product.CategoryId))
        {
            throw new InvalidOperationException($"La catégorie avec l'ID {product.CategoryId} n'existe pas.");
        }

        products.Add(product);
        SaveData(); // Sauvegarder après modification
    }

    public bool UpdateProduct(Product productToUpdate)
    {
        if (productToUpdate == null) throw new ArgumentNullException(nameof(productToUpdate));

        // Vérifier si la catégorie existe
        if (!CategoryExists(productToUpdate.CategoryId))
        {
            throw new InvalidOperationException($"La catégorie avec l'ID {productToUpdate.CategoryId} pour la mise à jour n'existe pas.");
        }

        // Pas de LINQ: boucle manuelle pour trouver l'index
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Id == productToUpdate.Id)
            {
                // Mettre à jour l'objet à l'index trouvé
                products[i] = productToUpdate;
                SaveData(); // Sauvegarder après modification
                return true; // Succès
            }
        }
        return false; // Produit non trouvé
    }

    public bool DeleteProduct(int id)
    {
        // Pas de LINQ: boucle manuelle pour trouver le produit
        Product productToRemove = null;
        foreach (Product p in products)
        {
            if (p.Id == id)
            {
                productToRemove = p;
                break;
            }
        }

        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            SaveData(); // Sauvegarder après modification
            return true; // Succès
        }
        return false; // Non trouvé
    }

    // --- Opérations CRUD pour Catégories (Dictionary<int, Category>) ---

    public Dictionary<int, Category> GetAllCategories()
    {
        // Retourne une copie
        return new Dictionary<int, Category>(categories);
    }

    public List<Category> GetAllCategoriesAsList()
    {
        // Méthode pratique pour les ComboBox par exemple
        List<Category> list = new List<Category>();
        foreach (KeyValuePair<int, Category> kvp in categories)
        {
            list.Add(kvp.Value);
        }
        return list;
    }


    public Category GetCategoryById(int id)
    {
        categories.TryGetValue(id, out Category category); // Utilise la recherche rapide du dictionnaire
        return category; // Retourne null si non trouvé
    }

    public bool CategoryExists(int id)
    {
        return categories.ContainsKey(id);
    }


    public void AddCategory(Category category)
    {
        if (category == null) throw new ArgumentNullException(nameof(category));

        category.Id = GetNextCategoryId();

        if (categories.ContainsKey(category.Id))
        {
            // Gérer le cas (peu probable avec GetNextId) où l'ID existe déjà
            throw new InvalidOperationException($"Une catégorie avec l'ID {category.Id} existe déjà.");
        }

        // Ajouter au dictionnaire
        categories.Add(category.Id, category);
        SaveData();
    }

    public bool UpdateCategory(Category categoryToUpdate)
    {
        if (categoryToUpdate == null) throw new ArgumentNullException(nameof(categoryToUpdate));

        if (categories.ContainsKey(categoryToUpdate.Id))
        {
            // Mettre à jour la valeur dans le dictionnaire
            categories[categoryToUpdate.Id] = categoryToUpdate;
            SaveData();
            return true;
        }
        return false; // Catégorie non trouvée
    }

    public bool DeleteCategory(int id)
    {
        // Vérifier si des produits utilisent cette catégorie
        bool isUsed = false;
        foreach (Product p in products)
        {
            if (p.CategoryId == id)
            {
                isUsed = true;
                break;
            }
        }

        if (isUsed)
        {
            throw new InvalidOperationException($"Impossible de supprimer la catégorie ID {id} car elle est utilisée par des produits.");
        }


        if (categories.Remove(id)) // Remove retourne true si la clé existait et a été supprimée
        {
            SaveData();
            return true;
        }
        return false; // Non trouvé
    }

    // --- Opérations pour Commandes (Queue<Order>) ---

    public Queue<Order> GetAllOrders()
    {
        // Retourne une copie pour éviter les modifications externes non contrôlées de la queue originale
        return new Queue<Order>(orders);
    }

    public void AddOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        order.Id = GetNextOrderId();
        order.OrderDate = DateTime.Now; // S'assurer que la date est actuelle

        // Validation simple: vérifier si les produits existent (pourrait être plus complexe)
        if (order.Items != null)
        {
            foreach (OrderItem item in order.Items)
            {
                if (!ProductExists(item.ProductId))
                {
                    throw new InvalidOperationException($"Le produit avec l'ID {item.ProductId} dans la commande n'existe pas.");
                }
                // On pourrait aussi vérifier les quantités ici si nécessaire
            }
        }

        orders.Enqueue(order); // Ajouter à la fin de la file
        SaveData();
    }

    public Order GetNextOrder()
    {
        if (orders.Count > 0)
        {
            return orders.Peek(); // Regarde le prochain élément sans le retirer
        }
        return null; // File vide
    }

    public Order ProcessNextOrder()
    {
        if (orders.Count > 0)
        {
            Order processedOrder = orders.Dequeue(); // Retire et retourne le prochain élément
                                                     // Ici, on pourrait ajouter une logique métier (ex: mettre à jour les stocks des produits)
                                                     // foreach(var item in processedOrder.Items) { ... }
            SaveData(); // Sauvegarder car la queue a été modifiée
            return processedOrder;
        }
        return null; // File vide
    }

    public int GetOrderQueueCount()
    {
        return orders.Count;
    }
}
