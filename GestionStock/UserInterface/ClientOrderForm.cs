using GestionStock.Data;
using GestionStock.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStock.UserInterface;
public partial class ClientOrderForm : Form
{
    private DataManager _dataManager;
    // Liste temporaire pour les articles du panier actuel
    private List<OrderItem> _currentCartItems = new List<OrderItem>();
    private Product _selectedAvailableProduct = null; // Produit sélectionné dans le ComboBox

    public ClientOrderForm(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager ?? throw new ArgumentNullException(nameof(dataManager)); // Vérification
    }

    private void ClientOrderForm_Load(object sender, EventArgs e)
    {
        PopulateAvailableProducts(); // Remplir la liste des produits
        ClearForm();                 // Initialiser le formulaire
    }

    // Remplit le ComboBox avec les produits disponibles (quantité > 0)
    private void PopulateAvailableProducts()
    {
        try
        {
            List<Product> allProducts = _dataManager.GetAllProducts();
            List<Product> availableProducts = new List<Product>();

            // Filtrer pour ne garder que les produits en stock
            foreach (Product p in allProducts)
            {
                if (p.Quantity > 0)
                {
                    availableProducts.Add(p);
                }
            }

            cmbAvailableProducts.DataSource = null; // Important pour rafraîchir
            cmbAvailableProducts.DataSource = availableProducts;
            // Assurez-vous que Product.ToString() est informatif (voir note plus bas)
            // Ou utilisez DisplayMember s'il y a une propriété dédiée
            // cmbAvailableProducts.DisplayMember = "Name"; // Si Product.ToString() n'est pas idéal
            cmbAvailableProducts.ValueMember = "Id";
            cmbAvailableProducts.SelectedIndex = -1; // Aucune sélection par défaut
            _selectedAvailableProduct = null;
            btnAddItemToCart.Enabled = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des produits : {ex.Message}", "Erreur Produits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Quand un produit est sélectionné dans la liste déroulante
    private void cmbAvailableProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbAvailableProducts.SelectedItem is Product selectedProd) // Utilisation du pattern matching
        {
            _selectedAvailableProduct = selectedProd;
            // Mettre à jour le maximum du NumericUpDown basé sur le stock
            numQuantityToAdd.Maximum = _selectedAvailableProduct.Quantity;
            // Réinitialiser la quantité à 1 à chaque sélection
            numQuantityToAdd.Value = 1;
            btnAddItemToCart.Enabled = true; // Activer le bouton "Ajouter"
        }
        else
        {
            _selectedAvailableProduct = null;
            numQuantityToAdd.Maximum = 1; // Mettre une limite basse sûre
            numQuantityToAdd.Value = 1;
            btnAddItemToCart.Enabled = false; // Désactiver le bouton "Ajouter"
        }
    }

    // Bouton "Ajouter au Panier"
    private void btnAddItemToCart_Click(object sender, EventArgs e)
    {
        if (_selectedAvailableProduct == null)
        {
            MessageBox.Show("Veuillez sélectionner un produit à ajouter.", "Aucun Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int quantityToAdd = (int)numQuantityToAdd.Value;

        // Vérification finale (au cas où le stock aurait changé entre temps)
        if (quantityToAdd > _selectedAvailableProduct.Quantity)
        {
            MessageBox.Show($"Quantité demandée ({quantityToAdd}) supérieure au stock disponible ({_selectedAvailableProduct.Quantity}) pour '{_selectedAvailableProduct.Name}'.",
                            "Stock Insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numQuantityToAdd.Value = _selectedAvailableProduct.Quantity; // Ajuster au max
            return;
        }

        // Vérifier si le produit est déjà dans le panier
        OrderItem existingItem = null;
        foreach (OrderItem item in _currentCartItems)
        {
            if (item.ProductId == _selectedAvailableProduct.Id)
            {
                existingItem = item;
                break;
            }
        }

        if (existingItem != null)
        {
            // Produit déjà présent : mettre à jour la quantité
            int newTotalQuantity = existingItem.Quantity + quantityToAdd;
            // Re-vérifier le stock total demandé
            if (newTotalQuantity > _selectedAvailableProduct.Quantity)
            {
                MessageBox.Show($"Ajouter {quantityToAdd} de plus dépasserait le stock total ({_selectedAvailableProduct.Quantity}) pour '{_selectedAvailableProduct.Name}'. Quantité actuelle dans le panier: {existingItem.Quantity}.",
                                "Stock Insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            existingItem.Quantity = newTotalQuantity;
            // Le prix unitaire reste celui du premier ajout, c'est une convention possible.
            // Si le prix peut changer, il faudrait peut-être le recalculer ou avoir une autre approche.
        }
        else
        {
            // Nouveau produit : créer et ajouter l'OrderItem
            OrderItem newItem = new OrderItem(
                _selectedAvailableProduct.Id,
                quantityToAdd,
                _selectedAvailableProduct.Price // Prix actuel au moment de l'ajout
            );
            _currentCartItems.Add(newItem);
        }

        // Mettre à jour l'affichage du panier
        RefreshCartListView();

        // Réinitialiser la sélection de produit
        cmbAvailableProducts.SelectedIndex = -1;
        numQuantityToAdd.Value = 1;
        _selectedAvailableProduct = null; // Important
        btnAddItemToCart.Enabled = false; // Important


        // Mettre à jour l'état du bouton "Passer la Commande"
        UpdatePlaceOrderButtonState();
    }

    // Met à jour la ListView du panier (lsvCartItems)
    private void RefreshCartListView()
    {
        lsvCartItems.Items.Clear();
        decimal totalOrderAmount = 0;

        foreach (OrderItem item in _currentCartItems)
        {
            Product product = _dataManager.GetProductById(item.ProductId);
            string productName = product?.Name ?? "Produit Inconnu/Supprimé"; // Gérer si le produit n'existe plus
            decimal itemTotalPrice = item.Quantity * item.PriceAtOrder;
            totalOrderAmount += itemTotalPrice;

            ListViewItem viewItem = new ListViewItem(productName);            // Colonne 1: Nom
            viewItem.SubItems.Add(item.Quantity.ToString());                  // Colonne 2: Qté
            viewItem.SubItems.Add(item.PriceAtOrder.ToString("C"));           // Colonne 3: Prix U.
            viewItem.SubItems.Add(itemTotalPrice.ToString("C"));              // Colonne 4: Total Ligne
            viewItem.SubItems.Add(item.ProductId.ToString());                 // Colonne 5: ID (caché)
            viewItem.Tag = item; // Stocker l'objet OrderItem (utile pour suppression éventuelle)
            lsvCartItems.Items.Add(viewItem);
        }

        // Optionnel: Afficher le total général quelque part (ex: dans le Text du GroupBox)
        // grpOrderCreation.Text = $"Nouvelle Commande Client - Total : {totalOrderAmount:C}";
    }

    // Active/Désactive le bouton "Passer la Commande"
    private void UpdatePlaceOrderButtonState()
    {
        bool customerOk = !string.IsNullOrWhiteSpace(txtCustomerName.Text);
        bool itemsOk = _currentCartItems.Count > 0;
        btnPlaceOrder.Enabled = customerOk && itemsOk;
    }

    // Si le nom du client change, vérifier si on peut activer le bouton "Passer"
    private void txtCustomerName_TextChanged(object sender, EventArgs e)
    {
        UpdatePlaceOrderButtonState();
    }

    // Bouton "Passer la Commande"
    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        // Double vérification (même si le bouton devrait être désactivé)
        if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || _currentCartItems.Count == 0)
        {
            MessageBox.Show("Veuillez entrer un nom de client et ajouter au moins un produit au panier.",
                            "Informations Manquantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // 1. Créer l'objet Order
            Order newOrder = new Order(0, txtCustomerName.Text.Trim()); // ID sera donné par DataManager
                                                                        // **TRÈS IMPORTANT**: Créer une NOUVELLE liste pour les items de la commande,
                                                                        // sinon la commande pointera vers _currentCartItems qui pourrait être modifié ensuite.
            newOrder.Items = new List<OrderItem>(_currentCartItems);

            // 2. Ajouter la commande via DataManager (qui gère la sauvegarde JSON)
            _dataManager.AddOrder(newOrder);

            // (Optionnel mais recommandé) Mettre à jour le stock si nécessaire ICI ou dans AddOrder
            // Si AddOrder ne met pas à jour le stock, il faudrait le faire ici ou attendre ProcessOrder
            // Exemple (si AddOrder ne le fait pas):
            /*
            foreach(var item in newOrder.Items)
            {
                 Product product = _dataManager.GetProductById(item.ProductId);
                 if (product != null)
                 {
                      product.Quantity -= item.Quantity;
                      _dataManager.UpdateProduct(product); // Assurez-vous que DataManager sauvegarde ici
                 }
            }
            // Il faudrait aussi recharger la liste des produits disponibles après ça
            // PopulateAvailableProducts();
            */

            // 3. Confirmer à l'utilisateur
            MessageBox.Show($"Commande #{newOrder.Id} pour '{newOrder.CustomerName}' a été créée et ajoutée à la file d'attente.",
                            "Commande Passée", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. Réinitialiser le formulaire pour une nouvelle commande
            ClearForm();

            // Optionnel : Fermer le formulaire après succès
            // this.Close();
        }
        catch (InvalidOperationException iopEx) // Ex: Le produit a disparu entre temps ?
        {
            MessageBox.Show($"Erreur lors de la validation de la commande : {iopEx.Message}", "Erreur Commande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Recharger les produits peut être utile si un produit a été supprimé
            PopulateAvailableProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Une erreur inattendue est survenue lors de la création de la commande : {ex.Message}",
                            "Erreur Inattendue", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Bouton "Annuler / Vider"
    private void btnCancelOrder_Click(object sender, EventArgs e)
    {
        // Si le panier n'est pas vide, demander confirmation avant de vider
        if (_currentCartItems.Count > 0)
        {
            DialogResult result = MessageBox.Show("Voulez-vous vraiment vider le panier et annuler la commande en cours ?",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Ne rien faire si l'utilisateur clique Non
            }
        }
        ClearForm(); // Vider le formulaire
    }

    // Réinitialise tous les champs et l'état du formulaire
    private void ClearForm()
    {
        txtCustomerName.Clear();
        _currentCartItems.Clear(); // Vider la liste temporaire du panier
        RefreshCartListView();     // Mettre à jour l'affichage (qui sera vide)
        cmbAvailableProducts.SelectedIndex = -1; // Désélectionner produit
        numQuantityToAdd.Value = 1;
        numQuantityToAdd.Maximum = 100; // Réinitialiser le max par défaut
        _selectedAvailableProduct = null;
        btnAddItemToCart.Enabled = false;
        UpdatePlaceOrderButtonState(); // Désactivera btnPlaceOrder
        txtCustomerName.Focus(); // Remettre le focus sur le nom du client
    }
}


