namespace Kickerliga
{
    partial class Passworteingabe
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
            this.tb_Passwort = new System.Windows.Forms.TextBox();
            this.btn_PasswortOk = new System.Windows.Forms.Button();
            this.btn_PasswortAbbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Passwort
            // 
            this.tb_Passwort.Location = new System.Drawing.Point(13, 13);
            this.tb_Passwort.Name = "tb_Passwort";
            this.tb_Passwort.PasswordChar = '*';
            this.tb_Passwort.Size = new System.Drawing.Size(156, 20);
            this.tb_Passwort.TabIndex = 0;
            this.tb_Passwort.UseSystemPasswordChar = true;
            // 
            // btn_PasswortOk
            // 
            this.btn_PasswortOk.Location = new System.Drawing.Point(13, 39);
            this.btn_PasswortOk.Name = "btn_PasswortOk";
            this.btn_PasswortOk.Size = new System.Drawing.Size(75, 23);
            this.btn_PasswortOk.TabIndex = 1;
            this.btn_PasswortOk.Text = "OK";
            this.btn_PasswortOk.UseVisualStyleBackColor = true;
            this.btn_PasswortOk.Click += new System.EventHandler(this.btn_PasswortOk_Click);
            // 
            // btn_PasswortAbbrechen
            // 
            this.btn_PasswortAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_PasswortAbbrechen.Location = new System.Drawing.Point(94, 39);
            this.btn_PasswortAbbrechen.Name = "btn_PasswortAbbrechen";
            this.btn_PasswortAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.btn_PasswortAbbrechen.TabIndex = 2;
            this.btn_PasswortAbbrechen.Text = "Abbrechen";
            this.btn_PasswortAbbrechen.UseVisualStyleBackColor = true;
            // 
            // Passworteingabe
            // 
            this.AcceptButton = this.btn_PasswortOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_PasswortAbbrechen;
            this.ClientSize = new System.Drawing.Size(180, 76);
            this.ControlBox = false;
            this.Controls.Add(this.btn_PasswortAbbrechen);
            this.Controls.Add(this.btn_PasswortOk);
            this.Controls.Add(this.tb_Passwort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Passworteingabe";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Passworteingabe";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Passwort;
        private System.Windows.Forms.Button btn_PasswortOk;
        private System.Windows.Forms.Button btn_PasswortAbbrechen;
    }
}