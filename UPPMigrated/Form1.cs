using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.Axes;
using UPPMigrated.Entities;
using YahooFinanceApi;

namespace UPPMigrated
{
    public partial class Form1 : Form
    {
        User? user;
        DateTime startDate = DateTime.Now.AddMonths(-1);
        DateTime endDate = DateTime.Now;
        public Form1(User? user)
        {
            InitializeComponent();
            this.user = user;
            PrintUser();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                FormAddBalance formAddBalance = new FormAddBalance();
                formAddBalance.ShowDialog();
                using (ApplicationContext db = new ApplicationContext())
                {
                    user.Balance += formAddBalance.summ;
                    db.Users.Update(user);
                    db.SaveChanges();
                    label1.Text = $"{user.Balance} у.е.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPortfolio formPortfolio = new FormPortfolio();
            Hide();
            formPortfolio.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormShares formShares = new FormShares();
            Hide();
            formShares.ShowDialog();
            Show();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateAccount createAccount = new FormCreateAccount();
            createAccount.ShowDialog();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOpenAccount openAccount = new FormOpenAccount();
            openAccount.ShowDialog();
            user = openAccount.user;
            if (user != null)
            {
                PrintUser();
            }

        }

        private void PrintUser()
        {
            label5.Text = user.Name;
            label1.Text = $"{Math.Round(user.Balance, 2)} у.е.";
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var history = await Yahoo.GetHistoricalAsync(listBox1.SelectedItem.ToString(), startDate, endDate, Period.Daily);

            plotView1.Model = Plotter.GetCandlesPlotModel(history);
            plotView1.Refresh();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (domainUpDown1.SelectedItem.ToString())
            {
                case "День":
                    startDate = DateTime.Now.AddDays(-1);
                    break;
                case "Неделя":
                    startDate = DateTime.Now.AddDays(-7);
                    break;
                case "Месяц":
                    startDate = DateTime.Now.AddMonths(-1);
                    break;
                case "3 Месяца":
                    startDate = DateTime.Now.AddMonths(-3);
                    break;
                case "6 Месяцев":
                    startDate = DateTime.Now.AddMonths(-6);
                    break;
                case "Год":
                    startDate = DateTime.Now.AddYears(-1);
                    break;
                case "За все время":
                    startDate = DateTime.Now.AddYears(-10);
                    break;
            }

            listBox1_SelectedIndexChanged(sender, e);
        }
    }
}
