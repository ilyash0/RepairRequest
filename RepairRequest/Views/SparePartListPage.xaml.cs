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
    /// Interaction logic for SparePartListPage.xaml
    /// </summary>
    public partial class SparePartListPage : Page
    {
        public SparePartListPage(int requestId)
        {
            InitializeComponent();
            sparePartsList.ItemsSource = ViewModel.GetSparePartRequestsForView(requestId);
        }

        private void RequestList_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new RequestListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new SparePartEditPage());
        }

        private void sparePartsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((ListBox)sender).SelectedItem is SparePartRequest sparePartRequest)
            {
                FrameContext.MainWindowFrame.Navigate(new SparePartEditPage(sparePartRequest.SparePart));
            }
        }
    }
}
