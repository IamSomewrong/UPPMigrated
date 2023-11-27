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
        PlotModel pm;
        CandleStickSeries series;
        List<HighLowItem> items = new List<HighLowItem>();
        DateTime startDate = DateTime.Now.AddDays(-10);
        DateTime endDate = DateTime.Now;
        public Form1()
        {
            InitializeComponent();

            pm = new PlotModel();

            var minValue = DateTimeAxis.ToDouble(startDate);
            var maxValue = DateTimeAxis.ToDouble(endDate);

            pm.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = minValue, Maximum = maxValue, StringFormat = "M/d" });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 100, Maximum = 200 });
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
                label5.Text = user.Name;
                label1.Text = $"{user.Balance} у.е.";
            }

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var history = await Yahoo.GetHistoricalAsync("AAPL", startDate, endDate, Period.Daily);
            items.Clear();
            foreach (var candle in history)
            {
                items.Add(new HighLowItem(DateTimeAxis.ToDouble(candle.DateTime), (double)candle.High, (double)candle.Low, (double)candle.Open, (double)candle.Close));
            }

            series = new CandleStickSeries
            {
                Color = OxyColors.Black,
                IncreasingColor = OxyColors.DarkGreen,
                DecreasingColor = OxyColors.Red,
                DataFieldX = "QTime",
                DataFieldHigh = "H",
                DataFieldLow = "L",
                DataFieldOpen = "O",
                DataFieldClose = "C",
                TrackerFormatString = "High: {3:0.00}\nLow: {4:0.00}\nOpen: {5:0.00}\nClose: {6:0.00}\nAsOf:{2:yyyy-MM-dd}",
                ItemsSource = items
            };

            pm.Series.Clear();
            pm.Series.Add(series);
            plotView1.Model = pm;
            plotView1.Update();
            plotView1.Refresh();
        }
    }
}
