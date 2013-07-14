using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Kickerliga
{
    public partial class Passworteingabe : Form
    {
        private byte[] passwortMD5 = new byte[16];

        public Passworteingabe()
        {
            InitializeComponent();
            passwortMD5[0] = 37;
            passwortMD5[1] = 80;
            passwortMD5[2] = 254;
            passwortMD5[3] = 224;
            passwortMD5[4] = 224;
            passwortMD5[5] = 107;
            passwortMD5[6] = 217;
            passwortMD5[7] = 118;
            passwortMD5[8] = 14;
            passwortMD5[9] = 58;
            passwortMD5[10] = 156;
            passwortMD5[11] = 139;
            passwortMD5[12] = 142;
            passwortMD5[13] = 49;
            passwortMD5[14] = 30;
            passwortMD5[15] = 193;
        }

        private void btn_PasswortOk_Click(object sender, EventArgs e)
        {
            if (checkPassword())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Falsches Passwort", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool checkPassword()
        {
            bool equal = true;
            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(tb_Passwort.Text);
            bytes = md5csp.ComputeHash(bytes);
            if (bytes.Length != passwortMD5.Length)
            {
                equal = false;
            }
            else
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] != passwortMD5[i])
                    {
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }
    }
}
