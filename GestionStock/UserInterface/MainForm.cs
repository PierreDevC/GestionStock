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
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void btnManageProducts_Click(object sender, EventArgs e)
    {
        // Utilise l'instance statique de Program
        ProductForm productForm = new ProductForm(Program.dataManager);
        productForm.ShowDialog(); // Ouvre comme une boîte de dialogue modale
    }

    private void btnManageCategories_Click(object sender, EventArgs e)
    {
        CategoryForm categoryForm = new CategoryForm(Program.dataManager);
        categoryForm.ShowDialog();
    }

    private void btnManageOrders_Click(object sender, EventArgs e)
    {
        OrderForm orderForm = new OrderForm(Program.dataManager);
        orderForm.ShowDialog();
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
