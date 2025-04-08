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
        this.btnProcessNextOrder.Size = new Size(770, 42);
        this.btnProcessNextOrder.TabIndex = 10;
        this.btnProcessNextOrder.Text = "Traiter la Prochaine Commande";
        this.btnProcessNextOrder.UseVisualStyleBackColor = true;
        this.btnProcessNextOrder.Click += this.btnProcessNextOrder_Click;
        // 
        // OrderForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.btnProcessNextOrder);
        this.Controls.Add(this.lsvOrderItems);
        this.Controls.Add(this.label10);
        this.Controls.Add(this.lstOrderQueue);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.lblNextOrderInfo);
        this.Controls.Add(this.lblQueueInfo);
        this.Name = "OrderForm";
        this.Text = "OrderForm";
        this.Load += this.OrderForm_Load;
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
}