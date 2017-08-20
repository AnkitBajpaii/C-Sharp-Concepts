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
using System.Windows.Threading;

namespace BackgroundWorkerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool _shouldUserReportProgress = false;
        string _loadingStatus = string.Empty;

        public bool ShouldUserReportProgress
        {
            get
            {
                return _shouldUserReportProgress;
            }

            set
            {
                _shouldUserReportProgress = value;
            }
        }
        public string LoadingStatus
        {
            get
            {
                return _loadingStatus;
            }

            set
            {
                _loadingStatus = value;
                RaisePropertyChanged("LoadingStatus");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnDoSynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            int max = 10000;
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();
            LoadingStatus = "Loading...";

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

            LoadingStatus = "Completed";
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + counter);
        }

        private void btnDoAsynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            BackgroundWorker _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;

            if (ShouldUserReportProgress)
            {
                _worker.WorkerReportsProgress = true;
                _worker.ProgressChanged += _worker_ProgressChanged;
                LoadingStatus = "Loading via ReportProgress";
            }
            else
                LoadingStatus = "Loading via Dispatcher";

            _worker.RunWorkerAsync(10000);
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadingStatus = "Completed";
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
                    if (ShouldUserReportProgress)
                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                    else
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => { pbCalculationProgress.Value = progressPercentage; lbResults.Items.Add(i); }), DispatcherPriority.Background, null);

                }
                else
                {
                    if (ShouldUserReportProgress)
                        (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    else
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => { pbCalculationProgress.Value = progressPercentage; }), DispatcherPriority.Background, null);
                }

                System.Threading.Thread.Sleep(1);
            }

            e.Result = counter;
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Value = e.ProgressPercentage;

            if (e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        #endregion

    }
}
