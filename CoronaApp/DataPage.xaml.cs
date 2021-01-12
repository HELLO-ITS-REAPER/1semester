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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoronaApp
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : Window
    {
        public DataPage()
        {
            InitializeComponent();
            ShowKommune();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AnbefalingerButton_Click(object sender, RoutedEventArgs e)
        {
            message message = new message();
            message.Show();
            this.Close();
        }

        private string myVal;
        public string MyVal
        {
            get { return myVal; }
            set { myVal = value; }

        }
        private async void ShowKommune()
        {
            await System.Threading.Tasks.Task.Delay(100);
            if (MyVal == "")
            {
                KommuneNavnText.Clear();
                this.KommuneNavnText.Text = "ingen Kommune valgt";
            }
            else
            {
                KommuneNavnText.Clear();

                this.KommuneNavnText.Text += myVal;
            }
        }
    }
}
