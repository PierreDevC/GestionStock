namespace GestionStock.UserInterface;

partial class ProductForm
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
        this.lstProducts = new ListView();
        this.columnHeader1 = new ColumnHeader();
        this.columnHeader2 = new ColumnHeader();
        this.columnHeader3 = new ColumnHeader();
        this.columnHeader4 = new ColumnHeader();
        this.columnHeader5 = new ColumnHeader();
        this.grpProductDetails = new GroupBox();
        this.label6 = new Label();
        this.cmbProductCategory = new ComboBox();
        this.numProductQuantity = new NumericUpDown();
        this.label5 = new Label();
        this.numProductPrice = new NumericUpDown();
        this.label4 = new Label();
        this.txtProductDescription = new TextBox();
        this.label3 = new Label();
        this.btnClearForm = new Button();
        this.btnDeleteProduct = new Button();
        this.btnUpdateProduct = new Button();
        this.btnAddProduct = new Button();
        this.txtProductName = new TextBox();
        this.label2 = new Label();
        this.txtProductId = new TextBox();
        this.label1 = new Label();
        this.button1 = new Button();
        this.grpProductDetails.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.numProductQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.numProductPrice).BeginInit();
        this.SuspendLayout();
        // 
        // lstProducts
        // 
        this.lstProducts.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4, this.columnHeader5 });
        this.lstProducts.FullRowSelect = true;
        this.lstProducts.GridLines = true;
        this.lstProducts.Location = new Point(12, 12);
        this.lstProducts.MultiSelect = false;
        this.lstProducts.Name = "lstProducts";
        this.lstProducts.Size = new Size(512, 426);
        this.lstProducts.TabIndex = 1;
        this.lstProducts.UseCompatibleStateImageBehavior = false;
        this.lstProducts.View = View.Details;
        this.lstProducts.SelectedIndexChanged += this.lstProducts_SelectedIndexChanged;
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "ID";
        this.columnHeader1.Width = 50;
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Nom";
        this.columnHeader2.Width = 150;
        // 
        // columnHeader3
        // 
        this.columnHeader3.Text = "Categorie";
        this.columnHeader3.Width = 100;
        // 
        // columnHeader4
        // 
        this.columnHeader4.Text = "Prix";
        this.columnHeader4.TextAlign = HorizontalAlignment.Right;
        this.columnHeader4.Width = 80;
        // 
        // columnHeader5
        // 
        this.columnHeader5.Text = "Quantité";
        // 
        // grpProductDetails
        // 
        this.grpProductDetails.Controls.Add(this.label6);
        this.grpProductDetails.Controls.Add(this.cmbProductCategory);
        this.grpProductDetails.Controls.Add(this.numProductQuantity);
        this.grpProductDetails.Controls.Add(this.label5);
        this.grpProductDetails.Controls.Add(this.numProductPrice);
        this.grpProductDetails.Controls.Add(this.label4);
        this.grpProductDetails.Controls.Add(this.txtProductDescription);
        this.grpProductDetails.Controls.Add(this.label3);
        this.grpProductDetails.Controls.Add(this.btnClearForm);
        this.grpProductDetails.Controls.Add(this.btnDeleteProduct);
        this.grpProductDetails.Controls.Add(this.btnUpdateProduct);
        this.grpProductDetails.Controls.Add(this.btnAddProduct);
        this.grpProductDetails.Controls.Add(this.txtProductName);
        this.grpProductDetails.Controls.Add(this.label2);
        this.grpProductDetails.Controls.Add(this.txtProductId);
        this.grpProductDetails.Controls.Add(this.label1);
        this.grpProductDetails.Location = new Point(530, 12);
        this.grpProductDetails.Name = "grpProductDetails";
        this.grpProductDetails.Size = new Size(258, 426);
        this.grpProductDetails.TabIndex = 2;
        this.grpProductDetails.TabStop = false;
        this.grpProductDetails.Text = "Détails Produit";
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new Point(6, 275);
        this.label6.Name = "label6";
        this.label6.Size = new Size(64, 15);
        this.label6.TabIndex = 15;
        this.label6.Text = "Catégorie :";
        // 
        // cmbProductCategory
        // 
        this.cmbProductCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbProductCategory.FormattingEnabled = true;
        this.cmbProductCategory.Location = new Point(79, 272);
        this.cmbProductCategory.Name = "cmbProductCategory";
        this.cmbProductCategory.Size = new Size(173, 23);
        this.cmbProductCategory.TabIndex = 14;
        // 
        // numProductQuantity
        // 
        this.numProductQuantity.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
        this.numProductQuantity.Location = new Point(79, 234);
        this.numProductQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        this.numProductQuantity.Name = "numProductQuantity";
        this.numProductQuantity.Size = new Size(173, 23);
        this.numProductQuantity.TabIndex = 13;
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new Point(6, 236);
        this.label5.Name = "label5";
        this.label5.Size = new Size(59, 15);
        this.label5.TabIndex = 12;
        this.label5.Text = "Quantité :";
        // 
        // numProductPrice
        // 
        this.numProductPrice.Increment = new decimal(new int[] { 10, 0, 0, 131072 });
        this.numProductPrice.Location = new Point(79, 197);
        this.numProductPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        this.numProductPrice.Name = "numProductPrice";
        this.numProductPrice.Size = new Size(173, 23);
        this.numProductPrice.TabIndex = 11;
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new Point(6, 199);
        this.label4.Name = "label4";
        this.label4.Size = new Size(32, 15);
        this.label4.TabIndex = 10;
        this.label4.Text = "Prix: ";
        // 
        // txtProductDescription
        // 
        this.txtProductDescription.Location = new Point(79, 106);
        this.txtProductDescription.Multiline = true;
        this.txtProductDescription.Name = "txtProductDescription";
        this.txtProductDescription.Size = new Size(173, 72);
        this.txtProductDescription.TabIndex = 9;
        this.txtProductDescription.TabStop = false;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new Point(6, 109);
        this.label3.Name = "label3";
        this.label3.Size = new Size(73, 15);
        this.label3.TabIndex = 8;
        this.label3.Text = "Description :";
        // 
        // btnClearForm
        // 
        this.btnClearForm.Location = new Point(6, 397);
        this.btnClearForm.Name = "btnClearForm";
        this.btnClearForm.Size = new Size(246, 23);
        this.btnClearForm.TabIndex = 7;
        this.btnClearForm.Text = "Effacer / Nouveau";
        this.btnClearForm.UseVisualStyleBackColor = true;
        this.btnClearForm.Click += this.btnClearForm_Click;
        // 
        // btnDeleteProduct
        // 
        this.btnDeleteProduct.Location = new Point(6, 368);
        this.btnDeleteProduct.Name = "btnDeleteProduct";
        this.btnDeleteProduct.Size = new Size(246, 23);
        this.btnDeleteProduct.TabIndex = 6;
        this.btnDeleteProduct.Text = "Supprimer";
        this.btnDeleteProduct.UseVisualStyleBackColor = true;
        this.btnDeleteProduct.Click += this.btnDeleteCategory_Click;
        // 
        // btnUpdateProduct
        // 
        this.btnUpdateProduct.Location = new Point(6, 339);
        this.btnUpdateProduct.Name = "btnUpdateProduct";
        this.btnUpdateProduct.Size = new Size(246, 23);
        this.btnUpdateProduct.TabIndex = 5;
        this.btnUpdateProduct.Text = "Mettre à jour";
        this.btnUpdateProduct.UseVisualStyleBackColor = true;
        this.btnUpdateProduct.Click += this.btnUpdateCategory_Click;
        // 
        // btnAddProduct
        // 
        this.btnAddProduct.Location = new Point(6, 310);
        this.btnAddProduct.Name = "btnAddProduct";
        this.btnAddProduct.Size = new Size(246, 23);
        this.btnAddProduct.TabIndex = 4;
        this.btnAddProduct.Text = "Ajouter";
        this.btnAddProduct.UseVisualStyleBackColor = true;
        this.btnAddProduct.Click += this.btnAddCategory_Click;
        // 
        // txtProductName
        // 
        this.txtProductName.Location = new Point(79, 67);
        this.txtProductName.Name = "txtProductName";
        this.txtProductName.Size = new Size(173, 23);
        this.txtProductName.TabIndex = 3;
        this.txtProductName.TabStop = false;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new Point(6, 70);
        this.label2.Name = "label2";
        this.label2.Size = new Size(40, 15);
        this.label2.TabIndex = 2;
        this.label2.Text = "Nom :";
        // 
        // txtProductId
        // 
        this.txtProductId.Location = new Point(79, 30);
        this.txtProductId.Name = "txtProductId";
        this.txtProductId.ReadOnly = true;
        this.txtProductId.Size = new Size(173, 23);
        this.txtProductId.TabIndex = 1;
        this.txtProductId.TabStop = false;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new Point(6, 33);
        this.label1.Name = "label1";
        this.label1.Size = new Size(27, 15);
        this.label1.TabIndex = 0;
        this.label1.Text = "ID : ";
        // 
        // button1
        // 
        this.button1.Location = new Point(856, 135);
        this.button1.Name = "button1";
        this.button1.Size = new Size(75, 23);
        this.button1.TabIndex = 3;
        this.button1.Text = "go back";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += this.button1_Click;
        // 
        // ProductForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(986, 450);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.grpProductDetails);
        this.Controls.Add(this.lstProducts);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "ProductForm";
        this.Text = "ProductForm";
        this.Load += this.ProductForm_Load;
        this.grpProductDetails.ResumeLayout(false);
        this.grpProductDetails.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.numProductQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.numProductPrice).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private ListView lstProducts;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private GroupBox grpProductDetails;
    private Button btnClearForm;
    private Button btnDeleteProduct;
    private Button btnUpdateProduct;
    private Button btnAddProduct;
    private TextBox txtProductName;
    private Label label2;
    private TextBox txtProductId;
    private Label label1;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private Label label4;
    private TextBox txtProductDescription;
    private Label label3;
    private NumericUpDown numProductQuantity;
    private Label label5;
    private NumericUpDown numProductPrice;
    private Label label6;
    private ComboBox cmbProductCategory;
    private Button button1;
}