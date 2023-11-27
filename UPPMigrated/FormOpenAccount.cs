using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UPPMigrated.Entities;

namespace UPPMigrated
{
    public partial class FormOpenAccount : Form
    {
        public User? user;

        public FormOpenAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = db.Users.ToList();
                if (users.Exists(x => x.Name == textBox1.Text))
                {
                    user = users.Find(x => x.Name == textBox1.Text);
                    FormOpen(user);
                }
                else
                    MessageBox.Show("Пользователя с таким именем не существует.", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = new User { Name = textBox1.Text, Balance = 0 };
                List<User> users = db.Users.ToList();
                if (users.Exists(x => x.Name == user.Name))
                    MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка");
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно создан.", "Успех");
                }
            }
        }

        private void FormOpen(User? user)
        {
            Form1 form = new Form1(user);
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
