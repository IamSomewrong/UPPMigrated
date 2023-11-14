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

namespace UPPMigrated
{
    public partial class Form1 : Form
    {
        PlotModel pm;
        CandleStickSeries series;
        List<HighLowItem> items = new List<HighLowItem> { new HighLowItem(DateTimeAxis.ToDouble(new DateTime(2023, 11, 9)), 0, 5, 1, 4)};
        public Form1()
        {
            InitializeComponent();
            pm = new PlotModel();

            var startDate = DateTime.Now.AddDays(-10);
            var endDate = DateTime.Now;

            var minValue = DateTimeAxis.ToDouble(startDate);
            var maxValue = DateTimeAxis.ToDouble(endDate);

            pm.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = minValue, Maximum = maxValue, StringFormat = "M/d" });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, Maximum = 10 });

            var series = new CandleStickSeries
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

            pm.Series.Add(series);
            plotView1.Model = pm;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPortfolio formPortfolio = new FormPortfolio();
            this.Hide();
            formPortfolio.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormShares formShares = new FormShares();
            this.Hide();
            formShares.ShowDialog();
            this.Show();
        }
    }
}
