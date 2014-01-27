using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathSeries;

namespace Graph
{
    static class Program
    {
        private static void GraphPartialSums(Chart chart)
        {
            // The graphs auto-scale so when you run them all together, some of the smaller ones get squashed.
            // Comment out the ones you don't want to see to isolate the graphs.

            chart.GraphSeries("euler", PartialSums.Euler(100));
            //chart.GraphSeries("geometric", PartialSums.Geometric(100));
            //chart.GraphSeries("grandi", PartialSums.Grandi(100));
            //chart.GraphSeries("grandi-cesaro", PartialSums.GrandiCesaro(100));
            //chart.GraphSeries("alternating", PartialSums.Alternating(100));
            //chart.GraphSeries("alternating-cesaro", PartialSums.Alternating(100));
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form
            {
                ClientSize = new Size(789, 372),
                AutoScaleDimensions = new SizeF(6F, 13F)
            };
            var chart = new Chart {Size = new Size(789, 372)};
            chart.Legends.Add("series");
            chart.ChartAreas.Add(new ChartArea("series"));
            form.Controls.Add(chart);
            form.Load += (sender, args) => GraphPartialSums(chart);
            Application.Run(form);
        }

        private static void GraphSeries(this Chart chart, string name, IEnumerable<SeriesTerm> dataPoints)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = SeriesChartType.Line;
            foreach (var point in dataPoints.Select(ToDataPoint))
            {
                chart.Series[name].Points.Add(point);
            }
            chart.Series[name].BorderWidth = 3;
        }

        private static DataPoint ToDataPoint(this SeriesTerm term)
        {
            return new DataPoint(term.Index, term.Value);
        }
    }
}
