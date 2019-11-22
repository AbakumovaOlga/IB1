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
    public partial class FormChangePwd : Form
    {
        public  myUser user;
        public FormChangePwd()
        {
            InitializeComponent();
        }

        public FormChangePwd(myUser user) : this()
        {
            InitializeComponent();
            this.user = user;
            if (user.IsEmptyPassword())
            {
                // Старого пароля нет
                textBox_OldPwd.Enabled = false;
            }
            else
            {
                textBox_OldPwd.Enabled = true;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            // Проверяем старый пароль
            if (!user.IsEmptyPassword())
            {
                if (!user.CheckHashPassword(textBox_OldPwd.Text))
                {
                    MessageBox.Show(this, "Неправильный старый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Проверяем новый пароль
            string newPassword = textBox_NewPwd.Text;
            string repeatPassword = textBox_RepPwd.Text;
            if (newPassword == null || newPassword == "")
            {
                MessageBox.Show(this, "Не введен новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (user.LimitPassword && !user.CheckPassword(newPassword, user.LengthPassword))
            {
                MessageBox.Show(this, "Пароль должен быть длинее " + user.LengthPassword, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword != repeatPassword)
            {
                MessageBox.Show(this, "Повторный пароль не совпадает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.SetNewPassword(newPassword);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormChangePwd_Load(object sender, EventArgs e)
        {
            if (user.IsEmptyPassword())
            {
                // Старого пароля нет
                textBox_OldPwd.Enabled = false;
            }
            else
            {
                textBox_OldPwd.Enabled = true;
            }
        }
    }
}
