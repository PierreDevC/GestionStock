namespace GestionStock.UserInterface;

partial class CategoryForm
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
        this.lstCategories = new ListView();
        this.columnHeader1 = new ColumnHeader();
        this.columnHeader2 = new ColumnHeader();
        this.groupBox1 = new GroupBox();
        this.btnClearForm = new Button();
        this.btnDeleteCategory = new Button();
        this.btnUpdateCategory = new Button();
        this.btnAddCategory = new Button();
        this.txtCategoryName = new TextBox();
        this.label2 = new Label();
        this.txtCategoryId = new TextBox();
        this.label1 = new Label();
        this.homeButton = new Button();
        this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // lstCategories
        // 
        this.lstCategories.Columns.AddRange(new ColumnHeader[] { this.columnHeader1, this.columnHeader2 });
        this.lstCategories.FullRowSelect = true;
        this.lstCategories.GridLines = true;
        this.lstCategories.Location = new Point(12, 12);
        this.lstCategories.MultiSelect = false;
        this.lstCategories.Name = "lstCategories";
        this.lstCategories.Size = new Size(512, 426);
        this.lstCategories.TabIndex = 0;
        this.lstCategories.UseCompatibleStateImageBehavior = false;
        this.lstCategories.View = View.Details;
        this.lstCategories.SelectedIndexChanged += this.lstCategories_SelectedIndexChanged;
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "ID";
        this.columnHeader1.Width = 50;
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Nom";
        this.columnHeader2.Width = 500;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.homeButton);
        this.groupBox1.Controls.Add(this.btnClearForm);
        this.groupBox1.Controls.Add(this.btnDeleteCategory);
        this.groupBox1.Controls.Add(this.btnUpdateCategory);
        this.groupBox1.Controls.Add(this.btnAddCategory);
        this.groupBox1.Controls.Add(this.txtCategoryName);
        this.groupBox1.Controls.Add(this.label2);
        this.groupBox1.Controls.Add(this.txtCategoryId);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new Point(530, 12);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new Size(258, 426);
        this.groupBox1.TabIndex = 1;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Contrôles";
        // 
        // btnClearForm
        // 
        this.btnClearForm.Location = new Point(6, 197);
        this.btnClearForm.Name = "btnClearForm";
        this.btnClearForm.Size = new Size(246, 23);
        this.btnClearForm.TabIndex = 7;
        this.btnClearForm.Text = "Effacer / Nouveau";
        this.btnClearForm.UseVisualStyleBackColor = true;
        this.btnClearForm.Click += this.btnClearForm_Click;
        // 
        // btnDeleteCategory
        // 
        this.btnDeleteCategory.Location = new Point(6, 168);
        this.btnDeleteCategory.Name = "btnDeleteCategory";
        this.btnDeleteCategory.Size = new Size(246, 23);
        this.btnDeleteCategory.TabIndex = 6;
        this.btnDeleteCategory.Text = "Supprimer";
        this.btnDeleteCategory.UseVisualStyleBackColor = true;
        this.btnDeleteCategory.Click += this.btnDeleteCategory_Click;
        // 
        // btnUpdateCategory
        // 
        this.btnUpdateCategory.Location = new Point(6, 139);
        this.btnUpdateCategory.Name = "btnUpdateCategory";
        this.btnUpdateCategory.Size = new Size(246, 23);
        this.btnUpdateCategory.TabIndex = 5;
        this.btnUpdateCategory.Text = "Mettre à jour";
        this.btnUpdateCategory.UseVisualStyleBackColor = true;
        this.btnUpdateCategory.Click += this.btnUpdateCategory_Click;
        // 
        // btnAddCategory
        // 
        this.btnAddCategory.Location = new Point(6, 110);
        this.btnAddCategory.Name = "btnAddCategory";
        this.btnAddCategory.Size = new Size(246, 23);
        this.btnAddCategory.TabIndex = 4;
        this.btnAddCategory.Text = "Ajouter";
        this.btnAddCategory.UseVisualStyleBackColor = true;
        this.btnAddCategory.Click += this.btnAddCategory_Click;
        // 
        // txtCategoryName
        // 
        this.txtCategoryName.Location = new Point(52, 67);
        this.txtCategoryName.Name = "txtCategoryName";
        this.txtCategoryName.Size = new Size(200, 23);
        this.txtCategoryName.TabIndex = 3;
        this.txtCategoryName.TabStop = false;
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
        // txtCategoryId
        // 
        this.txtCategoryId.Location = new Point(52, 30);
        this.txtCategoryId.Name = "txtCategoryId";
        this.txtCategoryId.ReadOnly = true;
        this.txtCategoryId.Size = new Size(200, 23);
        this.txtCategoryId.TabIndex = 1;
        this.txtCategoryId.TabStop = false;
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
        // homeButton
        // 
        this.homeButton.Location = new Point(65, 332);
        this.homeButton.Name = "homeButton";
        this.homeButton.Size = new Size(129, 23);
        this.homeButton.TabIndex = 8;
        this.homeButton.Text = "revenir en arrière";
        this.homeButton.UseVisualStyleBackColor = true;
        this.homeButton.Click += this.homeButton_Click;
        // 
        // CategoryForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.groupBox1);
        this.Controls.Add(this.lstCategories);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Name = "CategoryForm";
        this.Text = "CategoryForm";
        this.Load += this.CategoryForm_Load;
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private ListView lstCategories;
    private GroupBox groupBox1;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private Button btnAddCategory;
    private TextBox txtCategoryName;
    private Label label2;
    private TextBox txtCategoryId;
    private Label label1;
    private Button btnUpdateCategory;
    private Button btnClearForm;
    private Button btnDeleteCategory;
    private Button homeButton;
}