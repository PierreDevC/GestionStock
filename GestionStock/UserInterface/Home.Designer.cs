namespace GestionStock.UserInterface;

partial class Home
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
        this.products = new Button();
        this.categories = new Button();
        this.orders = new Button();
        this.quit = new Button();
        this.label1 = new Label();
        this.pictureBox1 = new PictureBox();
        this.clientOrder = new Button();
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
        this.SuspendLayout();
        // 
        // products
        // 
        this.products.Location = new Point(23, 80);
        this.products.Name = "products";
        this.products.Size = new Size(258, 86);
        this.products.TabIndex = 0;
        this.products.Text = "Accéder aux Produits";
        this.products.UseVisualStyleBackColor = true;
        this.products.Click += this.products_Click;
        // 
        // categories
        // 
        this.categories.Location = new Point(23, 172);
        this.categories.Name = "categories";
        this.categories.Size = new Size(258, 86);
        this.categories.TabIndex = 1;
        this.categories.Text = "Accéder aux Catégories";
        this.categories.UseVisualStyleBackColor = true;
        this.categories.Click += this.categories_Click;
        // 
        // orders
        // 
        this.orders.Location = new Point(23, 264);
        this.orders.Name = "orders";
        this.orders.Size = new Size(258, 86);
        this.orders.TabIndex = 2;
        this.orders.Text = "Accéder aux Commandes";
        this.orders.UseVisualStyleBackColor = true;
        this.orders.Click += this.orders_Click;
        // 
        // quit
        // 
        this.quit.Location = new Point(12, 493);
        this.quit.Name = "quit";
        this.quit.Size = new Size(269, 37);
        this.quit.TabIndex = 3;
        this.quit.Text = "Quitter";
        this.quit.UseVisualStyleBackColor = true;
        this.quit.Click += this.quit_Click;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.BackColor = Color.Transparent;
        this.label1.Font = new Font("No Continue", 32.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        this.label1.ForeColor = SystemColors.ControlDarkDark;
        this.label1.Location = new Point(12, 21);
        this.label1.Name = "label1";
        this.label1.Size = new Size(272, 43);
        this.label1.TabIndex = 6;
        this.label1.Text = "GestionStock";
        // 
        // pictureBox1
        // 
        this.pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        this.pictureBox1.Location = new Point(303, -10);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new Size(650, 556);
        this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        this.pictureBox1.TabIndex = 8;
        this.pictureBox1.TabStop = false;
        // 
        // clientOrder
        // 
        this.clientOrder.Location = new Point(23, 356);
        this.clientOrder.Name = "clientOrder";
        this.clientOrder.Size = new Size(258, 86);
        this.clientOrder.TabIndex = 9;
        this.clientOrder.Text = "Faire une Commande (en tant que client)";
        this.clientOrder.UseVisualStyleBackColor = true;
        this.clientOrder.Click += this.clientOrder_Click;
        // 
        // Home
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(950, 542);
        this.Controls.Add(this.clientOrder);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.quit);
        this.Controls.Add(this.orders);
        this.Controls.Add(this.categories);
        this.Controls.Add(this.products);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "Home";
        this.Text = "Home";
        this.Load += this.Home_Load;
        ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Button products;
    private Button categories;
    private Button orders;
    private Button quit;
    private Label label1;
    private PictureBox pictureBox1;
    private Button clientOrder;
}