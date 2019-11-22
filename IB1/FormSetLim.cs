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
    public partial class FormSetLim : Form
    {
        public ServicesFile services;
        myUser user;
        public FormSetLim(ServicesFile services, myUser user)
        {
            InitializeComponent();
            this.services = services;
            this.user = user;
        }

        private void FormSetLim_Load(object sender, EventArgs e)
        {
            textBox_Login.Text = user.Login;
            checkBox_Block.Checked = user.Blocked;
            numericUpDown_Limit.Value = user.LengthPassword;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            myUser newUser = services.FindUser(user.Login);
            newUser.Blocked = checkBox_Block.Checked;
            newUser.LengthPassword =Convert.ToInt32( numericUpDown_Limit.Value);
            Close();
        }
    }
}
