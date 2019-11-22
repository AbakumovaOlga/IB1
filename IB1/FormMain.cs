using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB1
{
    public partial class FormMain : Form
    {
        private ServicesFile services = new ServicesFile();
        myUser currentUser;
        public FormMain()
        {
            InitializeComponent();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsers(services).Show();
        }

        private void button_ChangePwd_Click(object sender, EventArgs e)
        {
            new FormChangePwd(services.currentUser).ShowDialog(this);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormPassFrase passPhraseForm = new FormPassFrase();
            passPhraseForm.ShowDialog(this);

            string passFrase = passPhraseForm.passFrase;
            if (passFrase == null || passFrase == "")
            {
                MessageBox.Show(this, "Не введена парольная фраза", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            services.passFrase = passFrase;
            try
            {
                services.LoadUsersFile();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Ошибка загрузки учетных данных пользователей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            if (services.FindUser(myUser.ADMIN) == null)
            {
                MessageBox.Show(this, "Не найден пользователь ADMIN. Парольная фраза неверная", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

           bool result = AuthenticateUser();
            if (!result)
            {
                Application.Exit();
                return;
            }
            LoadData();
        }

        private void LoadData()
        {
            usersToolStripMenuItem.Enabled = services.IsAdmin();
        }

        private bool AuthenticateUser()
        {
            string login = "";
            myUser user = null;
            bool authenticated = false;
            int wrongPasswordCount = 0;
            do
            {
                FormAuthent loginForm = new FormAuthent();
                loginForm.ShowDialog(this);
                if (loginForm.DialogResult != DialogResult.OK)
                {
                    MessageBox.Show(this, "Не пройдена аутентификация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                login = loginForm.login;
                string password = loginForm.password;

                user = services.FindUser(login);
                if (user == null)
                {
                    MessageBox.Show(this, "Не найден пользователь " + login, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    authenticated = false;
                }
                else if (user.Blocked)
                {
                    MessageBox.Show(this, "Пользователь " + login + " заблокирован", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    authenticated = false;
                }
                else if (user.IsEmptyPassword())
                {
                    FormChangePwd changeForm = new FormChangePwd();
                    changeForm.user = user;
                    changeForm.ShowDialog(this);
                }
                else
                {
                    authenticated = user.CheckHashPassword(password);
                    if (!authenticated)
                    {
                        MessageBox.Show(this, "Неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        wrongPasswordCount++;
                        if (wrongPasswordCount >= 3)
                            return false;
                    }
                }
            } while (user == null || !authenticated);

            services.currentUser = user;
            return true;
        }

        private bool RequestNewPassword(myUser user)
        {
            FormChangePwd changePasswordForm = new FormChangePwd(user);
            changePasswordForm.ShowDialog(this);
            return changePasswordForm.DialogResult == DialogResult.OK;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (services.currentUser == null)
                return;
            try
            {
                services.SaveUsersFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ошибка записи учетных данных пользователей в файл:\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormAbout().Show();
        }
    }
}
