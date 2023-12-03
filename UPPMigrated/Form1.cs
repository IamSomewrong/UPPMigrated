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
using Flurl.Util;

namespace UPPMigrated
{
    public partial class Form1 : Form
    {
        User? user;
        Dictionary<User?, Dictionary<string, int>> pack;
        DateTime startDate = DateTime.Now.AddMonths(-1);
        DateTime endDate = DateTime.Now;
        public Form1(User? user)
        {
            InitializeComponent();
            this.user = user;
            pack = new Dictionary<User?, Dictionary<string, int>>();
            CreateDict();
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
            FormLogin openAccount = new FormLogin();
            openAccount.ShowDialog();
            user = openAccount.user;
            CreateDict();
            if (user != null)
            {
                PrintUser();
            }

        }

        private void PrintUser()
        {
            label5.Text = user.Name;
            label1.Text = $"{Math.Round(user.Balance, 2)} у.е.";
            listBox1.SelectedIndex = -1;
            label3.Text = "0 шт.";
            label6.Text = "0 у.е.";
        }

        private void CreateDict()
        {
            if(user != null)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (var item in listBox1.Items)
                {
                    dict.Add(item.ToString(), 0);
                }
                pack.Add(user, dict);
            }
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                var history = await Yahoo.GetHistoricalAsync(listBox1.SelectedItem.ToString(), startDate, endDate, Period.Daily);

                label2.Text = listBox1.SelectedItem.ToString();
                label3.Text = pack[user][label2.Text].ToString() + " шт.";
                label6.Text = Math.Round
                        (pack[user][label2.Text] * (double)history.Last().High, 2).ToString() + " у.е.";

                plotView1.Model = Plotter.GetCandlesPlotModel(history);
                plotView1.Refresh();
            }

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

        private async void button1_Click_1(object sender, EventArgs e)
        {
            var history = await Yahoo.GetHistoricalAsync(listBox1.SelectedItem.ToString(), DateTime.Now.AddDays(-1), endDate, Period.Daily);

            int stock = 0;
            int.TryParse(textBox1.Text, out stock);
            double sum = 0;

            foreach (var candle in history)
                sum = (double)candle.High * stock;

            if(user.Balance - sum < 0)
                MessageBox.Show("Не хватает денег.", "Ошибка");
            else
            {
                user.Balance -= sum;
                label1.Text = Math.Round(user.Balance, 2).ToString();

                pack[user][listBox1.SelectedItem.ToString()] += stock;
                label3.Text = pack[user][label2.Text].ToString() + " шт.";
                /*string temp = label3.Text.Split(' ')[0];
                temp = (int.Parse(temp) + stock).ToString();
                label3.Text = temp + " шт.";
*/
                label6.Text = Math.Round
                    (pack[user][label2.Text] * (double)history[0].High, 2).ToString() + " у.е.";
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            var history = await Yahoo.GetHistoricalAsync(listBox1.SelectedItem.ToString(), DateTime.Now.AddDays(-1), endDate, Period.Daily);

            int stock = 0;
            int.TryParse(textBox1.Text, out stock);
            double sum = 0;

            if (pack[user][label2.Text] < stock)
                MessageBox.Show("Не хватает акций.", "Ошибка");
            else
            {
                sum = stock * (double)history[0].High;
                user.Balance += sum;
                label1.Text = Math.Round(user.Balance, 2).ToString();

                pack[user][listBox1.SelectedItem.ToString()] -= stock;
                label3.Text = pack[user][label2.Text].ToString() + " шт.";
                /*string temp = label3.Text.Split(' ')[0];
                temp = (int.Parse(temp) - stock).ToString();
                label3.Text = temp + " шт.";*/

                label6.Text = Math.Round
                    (pack[user][label2.Text] * (double)history[0].High, 2).ToString() + " у.е.";
            }

        }
    }
}
