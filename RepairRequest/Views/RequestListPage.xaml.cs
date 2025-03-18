﻿using System;
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
    }
}
