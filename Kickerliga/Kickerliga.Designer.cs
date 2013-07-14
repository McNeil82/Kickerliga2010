namespace Kickerliga
{
    partial class Mainframe
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
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LesemodusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BearbeitermodusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuerSpielerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelleJPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabTabelle = new System.Windows.Forms.TabPage();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.ListView = new System.Windows.Forms.ListView();
            this.ch_Spieler = new System.Windows.Forms.ColumnHeader();
            this.ch_Spiele = new System.Windows.Forms.ColumnHeader();
            this.ch_Tore = new System.Windows.Forms.ColumnHeader();
            this.ch_Gegentore = new System.Windows.Forms.ColumnHeader();
            this.ch_Differenz = new System.Windows.Forms.ColumnHeader();
            this.ch_Punkte = new System.Windows.Forms.ColumnHeader();
            this.ch_Platz = new System.Windows.Forms.ColumnHeader();
            this.TabPaarungen = new System.Windows.Forms.TabPage();
            this.btn_deletePaarungen = new System.Windows.Forms.Button();
            this.btn_addPaarung = new System.Windows.Forms.Button();
            this.PaarungenFokusPanel = new System.Windows.Forms.Panel();
            this.PaarungenPanel = new System.Windows.Forms.Panel();
            this.btn_PaarungenSpeichern = new System.Windows.Forms.Button();
            this.cb_Spieltage = new System.Windows.Forms.ComboBox();
            this.TabSpieltage = new System.Windows.Forms.TabPage();
            this.SpieltageFokusPanel = new System.Windows.Forms.Panel();
            this.SpieltagePanel = new System.Windows.Forms.Panel();
            this.btn_SpieltageSpeichern = new System.Windows.Forms.Button();
            this.btn_deleteSpieltage = new System.Windows.Forms.Button();
            this.btn_addSpieltag = new System.Windows.Forms.Button();
            this.TabSaisons = new System.Windows.Forms.TabPage();
            this.SaisonFokusPanel = new System.Windows.Forms.Panel();
            this.SaisonPanel = new System.Windows.Forms.Panel();
            this.lbl_AnzahlAbsteiger = new System.Windows.Forms.Label();
            this.tb_AnzahlAbsteiger = new System.Windows.Forms.TextBox();
            this.lbl_AnzahlAufsteiger = new System.Windows.Forms.Label();
            this.tb_AnzahlAufsteiger = new System.Windows.Forms.TextBox();
            this.lbl_Liga = new System.Windows.Forms.Label();
            this.tb_Liga = new System.Windows.Forms.TextBox();
            this.lbl_SaisonName = new System.Windows.Forms.Label();
            this.tb_SaisonName = new System.Windows.Forms.TextBox();
            this.btn_SaisonSpeichern = new System.Windows.Forms.Button();
            this.btn_addSaison = new System.Windows.Forms.Button();
            this.cb_Saisons = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabTabelle.SuspendLayout();
            this.TabPaarungen.SuspendLayout();
            this.PaarungenFokusPanel.SuspendLayout();
            this.TabSpieltage.SuspendLayout();
            this.SpieltageFokusPanel.SuspendLayout();
            this.TabSaisons.SuspendLayout();
            this.SaisonFokusPanel.SuspendLayout();
            this.SaisonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.neuerSpielerToolStripMenuItem,
            this.tabelleJPGToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Menu.Size = new System.Drawing.Size(632, 24);
            this.Menu.TabIndex = 4;
            this.Menu.Text = "Menu";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LesemodusToolStripMenuItem,
            this.BearbeitermodusToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editToolStripMenuItem.Text = "Modus";
            // 
            // LesemodusToolStripMenuItem
            // 
            this.LesemodusToolStripMenuItem.Checked = true;
            this.LesemodusToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LesemodusToolStripMenuItem.Name = "LesemodusToolStripMenuItem";
            this.LesemodusToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.LesemodusToolStripMenuItem.Text = "Lesemodus";
            this.LesemodusToolStripMenuItem.Click += new System.EventHandler(this.nurLesenToolStripMenuItem_Click);
            // 
            // BearbeitermodusToolStripMenuItem
            // 
            this.BearbeitermodusToolStripMenuItem.Name = "BearbeitermodusToolStripMenuItem";
            this.BearbeitermodusToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.BearbeitermodusToolStripMenuItem.Text = "Bearbeitermodus";
            this.BearbeitermodusToolStripMenuItem.Click += new System.EventHandler(this.bearbeitenToolStripMenuItem_Click);
            // 
            // neuerSpielerToolStripMenuItem
            // 
            this.neuerSpielerToolStripMenuItem.Name = "neuerSpielerToolStripMenuItem";
            this.neuerSpielerToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.neuerSpielerToolStripMenuItem.Text = "Neuer Spieler";
            this.neuerSpielerToolStripMenuItem.Visible = false;
            this.neuerSpielerToolStripMenuItem.Click += new System.EventHandler(this.neuerSpielerToolStripMenuItem_Click);
            // 
            // tabelleJPGToolStripMenuItem
            // 
            this.tabelleJPGToolStripMenuItem.Name = "tabelleJPGToolStripMenuItem";
            this.tabelleJPGToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.tabelleJPGToolStripMenuItem.Text = "Tabelle > PNG";
            this.tabelleJPGToolStripMenuItem.Click += new System.EventHandler(this.tabelleJPGToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.TabControl);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainPanel.Size = new System.Drawing.Size(632, 425);
            this.MainPanel.TabIndex = 5;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabTabelle);
            this.TabControl.Controls.Add(this.TabPaarungen);
            this.TabControl.Controls.Add(this.TabSpieltage);
            this.TabControl.Controls.Add(this.TabSaisons);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(10, 10);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.Name = "TabControl";
            this.TabControl.Padding = new System.Drawing.Point(0, 0);
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(612, 405);
            this.TabControl.TabIndex = 4;
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // TabTabelle
            // 
            this.TabTabelle.Controls.Add(this.lbl_Info);
            this.TabTabelle.Controls.Add(this.ListView);
            this.TabTabelle.Location = new System.Drawing.Point(4, 22);
            this.TabTabelle.Margin = new System.Windows.Forms.Padding(0);
            this.TabTabelle.Name = "TabTabelle";
            this.TabTabelle.Size = new System.Drawing.Size(604, 379);
            this.TabTabelle.TabIndex = 0;
            this.TabTabelle.Text = "Tabelle";
            this.TabTabelle.UseVisualStyleBackColor = true;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new System.Drawing.Point(-3, 366);
            this.lbl_Info.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(229, 13);
            this.lbl_Info.TabIndex = 2;
            this.lbl_Info.Text = "Doppelklick auf ein Spielerkürzel öffnet Details.";
            // 
            // ListView
            // 
            this.ListView.AllowColumnReorder = true;
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Spieler,
            this.ch_Spiele,
            this.ch_Tore,
            this.ch_Gegentore,
            this.ch_Differenz,
            this.ch_Punkte,
            this.ch_Platz});
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Margin = new System.Windows.Forms.Padding(0);
            this.ListView.MultiSelect = false;
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(604, 379);
            this.ListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.ListView.TabIndex = 1;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.DoubleClick += new System.EventHandler(this.ListView_DoubleClick);
            this.ListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView_ColumnClick);
            // 
            // ch_Spieler
            // 
            this.ch_Spieler.DisplayIndex = 1;
            this.ch_Spieler.Text = "Spieler";
            this.ch_Spieler.Width = 50;
            // 
            // ch_Spiele
            // 
            this.ch_Spiele.DisplayIndex = 2;
            this.ch_Spiele.Text = "Spiele";
            this.ch_Spiele.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Spiele.Width = 50;
            // 
            // ch_Tore
            // 
            this.ch_Tore.DisplayIndex = 3;
            this.ch_Tore.Text = "Tore";
            this.ch_Tore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Tore.Width = 50;
            // 
            // ch_Gegentore
            // 
            this.ch_Gegentore.DisplayIndex = 4;
            this.ch_Gegentore.Text = "Gegentore";
            this.ch_Gegentore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Gegentore.Width = 50;
            // 
            // ch_Differenz
            // 
            this.ch_Differenz.DisplayIndex = 5;
            this.ch_Differenz.Text = "Differenz";
            this.ch_Differenz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Differenz.Width = 50;
            // 
            // ch_Punkte
            // 
            this.ch_Punkte.DisplayIndex = 6;
            this.ch_Punkte.Text = "Punkte";
            this.ch_Punkte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_Punkte.Width = 50;
            // 
            // ch_Platz
            // 
            this.ch_Platz.DisplayIndex = 0;
            this.ch_Platz.Text = "Platz";
            this.ch_Platz.Width = 40;
            // 
            // TabPaarungen
            // 
            this.TabPaarungen.AutoScroll = true;
            this.TabPaarungen.Controls.Add(this.btn_deletePaarungen);
            this.TabPaarungen.Controls.Add(this.btn_addPaarung);
            this.TabPaarungen.Controls.Add(this.PaarungenFokusPanel);
            this.TabPaarungen.Controls.Add(this.cb_Spieltage);
            this.TabPaarungen.Location = new System.Drawing.Point(4, 22);
            this.TabPaarungen.Margin = new System.Windows.Forms.Padding(0);
            this.TabPaarungen.Name = "TabPaarungen";
            this.TabPaarungen.Size = new System.Drawing.Size(604, 379);
            this.TabPaarungen.TabIndex = 1;
            this.TabPaarungen.Text = "Paarungen";
            this.TabPaarungen.UseVisualStyleBackColor = true;
            // 
            // btn_deletePaarungen
            // 
            this.btn_deletePaarungen.AutoSize = true;
            this.btn_deletePaarungen.Location = new System.Drawing.Point(364, 6);
            this.btn_deletePaarungen.Name = "btn_deletePaarungen";
            this.btn_deletePaarungen.Size = new System.Drawing.Size(112, 23);
            this.btn_deletePaarungen.TabIndex = 5;
            this.btn_deletePaarungen.Text = "Paarungen löschen";
            this.btn_deletePaarungen.UseVisualStyleBackColor = true;
            this.btn_deletePaarungen.Visible = false;
            this.btn_deletePaarungen.Click += new System.EventHandler(this.btn_deletePaarungen_Click);
            // 
            // btn_addPaarung
            // 
            this.btn_addPaarung.AutoSize = true;
            this.btn_addPaarung.Location = new System.Drawing.Point(482, 6);
            this.btn_addPaarung.Name = "btn_addPaarung";
            this.btn_addPaarung.Size = new System.Drawing.Size(112, 23);
            this.btn_addPaarung.TabIndex = 4;
            this.btn_addPaarung.Text = "Paarung hinzufügen";
            this.btn_addPaarung.UseVisualStyleBackColor = true;
            this.btn_addPaarung.Visible = false;
            this.btn_addPaarung.Click += new System.EventHandler(this.btn_addPaarung_Click);
            // 
            // PaarungenFokusPanel
            // 
            this.PaarungenFokusPanel.Controls.Add(this.PaarungenPanel);
            this.PaarungenFokusPanel.Controls.Add(this.btn_PaarungenSpeichern);
            this.PaarungenFokusPanel.Location = new System.Drawing.Point(8, 35);
            this.PaarungenFokusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PaarungenFokusPanel.Name = "PaarungenFokusPanel";
            this.PaarungenFokusPanel.Size = new System.Drawing.Size(593, 341);
            this.PaarungenFokusPanel.TabIndex = 3;
            this.PaarungenFokusPanel.Validating += new System.ComponentModel.CancelEventHandler(this.FokusPanel_Validating);
            // 
            // PaarungenPanel
            // 
            this.PaarungenPanel.Location = new System.Drawing.Point(0, 0);
            this.PaarungenPanel.Name = "PaarungenPanel";
            this.PaarungenPanel.Size = new System.Drawing.Size(476, 341);
            this.PaarungenPanel.TabIndex = 1;
            // 
            // btn_PaarungenSpeichern
            // 
            this.btn_PaarungenSpeichern.Location = new System.Drawing.Point(511, 311);
            this.btn_PaarungenSpeichern.Margin = new System.Windows.Forms.Padding(10);
            this.btn_PaarungenSpeichern.Name = "btn_PaarungenSpeichern";
            this.btn_PaarungenSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btn_PaarungenSpeichern.TabIndex = 2;
            this.btn_PaarungenSpeichern.Text = "Speichern";
            this.btn_PaarungenSpeichern.UseVisualStyleBackColor = true;
            this.btn_PaarungenSpeichern.Visible = false;
            this.btn_PaarungenSpeichern.Click += new System.EventHandler(this.btn_PaarungenSpeichern_Click);
            // 
            // cb_Spieltage
            // 
            this.cb_Spieltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Spieltage.DropDownWidth = 342;
            this.cb_Spieltage.FormattingEnabled = true;
            this.cb_Spieltage.Location = new System.Drawing.Point(8, 8);
            this.cb_Spieltage.MaxDropDownItems = 15;
            this.cb_Spieltage.Name = "cb_Spieltage";
            this.cb_Spieltage.Size = new System.Drawing.Size(342, 21);
            this.cb_Spieltage.TabIndex = 0;
            this.cb_Spieltage.SelectedIndexChanged += new System.EventHandler(this.cb_Spieltage_SelectedIndexChanged);
            // 
            // TabSpieltage
            // 
            this.TabSpieltage.Controls.Add(this.SpieltageFokusPanel);
            this.TabSpieltage.Controls.Add(this.btn_deleteSpieltage);
            this.TabSpieltage.Controls.Add(this.btn_addSpieltag);
            this.TabSpieltage.Location = new System.Drawing.Point(4, 22);
            this.TabSpieltage.Margin = new System.Windows.Forms.Padding(0);
            this.TabSpieltage.Name = "TabSpieltage";
            this.TabSpieltage.Size = new System.Drawing.Size(604, 379);
            this.TabSpieltage.TabIndex = 3;
            this.TabSpieltage.Text = "Spieltage";
            this.TabSpieltage.UseVisualStyleBackColor = true;
            // 
            // SpieltageFokusPanel
            // 
            this.SpieltageFokusPanel.Controls.Add(this.SpieltagePanel);
            this.SpieltageFokusPanel.Controls.Add(this.btn_SpieltageSpeichern);
            this.SpieltageFokusPanel.Location = new System.Drawing.Point(8, 35);
            this.SpieltageFokusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SpieltageFokusPanel.Name = "SpieltageFokusPanel";
            this.SpieltageFokusPanel.Size = new System.Drawing.Size(593, 341);
            this.SpieltageFokusPanel.TabIndex = 9;
            this.SpieltageFokusPanel.Validating += new System.ComponentModel.CancelEventHandler(this.FokusPanel_Validating);
            // 
            // SpieltagePanel
            // 
            this.SpieltagePanel.Location = new System.Drawing.Point(0, 0);
            this.SpieltagePanel.Name = "SpieltagePanel";
            this.SpieltagePanel.Size = new System.Drawing.Size(476, 341);
            this.SpieltagePanel.TabIndex = 1;
            // 
            // btn_SpieltageSpeichern
            // 
            this.btn_SpieltageSpeichern.Location = new System.Drawing.Point(511, 311);
            this.btn_SpieltageSpeichern.Margin = new System.Windows.Forms.Padding(10);
            this.btn_SpieltageSpeichern.Name = "btn_SpieltageSpeichern";
            this.btn_SpieltageSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btn_SpieltageSpeichern.TabIndex = 2;
            this.btn_SpieltageSpeichern.Text = "Speichern";
            this.btn_SpieltageSpeichern.UseVisualStyleBackColor = true;
            this.btn_SpieltageSpeichern.Visible = false;
            this.btn_SpieltageSpeichern.Click += new System.EventHandler(this.btn_SpieltageSpeichern_Click);
            // 
            // btn_deleteSpieltage
            // 
            this.btn_deleteSpieltage.AutoSize = true;
            this.btn_deleteSpieltage.Location = new System.Drawing.Point(364, 6);
            this.btn_deleteSpieltage.Name = "btn_deleteSpieltage";
            this.btn_deleteSpieltage.Size = new System.Drawing.Size(112, 23);
            this.btn_deleteSpieltage.TabIndex = 8;
            this.btn_deleteSpieltage.Text = "Spieltage löschen";
            this.btn_deleteSpieltage.UseVisualStyleBackColor = true;
            this.btn_deleteSpieltage.Visible = false;
            this.btn_deleteSpieltage.Click += new System.EventHandler(this.btn_deleteSpieltage_Click);
            // 
            // btn_addSpieltag
            // 
            this.btn_addSpieltag.AutoSize = true;
            this.btn_addSpieltag.Location = new System.Drawing.Point(482, 6);
            this.btn_addSpieltag.Name = "btn_addSpieltag";
            this.btn_addSpieltag.Size = new System.Drawing.Size(112, 23);
            this.btn_addSpieltag.TabIndex = 7;
            this.btn_addSpieltag.Text = "Spieltag hinzufügen";
            this.btn_addSpieltag.UseVisualStyleBackColor = true;
            this.btn_addSpieltag.Visible = false;
            this.btn_addSpieltag.Click += new System.EventHandler(this.btn_addSpieltag_Click);
            // 
            // TabSaisons
            // 
            this.TabSaisons.Controls.Add(this.SaisonFokusPanel);
            this.TabSaisons.Controls.Add(this.btn_addSaison);
            this.TabSaisons.Controls.Add(this.cb_Saisons);
            this.TabSaisons.Location = new System.Drawing.Point(4, 22);
            this.TabSaisons.Margin = new System.Windows.Forms.Padding(0);
            this.TabSaisons.Name = "TabSaisons";
            this.TabSaisons.Size = new System.Drawing.Size(604, 379);
            this.TabSaisons.TabIndex = 2;
            this.TabSaisons.Text = "Saisons";
            this.TabSaisons.UseVisualStyleBackColor = true;
            // 
            // SaisonFokusPanel
            // 
            this.SaisonFokusPanel.Controls.Add(this.SaisonPanel);
            this.SaisonFokusPanel.Controls.Add(this.btn_SaisonSpeichern);
            this.SaisonFokusPanel.Location = new System.Drawing.Point(8, 35);
            this.SaisonFokusPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SaisonFokusPanel.Name = "SaisonFokusPanel";
            this.SaisonFokusPanel.Size = new System.Drawing.Size(593, 341);
            this.SaisonFokusPanel.TabIndex = 6;
            this.SaisonFokusPanel.Validating += new System.ComponentModel.CancelEventHandler(this.FokusPanel_Validating);
            // 
            // SaisonPanel
            // 
            this.SaisonPanel.Controls.Add(this.lbl_AnzahlAbsteiger);
            this.SaisonPanel.Controls.Add(this.tb_AnzahlAbsteiger);
            this.SaisonPanel.Controls.Add(this.lbl_AnzahlAufsteiger);
            this.SaisonPanel.Controls.Add(this.tb_AnzahlAufsteiger);
            this.SaisonPanel.Controls.Add(this.lbl_Liga);
            this.SaisonPanel.Controls.Add(this.tb_Liga);
            this.SaisonPanel.Controls.Add(this.lbl_SaisonName);
            this.SaisonPanel.Controls.Add(this.tb_SaisonName);
            this.SaisonPanel.Location = new System.Drawing.Point(0, 0);
            this.SaisonPanel.Name = "SaisonPanel";
            this.SaisonPanel.Size = new System.Drawing.Size(476, 341);
            this.SaisonPanel.TabIndex = 1;
            // 
            // lbl_AnzahlAbsteiger
            // 
            this.lbl_AnzahlAbsteiger.AutoSize = true;
            this.lbl_AnzahlAbsteiger.Location = new System.Drawing.Point(3, 87);
            this.lbl_AnzahlAbsteiger.Name = "lbl_AnzahlAbsteiger";
            this.lbl_AnzahlAbsteiger.Size = new System.Drawing.Size(51, 13);
            this.lbl_AnzahlAbsteiger.TabIndex = 7;
            this.lbl_AnzahlAbsteiger.Text = "Absteiger";
            // 
            // tb_AnzahlAbsteiger
            // 
            this.tb_AnzahlAbsteiger.Location = new System.Drawing.Point(63, 84);
            this.tb_AnzahlAbsteiger.MaxLength = 2;
            this.tb_AnzahlAbsteiger.Name = "tb_AnzahlAbsteiger";
            this.tb_AnzahlAbsteiger.ReadOnly = true;
            this.tb_AnzahlAbsteiger.Size = new System.Drawing.Size(20, 20);
            this.tb_AnzahlAbsteiger.TabIndex = 6;
            this.tb_AnzahlAbsteiger.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // lbl_AnzahlAufsteiger
            // 
            this.lbl_AnzahlAufsteiger.AutoSize = true;
            this.lbl_AnzahlAufsteiger.Location = new System.Drawing.Point(3, 61);
            this.lbl_AnzahlAufsteiger.Name = "lbl_AnzahlAufsteiger";
            this.lbl_AnzahlAufsteiger.Size = new System.Drawing.Size(54, 13);
            this.lbl_AnzahlAufsteiger.TabIndex = 5;
            this.lbl_AnzahlAufsteiger.Text = "Aufsteiger";
            // 
            // tb_AnzahlAufsteiger
            // 
            this.tb_AnzahlAufsteiger.Location = new System.Drawing.Point(63, 58);
            this.tb_AnzahlAufsteiger.MaxLength = 2;
            this.tb_AnzahlAufsteiger.Name = "tb_AnzahlAufsteiger";
            this.tb_AnzahlAufsteiger.ReadOnly = true;
            this.tb_AnzahlAufsteiger.Size = new System.Drawing.Size(20, 20);
            this.tb_AnzahlAufsteiger.TabIndex = 4;
            this.tb_AnzahlAufsteiger.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // lbl_Liga
            // 
            this.lbl_Liga.AutoSize = true;
            this.lbl_Liga.Location = new System.Drawing.Point(3, 32);
            this.lbl_Liga.Name = "lbl_Liga";
            this.lbl_Liga.Size = new System.Drawing.Size(27, 13);
            this.lbl_Liga.TabIndex = 3;
            this.lbl_Liga.Text = "Liga";
            // 
            // tb_Liga
            // 
            this.tb_Liga.Location = new System.Drawing.Point(63, 29);
            this.tb_Liga.MaxLength = 1;
            this.tb_Liga.Name = "tb_Liga";
            this.tb_Liga.ReadOnly = true;
            this.tb_Liga.Size = new System.Drawing.Size(20, 20);
            this.tb_Liga.TabIndex = 2;
            this.tb_Liga.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // lbl_SaisonName
            // 
            this.lbl_SaisonName.AutoSize = true;
            this.lbl_SaisonName.Location = new System.Drawing.Point(3, 6);
            this.lbl_SaisonName.Name = "lbl_SaisonName";
            this.lbl_SaisonName.Size = new System.Drawing.Size(35, 13);
            this.lbl_SaisonName.TabIndex = 1;
            this.lbl_SaisonName.Text = "Name";
            // 
            // tb_SaisonName
            // 
            this.tb_SaisonName.Location = new System.Drawing.Point(63, 3);
            this.tb_SaisonName.Name = "tb_SaisonName";
            this.tb_SaisonName.ReadOnly = true;
            this.tb_SaisonName.Size = new System.Drawing.Size(100, 20);
            this.tb_SaisonName.TabIndex = 0;
            this.tb_SaisonName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // btn_SaisonSpeichern
            // 
            this.btn_SaisonSpeichern.Location = new System.Drawing.Point(511, 311);
            this.btn_SaisonSpeichern.Margin = new System.Windows.Forms.Padding(10);
            this.btn_SaisonSpeichern.Name = "btn_SaisonSpeichern";
            this.btn_SaisonSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btn_SaisonSpeichern.TabIndex = 2;
            this.btn_SaisonSpeichern.Text = "Speichern";
            this.btn_SaisonSpeichern.UseVisualStyleBackColor = true;
            this.btn_SaisonSpeichern.Visible = false;
            this.btn_SaisonSpeichern.Click += new System.EventHandler(this.btn_SaisonSpeichern_Click);
            // 
            // btn_addSaison
            // 
            this.btn_addSaison.AutoSize = true;
            this.btn_addSaison.Location = new System.Drawing.Point(482, 6);
            this.btn_addSaison.Name = "btn_addSaison";
            this.btn_addSaison.Size = new System.Drawing.Size(112, 23);
            this.btn_addSaison.TabIndex = 5;
            this.btn_addSaison.Text = "Saison hinzufügen";
            this.btn_addSaison.UseVisualStyleBackColor = true;
            this.btn_addSaison.Visible = false;
            this.btn_addSaison.Click += new System.EventHandler(this.btn_addSaison_Click);
            // 
            // cb_Saisons
            // 
            this.cb_Saisons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Saisons.DropDownWidth = 342;
            this.cb_Saisons.FormattingEnabled = true;
            this.cb_Saisons.Location = new System.Drawing.Point(8, 8);
            this.cb_Saisons.MaxDropDownItems = 15;
            this.cb_Saisons.Name = "cb_Saisons";
            this.cb_Saisons.Size = new System.Drawing.Size(342, 21);
            this.cb_Saisons.TabIndex = 0;
            this.cb_Saisons.SelectedIndexChanged += new System.EventHandler(this.cb_Saisons_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 341);
            this.panel2.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 311);
            this.button3.Margin = new System.Windows.Forms.Padding(10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Speichern";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 341);
            this.panel3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 311);
            this.button1.Margin = new System.Windows.Forms.Padding(10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // Mainframe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(632, 449);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "Mainframe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kickerliga";
            this.Load += new System.EventHandler(this.Mainframe_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainframe_FormClosing);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.TabTabelle.ResumeLayout(false);
            this.TabTabelle.PerformLayout();
            this.TabPaarungen.ResumeLayout(false);
            this.TabPaarungen.PerformLayout();
            this.PaarungenFokusPanel.ResumeLayout(false);
            this.TabSpieltage.ResumeLayout(false);
            this.TabSpieltage.PerformLayout();
            this.SpieltageFokusPanel.ResumeLayout(false);
            this.TabSaisons.ResumeLayout(false);
            this.TabSaisons.PerformLayout();
            this.SaisonFokusPanel.ResumeLayout(false);
            this.SaisonPanel.ResumeLayout(false);
            this.SaisonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LesemodusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BearbeitermodusToolStripMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabTabelle;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader ch_Spieler;
        private System.Windows.Forms.ColumnHeader ch_Spiele;
        private System.Windows.Forms.ColumnHeader ch_Tore;
        private System.Windows.Forms.ColumnHeader ch_Gegentore;
        private System.Windows.Forms.ColumnHeader ch_Differenz;
        private System.Windows.Forms.ColumnHeader ch_Punkte;
        private System.Windows.Forms.ColumnHeader ch_Platz;
        private System.Windows.Forms.TabPage TabPaarungen;
        private System.Windows.Forms.Panel PaarungenPanel;
        private System.Windows.Forms.ComboBox cb_Spieltage;
        private System.Windows.Forms.Button btn_PaarungenSpeichern;
        private System.Windows.Forms.Panel PaarungenFokusPanel;
        private System.Windows.Forms.Button btn_addPaarung;
        private System.Windows.Forms.ToolStripMenuItem tabelleJPGToolStripMenuItem;
        private System.Windows.Forms.Button btn_deletePaarungen;
        private System.Windows.Forms.ToolStripMenuItem neuerSpielerToolStripMenuItem;
        private System.Windows.Forms.TabPage TabSaisons;
        private System.Windows.Forms.ComboBox cb_Saisons;
        private System.Windows.Forms.Button btn_addSaison;
        private System.Windows.Forms.Panel SaisonFokusPanel;
        private System.Windows.Forms.Panel SaisonPanel;
        private System.Windows.Forms.Button btn_SaisonSpeichern;
        private System.Windows.Forms.TextBox tb_SaisonName;
        private System.Windows.Forms.Label lbl_SaisonName;
        private System.Windows.Forms.Label lbl_Liga;
        private System.Windows.Forms.TextBox tb_Liga;
        private System.Windows.Forms.TextBox tb_AnzahlAufsteiger;
        private System.Windows.Forms.Label lbl_AnzahlAufsteiger;
        private System.Windows.Forms.TextBox tb_AnzahlAbsteiger;
        private System.Windows.Forms.Label lbl_AnzahlAbsteiger;
        private System.Windows.Forms.TabPage TabSpieltage;
        private System.Windows.Forms.Button btn_deleteSpieltage;
        private System.Windows.Forms.Button btn_addSpieltag;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel SpieltageFokusPanel;
        private System.Windows.Forms.Panel SpieltagePanel;
        private System.Windows.Forms.Button btn_SpieltageSpeichern;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;

    }
}

