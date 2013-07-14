using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class SaisonHinzufuegen : Form
    {
        public SaisonHinzufuegen()
        {
            InitializeComponent();
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            string error = Saison.speichere(Convert.ToInt32(tb_AnzahlAbsteiger.Text), Convert.ToInt32(tb_AnzahlAufsteiger.Text), Convert.ToInt32(tb_Liga.Text), tb_SaisonName.Text);
            if (String.IsNullOrEmpty(error))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
