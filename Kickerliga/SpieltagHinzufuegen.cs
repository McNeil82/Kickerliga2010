using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class SpieltagHinzufuegen : Form
    {
        private int saisonId = 0;

        public SpieltagHinzufuegen(int saisonId, int naechsterSpieltag, DateTime letztesDatum)
        {
            this.saisonId = saisonId;
            InitializeComponent();
            if (letztesDatum != DateTime.Today)
            {
                dtp_from.Value = letztesDatum.AddDays(3);
            }
            else
            {
                dtp_from.Value = letztesDatum;
            }
            berechneKalenderwoche();
            dtp_until.Value = dtp_from.Value.AddDays(4);
            tb_Spieltag.Text = naechsterSpieltag.ToString();
        }

        private void berechneKalenderwoche()
        {
            tb_weekday.Text = CultureInfo.CreateSpecificCulture("de-DE").Calendar.GetWeekOfYear(dtp_from.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            dtp_until.Value = dtp_from.Value.AddDays(4);
            berechneKalenderwoche();
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            string error = Spieltag.speichere(Convert.ToInt32(tb_Spieltag.Text), dtp_from.Value, dtp_until.Value, Convert.ToInt32(tb_weekday.Text), saisonId);
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
