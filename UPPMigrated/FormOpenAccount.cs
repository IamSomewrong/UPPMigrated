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
            using(ApplicationContext db =  new ApplicationContext())
            {
                List<User> users = db.Users.ToList();
                if (users.Exists(x => x.Name == textBox1.Text))
                {
                    user = users.Find(x => x.Name == textBox1.Text);
                    Close();
                }
                else
                    MessageBox.Show("Пользователя с таким именем не существует.", "Ошибка");
            }
        }
    }
}
