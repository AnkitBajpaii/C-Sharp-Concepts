using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

namespace MutithreadingDemo01
{
    public class Sample : BindableBase
    {
        string message;
        public string Message
        {
            get => message;
            set
            {
                SetProperty(ref message, value);
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        Sample _sample;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropChanged([CallerMemberName]string propertyName = null)
        {
             if(PropertyChanged != null && !String.IsNullOrEmpty(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Sample SampleObj
        {
            get => _sample;
            set
            {
                _sample = value;
                RaisePropChanged(nameof(SampleObj));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SampleObj = new Sample();
            SampleObj.Message = "Default Message";
//            tbMessage.Text = "Default Message";
        }

        private void btnDoTimeConsumingWork_Click(object sender, RoutedEventArgs e)
        {
            //Without multithreading
            //DoTimeConsumignWork();

            //With multithreading
            Thread workerThread = new Thread(DoTimeConsumignWork);
            workerThread.Start();
        }

        private void DoTimeConsumignWork()
        {
            ////tbMessage.Text = "Doing time consuming work"; 
            SampleObj.Message = "Doing time consuming work";
            Thread.Sleep(5000);
            SampleObj.Message = "Completed time consuming work";
            
        }

        private void btnPrintNum_Click(object sender, RoutedEventArgs e)
        {
            SampleObj.Message = "Printing numbers:";
            //tbMessage.Text = "Printing numbers:";
            for (int i = 0; i<=10; i++)
            {
                listBox.Items.Add(i);
            }
        }
    }
}
