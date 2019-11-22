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
    public partial class FormUsers : Form
    {
        ServicesFile services;
        public FormUsers()
        {
            InitializeComponent();
            dataGridView_Users.Select();
            dataGridView_Users.Focus();
        }

        public FormUsers(ServicesFile services)
        {
            InitializeComponent();
            this.services = services;

        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var bindingList = new BindingList<myUser>(services.myUsersList);
            var source = new BindingSource(bindingList, null);
            dataGridView_Users.DataSource = source;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new FormAddUser(services).ShowDialog(this);
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_Users.SelectedRows.Count == 1)
            {
                //  myUser curUser = services.FindUser(dataGridView_Users.CurrentRow.Cells[2].ToString());
                myUser curUser = services.GetUser(dataGridView_Users.CurrentRow.Index);
                if (curUser.IsAdmin())
                {
                    MessageBox.Show(this, "Администратора удалять нельзя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               // if (MessageBox.Show(this, "Удалить пользователя " + curUser.Login + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
              //  {
                    services.myUsersList.RemoveAt(dataGridView_Users.CurrentRow.Index);
               // }
            }
            LoadData();
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_Users_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView_Users_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (dataGridView_Users.SelectedRows.Count == 1)
            {
                string log = (dataGridView_Users.SelectedRows[0].Cells[0].Value).ToString();
                myUser user = services.FindUser(log);

                new FormSetLim(services,user).ShowDialog(this);
            }
        }
    }
}
