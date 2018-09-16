using System;
using System.Collections.Generic;
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

namespace ServiceMonitor
{
    /// <summary>
    /// Interaction logic for ServiceItem.xaml
    /// </summary>
    public partial class ServiceItem : UserControl
    {
        public ServiceItem()
        {
            InitializeComponent();
        }

        public ServiceItem(ServiceItemDTO serviceItemDTO)
        {
            InitializeComponent();

            this.lblDisplayInfo.Content = "Time: " + serviceItemDTO.StartTime.ToString("hh:mm tt") + " - " + serviceItemDTO.EndTime.ToString("hh:mm tt") + "      " + "Organizer: " + serviceItemDTO.OrganizerName;
        }
    }
}
