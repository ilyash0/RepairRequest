using RepairRequest.Models;
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

namespace RepairRequest.Views
{
    /// <summary>
    /// Interaction logic for SparePartRequestListPage.xaml
    /// </summary>
    public partial class SparePartRequestListPage : Page
    {
        private readonly int _requestId;
        public SparePartRequestListPage(int requestId)
        {
            InitializeComponent();
            _requestId = requestId;
            sparePartsList.ItemsSource = ViewModel.GetSparePartRequestsForView(_requestId);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new RequestListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new SparePartRequestEditPage(_requestId));
        }

        private void sparePartsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((ListBox)sender).SelectedItem is SparePartRequest sparePartRequest)
            {
                FrameContext.MainWindowFrame.Navigate(new SparePartRequestEditPage(sparePartRequest));
            }
        }
    }
}
