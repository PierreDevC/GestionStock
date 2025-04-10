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
    public static Panel MainPanel;
    public MainForm()
    {
        InitializeComponent();
        MainPanel = panel1; // Assigner le panel à la variable statique
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Home home = new Home();
        home.Dock = DockStyle.Fill; // Remplir le panel
        home.TopLevel = false; // Ne pas afficher la barre de titre
        panel1.Controls.Clear();
        panel1.Controls.Add(home); // Ajouter le contrôle au panel
        home.Show(); // Afficher le contrôle    
    }
}
