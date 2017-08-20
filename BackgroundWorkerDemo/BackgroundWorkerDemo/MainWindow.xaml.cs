using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackgroundWorkerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDoSynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            int max = 10000;
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();
            txtBlckLoadingStatus.Text = "Loading...";

            int counter = 0;
            for (int i = 0; i < max; i++)
            {
                if (i % 42 == 0)
                {
                    lbResults.Items.Add(i);
                    counter++;
                }

                System.Threading.Thread.Sleep(1);

                pbCalculationProgress.Value = Convert.ToInt32(((double)i / max) * 100);
            }

            txtBlckLoadingStatus.Text = "Completed";
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + counter);
        }

        private void btnDoAsynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();
            txtBlckLoadingStatus.Text = "Loading...";

            BackgroundWorker _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerAsync(10000);
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Value = e.ProgressPercentage;

            if (e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtBlckLoadingStatus.Text = "Completed";
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + e.Result);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = Int32.Parse(e.Argument.ToString());

            int counter = 0;
            for (int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % 42 == 0)
                {
                    counter++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);

                System.Threading.Thread.Sleep(1);
            }

            e.Result = counter;
        }
    }
}
