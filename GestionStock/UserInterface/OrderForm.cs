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

    public OrderForm(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
    }

    private void OrderForm_Load(object sender, EventArgs e)
    {
        RefreshOrderView();
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
}
