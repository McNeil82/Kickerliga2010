namespace Kickerliga
{
    partial class Spielerdetails
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Vorname = new System.Windows.Forms.TextBox();
            this.tb_Kuerzel = new System.Windows.Forms.TextBox();
            this.tb_Nachname = new System.Windows.Forms.TextBox();
            this.lbl_Vorname = new System.Windows.Forms.Label();
            this.lbl_Kuerzel = new System.Windows.Forms.Label();
            this.lbl_Nachname = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Vorname
            // 
            this.tb_Vorname.Location = new System.Drawing.Point(78, 13);
            this.tb_Vorname.MaxLength = 255;
            this.tb_Vorname.Name = "tb_Vorname";
            this.tb_Vorname.ReadOnly = true;
            this.tb_Vorname.Size = new System.Drawing.Size(100, 20);
            this.tb_Vorname.TabIndex = 0;
            // 
            // tb_Kuerzel
            // 
            this.tb_Kuerzel.Location = new System.Drawing.Point(78, 65);
            this.tb_Kuerzel.MaxLength = 3;
            this.tb_Kuerzel.Name = "tb_Kuerzel";
            this.tb_Kuerzel.ReadOnly = true;
            this.tb_Kuerzel.Size = new System.Drawing.Size(40, 20);
            this.tb_Kuerzel.TabIndex = 2;
            // 
            // tb_Nachname
            // 
            this.tb_Nachname.Location = new System.Drawing.Point(78, 39);
            this.tb_Nachname.MaxLength = 255;
            this.tb_Nachname.Name = "tb_Nachname";
            this.tb_Nachname.ReadOnly = true;
            this.tb_Nachname.Size = new System.Drawing.Size(100, 20);
            this.tb_Nachname.TabIndex = 1;
            // 
            // lbl_Vorname
            // 
            this.lbl_Vorname.AutoSize = true;
            this.lbl_Vorname.Location = new System.Drawing.Point(13, 16);
            this.lbl_Vorname.Name = "lbl_Vorname";
            this.lbl_Vorname.Size = new System.Drawing.Size(49, 13);
            this.lbl_Vorname.TabIndex = 3;
            this.lbl_Vorname.Text = "Vorname";
            // 
            // lbl_Kuerzel
            // 
            this.lbl_Kuerzel.AutoSize = true;
            this.lbl_Kuerzel.Location = new System.Drawing.Point(13, 68);
            this.lbl_Kuerzel.Name = "lbl_Kuerzel";
            this.lbl_Kuerzel.Size = new System.Drawing.Size(36, 13);
            this.lbl_Kuerzel.TabIndex = 4;
            this.lbl_Kuerzel.Text = "Kürzel";
            // 
            // lbl_Nachname
            // 
            this.lbl_Nachname.AutoSize = true;
            this.lbl_Nachname.Location = new System.Drawing.Point(13, 42);
            this.lbl_Nachname.Name = "lbl_Nachname";
            this.lbl_Nachname.Size = new System.Drawing.Size(59, 13);
            this.lbl_Nachname.TabIndex = 5;
            this.lbl_Nachname.Text = "Nachname";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(59, 91);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Speichern";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Spielerdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(192, 127);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_Nachname);
            this.Controls.Add(this.lbl_Kuerzel);
            this.Controls.Add(this.lbl_Vorname);
            this.Controls.Add(this.tb_Nachname);
            this.Controls.Add(this.tb_Kuerzel);
            this.Controls.Add(this.tb_Vorname);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Spielerdetails";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spielerdetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Vorname;
        private System.Windows.Forms.TextBox tb_Kuerzel;
        private System.Windows.Forms.TextBox tb_Nachname;
        private System.Windows.Forms.Label lbl_Vorname;
        private System.Windows.Forms.Label lbl_Kuerzel;
        private System.Windows.Forms.Label lbl_Nachname;
        private System.Windows.Forms.Button btn_save;
    }
}