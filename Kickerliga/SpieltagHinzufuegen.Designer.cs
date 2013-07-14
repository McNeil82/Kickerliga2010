namespace Kickerliga
{
    partial class SpieltagHinzufuegen
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
            this.tb_Spieltag = new System.Windows.Forms.TextBox();
            this.lbl_Spieltag = new System.Windows.Forms.Label();
            this.lbl_from = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.dtp_until = new System.Windows.Forms.DateTimePicker();
            this.lbl_until = new System.Windows.Forms.Label();
            this.lbl_weekday = new System.Windows.Forms.Label();
            this.tb_weekday = new System.Windows.Forms.TextBox();
            this.btn_abbrechen = new System.Windows.Forms.Button();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Spieltag
            // 
            this.tb_Spieltag.Location = new System.Drawing.Point(64, 12);
            this.tb_Spieltag.MaxLength = 2;
            this.tb_Spieltag.Name = "tb_Spieltag";
            this.tb_Spieltag.Size = new System.Drawing.Size(20, 20);
            this.tb_Spieltag.TabIndex = 0;
            // 
            // lbl_Spieltag
            // 
            this.lbl_Spieltag.AutoSize = true;
            this.lbl_Spieltag.Location = new System.Drawing.Point(13, 13);
            this.lbl_Spieltag.Name = "lbl_Spieltag";
            this.lbl_Spieltag.Size = new System.Drawing.Size(45, 13);
            this.lbl_Spieltag.TabIndex = 1;
            this.lbl_Spieltag.Text = "Spieltag";
            // 
            // lbl_from
            // 
            this.lbl_from.AutoSize = true;
            this.lbl_from.Location = new System.Drawing.Point(33, 44);
            this.lbl_from.Name = "lbl_from";
            this.lbl_from.Size = new System.Drawing.Size(25, 13);
            this.lbl_from.TabIndex = 2;
            this.lbl_from.Text = "von";
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(64, 38);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(100, 20);
            this.dtp_from.TabIndex = 3;
            this.dtp_from.Value = new System.DateTime(2009, 10, 26, 0, 0, 0, 0);
            this.dtp_from.ValueChanged += new System.EventHandler(this.dtp_from_ValueChanged);
            // 
            // dtp_until
            // 
            this.dtp_until.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_until.Location = new System.Drawing.Point(64, 64);
            this.dtp_until.Name = "dtp_until";
            this.dtp_until.Size = new System.Drawing.Size(100, 20);
            this.dtp_until.TabIndex = 5;
            this.dtp_until.Value = new System.DateTime(2009, 10, 26, 0, 0, 0, 0);
            // 
            // lbl_until
            // 
            this.lbl_until.AutoSize = true;
            this.lbl_until.Location = new System.Drawing.Point(38, 70);
            this.lbl_until.Name = "lbl_until";
            this.lbl_until.Size = new System.Drawing.Size(20, 13);
            this.lbl_until.TabIndex = 4;
            this.lbl_until.Text = "bis";
            // 
            // lbl_weekday
            // 
            this.lbl_weekday.AutoSize = true;
            this.lbl_weekday.Location = new System.Drawing.Point(33, 93);
            this.lbl_weekday.Name = "lbl_weekday";
            this.lbl_weekday.Size = new System.Drawing.Size(25, 13);
            this.lbl_weekday.TabIndex = 6;
            this.lbl_weekday.Text = "KW";
            // 
            // tb_weekday
            // 
            this.tb_weekday.Location = new System.Drawing.Point(64, 90);
            this.tb_weekday.MaxLength = 2;
            this.tb_weekday.Name = "tb_weekday";
            this.tb_weekday.ReadOnly = true;
            this.tb_weekday.Size = new System.Drawing.Size(20, 20);
            this.tb_weekday.TabIndex = 7;
            // 
            // btn_abbrechen
            // 
            this.btn_abbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_abbrechen.Location = new System.Drawing.Point(89, 116);
            this.btn_abbrechen.Name = "btn_abbrechen";
            this.btn_abbrechen.Size = new System.Drawing.Size(75, 23);
            this.btn_abbrechen.TabIndex = 10;
            this.btn_abbrechen.Text = "Abbrechen";
            this.btn_abbrechen.UseVisualStyleBackColor = true;
            // 
            // btn_speichern
            // 
            this.btn_speichern.Location = new System.Drawing.Point(8, 116);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(75, 23);
            this.btn_speichern.TabIndex = 9;
            this.btn_speichern.Text = "Speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            // 
            // SpieltagHinzufuegen
            // 
            this.AcceptButton = this.btn_speichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_abbrechen;
            this.ClientSize = new System.Drawing.Size(182, 152);
            this.ControlBox = false;
            this.Controls.Add(this.btn_abbrechen);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.tb_weekday);
            this.Controls.Add(this.lbl_weekday);
            this.Controls.Add(this.dtp_until);
            this.Controls.Add(this.lbl_until);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.lbl_from);
            this.Controls.Add(this.lbl_Spieltag);
            this.Controls.Add(this.tb_Spieltag);
            this.Name = "SpieltagHinzufuegen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spieltag hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Spieltag;
        private System.Windows.Forms.Label lbl_Spieltag;
        private System.Windows.Forms.Label lbl_from;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.DateTimePicker dtp_until;
        private System.Windows.Forms.Label lbl_until;
        private System.Windows.Forms.Label lbl_weekday;
        private System.Windows.Forms.TextBox tb_weekday;
        private System.Windows.Forms.Button btn_abbrechen;
        private System.Windows.Forms.Button btn_speichern;
    }
}