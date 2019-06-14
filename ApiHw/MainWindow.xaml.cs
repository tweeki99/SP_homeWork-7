using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using unirest_net.http;

namespace ApiHw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void checkButtonClick(object sender, RoutedEventArgs e)
        {
                var example = await LoadBody(firstNameTextBox.Text, secondNameTextBox.Text);

                percentageTextBlock.Text = example.percentage + "%";
                resultTextBlock.Text = example.result;
        }

        private Task<ResponseBody> LoadBody(string firstName, string secondName)
        {
            return Task.Run(() =>
            {
                    WebClient client = new WebClient();
                    client.Headers.Add("X-RapidAPI-Host", "love-calculator.p.rapidapi.com");
                    client.Headers.Add("X-RapidAPI-Key", "fe11498100msh828c381e2fc3795p1ee33ejsn03699552ce88");

                    string json = client.DownloadString("https://love-calculator.p.rapidapi.com/getPercentage?fname=" + firstName + "&sname=" + secondName);

                    return JsonConvert.DeserializeObject<ResponseBody>(json);
            });
        }
    }
}
