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
    /// Interaction logic for SparePartEditPage.xaml
    /// </summary>
    public partial class SparePartRequestEditPage : Page
    {
        private readonly SparePartRequest _sparePartRequest;
        private readonly int _requestId;
        public SparePartRequestEditPage(int requestId)
        {
            InitializeComponent();
            textBlockTitle.Text = "Новый компонент заявки";
            _sparePartRequest = new();
            _requestId = requestId;
            Init();
        }

        public SparePartRequestEditPage(SparePartRequest sparePartRequest)
        {
            InitializeComponent();
            _sparePartRequest = sparePartRequest;
            _requestId = sparePartRequest.RequestId;
            Init();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFilesValid())
            {
                MessageBox.Show("Все поля должны быть заполнены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Convert.ToDecimal(txtQuantity.Text) > Convert.ToDecimal(txtMaxQuantity.Text))
            {
                MessageBox.Show("Требуемое количество компонентов не должно превышать количество компонентов на складе", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (comboBoxSparePart.SelectedItem is SparePart selectedSparePart)
            {
                selectedSparePart.Quantity -= Convert.ToDecimal(txtQuantity.Text);
            }

            if (_sparePartRequest.SparePartRequestId != 0)
            {
                ViewModel.UpdateSparePartRequests(_sparePartRequest);
            }
            else
            {
                ViewModel.AddSparePartRequests(_sparePartRequest);
            }
            MessageBox.Show("Успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            FrameContext.MainWindowFrame.Navigate(new SparePartRequestListPage(_requestId));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.GoBack();
        }

        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9.]+"); // Все, кроме цифр и .
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Init()
        {
            comboBoxSparePart.ItemsSource = ViewModel.GetSparePartesForView();
            DataContext = _sparePartRequest;
            _sparePartRequest.RequestId = _requestId;
        }

        private bool IsFilesValid()
        {
            if (comboBoxSparePart.SelectedItem == null)
            {
                return false;
            }
            if (!decimal.TryParse(txtQuantity.Text, out decimal a) || a <= 0)
            {
                return false;
            }
            return true;
        }

        private void comboBoxSparePart_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSparePart.SelectedItem is SparePart selectedSparePart)
            {
                txtMaxQuantity.Text = $"{selectedSparePart.Quantity}";
            }
        }
    }
}
