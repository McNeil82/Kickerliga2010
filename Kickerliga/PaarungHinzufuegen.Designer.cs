namespace Kickerliga
{
    partial class PaarungHinzufuegen
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
            this.cb_Heim1 = new System.Windows.Forms.ComboBox();
            this.cb_Auswaerts2 = new System.Windows.Forms.ComboBox();
            this.cb_Heim2 = new System.Windows.Forms.ComboBox();
            this.cb_Auswaerts1 = new System.Windows.Forms.ComboBox();
            this.minus1 = new System.Windows.Forms.Label();
            this.slash = new System.Windows.Forms.Label();
            this.minus2 = new System.Windows.Forms.Label();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.btn_abbrechen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_Heim1
            // 
            this.cb_Heim1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Heim1.FormattingEnabled = true;
            this.cb_Heim1.Location = new System.Drawing.Point(12, 12);
            this.cb_Heim1.MaxDropDownItems = 15;
            this.cb_Heim1.Name = "cb_Heim1";
            this.cb_Heim1.Size = new System.Drawing.Size(75, 21);
            this.cb_Heim1.Sorted = true;
            this.cb_Heim1.TabIndex = 0;
            // 
            // cb_Auswaerts2
            // 
            this.cb_Auswaerts2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Auswaerts2.FormattingEnabled = true;
            this.cb_Auswaerts2.Location = new System.Drawing.Point(305, 12);
            this.cb_Auswaerts2.MaxDropDownItems = 15;
            this.cb_Auswaerts2.Name = "cb_Auswaerts2";
            this.cb_Auswaerts2.Size = new System.Drawing.Size(75, 21);
            this.cb_Auswaerts2.Sorted = true;
            this.cb_Auswaerts2.TabIndex = 1;
            // 
            // cb_Heim2
            // 
            this.cb_Heim2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Heim2.FormattingEnabled = true;
            this.cb_Heim2.Location = new System.Drawing.Point(109, 12);
            this.cb_Heim2.MaxDropDownItems = 15;
            this.cb_Heim2.Name = "cb_Heim2";
            this.cb_Heim2.Size = new System.Drawing.Size(75, 21);
            this.cb_Heim2.Sorted = true;
            this.cb_Heim2.TabIndex = 2;
            // 
            // cb_Auswaerts1
            // 
            this.cb_Auswaerts1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Auswaerts1.FormattingEnabled = true;
            this.cb_Auswaerts1.Location = new System.Drawing.Point(208, 12);
            this.cb_Auswaerts1.MaxDropDownItems = 15;
            this.cb_Auswaerts1.Name = "cb_Auswaerts1";
            this.cb_Auswaerts1.Size = new System.Drawing.Size(75, 21);
            this.cb_Auswaerts1.Sorted = true;
            this.cb_Auswaerts1.TabIndex = 3;
            // 
            // minus1
            // 
            this.minus1.AutoSize = true;
            this.minus1.Location = new System.Drawing.Point(93, 15);
            this.minus1.Name = "minus1";
            this.minus1.Size = new System.Drawing.Size(10, 13);
            this.minus1.TabIndex = 4;
            this.minus1.Text = "-";
            // 
            // slash
            // 
            this.slash.AutoSize = true;
            this.slash.Location = new System.Drawing.Point(190, 15);
            this.slash.Name = "slash";
            this.slash.Size = new System.Drawing.Size(12, 13);
            this.slash.TabIndex = 5;
            this.slash.Text = "/";
            // 
            // minus2
            // 
            this.minus2.AutoSize = true;
            this.minus2.Location = new System.Drawing.Point(289, 15);
            this.minus2.Name = "minus2";
            this.minus2.Size = new System.Drawing.Size(10, 13);
            this.minus2.TabIndex = 6;
            this.minus2.Text = "-";
            // 
            // btn_speichern
            // 
            this.btn_speichern.Location = new System.Drawing.Point(224, 56);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(75, 23);
            this.btn_speichern.TabIndex = 7;
            this.btn_speichern.Text = "Speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            // 
            // btn_abbrechen
            // 
            this.btn_abbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_abbrechen.Location = new System.Drawing.Point(305, 56);
            this.btn_abbrechen.Name = "btn_abbrechen";
            this.btn_abbrechen.Size = new System.Drawing.Size(75, 23);
            this.btn_abbrechen.TabIndex = 8;
            this.btn_abbrechen.Text = "Abbrechen";
            this.btn_abbrechen.UseVisualStyleBackColor = true;
            // 
            // PaarungHinzufuegen
            // 
            this.AcceptButton = this.btn_speichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btn_abbrechen;
            this.ClientSize = new System.Drawing.Size(394, 91);
            this.ControlBox = false;
            this.Controls.Add(this.btn_abbrechen);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.minus2);
            this.Controls.Add(this.slash);
            this.Controls.Add(this.minus1);
            this.Controls.Add(this.cb_Auswaerts1);
            this.Controls.Add(this.cb_Heim2);
            this.Controls.Add(this.cb_Auswaerts2);
            this.Controls.Add(this.cb_Heim1);
            this.Name = "PaarungHinzufuegen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paarung hinzufügen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Heim1;
        private System.Windows.Forms.ComboBox cb_Auswaerts2;
        private System.Windows.Forms.ComboBox cb_Heim2;
        private System.Windows.Forms.ComboBox cb_Auswaerts1;
        private System.Windows.Forms.Label minus1;
        private System.Windows.Forms.Label slash;
        private System.Windows.Forms.Label minus2;
        private System.Windows.Forms.Button btn_speichern;
        private System.Windows.Forms.Button btn_abbrechen;
    }
}