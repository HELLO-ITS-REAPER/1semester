using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.IO;

namespace CoronaApp
{
    /// <summary>
    /// Interaction logic for DataPage.xaml
    /// </summary>
    public partial class DataPage : Window
    {
        private List<OldDataRepository> list = new List<OldDataRepository>();
        public DataPage()
        {
            InitializeComponent();
            ShowKommune();
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


        private string kommuneNavn;
        public string KommuneNavn
        {
            get { return kommuneNavn; }
            set { kommuneNavn = value; }

        }

        private string testede;
        public string Testede
        {
            get { return testede; }
            set { testede = value; }
        }
        private string bekræftede;
        public string Bekræftede
        {
            get { return bekræftede; }
            set { bekræftede = value; }
        }
        private string kumulative;
        public string Kumulative
        {
            get { return kumulative; }
            set { kumulative = value; }
        }
        private string befolningstal;
        public string Befolningstal
        {
            get { return befolningstal; }
            set { befolningstal = value; }
        }
        private string municipalityID;
        public string MnicipalityID
        {
            get { return municipalityID; }
            set { municipalityID = value; }
        }

        private async void ShowKommune()
        {
            await System.Threading.Tasks.Task.Delay(100);
            if (KommuneNavn == "")
            {
                KommuneNavnText.Clear();
                this.KommuneNavnText.Text = "Ingen Kommune valgt";
                TestedeText.Clear();
            }
            else
            {
                KommuneNavnText.Clear();

                this.KommuneNavnText.Text += kommuneNavn;
            }
            this.TestedeText.Text = testede;
            BekræftedeText.Clear();
            this.BekræftedeText.Text = bekræftede;
            KumulativeText.Clear();
            this.KumulativeText.Text = kumulative;
            BefolningstalText.Clear();
            this.BefolningstalText.Text = befolningstal;
            DataFilter();
        }



        private void AnbefalingerButton_Click(object sender, RoutedEventArgs e)
        {
            message Message = new message();

            string municipality = municipalityID;
            Message.KumulativTransfer = kumulative;
            Message.MunicipalityID = municipality;
            Message.Show();

        }

        private void SQLViewer()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Cumulative_incidents", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                list.Clear();
                while (reader.Read()) list.Add(new OldDataRepository { KommuneID = reader[0].ToString(), AntalTestede = reader[1].ToString(), AntalBekræftedeCOVID19 = reader[2].ToString(), Befolkningstal = reader[3].ToString(), KumulativIncidens = reader[4].ToString(), Dato = reader[5].ToString() });
                connection.Close();

                OldData.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }

        private void DataFilter()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Cumulative_incidents WHERE Municipality_name = '" + KommuneNavnText.Text + "'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                list.Clear();
                while (reader.Read()) list.Add(new OldDataRepository { KommuneID = reader[0].ToString(), AntalTestede = reader[1].ToString(), AntalBekræftedeCOVID19 = reader[2].ToString(), Befolkningstal = reader[3].ToString(), KumulativIncidens = reader[4].ToString(), Dato = reader[5].ToString() });
                connection.Close();

                OldData.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null) connection.Close();
            }
        }
    }
}