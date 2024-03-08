using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Naughts_and_Crosses
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Settings : Window
    {
        
        public Settings(Window mainWindow)
        {
            InitializeComponent();
            cmbTheme.Text = "Dark";
            cmbTheme.Foreground = new SolidColorBrush((Color)Color.FromArgb(255, 0, 0, 0));
            cmbTheme.Background = new SolidColorBrush((Color)Color.FromArgb(255, 255, 11, 11));
            //Downloads the settings and changes the slider value to the values in the settings
            List<List<string>> settings=((MainWindow)System.Windows.Application.Current.MainWindow).DownloadCSV("Files//Settings.csv");
            sldPlayer1Alpha.Value = Int32.Parse(settings[0][0]);
            sldPlayer1Red.Value = Int32.Parse(settings[0][1]);
            sldPlayer1Green.Value = Int32.Parse(settings[0][2]);
            sldPlayer1Blue.Value = Int32.Parse(settings[0][3]);
            sldPlayer2Alpha.Value = Int32.Parse(settings[1][0]);
            sldPlayer2Red.Value = Int32.Parse(settings[1][1]);
            sldPlayer2Green.Value = Int32.Parse(settings[1][2]);
            sldPlayer2Blue.Value = Int32.Parse(settings[1][3]);
        }
        //Closes down the form
        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //When one of the values of the slider is changed the colour of the box is changed to the new values of the slider
        private void sldPlayer1_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color colour = Color.FromArgb((byte)sldPlayer1Alpha.Value,(byte)sldPlayer1Red.Value, (byte)sldPlayer1Green.Value, (byte)sldPlayer1Blue.Value);
            Brush myBrush = new SolidColorBrush((Color)colour);
            rectPlayer1.Fill = myBrush;
        }

        private void sldPlayer2_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            Color colour = Color.FromArgb((byte)sldPlayer2Alpha.Value, (byte)sldPlayer2Red.Value, (byte)sldPlayer2Green.Value, (byte)sldPlayer2Blue.Value);
            Brush myBrush = new SolidColorBrush((Color)colour);
            rectPlayer2.Fill = myBrush;
        }
        //Saves the settings to a text file
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> lin1 = new List<string> { sldPlayer1Alpha.Value.ToString(),
            sldPlayer1Red.Value.ToString(),
            sldPlayer1Green.Value.ToString(),
            sldPlayer1Blue.Value.ToString()};
            List<string> lin2 = new List<string> { sldPlayer2Alpha.Value.ToString(),
            sldPlayer2Red.Value.ToString(),
            sldPlayer2Green.Value.ToString(),
            sldPlayer2Blue.Value.ToString()};
            list.Add(lin1);
            list.Add(lin2);

            using (var file = File.CreateText("Files//Settings.csv")) 
            {
                //Loops through each string 
                foreach (var arr in list)
                {
                    file.WriteLine(string.Join(",", arr));
                }
            }
        }

        private void cmbTheme_Closed(object sender, EventArgs e)
        {
            Brush myBrush;
            switch (cmbTheme.Text)//Switch case to change the background colour
            {
                case "Light"://If the value of the comboBox is "Light" the background colour will change to white
                    myBrush=new SolidColorBrush((Color) Color.FromArgb(255,200,200,200));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;

                case "Dark": 
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 33, 33, 33));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;

                case "Turquoise":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 15, 251, 255));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                case "Pink":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 247, 0, 153));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                case "Orange":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255,247, 144, 0));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                case "Red":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 255, 36, 36));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                case "Green":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 36, 255, 36));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                case "Blue":
                    myBrush = new SolidColorBrush((Color)Color.FromArgb(255, 48, 70, 240));
                    ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background = myBrush;
                    grid.Background = myBrush;
                    break;
                default:
                    break;
            }
        }
    }
}