using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoronaApp
{
    /// <summary>
    /// Interaction logic for message.xaml
    /// </summary>
    public partial class message : Window
    {
        public message()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TilbageButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void AnvendButton_Click(object sender, RoutedEventArgs e)
        {
            // Indsæt anvendelses code her, så der bliver filtreret for smittede kommuner.


            DataPage dataPage = new DataPage();
            dataPage.Show();
            this.Close();
        }
    }


}
