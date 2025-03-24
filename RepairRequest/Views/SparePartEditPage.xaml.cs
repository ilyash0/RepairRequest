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
    public partial class SparePartEditPage : Page
    {
        private readonly SparePart _sparePart;
        public SparePartEditPage()
        {
            InitializeComponent();
            textBlockTitle.Text = "Новый компонент";
            _sparePart = new SparePart();
            Init();
        }

        public SparePartEditPage(SparePart sparePart)
        {
            InitializeComponent();
            _sparePart = sparePart;
            Init();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFilesValid())
            {
                MessageBox.Show("Все поля должны быть заполнены", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_sparePart.SparePartId != 0)
            {
                ViewModel.UpdateSpareParts(_sparePart);
            }
            else
            {
                ViewModel.AddSpareParts(_sparePart);
            }
            MessageBox.Show("Успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            FrameContext.MainWindowFrame.GoBack();
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
            comboBoxSparePartType.ItemsSource = ViewModel.GetSparePartTypesForView();
            DataContext = _sparePart;
        }

        private bool IsFilesValid()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtSparePartCost.Text))
            {
                return false;
            }
            if (comboBoxSparePartType.SelectedItem == null)
            {
                return false;
            }
            return true;
        }
    }
}
