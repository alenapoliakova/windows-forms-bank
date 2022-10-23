using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace lab_1
{
    public partial class AuthorizationForm : Form
    {
        private List<byte[]> passwordHash = new();
        public bool status = false;
        private string adminHash;
        public AuthorizationForm()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            this.adminHash = "9v3/5IyQjesPTDvTbAMucg==";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "admin")
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
        
        private void addMD5Password(string login, string password)
        {
            string sSourceData = login + password;

            // Create a byte array from login + password
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            // Compute hash based on password
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            passwordHash.Add(tmpHash);
        }

        private bool checkPassword(string login, string password)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(login + password);
            byte[] tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            string userHash = System.Convert.ToBase64String(tmpNewHash);
            if (adminHash == userHash)
            {
                return true;
            }
            return false;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            var login = comboBox1.Text;
            var password = textBox1.Text;
            if (login.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("No valid data");
                return;
            }

            if (checkPassword(login, password))
            {
                status = true;
                MessageBox.Show("Authorization passed");
                this.Close();
            }
            else
            {
                status = false;
                MessageBox.Show("Try again");
            }
        }

        private void Form3_Load(object sender, EventArgs e) { }
    }
}
