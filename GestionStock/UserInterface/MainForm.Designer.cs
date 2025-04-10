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
        this.panel1 = new Panel();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.Dock = DockStyle.Fill;
        this.panel1.Location = new Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new Size(930, 499);
        this.panel1.TabIndex = 6;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.AutoValidate = AutoValidate.EnableAllowFocusChange;
        this.BackColor = Color.White;
        this.ClientSize = new Size(930, 499);
        this.Controls.Add(this.panel1);
        this.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        this.FormBorderStyle = FormBorderStyle.Fixed3D;
        this.Name = "MainForm";
        this.Text = "MainForm";
        this.Load += this.MainForm_Load;
        this.ResumeLayout(false);
    }

    #endregion
    private Panel panel1;
}