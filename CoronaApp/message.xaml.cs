using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        private string kumulativTransfer;

        public string KumulativTransfer
        {
            get { return kumulativTransfer; }
            set { kumulativTransfer = value; }

        }
        private string municipalityNm;
        public string MunicipalityNm
        {
            get { return municipalityNm; }
            set { municipalityNm = value; }
        }
        private List<RestrictionsData> list = new List<RestrictionsData>();
        public message()
        {
            InitializeComponent();

            SQLMessage();

        }


        private async void SQLMessage()
        {
            await System.Threading.Tasks.Task.Delay(3000);
            //decimal kumulativtal = decimal.Parse(kumulativTransfer);
            var kumulativtal = decimal.Parse(kumulativTransfer, new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            if (kumulativtal > 10)
            {
                string Kumulativtal = "0." + Convert.ToString(kumulativtal);


                kumulativtal = decimal.Parse(Kumulativtal, new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = "." });
            }

            SqlConnection connection = null;
            try
            {
                if (kumulativtal >= 0.1m && kumulativtal < 1)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Restrictions WHERE Risikoniveau = '1' AND Municipality_id = " + municipalityNm + "", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list.Clear();
                    while (reader.Read()) list.Add(new RestrictionsData { Risikoniveau = reader[0].ToString(), Restriktioner = reader[1].ToString(), Beskrivelser = reader[2].ToString(), KumulativeIncidenstal = reader[3].ToString(), RestriktionsDato = reader[4].ToString() });
                    connection.Close();

                    AnbefalingsData.ItemsSource = list;
                }
                else if (kumulativtal >= 1 && kumulativtal < 2)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Restrictions WHERE Risikoniveau = '2' AND Municipality_id = " + municipalityNm + "", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list.Clear();
                    while (reader.Read()) list.Add(new RestrictionsData { Risikoniveau = reader[0].ToString(), Restriktioner = reader[1].ToString(), Beskrivelser = reader[2].ToString(), KumulativeIncidenstal = reader[3].ToString(), RestriktionsDato = reader[4].ToString() });
                    connection.Close();

                    AnbefalingsData.ItemsSource = list;
                }
                else if (kumulativtal >= 2 && kumulativtal < 3)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Restrictions WHERE Risikoniveau = '3' AND Municipality_id = " + municipalityNm + "", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list.Clear();
                    while (reader.Read()) list.Add(new RestrictionsData { Risikoniveau = reader[0].ToString(), Restriktioner = reader[1].ToString(), Beskrivelser = reader[2].ToString(), KumulativeIncidenstal = reader[3].ToString(), RestriktionsDato = reader[4].ToString() });
                    connection.Close();

                    AnbefalingsData.ItemsSource = list;
                }
                else if (kumulativtal >= 3 && kumulativtal < 4)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Restrictions WHERE Risikoniveau = '4'  AND Municipality_id = " + municipalityNm + "", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list.Clear();
                    while (reader.Read()) list.Add(new RestrictionsData { Risikoniveau = reader[0].ToString(), Restriktioner = reader[1].ToString(), Beskrivelser = reader[2].ToString(), KumulativeIncidenstal = reader[3].ToString(), RestriktionsDato = reader[4].ToString() });
                    connection.Close();

                    AnbefalingsData.ItemsSource = list;
                }
                else if (kumulativtal >= 4)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT * FROM dbo.Restrictions WHERE Risikoniveau = '5'  AND Municipality_id = " + municipalityNm + "", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    list.Clear();
                    while (reader.Read()) list.Add(new RestrictionsData { Risikoniveau = reader[0].ToString(), Restriktioner = reader[1].ToString(), Beskrivelser = reader[2].ToString(), KumulativeIncidenstal = reader[3].ToString(), RestriktionsDato = reader[4].ToString() });
                    connection.Close();

                    AnbefalingsData.ItemsSource = list;
                }
                else if (kumulativtal == 0)
                {
                    MessageBox.Show("Der er en kumulativ incidens på 0");
                }
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