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
public partial class ProductForm : Form
{
    private DataManager _dataManager;
    private Product _selectedProduct = null;

    public ProductForm(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
    }

    private void ProductForm_Load(object sender, EventArgs e)
    {
        PopulateCategoryComboBox();
        RefreshProductList();
        ClearFormFields();
    }

    // Charge les catégories dans le ComboBox
    private void PopulateCategoryComboBox()
    {
        try
        {
            List<Category> categories = _dataManager.GetAllCategoriesAsList();
            cmbProductCategory.DataSource = null; // Important si on recharge
            cmbProductCategory.DataSource = categories;
            cmbProductCategory.DisplayMember = "Name"; // Texte affiché
            cmbProductCategory.ValueMember = "Id";     // Valeur sous-jacente (l'ID)
            cmbProductCategory.SelectedIndex = -1; // Aucune sélection initiale
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des catégories: {ex.Message}", "Erreur ComboBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Met à jour la ListView des produits
    private void RefreshProductList()
    {
        lstProducts.Items.Clear();
        try
        {
            List<Product> products = _dataManager.GetAllProducts();
            Dictionary<int, Category> categories = _dataManager.GetAllCategories(); // Pour lookup rapide

            foreach (Product prod in products)
            {
                string categoryName = "Inconnue";
                if (categories.TryGetValue(prod.CategoryId, out Category cat))
                {
                    categoryName = cat.Name;
                }

                ListViewItem item = new ListViewItem(prod.Id.ToString());        // ID
                item.SubItems.Add(prod.Name);                                  // Nom
                item.SubItems.Add(categoryName);                               // Nom Catégorie
                item.SubItems.Add(prod.Price.ToString("C"));                   // Prix (Format monétaire)
                item.SubItems.Add(prod.Quantity.ToString());                   // Quantité
                item.Tag = prod; // Stocker l'objet Product
                lstProducts.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des produits: {ex.Message}", "Erreur Liste Produits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstProducts.SelectedItems.Count > 0)
        {
            _selectedProduct = (Product)lstProducts.SelectedItems[0].Tag;

            txtProductId.Text = _selectedProduct.Id.ToString();
            txtProductName.Text = _selectedProduct.Name;
            txtProductDescription.Text = _selectedProduct.Description;
            numProductPrice.Value = _selectedProduct.Price;
            numProductQuantity.Value = _selectedProduct.Quantity;

            // Sélectionner la bonne catégorie dans le ComboBox
            if (_dataManager.CategoryExists(_selectedProduct.CategoryId))
            {
                cmbProductCategory.SelectedValue = _selectedProduct.CategoryId;
            }
            else
            {
                cmbProductCategory.SelectedIndex = -1; // Catégorie n'existe plus?
                                                       // Peut-être afficher un avertissement ici.
            }


            btnAddProduct.Text = "Ajouter";
            btnUpdateProduct.Enabled = true;
            btnDeleteProduct.Enabled = true;
        }
        else
        {
            _selectedProduct = null;
            ClearFormFields();
        }
    }

    private void btnAddCategory_Click(object sender, EventArgs e)
    {
        // --- Validation ---
        if (string.IsNullOrWhiteSpace(txtProductName.Text))
        {
            MessageBox.Show("Le nom du produit est requis.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductName.Focus();
            return;
        }
        if (cmbProductCategory.SelectedValue == null)
        {
            MessageBox.Show("Veuillez sélectionner une catégorie.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbProductCategory.Focus();
            return;
        }
        if (numProductPrice.Value < 0)
        {
            MessageBox.Show("Le prix ne peut pas être négatif.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numProductPrice.Focus();
            return;
        }
        if (numProductQuantity.Value < 0)
        {
            MessageBox.Show("La quantité ne peut pas être négative.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numProductQuantity.Focus();
            return;
        }
        // --- Fin Validation ---

        try
        {
            Product newProduct = new Product(
                0, // ID auto-généré
                txtProductName.Text.Trim(),
                txtProductDescription.Text.Trim(),
                numProductPrice.Value,
                (int)numProductQuantity.Value,
                (int)cmbProductCategory.SelectedValue // Récupère l'ID de la catégorie
            );

            _dataManager.AddProduct(newProduct);
            MessageBox.Show("Produit ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshProductList();
            ClearFormFields();
        }
        catch (InvalidOperationException iopEx) // Cas où la catégorie n'existe pas
        {
            MessageBox.Show(iopEx.Message, "Erreur Ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            PopulateCategoryComboBox(); // Rafraichir la liste des catégories au cas où
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'ajout du produit: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        if (_selectedProduct == null)
        {
            MessageBox.Show("Veuillez sélectionner un produit à mettre à jour.", "Aucune Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // --- Validation (similaire à Add) ---
        if (string.IsNullOrWhiteSpace(txtProductName.Text)) { /*...*/ return; }
        if (cmbProductCategory.SelectedValue == null) { /*...*/ return; }
        if (numProductPrice.Value < 0) { /*...*/ return; }
        if (numProductQuantity.Value < 0) { /*...*/ return; }
        // --- Fin Validation ---

        try
        {
            Product updatedProduct = new Product(
               _selectedProduct.Id, // Garder l'ID existant
               txtProductName.Text.Trim(),
               txtProductDescription.Text.Trim(),
               numProductPrice.Value,
               (int)numProductQuantity.Value,
               (int)cmbProductCategory.SelectedValue
           );

            bool success = _dataManager.UpdateProduct(updatedProduct);
            if (success)
            {
                MessageBox.Show("Produit mis à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductList();
                ClearFormFields();
            }
            else
            {
                MessageBox.Show("Le produit sélectionné n'a pas pu être trouvé pour la mise à jour.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (InvalidOperationException iopEx) // Cas où la catégorie n'existe pas
        {
            MessageBox.Show(iopEx.Message, "Erreur Mise à Jour", MessageBoxButtons.OK, MessageBoxIcon.Error);
            PopulateCategoryComboBox();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la mise à jour du produit: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDeleteCategory_Click(object sender, EventArgs e)
    {
        if (_selectedProduct == null)
        {
            MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Aucune Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer le produit '{_selectedProduct.Name}' (ID: {_selectedProduct.Id}) ?",
                                              "Confirmation de Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                bool success = _dataManager.DeleteProduct(_selectedProduct.Id);
                if (success)
                {
                    MessageBox.Show("Produit supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductList();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Le produit sélectionné n'a pas pu être trouvé pour la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // Gérer d'autres erreurs potentielles (ex: droits fichier)
            {
                MessageBox.Show($"Erreur lors de la suppression du produit: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



    private void btnClearForm_Click(object sender, EventArgs e)
    {
        lstProducts.SelectedItems.Clear();
        // ClearFormFields(); // Sera appelé par l'événement SelectedIndexChanged
    }

    // Réinitialise les champs
    private void ClearFormFields()
    {
        _selectedProduct = null;
        txtProductId.Text = "(Nouveau)";
        txtProductName.Clear();
        txtProductDescription.Clear();
        numProductPrice.Value = numProductPrice.Minimum;
        numProductQuantity.Value = numProductQuantity.Minimum;
        cmbProductCategory.SelectedIndex = -1; // Désélectionner la catégorie

        btnAddProduct.Text = "Ajouter";
        btnUpdateProduct.Enabled = false;
        btnDeleteProduct.Enabled = false;
        txtProductName.Focus();
    }
}
