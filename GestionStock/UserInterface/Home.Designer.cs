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
        this.products = new Button();
        this.categories = new Button();
        this.orders = new Button();
        this.quit = new Button();
        this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
        this.SuspendLayout();
        // 
        // products
        // 
        this.products.Location = new Point(670, 283);
        this.products.Name = "products";
        this.products.Size = new Size(199, 37);
        this.products.TabIndex = 0;
        this.products.Text = "go to Products";
        this.products.UseVisualStyleBackColor = true;
        this.products.Click += this.products_Click;
        // 
        // categories
        // 
        this.categories.Location = new Point(611, 131);
        this.categories.Name = "categories";
        this.categories.Size = new Size(199, 37);
        this.categories.TabIndex = 1;
        this.categories.Text = "go to Categories";
        this.categories.UseVisualStyleBackColor = true;
        this.categories.Click += this.categories_Click;
        // 
        // orders
        // 
        this.orders.Location = new Point(518, 38);
        this.orders.Name = "orders";
        this.orders.Size = new Size(199, 37);
        this.orders.TabIndex = 2;
        this.orders.Text = "go to Orders";
        this.orders.UseVisualStyleBackColor = true;
        this.orders.Click += this.orders_Click;
        // 
        // quit
        // 
        this.quit.Location = new Point(564, 378);
        this.quit.Name = "quit";
        this.quit.Size = new Size(199, 37);
        this.quit.TabIndex = 3;
        this.quit.Text = "Quitter";
        this.quit.UseVisualStyleBackColor = true;
        this.quit.Click += this.quit_Click;
        // 
        // materialTabSelector1
        // 
        this.materialTabSelector1.BaseTabControl = null;
        this.materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
        this.materialTabSelector1.Depth = 0;
        this.materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        this.materialTabSelector1.Location = new Point(103, 191);
        this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
        this.materialTabSelector1.Name = "materialTabSelector1";
        this.materialTabSelector1.Size = new Size(426, 429);
        this.materialTabSelector1.TabIndex = 4;
        this.materialTabSelector1.Text = "materialTabSelector1";
        // 
        // Home
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1366, 768);
        this.Controls.Add(this.materialTabSelector1);
        this.Controls.Add(this.quit);
        this.Controls.Add(this.orders);
        this.Controls.Add(this.categories);
        this.Controls.Add(this.products);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "Home";
        this.Text = "Home";
        this.Load += this.Home_Load;
        this.ResumeLayout(false);
    }

    #endregion

    private Button products;
    private Button categories;
    private Button orders;
    private Button quit;
    private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
}