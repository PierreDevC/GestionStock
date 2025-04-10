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
public partial class Home : Form
{
    public Home()
    {
        InitializeComponent();
    }

    private void products_Click(object sender, EventArgs e)
    {
        ProductForm productForm = new ProductForm(Program.dataManager);
        productForm.Dock = DockStyle.Fill; 
        productForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(productForm);
        productForm.Show();
    }

    private void categories_Click(object sender, EventArgs e)
    {
        CategoryForm categoryForm = new CategoryForm(Program.dataManager);
        categoryForm.Dock = DockStyle.Fill;
        categoryForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(categoryForm);
        categoryForm.Show();
    }

    private void orders_Click(object sender, EventArgs e)
    {
        OrderForm orderForm = new OrderForm(Program.dataManager);
        orderForm.Dock = DockStyle.Fill;
        orderForm.TopLevel = false;
        MainForm.MainPanel.Controls.Clear();
        MainForm.MainPanel.Controls.Add(orderForm);
        orderForm.Show();
    }

    private void quit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Home_Load(object sender, EventArgs e)
    {

    }
}
