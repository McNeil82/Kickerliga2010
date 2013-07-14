using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class Mainframe : Form
    {
        private const int COLUMN_INDEX_NAMEN = 0;
        private const int COLUMN_INDEX_SPIELE = 1;
        private const int COLUMN_INDEX_TORE = 2;
        private const int COLUMN_INDEX_GEGENTORE = 3;
        private const int COLUMN_INDEX_DIFFERENZ = 4;
        private const int COLUMN_INDEX_PUNKTE = 5;
        private const int COLUMN_INDEX_PLATZ = 6;

        private const int TAB_INDEX_TABELLE = 0;
        private const int TAB_INDEX_PAARUNGEN = 1;
        private const int TAB_INDEX_SPIELTAGE = 2;
        private const int TAB_INDEX_SAISONS = 3;

        private bool isComboBoxSpieltageBound = false;
        private bool isComboBoxSaisonsBound = false;
        private bool readOnly = true;
        private bool modified = false;
        private bool triedTabChange = false;

        private int plusCounter = 0;
        private int minusCounter = 0;
        private int currentSortColumn = COLUMN_INDEX_PUNKTE;
        private SortOrder currentSortOrder = SortOrder.Descending;

        private ListViewColumnSorter listviewColumnSorter = new ListViewColumnSorter();

        private Saison aktiveSaison = Saison.ladeAktiveSaison();
        private Saison aktuellAusgewaehlteSaison = new Saison();
        private Spieltag aktuellAusgewaehlterSpieltag = new Spieltag();

        private List<int> zuLoeschendePaarungen = new List<int>();
        private List<int> zuLoeschendeSpieltage = new List<int>();

        public Mainframe()
        {
            if (!Version.checkVersion())
            {
                Environment.Exit(-1);
            }
            InitializeComponent();
            ListView.ListViewItemSorter = listviewColumnSorter;
            this.Text = "Kickerliga - " + aktiveSaison.Name;
            aktuellAusgewaehlteSaison = aktiveSaison;
        }

        private void Mainframe_Load(object sender, EventArgs e)
        {
            erzeugeTabelle();
            reloadSpieltage();
            this.Activate();
        }

        private void erzeugeTabelle()
        {
            List<Tabellenzeile> tabelle = Tabellenzeile.ladeTabelle(aktuellAusgewaehlteSaison.ID);
            fillListView(tabelle);
            sortTabelle(currentSortColumn);
            ermittlePlatzierungenNachPunkten();
        }

        private void fillListView(List<Tabellenzeile> tabelle)
        {
            ListView.Items.Clear();

            foreach (Tabellenzeile zeile in tabelle)
            {
                ListViewItem lvi = new ListViewItem(new string[] { zeile.Kuerzel, zeile.Spiele.ToString(),
                                                                   zeile.Tore.ToString(), zeile.Gegentore.ToString(),
                                                                   zeile.Differenz.ToString(), zeile.Punkte.ToString(),
                                                                   "" });
                lvi.Tag = zeile.SpielerID;
                ListView.Items.Add(lvi);
            }
        }

        private void sortTabelle(int columnIndex)
        {
            if (columnIndex != COLUMN_INDEX_PLATZ)
            {
                if (columnIndex == COLUMN_INDEX_PUNKTE)
                {
                    currentSortOrder = SortOrder.Descending;
                    currentSortColumn = columnIndex;
                    sortiereNachPunkten();
                }
                else
                {
                    if (currentSortColumn != columnIndex)
                    {
                        if (columnIndex == COLUMN_INDEX_NAMEN)
                        {
                            currentSortOrder = SortOrder.Ascending;
                        }
                        else
                        {
                            currentSortOrder = SortOrder.Descending;
                        }
                    }
                    else
                    {
                        if (currentSortOrder == SortOrder.Ascending)
                        {
                            currentSortOrder = SortOrder.Descending;
                        }
                        else
                        {
                            currentSortOrder = SortOrder.Ascending;
                        }
                    }

                    currentSortColumn = columnIndex;
                    sortiere();
                }
            }
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortTabelle(e.Column);
        }

        private void sortiere()
        {
            listviewColumnSorter.Order = currentSortOrder;
            listviewColumnSorter.SortColumn = currentSortColumn;
            ListView.Sort();
        }

        private void sortiereNachPunkten()
        {
            listviewColumnSorter.Order = currentSortOrder;
            listviewColumnSorter.SortColumn = COLUMN_INDEX_TORE;
            ListView.Sort();
            listviewColumnSorter.SortColumn = COLUMN_INDEX_DIFFERENZ;
            ListView.Sort();
            listviewColumnSorter.SortColumn = COLUMN_INDEX_PUNKTE;
            ListView.Sort();
        }

        private void ermittlePlatzierungenNachPunkten()
        {
            string punkte = "";
            string differenz = "";
            string tore = "";
            ListView.ListViewItemCollection lvis = ListView.Items;
            int anzahl = ListView.Items.Count;
            bool markMore = true;

            for (int i = 0; i < lvis.Count; ++i)
            {
                if (!punkte.Equals(lvis[i].SubItems[COLUMN_INDEX_PUNKTE].Text)
                 || !differenz.Equals(lvis[i].SubItems[COLUMN_INDEX_DIFFERENZ].Text)
                 || !tore.Equals(lvis[i].SubItems[COLUMN_INDEX_TORE].Text))
                {
                    punkte = lvis[i].SubItems[COLUMN_INDEX_PUNKTE].Text;
                    differenz = lvis[i].SubItems[COLUMN_INDEX_DIFFERENZ].Text;
                    tore = lvis[i].SubItems[COLUMN_INDEX_TORE].Text;
                    lvis[i].SubItems[COLUMN_INDEX_PLATZ].Text = (i + 1).ToString() + ".";
                }
                else
                {
                    lvis[i].SubItems[COLUMN_INDEX_PLATZ].Text = "";
                }

                if ((i + 1) <= aktuellAusgewaehlteSaison.AnzahlAufsteiger || markMore)
                {
                    if ((i + 1) > aktuellAusgewaehlteSaison.AnzahlAufsteiger && !String.IsNullOrEmpty(lvis[i].SubItems[COLUMN_INDEX_PLATZ].Text))
                    {
                        markMore = false;
                    }
                    else
                    {
                        lvis[i].BackColor = Color.LightGreen;
                    }
                }
            }

            markMore = true;
            for (int i = lvis.Count - 1; i >= 0; --i)
            {
                if (anzahl - (i + 1) < aktuellAusgewaehlteSaison.AnzahlAbsteiger || markMore)
                {
                    lvis[i].BackColor = Color.OrangeRed;

                    if (anzahl - i >= aktuellAusgewaehlteSaison.AnzahlAbsteiger && !String.IsNullOrEmpty(lvis[i].SubItems[COLUMN_INDEX_PLATZ].Text))
                    {
                        break;
                    }
                }
            }
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            this.Enabled = false;
            int spielerID = Convert.ToInt32(ListView.SelectedItems[0].Tag);
            Spieler spieler = Spieler.ladeSpieler(spielerID);
            Spielerdetails spd = new Spielerdetails(spieler, readOnly);
            if (spd.ShowDialog() == DialogResult.OK) { }
            if (!readOnly)
            {
                spieler = Spieler.ladeSpieler(spielerID);
                ListViewItem lvi = ListView.SelectedItems[0];
                lvi.SubItems[0].Text = spieler.Kuerzel;
            }
            this.Enabled = true;
        }

        private void addNewMatchDay(Spieltag spieltag, int zeile)
        {
            Panel panel = new Panel();
            TextBox matchday = new TextBox();
            DateTimePicker from = new DateTimePicker();
            DateTimePicker until = new DateTimePicker();
            TextBox weeknumber = new TextBox();
            CheckBox delete = new CheckBox();

            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(0);
            panel.Name = "panel_Spieltag_" + spieltag.ID.ToString();
            panel.Size = new Size(342, 26);
            panel.TabIndex = zeile;

            matchday.Location = new Point(0, 0);
            matchday.MaxLength = 2;
            matchday.Name = "tb_matchday_" + spieltag.ID.ToString();
            matchday.ReadOnly = readOnly;
            matchday.Size = new Size(40, 20);
            matchday.Text = spieltag.SpieltagNr.ToString();
            matchday.TextChanged += new EventHandler(textBox_TextChanged);
            from.Enabled = !readOnly;
            from.Format = DateTimePickerFormat.Short;
            from.Location = new Point(46, 0);
            from.Name = "dtp_from_" + spieltag.ID.ToString();
            from.Size = new Size(100, 20);
            from.Value = spieltag.DatumVon;
            from.ValueChanged += new EventHandler(datePicker_ValueChanged);
            until.Enabled = !readOnly;
            until.Format = DateTimePickerFormat.Short;
            until.Location = new Point(152, 0);
            until.Name = "dtp_until_" + spieltag.ID.ToString();
            until.Size = new Size(100, 20);
            until.Value = spieltag.DatumBis;
            weeknumber.Location = new Point(258, 0);
            weeknumber.MaxLength = 2;
            weeknumber.Name = "tb_weeknumber_" + spieltag.ID.ToString();
            weeknumber.ReadOnly = true;
            weeknumber.Size = new Size(40, 20);
            weeknumber.Text = spieltag.Kalenderwoche.ToString();
            weeknumber.TextChanged += new EventHandler(textBox_TextChanged);

            delete.AutoSize = true;
            delete.Location = new Point(304, 3);
            delete.Name = "check_delete_" + spieltag.ID.ToString();
            delete.Size = new Size(15, 14);
            delete.UseVisualStyleBackColor = true;
            delete.Tag = spieltag.ID;
            delete.CheckedChanged += new EventHandler(check_delete_Matchday_CheckedChanged);
            delete.Visible = !readOnly;

            panel.Controls.Add(matchday);
            panel.Controls.Add(from);
            panel.Controls.Add(until);
            panel.Controls.Add(weeknumber);
            panel.Controls.Add(delete);

            SpieltagePanel.Controls.Add(panel);
        }

        private void addNewMatch(Paarung paarung, int zeile)
        {
            string heimtore = "";
            string auswaertstore = "";
            Ergebnis ergebnis = paarung.Ergebnis;
            if (ergebnis != null)
            {
                heimtore = ergebnis.Heimtore.ToString();
                auswaertstore = ergebnis.Auswaertstore.ToString();
            }

            Panel panel = new Panel();
            TextBox home1 = new TextBox();
            TextBox home2 = new TextBox();
            TextBox away1 = new TextBox();
            TextBox away2 = new TextBox();
            TextBox homeGoals = new TextBox();
            TextBox awayGoals = new TextBox();
            Label slashHome = new Label();
            Label slashAway = new Label();
            Label minus = new Label();
            Label colon = new Label();
            CheckBox delete = new CheckBox();

            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(0);
            panel.Name = "panel_Paarung_" + paarung.ID.ToString();
            panel.Size = new Size(342, 26);
            panel.TabIndex = zeile;

            home1.Location = new Point(0, 0);
            home1.MaxLength = 3;
            home1.Name = "tb_Home1_" + paarung.ID.ToString();
            home1.ReadOnly = true;
            home1.Size = new Size(40, 20);
            home1.Text = paarung.HeimSpieler1;
            slashHome.AutoSize = true;
            slashHome.Location = new Point(46, 4);
            slashHome.Name = "lbl_slash1_" + paarung.ID.ToString();
            slashHome.Size = new Size(12, 13);
            slashHome.Text = "/";
            home2.Location = new Point(64, 0);
            home2.MaxLength = 3;
            home2.Name = "tb_Home2_" + paarung.ID.ToString();
            home2.ReadOnly = true;
            home2.Size = new Size(40, 20);
            home2.Text = paarung.HeimSpieler2;
            minus.AutoSize = true;
            minus.Location = new Point(110, 4);
            minus.Name = "lbl_minus_" + paarung.ID.ToString();
            minus.Size = new Size(10, 13);
            minus.Text = "-";
            away1.Location = new Point(126, 0);
            away1.MaxLength = 3;
            away1.Name = "tb_Away1_" + paarung.ID.ToString();
            away1.ReadOnly = true;
            away1.Size = new Size(40, 20);
            away1.Text = paarung.AuswaertsSpieler1;
            slashAway.AutoSize = true;
            slashAway.Location = new Point(172, 4);
            slashAway.Name = "lbl_slash2_" + paarung.ID.ToString();
            slashAway.Size = new Size(12, 13);
            slashAway.Text = "/";
            away2.Location = new Point(190, 0);
            away2.MaxLength = 3;
            away2.Name = "tb_Away2_" + paarung.ID.ToString();
            away2.ReadOnly = true;
            away2.Size = new Size(40, 20);
            away2.Text = paarung.AuswaertsSpieler2;
            homeGoals.Location = new Point(292, 0);
            homeGoals.MaxLength = 1;
            homeGoals.Name = "tb_HomeGoals_" + paarung.ID.ToString();
            homeGoals.ReadOnly = readOnly;
            homeGoals.Size = new Size(14, 20);
            homeGoals.Text = heimtore;
            homeGoals.TextChanged += new EventHandler(textBox_TextChanged);
            colon.AutoSize = true;
            colon.Location = new Point(312, 4);
            colon.Name = "lbl_colon_" + paarung.ID.ToString();
            colon.Size = new Size(10, 13);
            colon.Text = ":";
            awayGoals.Location = new Point(328, 0);
            awayGoals.MaxLength = 1;
            awayGoals.Name = "tb_AwayGoals_" + paarung.ID.ToString();
            awayGoals.ReadOnly = readOnly;
            awayGoals.Size = new Size(14, 20);
            awayGoals.Text = auswaertstore;
            awayGoals.TextChanged += new EventHandler(textBox_TextChanged);

            delete.AutoSize = true;
            delete.Location = new Point(367, 3);
            delete.Name = "check_delete_" + paarung.ID.ToString();
            delete.Size = new Size(15, 14);
            delete.UseVisualStyleBackColor = true;
            delete.Tag = paarung.ID;
            delete.CheckedChanged += new EventHandler(check_delete_CheckedChanged);
            if (paarung.Ergebnis == null)
            {
                delete.Visible = !readOnly;
            }
            else
            {
                delete.Visible = false;
            }

            panel.Controls.Add(home1);
            panel.Controls.Add(slashHome);
            panel.Controls.Add(home2);
            panel.Controls.Add(minus);
            panel.Controls.Add(away1);
            panel.Controls.Add(slashAway);
            panel.Controls.Add(away2);
            panel.Controls.Add(homeGoals);
            panel.Controls.Add(colon);
            panel.Controls.Add(awayGoals);

            panel.Controls.Add(delete);

            PaarungenPanel.Controls.Add(panel);
        }

        void check_delete_CheckedChanged(object sender, EventArgs e)
        {
            int paarungID = Convert.ToInt32(((CheckBox)sender).Tag);
            if (((CheckBox)sender).Checked)
            {
                zuLoeschendePaarungen.Add(paarungID);
            }
            else
            {
                zuLoeschendePaarungen.Remove(paarungID);
            }
        }

        void check_delete_Matchday_CheckedChanged(object sender, EventArgs e)
        {
            int spieltagID = Convert.ToInt32(((CheckBox)sender).Tag);
            if (((CheckBox)sender).Checked)
            {
                zuLoeschendeSpieltage.Add(spieltagID);
            }
            else
            {
                zuLoeschendeSpieltage.Remove(spieltagID);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TabControl.SelectedIndex == TAB_INDEX_SAISONS && !isComboBoxSaisonsBound) || !isComboBoxSaisonsBound)
            {
                cb_Saisons.DisplayMember = "ComboBoxAnzeige";
                cb_Saisons.DataSource = Saison.ladeAlleSaisons();
                cb_Saisons.SelectedIndex = cb_Saisons.FindStringExact(aktiveSaison.ComboBoxAnzeige);
                isComboBoxSaisonsBound = true;
            }

            if ((TabControl.SelectedIndex == TAB_INDEX_PAARUNGEN && !isComboBoxSpieltageBound) || !isComboBoxSpieltageBound)
            {
                cb_Spieltage.DisplayMember = "ComboBoxAnzeige";
                cb_Spieltage.DataSource = Spieltag.ladeAlleSpieltage(aktuellAusgewaehlteSaison.ID);
                cb_Spieltage.SelectedIndex = cb_Spieltage.FindStringExact(aktuellAusgewaehlterSpieltag.ComboBoxAnzeige);
                isComboBoxSpieltageBound = true;
            }
        }

        private void aktiviereEventhandlerTabSaisons()
        {
            plusCounter++;
            tb_AnzahlAbsteiger.TextChanged += new EventHandler(textBox_TextChanged);
            tb_AnzahlAufsteiger.TextChanged += new EventHandler(textBox_TextChanged);
            tb_Liga.TextChanged += new EventHandler(textBox_TextChanged);
            tb_SaisonName.TextChanged += new EventHandler(textBox_TextChanged);
        }

        private void deaktiviereEventhandlerTabSaisons()
        {
            minusCounter++;
            tb_AnzahlAbsteiger.TextChanged -= new EventHandler(textBox_TextChanged);
            tb_AnzahlAufsteiger.TextChanged -= new EventHandler(textBox_TextChanged);
            tb_Liga.TextChanged -= new EventHandler(textBox_TextChanged);
            tb_SaisonName.TextChanged -= new EventHandler(textBox_TextChanged);
        }

        private void cb_Spieltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadPaarungen();
        }

        private void cb_Saisons_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadSaison();
            cb_Spieltage.SelectedIndex = -1;
            isComboBoxSpieltageBound = false;
            aktuellAusgewaehlterSpieltag = new Spieltag();
            reloadSpieltage();
            reloadPaarungen();
            erzeugeTabelle();
        }

        private void reloadSaison()
        {
            deaktiviereEventhandlerTabSaisons();
            aktuellAusgewaehlteSaison = (Saison)cb_Saisons.Items[cb_Saisons.SelectedIndex];

            tb_AnzahlAbsteiger.Text = aktuellAusgewaehlteSaison.AnzahlAbsteiger.ToString();
            tb_AnzahlAufsteiger.Text = aktuellAusgewaehlteSaison.AnzahlAufsteiger.ToString();
            tb_Liga.Text = aktuellAusgewaehlteSaison.Liga.ToString();
            tb_SaisonName.Text = aktuellAusgewaehlteSaison.Name;
            this.Text = "Kickerliga - " + aktuellAusgewaehlteSaison.Name;
            aktiviereEventhandlerTabSaisons();
        }

        private void reloadSpieltage()
        {
            SpieltagePanel.SuspendLayout();
            SpieltagePanel.Controls.Clear();

            List<Spieltag> spieltage = aktuellAusgewaehlteSaison.Spieltage;
            for (int i = spieltage.Count - 1; i > -1; i--)
            {
                Spieltag spieltag = spieltage[i];
                addNewMatchDay(spieltag, i);
            }

            SpieltagePanel.ResumeLayout();
            isComboBoxSpieltageBound = false;
        }

        private void reloadPaarungen()
        {
            PaarungenPanel.SuspendLayout();
            PaarungenPanel.Controls.Clear();

            if (cb_Spieltage.SelectedIndex != -1)
            {
                aktuellAusgewaehlterSpieltag = (Spieltag)cb_Spieltage.Items[cb_Spieltage.SelectedIndex];
                List<Paarung> paarungen = aktuellAusgewaehlterSpieltag.Paarungen;
                for (int i = paarungen.Count - 1; i > -1; i--)
                {
                    Paarung paarung = paarungen[i];
                    addNewMatch(paarung, i);
                }
            }
            PaarungenPanel.ResumeLayout();
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BearbeitermodusToolStripMenuItem.Checked)
            {
                Passworteingabe passwort = new Passworteingabe();
                if (passwort.ShowDialog() == DialogResult.OK)
                {
                    BearbeitermodusToolStripMenuItem.Checked = true;
                    LesemodusToolStripMenuItem.Checked = false;
                    setReadOnly(false);
                }
            }
        }

        private void nurLesenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!LesemodusToolStripMenuItem.Checked)
            {
                if (modified)
                {
                    if (proceedDespiteModified())
                    {
                        modified = false;
                        if (TabControl.SelectedIndex == TAB_INDEX_PAARUNGEN)
                        {
                            reloadPaarungen();
                        }
                        else if (TabControl.SelectedIndex == TAB_INDEX_SAISONS)
                        {
                            reloadSaison();
                        }
                        else if (TabControl.SelectedIndex == TAB_INDEX_SPIELTAGE)
                        {
                            reloadSpieltage();
                        }
                    }
                    else
                    {
                        if (TabControl.SelectedIndex == TAB_INDEX_PAARUNGEN)
                        {
                            PaarungenFokusPanel.Focus();
                        }
                        else if (TabControl.SelectedIndex == TAB_INDEX_SAISONS)
                        {
                            SaisonFokusPanel.Focus();
                        }
                        else if (TabControl.SelectedIndex == TAB_INDEX_SPIELTAGE)
                        {
                            SpieltageFokusPanel.Focus();
                        }
                    }
                }

                if (!modified)
                {
                    BearbeitermodusToolStripMenuItem.Checked = false;
                    LesemodusToolStripMenuItem.Checked = true;
                    setReadOnly(true);
                }
            }
        }

        private void setReadOnly(bool readOnly)
        {
            this.readOnly = readOnly;
            btn_PaarungenSpeichern.Visible = !readOnly;
            btn_addPaarung.Visible = !readOnly;
            btn_deletePaarungen.Visible = !readOnly;
            btn_addSpieltag.Visible = !readOnly;
            btn_deleteSpieltage.Visible = !readOnly;
            btn_SpieltageSpeichern.Visible = !readOnly;
            btn_addSaison.Visible = !readOnly;
            btn_SaisonSpeichern.Visible = !readOnly;
            neuerSpielerToolStripMenuItem.Visible = !readOnly;

            tb_AnzahlAbsteiger.ReadOnly = readOnly;
            tb_AnzahlAufsteiger.ReadOnly = readOnly;
            tb_Liga.ReadOnly = readOnly;
            tb_SaisonName.ReadOnly = readOnly;

            List<Paarung> paarungen = aktuellAusgewaehlterSpieltag.Paarungen;
            foreach (Paarung paarung in paarungen)
            {
                Panel panel = (Panel)PaarungenPanel.Controls["panel_Paarung_" + paarung.ID.ToString()];
                ((TextBox)panel.Controls["tb_HomeGoals_" + paarung.ID.ToString()]).ReadOnly = readOnly;
                ((TextBox)panel.Controls["tb_AwayGoals_" + paarung.ID.ToString()]).ReadOnly = readOnly;
                if (paarung.Ergebnis == null)
                {
                    ((CheckBox)panel.Controls["check_delete_" + paarung.ID.ToString()]).Visible = !readOnly;
                }
                else
                {
                    ((CheckBox)panel.Controls["check_delete_" + paarung.ID.ToString()]).Visible = false;
                }
            }

            List<Spieltag> spieltage = aktuellAusgewaehlteSaison.Spieltage;
            foreach (Spieltag spieltag in spieltage)
            {
                Panel panel = (Panel)SpieltagePanel.Controls["panel_Spieltag_" + spieltag.ID.ToString()];
                ((TextBox)panel.Controls["tb_matchday_" + spieltag.ID.ToString()]).ReadOnly = readOnly;
                ((DateTimePicker)panel.Controls["dtp_from_" + spieltag.ID.ToString()]).Enabled = !readOnly;
                ((DateTimePicker)panel.Controls["dtp_until_" + spieltag.ID.ToString()]).Enabled = !readOnly;
                ((CheckBox)panel.Controls["check_delete_" + spieltag.ID.ToString()]).Visible = !readOnly;
            }
        }

        private void btn_SaisonSpeichern_Click(object sender, EventArgs e)
        {
            Saison saison = aktuellAusgewaehlteSaison.Clone();
            int anzahlAbsteiger = 0;
            int anzahlAufsteiger = 0;
            int liga = 0;
            Int32.TryParse(tb_AnzahlAbsteiger.Text, out anzahlAbsteiger);
            Int32.TryParse(tb_AnzahlAufsteiger.Text, out anzahlAufsteiger);
            Int32.TryParse(tb_Liga.Text, out liga);

            saison.AnzahlAbsteiger = anzahlAbsteiger;
            saison.AnzahlAufsteiger = anzahlAufsteiger;
            saison.Liga = liga;
            saison.Name = tb_SaisonName.Text;

            string errorMessage = saison.save();
            if (!String.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                int index = cb_Saisons.SelectedIndex;
                cb_Saisons.DataSource = Saison.ladeAlleSaisons();
                cb_Saisons.SelectedIndex = index;
                modified = false;

                erzeugeTabelle();
            }
        }

        private void btn_SpieltageSpeichern_Click(object sender, EventArgs e)
        {
            List<Spieltag> spieltage = aktuellAusgewaehlteSaison.Spieltage;
            foreach (Spieltag spieltag in spieltage)
            {
                Panel panel = (Panel)SpieltagePanel.Controls["panel_Spieltag_" + spieltag.ID.ToString()];
                int nummer = 0;
                Int32.TryParse(((TextBox)panel.Controls["tb_matchday_" + spieltag.ID.ToString()]).Text, out nummer);
                DateTime von = ((DateTimePicker)panel.Controls["dtp_from_" + spieltag.ID.ToString()]).Value;
                DateTime bis = ((DateTimePicker)panel.Controls["dtp_until_" + spieltag.ID.ToString()]).Value;
                int kw = Convert.ToInt32(((TextBox)panel.Controls["tb_weeknumber_" + spieltag.ID.ToString()]).Text);

                spieltag.SpieltagNr = nummer;
                spieltag.DatumVon = von;
                spieltag.DatumBis = bis;
                spieltag.Kalenderwoche = kw;
            }

            string errorMessage = aktuellAusgewaehlteSaison.aktualisiereSpieltage();
            if (!String.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                int index = cb_Spieltage.SelectedIndex;
                cb_Spieltage.DataSource = Spieltag.ladeAlleSpieltage(aktuellAusgewaehlteSaison.ID);
                cb_Spieltage.SelectedIndex = index;
                modified = false;
            }
        }

        private void btn_PaarungenSpeichern_Click(object sender, EventArgs e)
        {
            List<Paarung> paarungen = aktuellAusgewaehlterSpieltag.Paarungen;
            foreach (Paarung paarung in paarungen)
            {
                Ergebnis ergebnis = paarung.Ergebnis;
                Panel panel = (Panel)PaarungenPanel.Controls["panel_Paarung_" + paarung.ID.ToString()];
                string heimtoreString = ((TextBox)panel.Controls["tb_HomeGoals_" + paarung.ID.ToString()]).Text;
                string auswaertstoreString = ((TextBox)panel.Controls["tb_AwayGoals_" + paarung.ID.ToString()]).Text;
                if (heimtoreString.Equals("") && auswaertstoreString.Equals(""))
                {
                    paarung.Ergebnis = null;
                }
                else
                {
                    int heimtore = 0;
                    int auswaertstore = 0;
                    if (Int32.TryParse(heimtoreString, out heimtore)
                     && Int32.TryParse(auswaertstoreString, out auswaertstore))
                    {

                        if (ergebnis != null)
                        {
                            ergebnis.Auswaertstore = auswaertstore;
                            ergebnis.Heimtore = heimtore;
                        }
                        else
                        {
                            Ergebnis neuesErgebnis = new Ergebnis();
                            neuesErgebnis.Auswaertstore = auswaertstore;
                            neuesErgebnis.Heimtore = heimtore;
                            paarung.Ergebnis = neuesErgebnis;
                        }
                    }
                }
            }

            string errorMessage = aktuellAusgewaehlterSpieltag.save();
            if (!String.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                int index = cb_Spieltage.SelectedIndex;
                cb_Spieltage.DataSource = Spieltag.ladeAlleSpieltage(aktuellAusgewaehlteSaison.ID);
                cb_Spieltage.SelectedIndex = index;
                modified = false;

                erzeugeTabelle();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private bool proceedDespiteModified()
        {
            bool proceed = true;

            DialogResult result = MessageBox.Show("Es sind noch ungespeicherte Änderungen vorhanden. Diese gehen verloren.\nFortfahren?",
                                                  "Ungespeicherte Änderungen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                proceed = false;
            }

            return proceed;
        }

        private void FokusPanel_Validating(object sender, CancelEventArgs e)
        {
            if (triedTabChange)
            {
                ((Panel)sender).Focus();
                triedTabChange = false;
            }
            else if (modified)
            {
                if (proceedDespiteModified())
                {
                    modified = false;
                    if (((Panel)sender) == SaisonFokusPanel)
                    {
                        reloadSaison();
                    }
                    else if (((Panel)sender) == PaarungenFokusPanel)
                    {
                        reloadPaarungen();
                    }
                    else if (((Panel)sender) == SpieltageFokusPanel)
                    {
                        reloadSpieltage();
                    }
                }
                else
                {
                    e.Cancel = true;
                    ((Panel)sender).Focus();
                }
            }
        }

        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (modified)
            {
                e.Cancel = true;
                triedTabChange = true;
            }
        }

        private void btn_addSpieltag_Click(object sender, EventArgs e)
        {
            DateTime letztesDatum = DateTime.Today;

            if (aktuellAusgewaehlteSaison.Spieltage.Count > 0)
            {
                letztesDatum = aktuellAusgewaehlteSaison.Spieltage[aktuellAusgewaehlteSaison.Spieltage.Count - 1].DatumBis;
            }

            SpieltagHinzufuegen neuerSpieltag = new SpieltagHinzufuegen(aktuellAusgewaehlteSaison.ID, aktuellAusgewaehlteSaison.Spieltage.Count + 1, letztesDatum);
            this.Enabled = false;
            if (neuerSpieltag.ShowDialog() == DialogResult.OK)
            {
                aktuellAusgewaehlteSaison.setLoaded(false);
                reloadSpieltage();
            }
            this.Enabled = true;
        }

        private void btn_addSaison_Click(object sender, EventArgs e)
        {
            SaisonHinzufuegen neueSaison = new SaisonHinzufuegen();
            this.Enabled = false;
            if (neueSaison.ShowDialog() == DialogResult.OK)
            {
                cb_Saisons.BindingContext[cb_Saisons.DataSource].SuspendBinding();
                cb_Saisons.DataSource = Saison.ladeAlleSaisons();
                aktiveSaison = Saison.ladeAktiveSaison();
                cb_Saisons.SelectedIndex = cb_Saisons.FindStringExact(aktiveSaison.ComboBoxAnzeige);
                cb_Saisons.BindingContext[cb_Saisons.DataSource].ResumeBinding();

                reloadSaison();
            }
            this.Enabled = true;
        }

        private void btn_addPaarung_Click(object sender, EventArgs e)
        {
            PaarungHinzufuegen neuePaarung = new PaarungHinzufuegen(aktuellAusgewaehlterSpieltag.ID, aktuellAusgewaehlteSaison.ID);
            this.Enabled = false;
            if (neuePaarung.ShowDialog() == DialogResult.OK)
            {
                aktuellAusgewaehlterSpieltag.setLoaded(false);
                reloadPaarungen();
                erzeugeTabelle();
            }
            this.Enabled = true;
        }

        private void tabelleJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int breite = 3;
            int hoehe = (ListView.Font.Height + 4) * (ListView.Items.Count + 2);

            foreach (ColumnHeader col in ListView.Columns)
            {
                breite += col.Width;
            }

            Bitmap bmp = new Bitmap(breite, hoehe);

            ListView.DrawToBitmap(bmp, Rectangle.FromLTRB(0, 0, breite, hoehe));
            bmp.Save(aktuellAusgewaehlteSaison.Liga.ToString() + ". Liga - " + aktuellAusgewaehlteSaison.Name + " Tabelle vom " + DateTime.Now.ToShortDateString() + ".png", ImageFormat.Png);

            MessageBox.Show("Screenshot erstellt!", "Screenshot", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_deleteSpieltage_Click(object sender, EventArgs e)
        {
            if (zuLoeschendeSpieltage.Count > 0)
            {
                DialogResult result = MessageBox.Show("Sicher, dass diese(r) Spieltag(e) gelöscht werden soll(en)?", "Sicherheitsfrage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string errorMessage = Spieltag.loescheSpieltage(zuLoeschendeSpieltage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        aktuellAusgewaehlteSaison.setLoaded(false);
                        reloadSpieltage();
                    }
                }
            }
            else
            {
                MessageBox.Show("Keine Spieltage ausgewählt!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_deletePaarungen_Click(object sender, EventArgs e)
        {
            if (zuLoeschendePaarungen.Count > 0)
            {
                DialogResult result = MessageBox.Show("Sicher, dass diese Paarung(en) gelöscht werden soll(en)?", "Sicherheitsfrage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string errorMessage = Paarung.loeschePaarung(zuLoeschendePaarungen);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        aktuellAusgewaehlterSpieltag.setLoaded(false);
                        reloadPaarungen();
                    }
                }
            }
            else
            {
                MessageBox.Show("Keine Paarungen ausgewählt!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void neuerSpielerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Spielerdetails spd = new Spielerdetails(new Spieler(), readOnly);
            if (spd.ShowDialog() == DialogResult.OK) { }
            this.Enabled = true;
        }

        private void Mainframe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saison.aktiviereSaison(aktuellAusgewaehlteSaison.ID);
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            modified = true;
            DateTimePicker from = ((DateTimePicker)sender);
            string name = from.Name;
            string id = name.Replace("dtp_from_", "");
            Panel panel = (Panel)SpieltagePanel.Controls["panel_Spieltag_" + id];
            ((DateTimePicker)panel.Controls["dtp_until_" + id]).Value = from.Value.AddDays(4);
            ((TextBox)panel.Controls["tb_weeknumber_" + id]).Text = CultureInfo.CreateSpecificCulture("de-DE").Calendar.GetWeekOfYear(from.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();
        }
    }
}
