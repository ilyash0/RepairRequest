using RepairRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RequestEditPage.xaml
    /// </summary>
    public partial class RequestEditPage : Page
    {
        private readonly Request _request;
        public RequestEditPage()
        {
            InitializeComponent();
            textBlockTitle.Text = "Новая заявка";
            _request = new Request(3, DateTime.Today);  // Статус заявки "Выполнена"
            Init();
        }

        public RequestEditPage(Request request)
        {
            InitializeComponent();
            _request = request;
            Init();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFilesValid())
            {
                MessageBox.Show("Все поля должны быть заполнены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Client? potentialClent = ViewModel.GetClientOtNullByPhoneNumber(txtClientPhoneNumber.Text);
            if (potentialClent != null && potentialClent.ClientId != _request.ClientId)
            {
                _request.ClientId = potentialClent.ClientId;
                MessageBox.Show($"Найден клиент с введёным номером. Клиент заменён на {potentialClent.ClientName}", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (potentialClent == null && _request.Client == null)
            {
                Client _client = new Client(txtClientName.Text, txtClientPhoneNumber.Text);
                _request.ClientId = ViewModel.AddClient(_client).ClientId;
            }

            if (_request.StatusId == 2)  // Статус заявки "Выполнена"
            {
                _request.DateClosed = DateTime.Today;
            }

            if (_request.RequestId != 0)
            {
                ViewModel.UpdateRequests(_request);
            }
            else
            {
                ViewModel.AddRequests(_request);
            }
            MessageBox.Show("Успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            FrameContext.MainWindowFrame.Navigate(new RequestListPage());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(new RequestListPage());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+"); // Все, кроме цифр
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Init()
        {
            comboBoxProblemType.ItemsSource = ViewModel.GetProblemTypesForView();
            comboBoxStatus.ItemsSource = ViewModel.GetStatusView();
            DataContext = _request;
        }

        private bool IsFilesValid()
        {
            if (string.IsNullOrEmpty(txtEquipment.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtDateAdded.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtClientName.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtClientPhoneNumber.Text))
            {
                return false;
            }
            if (comboBoxProblemType.SelectedItem == null)
            {
                return false;
            }
            if (comboBoxStatus.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

    }
}
