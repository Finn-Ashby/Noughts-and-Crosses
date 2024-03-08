using System;
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
using System.Windows.Shapes;

namespace Naughts_and_Crosses
{
    /// <summary>
    /// Interaction logic for Leaderboad.xaml
    /// </summary>
    public partial class Leaderboad : Window
    {
        public Leaderboad(Window mainWindow)
        {
            InitializeComponent();
            grid.Background = ((MainWindow)System.Windows.Application.Current.MainWindow).griMain.Background;
            List<List<string>> Scores = ((MainWindow)System.Windows.Application.Current.MainWindow).DownloadCSV("Files//Scores.csv");
            for (int i = 0; i < 10; i++)//Loops through 10 times adding the top 10 name,wins and losses to each player
            {
                try
                {
                    lblNames.Content = lblNames.Content.ToString() + '\n' + Scores[i][0];//Adds the name to the name label
                    lblWins.Content = lblWins.Content.ToString() + '\n' + Scores[i][1];//Adds the wins to the wins label
                    lblLosses.Content = lblLosses.Content.ToString() + '\n' + Scores[i][2];//Adds the losses to the losses label
                }
                catch
                {
                    break;
                }
            }
        }
        //Closes down the form
        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            Close();//Closes the form
        }
    }
}
