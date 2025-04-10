namespace GestionStock.UserInterface;

partial class OrderForm
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
        this.lblQueueInfo = new Label();
        this.lblNextOrderInfo = new Label();
        this.label9 = new Label();
        this.lstOrderQueue = new ListBox();
        this.label10 = new Label();
        this.lsvOrderItems = new ListView();
        this.columnHeader1 = new ColumnHeader();
        this.columnHeader2 = new ColumnHeader();
        this.columnHeader3 = new ColumnHeader();
        this.columnHeader4 = new ColumnHeader();
        this.btnProcessNextOrder = new Button();
        this.groupBox1 = new GroupBox();
        this.lsvNewOrderItems = new ListView();
        this.columnHeader5 = new ColumnHeader();
        this.columnHeader6 = new ColumnHeader();
        this.columnHeader7 = new ColumnHeader();
        this.columnHeader8 = new ColumnHeader();
        this.label4 = new Label();
        this.btnAddItemToOrder = new Button();
        this.numQuantityToAdd = new NumericUpDown();
        this.label3 = new Label();
        this.cmbAvailableProducts = new ComboBox();
        this.label2 = new Label();
        this.txtCustomerName = new TextBox();
        this.label1 = new Label();
        this.btnPlaceOrder = new Button();
        this.btnCancelNewOrder = new Button();
        this.homeButton = new Button();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numQuantityToAdd).BeginInit();
        this.SuspendLayout();
        // 
        // lblQueueInfo
        // 
        this.lblQueueInfo.Location = new Point(12, 12);
        this.lblQueueInfo.Name = "lblQueueInfo";
        this.lblQueueInfo.Size = new Size(154, 23);
        this.lblQueueInfo.TabIndex = 4;
        this.lblQueueInfo.Text = "Commandes en attentes : 0";
        this.lblQueueInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblNextOrderInfo
        // 
        this.lblNextOrderInfo.Location = new Point(12, 40);
        this.lblNextOrderInfo.Name = "lblNextOrderInfo";
        this.lblNextOrderInfo.Size = new Size(179, 20);
        this.lblNextOrderInfo.TabIndex = 5;
        this.lblNextOrderInfo.Text = "Prochaine commande : N/A";
        this.lblNextOrderInfo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new Point(12, 70);
        this.label9.Name = "label9";
        this.label9.Size = new Size(81, 15);
        this.label9.TabIndex = 6;
        this.label9.Text = "File d'attente :";
        // 
        // lstOrderQueue
        // 
        this.lstOrderQueue.FormattingEnabled = true;
        this.lstOrderQueue.IntegralHeight = false;
        this.lstOrderQueue.ItemHeight = 15;
        this.lstOrderQueue.Location = new Point(12, 98);
        this.lstOrderQueue.Name = "lstOrderQueue";
        this.lstOrderQueue.Size = new Size(134, 283);
        this.lstOrderQueue.TabIndex = 7;
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new Point(216, 70);
        this.label10.Name = "label10";
        this.label10.Size = new Size(170, 15);
        this.label10.TabIndex = 8;
        this.label10.Text = "Détails Prochaine Commande: ";
        // 
        // lsvOrderItems
        // 
        this.lsvOrderItems.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4 });
        this.lsvOrderItems.FullRowSelect = true;
        this.lsvOrderItems.GridLines = true;
        this.lsvOrderItems.Location = new Point(152, 98);
        this.lsvOrderItems.MultiSelect = false;
        this.lsvOrderItems.Name = "lsvOrderItems";
        this.lsvOrderItems.Size = new Size(636, 283);
        this.lsvOrderItems.TabIndex = 9;
        this.lsvOrderItems.UseCompatibleStateImageBehavior = false;
        this.lsvOrderItems.View = View.Details;
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "ID Produit";
        this.columnHeader1.Width = 70;
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Nom Produit";
        this.columnHeader2.Width = 150;
        // 
        // columnHeader3
        // 
        this.columnHeader3.Text = "Quantité";
        this.columnHeader3.TextAlign = HorizontalAlignment.Right;
        // 
        // columnHeader4
        // 
        this.columnHeader4.Text = "Prix Unitaire";
        this.columnHeader4.TextAlign = HorizontalAlignment.Right;
        this.columnHeader4.Width = 80;
        // 
        // btnProcessNextOrder
        // 
        this.btnProcessNextOrder.Enabled = false;
        this.btnProcessNextOrder.Location = new Point(18, 396);
        this.btnProcessNextOrder.Name = "btnProcessNextOrder";
        this.btnProcessNextOrder.Size = new Size(759, 83);
        this.btnProcessNextOrder.TabIndex = 10;
        this.btnProcessNextOrder.Text = "Traiter la Prochaine Commande";
        this.btnProcessNextOrder.UseVisualStyleBackColor = true;
        this.btnProcessNextOrder.Click += this.btnProcessNextOrder_Click;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.lsvNewOrderItems);
        this.groupBox1.Controls.Add(this.label4);
        this.groupBox1.Controls.Add(this.btnAddItemToOrder);
        this.groupBox1.Controls.Add(this.numQuantityToAdd);
        this.groupBox1.Controls.Add(this.label3);
        this.groupBox1.Controls.Add(this.cmbAvailableProducts);
        this.groupBox1.Controls.Add(this.label2);
        this.groupBox1.Controls.Add(this.txtCustomerName);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new Point(794, 12);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new Size(344, 391);
        this.groupBox1.TabIndex = 11;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Créer une Nouvelle Commande";
        // 
        // lsvNewOrderItems
        // 
        this.lsvNewOrderItems.Columns.AddRange(new ColumnHeader[] { this.columnHeader5, this.columnHeader6, this.columnHeader7, this.columnHeader8 });
        this.lsvNewOrderItems.FullRowSelect = true;
        this.lsvNewOrderItems.GridLines = true;
        this.lsvNewOrderItems.Location = new Point(6, 220);
        this.lsvNewOrderItems.Name = "lsvNewOrderItems";
        this.lsvNewOrderItems.Size = new Size(324, 161);
        this.lsvNewOrderItems.TabIndex = 8;
        this.lsvNewOrderItems.UseCompatibleStateImageBehavior = false;
        this.lsvNewOrderItems.View = View.Details;
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
        // btnAddItemToOrder
        // 
        this.btnAddItemToOrder.Enabled = false;
        this.btnAddItemToOrder.Location = new Point(15, 167);
        this.btnAddItemToOrder.Name = "btnAddItemToOrder";
        this.btnAddItemToOrder.Size = new Size(258, 23);
        this.btnAddItemToOrder.TabIndex = 6;
        this.btnAddItemToOrder.Text = "Ajouter au Panier";
        this.btnAddItemToOrder.UseVisualStyleBackColor = true;
        this.btnAddItemToOrder.Click += this.btnAddItemToOrder_Click;
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
        this.cmbAvailableProducts.SelectedIndexChanged += this.cmbAvailableProducts_SelectedIndexChanged;
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
        this.txtCustomerName.TextChanged += this.txtCustomerName_TextChanged;
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
        // btnPlaceOrder
        // 
        this.btnPlaceOrder.Enabled = false;
        this.btnPlaceOrder.Location = new Point(800, 399);
        this.btnPlaceOrder.Name = "btnPlaceOrder";
        this.btnPlaceOrder.Size = new Size(169, 80);
        this.btnPlaceOrder.TabIndex = 12;
        this.btnPlaceOrder.Text = "Passer la Commande";
        this.btnPlaceOrder.UseVisualStyleBackColor = true;
        this.btnPlaceOrder.Click += this.btnPlaceOrder_Click;
        // 
        // btnCancelNewOrder
        // 
        this.btnCancelNewOrder.Location = new Point(975, 399);
        this.btnCancelNewOrder.Name = "btnCancelNewOrder";
        this.btnCancelNewOrder.Size = new Size(151, 80);
        this.btnCancelNewOrder.TabIndex = 13;
        this.btnCancelNewOrder.Text = "Annuler";
        this.btnCancelNewOrder.UseVisualStyleBackColor = true;
        this.btnCancelNewOrder.Click += this.btnCancelNewOrder_Click;
        // 
        // homeButton
        // 
        this.homeButton.Location = new Point(367, 495);
        this.homeButton.Name = "homeButton";
        this.homeButton.Size = new Size(121, 23);
        this.homeButton.TabIndex = 14;
        this.homeButton.Text = "Revenir en arrière";
        this.homeButton.UseVisualStyleBackColor = true;
        this.homeButton.Click += this.homeButton_Click;
        // 
        // OrderForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1240, 570);
        this.Controls.Add(this.homeButton);
        this.Controls.Add(this.btnCancelNewOrder);
        this.Controls.Add(this.btnPlaceOrder);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.btnProcessNextOrder);
        this.Controls.Add(this.lsvOrderItems);
        this.Controls.Add(this.label10);
        this.Controls.Add(this.lstOrderQueue);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.lblNextOrderInfo);
        this.Controls.Add(this.lblQueueInfo);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "OrderForm";
        this.Text = "OrderForm";
        this.Load += this.OrderForm_Load;
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numQuantityToAdd).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
    private Label lblQueueInfo;
    private Label lblNextOrderInfo;
    private Label label9;
    private ListBox lstOrderQueue;
    private Label label10;
    private ListView lsvOrderItems;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private Button btnProcessNextOrder;
    private GroupBox groupBox1;
    private Label label1;
    private ListView lsvNewOrderItems;
    private Label label4;
    private Button btnAddItemToOrder;
    private NumericUpDown numQuantityToAdd;
    private Label label3;
    private ComboBox cmbAvailableProducts;
    private Label label2;
    private TextBox txtCustomerName;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private Button btnPlaceOrder;
    private Button btnCancelNewOrder;
    private Button homeButton;
}