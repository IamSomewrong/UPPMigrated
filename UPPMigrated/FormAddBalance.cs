using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPPMigrated
{
    public partial class FormAddBalance : Form
    {
        public double summ = 0;

        public FormAddBalance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                summ = Convert.ToDouble(textBox1.Text);
                Close();
            }
            catch { MessageBox.Show("Введено неккоректное число.", "Ошибка"); }
            
        }
    }
}
