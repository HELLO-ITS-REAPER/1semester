﻿using System;
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

        }

        private string myVal;
        public string MyVal
        {
            get { return myVal; }
            set { myVal = value; }

        }
        private string fileCSV;
        public string FileCSV
        {
            get { return fileCSV; }
            set { fileCSV = value; }

        }
        private async void ShowKommune()
        {
            await System.Threading.Tasks.Task.Delay(100);
            if (MyVal == "")
            {
                KommuneNavnText.Clear();
                this.KommuneNavnText.Text = "Ingen Kommune valgt";
            }
            else
            {
                KommuneNavnText.Clear();

                this.KommuneNavnText.Text += myVal;
                CSVdatareader();
            }
        }

        private void CSVdatareader()
        {
            string linje = "";

            string[] csvLines = File.ReadAllLines(fileCSV);
            for (int i = 1; i < csvLines.Length; i++)
            {
                if (csvLines[i].Contains(myVal))
                {
                    linje = csvLines[i];
                }



            }

            string[] rowdata = linje.Split(';');
            this.TestedeText.Text = rowdata[2];
            this.BekræftedeText.Text = rowdata[3];
            this.BefolningstalText.Text = rowdata[4];
            this.KumulativeText.Text = rowdata[5];

            Console.ReadLine();
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
    }
}
