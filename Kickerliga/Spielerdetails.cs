using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class Spielerdetails : Form
    {
        private Spieler spieler;

        public Spielerdetails(Spieler spieler, bool readOnly)
        {
            InitializeComponent();
            if (spieler.ID > 0)
            {
                tb_Kuerzel.Text = spieler.Kuerzel;
                tb_Nachname.Text = spieler.Nachname;
                tb_Vorname.Text = spieler.Vorname;
            }
            this.spieler = spieler;

            tb_Kuerzel.ReadOnly = readOnly;
            tb_Nachname.ReadOnly = readOnly;
            tb_Vorname.ReadOnly = readOnly;
            btn_save.Visible = !readOnly;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_Kuerzel.Text)
                || String.IsNullOrEmpty(tb_Vorname.Text)
                || String.IsNullOrEmpty(tb_Nachname.Text))
            {
                MessageBox.Show("Es müssen alle Felder gefüllt sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                spieler.Kuerzel = tb_Kuerzel.Text;
                spieler.Nachname = tb_Nachname.Text;
                spieler.Vorname = tb_Vorname.Text;

                string error = spieler.save();
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
}
