namespace GestionStock.UserInterface;

partial class ClientOrderForm
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
        this.btnCancelNewOrder = new Button();
        this.btnPlaceOrder = new Button();
        this.groupBox1 = new GroupBox();
        this.lsvCartItems = new ListView();
        this.columnHeader5 = new ColumnHeader();
        this.columnHeader6 = new ColumnHeader();
        this.columnHeader7 = new ColumnHeader();
        this.columnHeader8 = new ColumnHeader();
        this.label4 = new Label();
        this.btnAddItemToCart = new Button();
        this.numQuantityToAdd = new NumericUpDown();
        this.label3 = new Label();
        this.cmbAvailableProducts = new ComboBox();
        this.label2 = new Label();
        this.txtCustomerName = new TextBox();
        this.label1 = new Label();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numQuantityToAdd).BeginInit();
        this.SuspendLayout();
        // 
        // btnCancelNewOrder
        // 
        this.btnCancelNewOrder.Location = new Point(481, 427);
        this.btnCancelNewOrder.Name = "btnCancelNewOrder";
        this.btnCancelNewOrder.Size = new Size(151, 61);
        this.btnCancelNewOrder.TabIndex = 16;
        this.btnCancelNewOrder.Text = "Annuler";
        this.btnCancelNewOrder.UseVisualStyleBackColor = true;
        // 
        // btnPlaceOrder
        // 
        this.btnPlaceOrder.Enabled = false;
        this.btnPlaceOrder.Location = new Point(294, 427);
        this.btnPlaceOrder.Name = "btnPlaceOrder";
        this.btnPlaceOrder.Size = new Size(169, 61);
        this.btnPlaceOrder.TabIndex = 15;
        this.btnPlaceOrder.Text = "Passer la Commande";
        this.btnPlaceOrder.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.lsvCartItems);
        this.groupBox1.Controls.Add(this.label4);
        this.groupBox1.Controls.Add(this.btnAddItemToCart);
        this.groupBox1.Controls.Add(this.numQuantityToAdd);
        this.groupBox1.Controls.Add(this.label3);
        this.groupBox1.Controls.Add(this.cmbAvailableProducts);
        this.groupBox1.Controls.Add(this.label2);
        this.groupBox1.Controls.Add(this.txtCustomerName);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new Point(288, 30);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new Size(344, 391);
        this.groupBox1.TabIndex = 14;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Créer une Nouvelle Commande";
        // 
        // lsvCartItems
        // 
        this.lsvCartItems.Columns.AddRange(new ColumnHeader[] { this.columnHeader5, this.columnHeader6, this.columnHeader7, this.columnHeader8 });
        this.lsvCartItems.FullRowSelect = true;
        this.lsvCartItems.GridLines = true;
        this.lsvCartItems.Location = new Point(6, 220);
        this.lsvCartItems.Name = "lsvCartItems";
        this.lsvCartItems.Size = new Size(324, 161);
        this.lsvCartItems.TabIndex = 8;
        this.lsvCartItems.UseCompatibleStateImageBehavior = false;
        this.lsvCartItems.View = View.Details;
        // 
        // columnHeader5
        // 
        this.columnHeader5.Text = "Produit";
        this.columnHeader5.Width = 100;
        // 
        // columnHeader6
        // 
        this.columnHeader6.Text = "Qté";
        this.columnHeader6.Width = 80;
        // 
        // columnHeader7
        // 
        this.columnHeader7.Text = "Prix U.";
        this.columnHeader7.Width = 80;
        // 
        // columnHeader8
        // 
        this.columnHeader8.Text = "ID Produit";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new Point(15, 202);
        this.label4.Name = "label4";
        this.label4.Size = new Size(149, 15);
        this.label4.TabIndex = 7;
        this.label4.Text = "Articles de la Commande : ";
        // 
        // btnAddItemToCart
        // 
        this.btnAddItemToCart.Enabled = false;
        this.btnAddItemToCart.Location = new Point(15, 167);
        this.btnAddItemToCart.Name = "btnAddItemToCart";
        this.btnAddItemToCart.Size = new Size(258, 23);
        this.btnAddItemToCart.TabIndex = 6;
        this.btnAddItemToCart.Text = "Ajouter au Panier";
        this.btnAddItemToCart.UseVisualStyleBackColor = true;
        this.btnAddItemToCart.Click += this.btnAddItemToCart_Click;
        // 
        // numQuantityToAdd
        // 
        this.numQuantityToAdd.Location = new Point(74, 124);
        this.numQuantityToAdd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.numQuantityToAdd.Name = "numQuantityToAdd";
        this.numQuantityToAdd.Size = new Size(199, 23);
        this.numQuantityToAdd.TabIndex = 5;
        this.numQuantityToAdd.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new Point(6, 126);
        this.label3.Name = "label3";
        this.label3.Size = new Size(62, 15);
        this.label3.TabIndex = 4;
        this.label3.Text = "Quantité : ";
        // 
        // cmbAvailableProducts
        // 
        this.cmbAvailableProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbAvailableProducts.FormattingEnabled = true;
        this.cmbAvailableProducts.Location = new Point(6, 85);
        this.cmbAvailableProducts.Name = "cmbAvailableProducts";
        this.cmbAvailableProducts.Size = new Size(267, 23);
        this.cmbAvailableProducts.TabIndex = 3;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new Point(6, 67);
        this.label2.Name = "label2";
        this.label2.Size = new Size(115, 15);
        this.label2.TabIndex = 2;
        this.label2.Text = "Produits Disponibles";
        // 
        // txtCustomerName
        // 
        this.txtCustomerName.Location = new Point(80, 28);
        this.txtCustomerName.Name = "txtCustomerName";
        this.txtCustomerName.Size = new Size(193, 23);
        this.txtCustomerName.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new Point(6, 31);
        this.label1.Name = "label1";
        this.label1.Size = new Size(68, 15);
        this.label1.TabIndex = 0;
        this.label1.Text = "Nom Client";
        // 
        // ClientOrderForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(950, 542);
        this.Controls.Add(this.btnCancelNewOrder);
        this.Controls.Add(this.btnPlaceOrder);
        this.Controls.Add(this.groupBox1);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "ClientOrderForm";
        this.Text = "ClientOrderForm";
        this.Load += this.ClientOrderForm_Load;
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numQuantityToAdd).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private Button btnCancelNewOrder;
    private Button btnPlaceOrder;
    private GroupBox groupBox1;
    private ListView lsvCartItems;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private Label label4;
    private Button btnAddItemToCart;
    private NumericUpDown numQuantityToAdd;
    private Label label3;
    private ComboBox cmbAvailableProducts;
    private Label label2;
    private TextBox txtCustomerName;
    private Label label1;
}