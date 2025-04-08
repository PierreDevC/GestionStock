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
public partial class CategoryForm : Form
{
    private DataManager _dataManager;
    private Category _selectedCategory = null; // Pour garder une trace de l'objet sélectionné

    public CategoryForm(DataManager dataManager)
    {
        InitializeComponent();
        _dataManager = dataManager;
    }

    private void CategoryForm_Load(object sender, EventArgs e)
    {
        // Optionnel: Configurer la ListView (peut aussi se faire dans le designer)
        // lstCategories.View = View.Details;
        // lstCategories.FullRowSelect = true; etc.

        RefreshCategoryList(); // Charger les données initiales
        ClearFormFields();     // Assurer un état initial propre
    }

    // Met à jour la ListView avec les données actuelles
    private void RefreshCategoryList()
    {
        lstCategories.Items.Clear(); // Vider la liste actuelle
        try
        {
            List<Category> categories = _dataManager.GetAllCategoriesAsList();
            foreach (Category cat in categories)
            {
                ListViewItem item = new ListViewItem(cat.Id.ToString()); // Colonne 1: ID
                item.SubItems.Add(cat.Name);                            // Colonne 2: Nom
                item.Tag = cat; // <- TRÈS IMPORTANT: Stocker l'objet Category entier ici
                lstCategories.Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du chargement des catégories: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstCategories.SelectedItems.Count > 0)
        {
            // Un item est sélectionné
            ListViewItem selectedItem = lstCategories.SelectedItems[0];
            _selectedCategory = (Category)selectedItem.Tag; // Récupérer l'objet stocké

            // Afficher les données dans les champs
            txtCategoryId.Text = _selectedCategory.Id.ToString();
            txtCategoryName.Text = _selectedCategory.Name;

            // Mettre à jour l'état des boutons
            btnAddCategory.Text = "Ajouter"; // Revenir au texte standard
            btnUpdateCategory.Enabled = true;
            btnDeleteCategory.Enabled = true;
        }
        else
        {
            // Aucun item sélectionné (ou après Clear)
            _selectedCategory = null;
            ClearFormFields(); // Réinitialiser les champs et les boutons
        }
    }

    private void btnAddCategory_Click(object sender, EventArgs e)
    {
        string name = txtCategoryName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Le nom de la catégorie ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCategoryName.Focus();
            return;
        }

        try
        {
            Category newCategory = new Category(0, name); // ID sera attribué par DataManager
            _dataManager.AddCategory(newCategory);
            MessageBox.Show("Catégorie ajoutée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshCategoryList(); // Mettre à jour la liste
            ClearFormFields();     // Réinitialiser pour une nouvelle saisie
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'ajout de la catégorie: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        if (_selectedCategory == null)
        {
            MessageBox.Show("Veuillez sélectionner une catégorie à mettre à jour.", "Aucune Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string name = txtCategoryName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Le nom de la catégorie ne peut pas être vide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCategoryName.Focus();
            return;
        }

        try
        {
            // Créer un objet mis à jour avec l'ID existant
            Category updatedCategory = new Category(_selectedCategory.Id, name);
            bool success = _dataManager.UpdateCategory(updatedCategory);

            if (success)
            {
                MessageBox.Show("Catégorie mise à jour avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCategoryList();
                ClearFormFields();
            }
            else
            {
                MessageBox.Show("La catégorie sélectionnée n'a pas pu être trouvée pour la mise à jour.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la mise à jour de la catégorie: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDeleteCategory_Click(object sender, EventArgs e)
    {
        if (_selectedCategory == null)
        {
            MessageBox.Show("Veuillez sélectionner une catégorie à supprimer.", "Aucune Sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Confirmation
        DialogResult result = MessageBox.Show($"Êtes-vous sûr de vouloir supprimer la catégorie '{_selectedCategory.Name}' (ID: {_selectedCategory.Id}) ?",
                                              "Confirmation de Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                bool success = _dataManager.DeleteCategory(_selectedCategory.Id);
                if (success)
                {
                    MessageBox.Show("Catégorie supprimée avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCategoryList();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("La catégorie sélectionnée n'a pas pu être trouvée pour la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidOperationException ioEx) // Cas où la catégorie est utilisée
            {
                MessageBox.Show(ioEx.Message, "Suppression Impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la catégorie: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void txtCategoryId_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtCategoryName_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnClearForm_Click(object sender, EventArgs e)
    {
        lstCategories.SelectedItems.Clear(); // Désélectionne tout dans la liste
        // Cela déclenchera l'événement SelectedIndexChanged qui appellera ClearFormFields
        // Si ce n'est pas le cas (ou pour être sûr), appelez-le explicitement:
        // ClearFormFields();
    }

    // Réinitialise les champs de saisie et l'état des boutons
    private void ClearFormFields()
    {
        _selectedCategory = null;
        txtCategoryId.Text = "(Nouveau)"; // Indiquer qu'aucun ID n'est sélectionné
        txtCategoryName.Clear();
        btnAddCategory.Text = "Ajouter";
        btnUpdateCategory.Enabled = false;
        btnDeleteCategory.Enabled = false;
        txtCategoryName.Focus(); // Mettre le focus sur le champ nom
    }
}
