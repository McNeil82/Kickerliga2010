namespace Kickerliga
{
    partial class SaisonHinzufuegen
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
            this.lbl_AnzahlAbsteiger = new System.Windows.Forms.Label();
            this.tb_AnzahlAbsteiger = new System.Windows.Forms.TextBox();
            this.lbl_AnzahlAufsteiger = new System.Windows.Forms.Label();
            this.tb_AnzahlAufsteiger = new System.Windows.Forms.TextBox();
            this.lbl_Liga = new System.Windows.Forms.Label();
            this.tb_Liga = new System.Windows.Forms.TextBox();
            this.lbl_SaisonName = new System.Windows.Forms.Label();
            this.tb_SaisonName = new System.Windows.Forms.TextBox();
            this.btn_abbrechen = new System.Windows.Forms.Button();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_AnzahlAbsteiger
            // 
            this.lbl_AnzahlAbsteiger.AutoSize = true;
            this.lbl_AnzahlAbsteiger.Location = new System.Drawing.Point(12, 90);
            this.lbl_AnzahlAbsteiger.Name = "lbl_AnzahlAbsteiger";
            this.lbl_AnzahlAbsteiger.Size = new System.Drawing.Size(51, 13);
            this.lbl_AnzahlAbsteiger.TabIndex = 15;
            this.lbl_AnzahlAbsteiger.Text = "Absteiger";
            // 
            // tb_AnzahlAbsteiger
            // 
            this.tb_AnzahlAbsteiger.Location = new System.Drawing.Point(72, 87);
            this.tb_AnzahlAbsteiger.MaxLength = 2;
            this.tb_AnzahlAbsteiger.Name = "tb_AnzahlAbsteiger";
            this.tb_AnzahlAbsteiger.Size = new System.Drawing.Size(20, 20);
            this.tb_AnzahlAbsteiger.TabIndex = 14;
            // 
            // lbl_AnzahlAufsteiger
            // 
            this.lbl_AnzahlAufsteiger.AutoSize = true;
            this.lbl_AnzahlAufsteiger.Location = new System.Drawing.Point(12, 64);
            this.lbl_AnzahlAufsteiger.Name = "lbl_AnzahlAufsteiger";
            this.lbl_AnzahlAufsteiger.Size = new System.Drawing.Size(54, 13);
            this.lbl_AnzahlAufsteiger.TabIndex = 13;
            this.lbl_AnzahlAufsteiger.Text = "Aufsteiger";
            // 
            // tb_AnzahlAufsteiger
            // 
            this.tb_AnzahlAufsteiger.Location = new System.Drawing.Point(72, 61);
            this.tb_AnzahlAufsteiger.MaxLength = 2;
            this.tb_AnzahlAufsteiger.Name = "tb_AnzahlAufsteiger";
            this.tb_AnzahlAufsteiger.Size = new System.Drawing.Size(20, 20);
            this.tb_AnzahlAufsteiger.TabIndex = 12;
            // 
            // lbl_Liga
            // 
            this.lbl_Liga.AutoSize = true;
            this.lbl_Liga.Location = new System.Drawing.Point(12, 35);
            this.lbl_Liga.Name = "lbl_Liga";
            this.lbl_Liga.Size = new System.Drawing.Size(27, 13);
            this.lbl_Liga.TabIndex = 11;
            this.lbl_Liga.Text = "Liga";
            // 
            // tb_Liga
            // 
            this.tb_Liga.Location = new System.Drawing.Point(72, 32);
            this.tb_Liga.MaxLength = 1;
            this.tb_Liga.Name = "tb_Liga";
            this.tb_Liga.Size = new System.Drawing.Size(20, 20);
            this.tb_Liga.TabIndex = 10;
            // 
            // lbl_SaisonName
            // 
            this.lbl_SaisonName.AutoSize = true;
            this.lbl_SaisonName.Location = new System.Drawing.Point(12, 9);
            this.lbl_SaisonName.Name = "lbl_SaisonName";
            this.lbl_SaisonName.Size = new System.Drawing.Size(35, 13);
            this.lbl_SaisonName.TabIndex = 9;
            this.lbl_SaisonName.Text = "Name";
            // 
            // tb_SaisonName
            // 
            this.tb_SaisonName.Location = new System.Drawing.Point(72, 6);
            this.tb_SaisonName.Name = "tb_SaisonName";
            this.tb_SaisonName.Size = new System.Drawing.Size(100, 20);
            this.tb_SaisonName.TabIndex = 8;
            // 
            // btn_abbrechen
            // 
            this.btn_abbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_abbrechen.Location = new System.Drawing.Point(197, 113);
            this.btn_abbrechen.Name = "btn_abbrechen";
            this.btn_abbrechen.Size = new System.Drawing.Size(75, 23);
            this.btn_abbrechen.TabIndex = 17;
            this.btn_abbrechen.Text = "Abbrechen";
            this.btn_abbrechen.UseVisualStyleBackColor = true;
            // 
            // btn_speichern
            // 
            this.btn_speichern.Location = new System.Drawing.Point(116, 113);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(75, 23);
            this.btn_speichern.TabIndex = 16;
            this.btn_speichern.Text = "Speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            // 
            // SaisonHinzufuegen
            // 
            this.AcceptButton = this.btn_abbrechen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_abbrechen;
            this.ClientSize = new System.Drawing.Size(284, 146);
            this.ControlBox = false;
            this.Controls.Add(this.btn_abbrechen);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.lbl_AnzahlAbsteiger);
            this.Controls.Add(this.tb_AnzahlAbsteiger);
            this.Controls.Add(this.lbl_AnzahlAufsteiger);
            this.Controls.Add(this.tb_AnzahlAufsteiger);
            this.Controls.Add(this.lbl_Liga);
            this.Controls.Add(this.tb_Liga);
            this.Controls.Add(this.lbl_SaisonName);
            this.Controls.Add(this.tb_SaisonName);
            this.Name = "SaisonHinzufuegen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saison hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_AnzahlAbsteiger;
        private System.Windows.Forms.TextBox tb_AnzahlAbsteiger;
        private System.Windows.Forms.Label lbl_AnzahlAufsteiger;
        private System.Windows.Forms.TextBox tb_AnzahlAufsteiger;
        private System.Windows.Forms.Label lbl_Liga;
        private System.Windows.Forms.TextBox tb_Liga;
        private System.Windows.Forms.Label lbl_SaisonName;
        private System.Windows.Forms.TextBox tb_SaisonName;
        private System.Windows.Forms.Button btn_abbrechen;
        private System.Windows.Forms.Button btn_speichern;
    }
}