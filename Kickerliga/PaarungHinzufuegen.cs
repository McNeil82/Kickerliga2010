using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class PaarungHinzufuegen : Form
    {
        private List<Spieler> spielerList = new List<Spieler>();
        private List<Spieler> spielerListHeim1 = new List<Spieler>();
        private List<Spieler> spielerListHeim2 = new List<Spieler>();
        private List<Spieler> spielerListAuswaerts1 = new List<Spieler>();
        private List<Spieler> spielerListAuswaerts2 = new List<Spieler>();

        private int alterIndexHeim1 = 0;
        private int alterIndexHeim2 = 0;
        private int alterIndexAuswaerts1 = 0;
        private int alterIndexAuswaerts2 = 0;
        private int spieltagId = 0;
        private int saisonId = 0;

        public PaarungHinzufuegen(int spieltagId, int saisonId)
        {
            this.spieltagId = spieltagId;
            this.saisonId = saisonId;
            InitializeComponent();
            initialisiereSpielerListen();
        }

        private void initialisiereSpielerListen()
        {
            spielerList = Spieler.ladeAlleSpieler();
            spielerListHeim1.AddRange(spielerList);
            spielerListHeim2.AddRange(spielerListHeim1);
            spielerListHeim2.RemoveAt(0);
            spielerListAuswaerts1.AddRange(spielerListHeim2);
            spielerListAuswaerts1.RemoveAt(0);
            spielerListAuswaerts2.AddRange(spielerListAuswaerts1);
            spielerListAuswaerts2.RemoveAt(0);
            spielerListHeim1.RemoveAt(1);
            spielerListHeim1.RemoveAt(1);
            spielerListHeim1.RemoveAt(1);
            spielerListHeim2.RemoveAt(1);
            spielerListHeim2.RemoveAt(1);
            spielerListAuswaerts1.RemoveAt(1);

            cb_Heim1.DisplayMember = "Kuerzel";
            cb_Heim1.DataSource = spielerListHeim1;
            cb_Heim2.DisplayMember = "Kuerzel";
            cb_Heim2.DataSource = spielerListHeim2;
            cb_Auswaerts1.DisplayMember = "Kuerzel";
            cb_Auswaerts1.DataSource = spielerListAuswaerts1;
            cb_Auswaerts2.DisplayMember = "Kuerzel";
            cb_Auswaerts2.DataSource = spielerListAuswaerts2;

            addSelectedIndexChangeEvents();

        }

        private void addSelectedIndexChangeEvents()
        {
            cb_Heim1.SelectedIndexChanged += new EventHandler(cb_Heim1_SelectedIndexChanged);
            cb_Heim2.SelectedIndexChanged += new EventHandler(cb_Heim2_SelectedIndexChanged);
            cb_Auswaerts1.SelectedIndexChanged += new EventHandler(cb_Auswaerts1_SelectedIndexChanged);
            cb_Auswaerts2.SelectedIndexChanged += new EventHandler(cb_Auswaerts2_SelectedIndexChanged);
        }

        private void removeSelectedIndexChangeEvents()
        {
            cb_Heim1.SelectedIndexChanged -= new EventHandler(cb_Heim1_SelectedIndexChanged);
            cb_Heim2.SelectedIndexChanged -= new EventHandler(cb_Heim2_SelectedIndexChanged);
            cb_Auswaerts1.SelectedIndexChanged -= new EventHandler(cb_Auswaerts1_SelectedIndexChanged);
            cb_Auswaerts2.SelectedIndexChanged -= new EventHandler(cb_Auswaerts2_SelectedIndexChanged);
        }

        private void resetIndexes()
        {
            alterIndexHeim1 = cb_Heim1.SelectedIndex;
            alterIndexHeim2 = cb_Heim2.SelectedIndex;
            alterIndexAuswaerts1 = cb_Auswaerts1.SelectedIndex;
            alterIndexAuswaerts2 = cb_Auswaerts2.SelectedIndex;
        }

        private void cb_Heim1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alterIndexHeim1 != cb_Heim1.SelectedIndex)
            {
                removeSelectedIndexChangeEvents();

                Spieler neuerSpieler = (Spieler)cb_Heim1.SelectedItem;
                Spieler alterSpieler = (Spieler)cb_Heim1.Items[alterIndexHeim1];

                erneuereListe(neuerSpieler, alterSpieler, cb_Heim2, spielerListHeim2);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts1, spielerListAuswaerts1);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts2, spielerListAuswaerts2);

                resetIndexes();
                addSelectedIndexChangeEvents();
            }
        }

        private void erneuereListe(Spieler neuerSpieler, Spieler alterSpieler, ComboBox box, List<Spieler> liste)
        {
            if (box.DataSource != null)
            {
                Spieler selektierterSpieler = (Spieler)box.SelectedItem;
                box.BindingContext[box.DataSource].SuspendBinding();
                if (liste.Contains(neuerSpieler))
                {
                    liste.Remove(neuerSpieler);
                }
                if (!liste.Contains(alterSpieler))
                {
                    liste.Add(alterSpieler);
                }
                box.DataSource = liste;
                box.BindingContext[box.DataSource].ResumeBinding();
                if (liste.Contains(selektierterSpieler))
                {
                    box.SelectedItem = selektierterSpieler;
                }
            }
        }

        private void cb_Heim2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alterIndexHeim2 != cb_Heim2.SelectedIndex)
            {
                removeSelectedIndexChangeEvents();

                Spieler neuerSpieler = (Spieler)cb_Heim2.SelectedItem;
                Spieler alterSpieler = (Spieler)cb_Heim2.Items[alterIndexHeim2];

                erneuereListe(neuerSpieler, alterSpieler, cb_Heim1, spielerListHeim1);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts1, spielerListAuswaerts1);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts2, spielerListAuswaerts2);

                resetIndexes();
                addSelectedIndexChangeEvents();
            }
        }

        private void cb_Auswaerts1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alterIndexAuswaerts1 != cb_Auswaerts1.SelectedIndex)
            {
                removeSelectedIndexChangeEvents();

                Spieler neuerSpieler = (Spieler)cb_Auswaerts1.SelectedItem;
                Spieler alterSpieler = (Spieler)cb_Auswaerts1.Items[alterIndexAuswaerts1];

                erneuereListe(neuerSpieler, alterSpieler, cb_Heim1, spielerListHeim1);
                erneuereListe(neuerSpieler, alterSpieler, cb_Heim2, spielerListHeim2);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts2, spielerListAuswaerts2);

                resetIndexes();
                addSelectedIndexChangeEvents();
            }
        }

        private void cb_Auswaerts2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alterIndexAuswaerts2 != cb_Auswaerts2.SelectedIndex)
            {
                removeSelectedIndexChangeEvents();

                Spieler neuerSpieler = (Spieler)cb_Auswaerts2.SelectedItem;
                Spieler alterSpieler = (Spieler)cb_Auswaerts2.Items[alterIndexAuswaerts2];

                erneuereListe(neuerSpieler, alterSpieler, cb_Heim1, spielerListHeim1);
                erneuereListe(neuerSpieler, alterSpieler, cb_Heim2, spielerListHeim2);
                erneuereListe(neuerSpieler, alterSpieler, cb_Auswaerts1, spielerListAuswaerts1);

                resetIndexes();
                addSelectedIndexChangeEvents();
            }
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            int heim1 = ((Spieler)cb_Heim1.SelectedItem).ID;
            int heim2 = ((Spieler)cb_Heim2.SelectedItem).ID;
            int auswaerts1 = ((Spieler)cb_Auswaerts1.SelectedItem).ID;
            int auswaerts2 = ((Spieler)cb_Auswaerts2.SelectedItem).ID;
            if (Paarung.existsPaarung(heim1, heim2, auswaerts1, auswaerts2, saisonId))
            {
                MessageBox.Show("Diese Kombination aus Spielern gibts es in dieser Saison schon!", "Paarung existiert bereits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string error = Paarung.speichereKombination(heim1, heim2, auswaerts1, auswaerts2, spieltagId);
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
