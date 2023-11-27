using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using YahooFinanceApi;

namespace UPPMigrated
{
    internal static class Plotter
    {
        public static PlotModel GetCandlesPlotModel(IReadOnlyList<Candle> history)
        {
            PlotModel pm = new PlotModel();
            List<HighLowItem> items = new List<HighLowItem>();
            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;

            double minValue = Double.MaxValue;
            double maxValue = Double.MinValue;

            foreach (var candle in history)
            {
                if(candle.DateTime > maxDate)
                    maxDate = candle.DateTime;
                if(candle.DateTime < minDate)
                    minDate = candle.DateTime;

                if((double)candle.High > maxValue)
                    maxValue = (double)candle.High;
                if((double)candle.Low < minValue)
                    minValue = (double)candle.Low;

                items.Add(new HighLowItem(DateTimeAxis.ToDouble(candle.DateTime), (double)candle.High, (double)candle.Low, (double)candle.Open, (double)candle.Close));
            }

            CandleStickSeries series = new CandleStickSeries
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

            
            pm.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = DateTimeAxis.ToDouble(minDate.AddDays(-1)), Maximum = DateTimeAxis.ToDouble(maxDate.AddDays(1)), StringFormat = "M/d" });
            pm.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = minValue - 5, Maximum = maxValue + 5 });
            pm.Series.Add(series);

            return pm;
        }
    }
}
