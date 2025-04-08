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
public partial class OrderForm : Form
{
    private DataManager _dataManager;
    // Pour stocker les articles de la commande en cours de création
    private List<OrderItem> _currentOrderItems = new List<OrderItem>();
    private Product _selectedAvailableProduct = null; // Produit sélectionné dans le ComboBox

    public OrderForm(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
    }

    private void OrderForm_Load(object sender, EventArgs e)
    {
        RefreshOrderView(); // Met à jour la vue de la file d'attente existante
        PopulateAvailableProducts(); // Charge les produits dans le ComboBox de création
        ClearNewOrderForm(); // Assure un état initial propre pour la création
    }

    // Met à jour tout l'affichage du formulaire
    private void RefreshOrderView()
    {
        try
        {
            // 1. Mettre à jour le compteur
            int queueCount = _dataManager.GetOrderQueueCount();
            lblQueueInfo.Text = $"Commandes en attente : {queueCount}";

            // 2. Vider les listes
            lstOrderQueue.Items.Clear();
            lsvOrderItems.Items.Clear();

            // 3. Afficher la prochaine commande et ses détails
            Order nextOrder = _dataManager.GetNextOrder(); // Utilise Peek()
            if (nextOrder != null)
            {
                lblNextOrderInfo.Text = $"Prochaine commande : #{nextOrder.Id} - {nextOrder.CustomerName} ({nextOrder.OrderDate.ToShortDateString()})";

                // Peupler les détails de la commande
                foreach (OrderItem item in nextOrder.Items)
                {
                    Product product = _dataManager.GetProductById(item.ProductId);
                    string productName = (product != null) ? product.Name : "Produit Inconnu/Supprimé";

                    ListViewItem viewItem = new ListViewItem(item.ProductId.ToString());
                    viewItem.SubItems.Add(productName);
                    viewItem.SubItems.Add(item.Quantity.ToString());
                    viewItem.SubItems.Add(item.PriceAtOrder.ToString("C")); // Prix au moment de la commande
                    lsvOrderItems.Items.Add(viewItem);
                }

                btnProcessNextOrder.Enabled = true; // Activer le bouton
            }
            else
            {
                lblNextOrderInfo.Text = "Aucune commande en attente.";
                btnProcessNextOrder.Enabled = false; // Désactiver le bouton
            }

            // 4. Peupler la ListBox avec TOUTE la file d'attente (pour info)
            // Récupère une COPIE de la file pour l'affichage sans la modifier
            Queue<Order> orderQueueCopy = _dataManager.GetAllOrders();
            foreach (Order order in orderQueueCopy) // Itérer sur la copie
            {
                lstOrderQueue.Items.Add(order.ToString()); // Utilise la méthode ToString() de Order
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'affichage des commandes: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnProcessNextOrder.Enabled = false; // Sécurité
        }
    }

    private void btnProcessNextOrder_Click(object sender, EventArgs e)
    {
        try
        {
            // Confirmation (optionnelle mais recommandée)
            Order nextOrderToProcess = _dataManager.GetNextOrder();
            if (nextOrderToProcess == null)
            {
                MessageBox.Show("Il n'y a plus de commande à traiter.", "File Vide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrderView(); // Mettre à jour l'UI
                return;
            }

            DialogResult confirm = MessageBox.Show($"Traiter la commande #{nextOrderToProcess.Id} pour '{nextOrderToProcess.CustomerName}' ?",
                                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Retirer la commande de la file
                Order processedOrder = _dataManager.ProcessNextOrder(); // Utilise Dequeue()

                if (processedOrder != null)
                {
                    MessageBox.Show($"Commande #{processedOrder.Id} traitée avec succès.", "Traitement Terminé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ici, on pourrait ajouter la logique métier :
                    // - Mettre à jour le stock des produits vendus
                    // - Marquer la commande comme complétée (si on avait une liste de commandes traitées)
                    // foreach (var item in processedOrder.Items) { UpdateStock(item.ProductId, item.Quantity); }
                }
                else
                {
                    // Ne devrait pas arriver si le bouton était activé, mais par sécurité
                    MessageBox.Show("Erreur : Aucune commande n'a été traitée (la file était peut-être vide).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Mettre à jour l'affichage après traitement
                RefreshOrderView();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du traitement de la commande: {ex.Message}", "Erreur de Traitement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // Mettre à jour l'affichage même en cas d'erreur peut être utile
            RefreshOrderView();
        }
    }

    // --- FIN Logique de la file d'attente existante ---
    // Charge les produits dans le ComboBox
    private void PopulateAvailableProducts()
    {
        try
        {
            List<Product> products = _dataManager.GetAllProducts();
            // Filtrer les produits en stock (optionnel mais recommandé)
            List<Product> availableProducts = new List<Product>();
            foreach (Product p in products)
            {
                if (p.Quantity > 0)
                {
                    availableProducts.Add(p);
                }
            }

            cmbAvailableProducts.DataSource = null;
            cmbAvailableProducts.DataSource = availableProducts; // N'afficher que ceux en stock
                                                                 // Utiliser ToString() du produit pour l'affichage (il faut qu'il soit informatif)
                                                                 // Ou configurer DisplayMember si vous avez une propriété spécifique
            cmbAvailableProducts.DisplayMember = "Name"; // Ou une propriété plus descriptive
            cmbAvailableProducts.ValueMember = "Id";
            cmbAvailableProducts.SelectedIndex = -1; // Pas de sélection initiale
            _selectedAvailableProduct = null;
            btnAddItemToOrder.Enabled = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des produits disponibles: {ex.Message}", "Erreur Produits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void cmbAvailableProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbAvailableProducts.SelectedItem != null)
        {
            _selectedAvailableProduct = (Product)cmbAvailableProducts.SelectedItem;
            // Ajuster le max du NumericUpDown à la quantité dispo
            numQuantityToAdd.Maximum = _selectedAvailableProduct.Quantity;
            numQuantityToAdd.Value = 1; // Réinitialiser à 1
            btnAddItemToOrder.Enabled = true; // Activer le bouton d'ajout
        }
        else
        {
            _selectedAvailableProduct = null;
            btnAddItemToOrder.Enabled = false;
            numQuantityToAdd.Maximum = 1; // Valeur sûre si rien n'est sélectionné
            numQuantityToAdd.Value = 1;
        }
        UpdatePlaceOrderButtonState();
    }

    private void btnAddItemToOrder_Click(object sender, EventArgs e)
    {
        if (_selectedAvailableProduct == null)
        {
            MessageBox.Show("Veuillez sélectionner un produit.", "Aucun Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int quantity = (int)numQuantityToAdd.Value;
        if (quantity <= 0)
        {
            MessageBox.Show("La quantité doit être supérieure à zéro.", "Quantité Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        // Vérification supplémentaire (même si le max du NumericUpDown devrait le gérer)
        if (quantity > _selectedAvailableProduct.Quantity)
        {
            MessageBox.Show($"Quantité insuffisante en stock pour '{_selectedAvailableProduct.Name}'. Disponible : {_selectedAvailableProduct.Quantity}", "Stock Insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numQuantityToAdd.Value = _selectedAvailableProduct.Quantity; // Mettre au max dispo
            return;
        }

        // Créer l'objet OrderItem (important: utiliser le prix actuel du produit)
        OrderItem newItem = new OrderItem(_selectedAvailableProduct.Id, quantity, _selectedAvailableProduct.Price);

        // Ajouter à notre liste temporaire
        // Vérifier si le produit est déjà dans le panier pour juste augmenter la quantité (optionnel)
        bool found = false;
        for (int i = 0; i < _currentOrderItems.Count; i++)
        {
            if (_currentOrderItems[i].ProductId == newItem.ProductId)
            {
                // Augmenter la quantité existante
                // Vérifier si l'ajout dépasse le stock total !
                int newTotalQuantity = _currentOrderItems[i].Quantity + newItem.Quantity;
                if (newTotalQuantity > _selectedAvailableProduct.Quantity)
                {
                    MessageBox.Show($"Quantité totale ({newTotalQuantity}) dépasse le stock disponible ({_selectedAvailableProduct.Quantity}) pour '{_selectedAvailableProduct.Name}'.", "Stock Insuffisant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Ne pas ajouter
                }
                _currentOrderItems[i].Quantity = newTotalQuantity;
                found = true;
                break;
            }
        }
        if (!found)
        {
            _currentOrderItems.Add(newItem);
        }


        // Mettre à jour la ListView du panier
        RefreshNewOrderItemsList();

        // Réinitialiser pour le prochain ajout
        cmbAvailableProducts.SelectedIndex = -1; // Désélectionner
        numQuantityToAdd.Value = 1;
        _selectedAvailableProduct = null;
        btnAddItemToOrder.Enabled = false;

        UpdatePlaceOrderButtonState(); // Mettre à jour l'état du bouton "Passer la commande"
    }

    // Met à jour la ListView lsvNewOrderItems
    private void RefreshNewOrderItemsList()
    {
        lsvNewOrderItems.Items.Clear();
        foreach (OrderItem item in _currentOrderItems)
        {
            Product product = _dataManager.GetProductById(item.ProductId);
            string productName = (product != null) ? product.Name : "Produit Inconnu";

            ListViewItem viewItem = new ListViewItem(productName);
            viewItem.SubItems.Add(item.Quantity.ToString());
            viewItem.SubItems.Add(item.PriceAtOrder.ToString("C"));
            viewItem.SubItems.Add(item.ProductId.ToString()); // ID caché
            viewItem.Tag = item; // Stocker l'objet OrderItem si besoin (ex: pour suppression)
            lsvNewOrderItems.Items.Add(viewItem);
        }
    }

    // Activer/Désactiver le bouton "Passer la Commande"
    private void UpdatePlaceOrderButtonState()
    {
        bool customerNameOk = !string.IsNullOrWhiteSpace(txtCustomerName.Text);
        bool itemsOk = _currentOrderItems.Count > 0;
        btnPlaceOrder.Enabled = customerNameOk && itemsOk;
    }

    private void txtCustomerName_TextChanged(object sender, EventArgs e)
    {
        UpdatePlaceOrderButtonState();
    }


    private void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
        {
            MessageBox.Show("Veuillez entrer un nom de client.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCustomerName.Focus();
            return;
        }
        if (_currentOrderItems.Count == 0)
        {
            MessageBox.Show("Veuillez ajouter au moins un produit à la commande.", "Panier Vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Créer la nouvelle commande
            Order newOrder = new Order(0, txtCustomerName.Text.Trim()); // ID sera généré
                                                                        // Important : Cloner la liste d'items pour éviter les références partagées
            newOrder.Items = new List<OrderItem>(_currentOrderItems);

            // Ajouter la commande à la file d'attente via DataManager
            _dataManager.AddOrder(newOrder);

            MessageBox.Show($"Commande #{newOrder.Id} pour '{newOrder.CustomerName}' ajoutée à la file d'attente.", "Commande Passée", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Réinitialiser le formulaire de nouvelle commande
            ClearNewOrderForm();

            // Mettre à jour l'affichage de la file d'attente principale
            RefreshOrderView();

            // Recharger les produits disponibles (le stock a peut-être changé si AddOrder le modifiait,
            // mais idéalement, le stock ne change qu'au traitement 'ProcessNextOrder')
            // Si le stock est réduit à la commande, il faut recharger :
            // PopulateAvailableProducts();
            // Sinon, ce n'est pas nécessaire ici.
        }
        catch (InvalidOperationException iopEx) // Ex: Produit n'existe plus entre temps
        {
            MessageBox.Show(iopEx.Message, "Erreur Commande", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la création de la commande : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancelNewOrder_Click(object sender, EventArgs e)
    {
        ClearNewOrderForm();
    }

    // Réinitialise la section de création de commande
    private void ClearNewOrderForm()
    {
        txtCustomerName.Clear();
        cmbAvailableProducts.SelectedIndex = -1;
        numQuantityToAdd.Value = 1;
        _currentOrderItems.Clear();
        lsvNewOrderItems.Items.Clear();
        _selectedAvailableProduct = null;
        btnAddItemToOrder.Enabled = false;
        btnPlaceOrder.Enabled = false; // Désactiver le bouton Passer Commande
    }



}
