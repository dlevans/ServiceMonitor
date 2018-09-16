using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace ServiceMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Timer refreshTimer = new Timer();
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Interval = 600000;
            refreshTimer.Enabled = true;
            this.RefreshTimer_Elapsed(null, null);
        }

        private void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                lblDate.Content = this.GetFormattedDateText();

                var events = Repository.GetDataFromApi();
               
                lbServiceItems.Items.Clear();
                foreach (var item in events)
                {
                    ServiceItem serviceItem = new ServiceItem(item);
                    lbServiceItems.Items.Add(serviceItem);
                }
            });
        }

        private string GetFormattedDateText()
        {
            int dayOfWeek = (int)DateTime.Now.DayOfWeek - 1;
            string dateText = DateTime.Now.ToString("dddd MMMM") + " " + dayOfWeek.ToString();

            switch (dayOfWeek)
            {
                case 1:
                case 21:
                case 31:
                    dateText += "st";
                    break;
                case 2:
                case 22:
                    dateText += "nd";
                    break;
                case 3:
                case 23:
                    dateText += "rd";
                    break;
                default:
                    dateText += "th";
                    break;
            }
            return dateText;
        }
    }     
}