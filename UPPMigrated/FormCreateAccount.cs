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
    public partial class FormCreateAccount : Form
    {
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    Close();
                }  
            }
            
        }
    }
}
