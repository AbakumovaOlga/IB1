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
    public partial class FormAddUser : Form
    {
        ServicesFile services;
        public FormAddUser()
        {
            InitializeComponent();
        }

        public FormAddUser(ServicesFile services)
        {
            InitializeComponent();
            this.services = services;

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string login =textBox_Login.Text ;
            foreach(var myuser in services.myUsersList)
            {

                if (myuser.Login == login)
                {
                    MessageBox.Show(this, "Пользователь с таким имененм уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
                }

            }
            services.myUsersList.Add(new myUser(login));
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
