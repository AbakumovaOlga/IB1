using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB1
{
    public partial class FormAuthent : Form
    {
        public string login;
        public string password;

        public FormAuthent()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            login = textBox_Login.Text;
            password = textBox_Pwd.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
