namespace GestionStock.UserInterface;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.btnManageProducts = new Button();
        this.btnManageCategories = new Button();
        this.btnManageOrders = new Button();
        this.btnExit = new Button();
        this.SuspendLayout();
        // 
        // btnManageProducts
        // 
        this.btnManageProducts.Location = new Point(388, 162);
        this.btnManageProducts.Name = "btnManageProducts";
        this.btnManageProducts.Size = new Size(140, 23);
        this.btnManageProducts.TabIndex = 0;
        this.btnManageProducts.Text = "Gérer les Produits";
        this.btnManageProducts.UseVisualStyleBackColor = true;
        this.btnManageProducts.Click += this.btnManageProducts_Click;
        // 
        // btnManageCategories
        // 
        this.btnManageCategories.Location = new Point(388, 205);
        this.btnManageCategories.Name = "btnManageCategories";
        this.btnManageCategories.Size = new Size(140, 23);
        this.btnManageCategories.TabIndex = 1;
        this.btnManageCategories.Text = "Gérer les Catégories";
        this.btnManageCategories.UseVisualStyleBackColor = true;
        this.btnManageCategories.Click += this.btnManageCategories_Click;
        // 
        // btnManageOrders
        // 
        this.btnManageOrders.Location = new Point(388, 245);
        this.btnManageOrders.Name = "btnManageOrders";
        this.btnManageOrders.Size = new Size(140, 23);
        this.btnManageOrders.TabIndex = 2;
        this.btnManageOrders.Text = "Gérer les Commandes";
        this.btnManageOrders.UseVisualStyleBackColor = true;
        this.btnManageOrders.Click += this.btnManageOrders_Click;
        // 
        // btnExit
        // 
        this.btnExit.Location = new Point(388, 288);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new Size(140, 23);
        this.btnExit.TabIndex = 3;
        this.btnExit.Text = "Quitter";
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.Click += this.btnExit_Click;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.btnExit);
        this.Controls.Add(this.btnManageOrders);
        this.Controls.Add(this.btnManageCategories);
        this.Controls.Add(this.btnManageProducts);
        this.Name = "MainForm";
        this.Text = "MainForm";
        this.Load += this.MainForm_Load;
        this.ResumeLayout(false);
    }

    #endregion

    private Button btnManageProducts;
    private Button btnManageCategories;
    private Button btnManageOrders;
    private Button btnExit;
}