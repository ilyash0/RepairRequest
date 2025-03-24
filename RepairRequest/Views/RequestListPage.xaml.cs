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
    /// Interaction logic for RequestListPage.xaml
    /// </summary>
    public partial class RequestListPage : Page
    {
        public RequestListPage()
        {
            InitializeComponent();
            requestsList.ItemsSource = ViewModel.GetRequestsForView();
            textBoxAvgTime.Text += $"{ViewModel.AverageCompletionTime().Days} дн. " +
                $"{ViewModel.AverageCompletionTime().Hours} ч. " +
                $"{ViewModel.AverageCompletionTime().Minutes} мин.";
        }

        private void NewRequest_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new RequestEditPage());
        }

        private void requestsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((ListBox)sender).SelectedItem is Request request)
            {
                FrameContext.MainWindowFrame.Navigate(new RequestEditPage(request));
            }
        }

        private void SparePartsList_Click(object sender, RoutedEventArgs e)
        {
            if (requestsList.SelectedItem is Request request)
            {
                FrameContext.MainWindowFrame.Navigate(new SparePartListPage(request.RequestId));
            }
        }
    }
}
