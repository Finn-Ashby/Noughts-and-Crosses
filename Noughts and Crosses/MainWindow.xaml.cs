using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Naughts_and_Crosses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool reset = false;
        bool songFlag = true;
        int[] playerFlag = { -1, -1 };
        List<List<string>> scores = new List<List<string>>();
        bool ai = false;//boolean to see if the ai is selected
        int counter = 0;//Increments every time a move is made
        bool playFlag = false; //changes when the play button is pressed
        bool naughtCross = true; //boolean variable that changes to show if naughts or crosses is drawing
        public MainWindow()
        {
            InitializeComponent();
            playSong("Kahoot!Christmas");   
        }
        public void playSong(string song)//Procedure dedicated to playing songs
        {
            SoundPlayer sound = new SoundPlayer($"Files//{song}.wav");//Creates a SoundPlayer object 
            sound.Load();
            sound.PlayLooping();
        }
        public List<List<string>> Sort(List<List<string>> ogList)//Performs a bubble sort on a 2d list
        {
            const int sorted = 1;//The index in each list showing the wins
            List<string> t = new List<string>();
            List<List<string>> newList = new List<List<string>>();
            for (int p = 0; p <= ogList.Count - 2; p++)
            {
                for (int i = 0; i <= ogList.Count - 2; i++)
                {
                    if (Int32.Parse(ogList[i][sorted]) < Int32.Parse(ogList[i + 1][sorted]))
                    {
                        t = ogList[i + 1];
                        ogList[i + 1] = ogList[i];
                        ogList[i] = t;
                    }
                }
            }
            return ogList;
        }
        public bool WinCheck(List<List<Button>> list, bool player) //A function returning a true or false value to determine if the player who has just made a move has won
        {
            int total, totalTrue, totalTrue2;
            totalTrue2 = 0;
            totalTrue = 0;
            if (player)
            {
                total = 30;//The total required for if crosses made a move 
            }
            else
            {
                total = 3;//The total required for if noughts just made a move
            }
            //Checks if the rows or columns add up to 3 or 30
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    totalTrue += Int32.Parse(list[i][j].Content.ToString());//Adds the value in each row  to totalTrue
                    totalTrue2 += Int32.Parse(list[j][i].Content.ToString());//Adds the value in each column  to totalTrue2
                }
                if (totalTrue == total || totalTrue2 == total)
                {
                    return (true); //Returns true if the columns or rows add up to 3 or 30
                }
                totalTrue = 0;
                totalTrue2 = 0;
            }
            for (int i = 0; i <= 2; i++)//Adds up diagonals to totalTrue and totalTrue2
            {
                totalTrue += Int32.Parse(list[i][i].Content.ToString());//(0,0)+(1,1)+(2,2)
                totalTrue2 += Int32.Parse(list[2 - i][i].Content.ToString());//(0,2)+(1,1)+(0,2)
            }
            if (total == totalTrue || total == totalTrue2)//If one of the diagonals adds up to the total
            {
                return (true);
            }
            totalTrue = 0;
            totalTrue2 = 0;
            return (false);//If no diagonals or rows or columns add up to 30/3 then the player who has just made a move hasnt won
        }
        public List<List<string>> DownloadCSV(string csvPath)//Function returning a csv file as a 2d list
        {
             
            List<string> oneD = new List<string>();
            List<List<string>> list = new List<List<string>>();
            string[][] lines = File.ReadLines(csvPath).Select(s => s.Split(",".ToCharArray())).ToArray().ToArray();//Gets the csv file into a jagged array
            for(int i = 0; i < lines.Length; i++)//Loops through the number of people in the lb
            {
                for (int j = 0; j < lines[0].Length; j++)//Loops through the length of each array within the array
                {
                    oneD.Add(lines[i][j]);//Adds 
                }
                list.Add(oneD);//Adds the list to the 2d list
                oneD = new List<string>();//Clears the list
            }

            return list;
        }
        public void bntPress_Click(object sender, RoutedEventArgs e)
        {
            if (playFlag)
            {
                songFlag = true;
                reset = true;
                Button btnClicked = e.Source as Button;//Creates a button object to be the same as the one that was just clicked. Allows for one subroutine instead of 9 for when a button in the grid is pressed
                if (btnClicked.Content.ToString() == "0") //Ensures the button that was clicked hasn't already been chosen
                {
                    List<List<string>> settings = settings = DownloadCSV("Files//Settings.csv");
                    Color colours;
                    counter += 1;//Increments the counter by 1
                    List<List<Button>> grid = new List<List<Button>>();//Creates a 2d list of button objects
                    List<Button> row1 = new List<Button> { btn1, btn2, btn3 };
                    List<Button> row2 = new List<Button> { btn4, btn5, btn6 };
                    List<Button> row3 = new List<Button> { btn7, btn8, btn9 };
                    List<int> coords = new List<int>();
                    grid.Add(row1);
                    grid.Add(row2);
                    grid.Add(row3);
                    //use BtnClicked.Name==grid[i][j] iteration to get which button to draw it over 
                    //Use the index to find coordinates in a separate 2d list to be passed to the drawing subroutine
                    //Manipulate coordinates for drawing X and O in subroutine.

                    if (ai == false)
                    {
                        if (naughtCross) ///If the naughtCross boolean is true then a 10 is placed
                                         ///If the naughtCross boolean is false then an 1 is placed
                                         ///The naughtCross boolean changes after a naught or cross is placed
                        {
                            List<int> fullCoords = new List<int> { 16, 122, 228 };//List of values for where the coordinates for the x to be placed
                            for (int i = 0; i < 3; i++)//Loops through the list of buttons to find out the index of the button just pressed
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (grid[j][i].Name == btnClicked.Name)//If the button name is the same as the one 
                                                                           //in the list then the 
                                                                           //index of the button is used to find the coordinates of where to draw the 
                                                                           //button in the other list
                                    {

                                        coords.Add(fullCoords[i]);//The coords list is given the coordinates
                                        coords.Add(fullCoords[j]);
                                    }
                                }
                            }
                            cheese1.Content = scores[0][0];
                            colours = Color.FromArgb((byte)Int32.Parse(settings[0][0]), (byte)Int32.Parse(settings[0][1]), (byte)Int32.Parse(settings[0][2]), (byte)Int32.Parse(settings[0][3]));
                            Draw(coords, naughtCross, colours);
                            btnClicked.Content = "10";//Changes the content of the button clicked to 10
                            lblMain.Content = $"{lblPlayer1.Text}'s turn";//Changes the label to show who's turn it is
                            if (WinCheck(grid, naughtCross))//Runs the WinCheck function which returns a true or false value
                            {

                                scores[playerFlag[1]][2] = (Int32.Parse(scores[playerFlag[1]][2]) + 1).ToString();
                                scores[playerFlag[0]][1] = (Int32.Parse(scores[playerFlag[0]][1]) + 1).ToString();
                                scores=Sort(scores);
                                using (var file = File.CreateText("Files//Scores.csv"))
                                {
                                    //Loops through each string 
                                    foreach (var arr in scores)
                                    {

                                        file.Write(string.Join(",", arr));
                                        file.Write('\r');

                                    }
                                }
                                songFlag = false;
                                playSong("Kahoot!Christmas");
                                lblMain.Content = $"{lblPlayer1.Text} wins!";//Displays crosses wins on the display
                                playFlag = false;//Sets the play flag to false because the game is over
                                counter = 0;//resets the counter
                            }
                            else
                            {
                                naughtCross = false;//Changes the boolean to false so next turn an O is placed
                            }
                        }
                        else
                        {
                            List<int> fullCoords = new List<int> { 5, 111, 217 };//List of coordinates for where the circle centre is
                            for (int i = 0; i < 3; i++)//Loops through the list of buttons to find out the index of the button just pressed
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (grid[j][i].Name == btnClicked.Name)//If the button name is the same as the one 
                                                                           //in the list then the 
                                                                           //index of the button is used to find the coordinates of where to draw the 
                                                                           //button in the other list
                                    {
                                        coords.Add(fullCoords[i]);//The coords list is given the coordinates
                                        coords.Add(fullCoords[j]);
                                    }
                                }
                            }
                            colours = Color.FromArgb((byte)Int32.Parse(settings[1][0]), (byte)Int32.Parse(settings[1][1]), (byte)Int32.Parse(settings[1][2]), (byte)Int32.Parse(settings[1][3]));
                            Draw(coords, naughtCross, colours);
                            btnClicked.Content = "1";//Changes the content of buttn clicked to 1
                            lblMain.Content = $"{lblPlayer2.Text}'s turn";//Changes the label to show who's turn it is
                            if (WinCheck(grid, naughtCross))//Runs the WinCheck function which returns a true of false value to determine if O has won
                            {
                                scores[playerFlag[0]][2] = (Int32.Parse(scores[playerFlag[1]][2]) + 1).ToString();
                                scores[playerFlag[1]][1] = (Int32.Parse(scores[playerFlag[0]][1]) + 1).ToString();
                                scores=Sort(scores);
                                using (var file = File.CreateText("Files//Scores.csv"))
                                {
                                    //Loops through each string 
                                    foreach (var arr in scores)
                                    {

                                        file.Write(string.Join(",", arr));
                                        file.Write('\r');

                                    }
                                }
                                songFlag = false;
                                playSong("Kahoot!Christmas");
                                lblMain.Content = $"{lblPlayer2.Text} wins!";//Displays that O has won on the display
                                counter = 0;//resets the counter
                                playFlag = false;//Sets the play flag to false because the game is over
                            }
                            naughtCross = true;//Changes the boolean to true so next turn an X is placed
                        }
                        if (counter == 9 && playFlag == true)//Checks if the counter is at 8 and nobody has won
                        {
                            playFlag = false;
                            lblMain.Content = "Draw!";//Displays draw on the display
                            counter = 0;
                        }
                    }
                    else
                    {
                        naughtCross = true;
                        List<int> fullCoords = new List<int> { 16, 122, 228 };//List of values for where the coordinates for the x to be placed
                        for (int i = 0; i < 3; i++)//Loops through the list of buttons to find out the index of the button just pressed
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (grid[j][i].Name == btnClicked.Name)//If the button name is the same as the one 
                                                                       //in the list then the 
                                                                       //index of the button is used to find the coordinates of where to draw the 
                                                                       //button in the other list
                                {

                                    coords.Add(fullCoords[i]);//The coords list is given the coordinates
                                    coords.Add(fullCoords[j]);
                                }
                            }
                        }
                        
                        colours = Color.FromArgb((byte)Int32.Parse(settings[0][0]), (byte)Int32.Parse(settings[0][1]), (byte)Int32.Parse(settings[0][2]), (byte)Int32.Parse(settings[0][3]));
                        Draw(coords, naughtCross, colours);
                        
                        btnClicked.Content = "10";//Changes the content of the button clicked to 10
                        if (WinCheck(grid, naughtCross))//Runs the WinCheck function which returns a true or false value
                        {
                            songFlag = false;
                            playSong("Kahoot!Christmas");
                            lblMain.Content = $"{lblPlayer1.Text} wins!";//Displays crosses wins on the display
                            playFlag = false;//Sets the play flag to false because the game is over
                            counter = 0;//resets the counter
                        }
                        else
                        {
                            if (counter < 9)
                            {
                                
                                fullCoords = new List<int> { 5, 111, 217 };

                                naughtCross = false;
                                List<int> Coordis = new List<int>();
                                counter++;////////////////////////
                                switch (sldDifficulty.Value)//Switch case for AI to make move based on difficulty selected
                                {
                                    case 6://Hard difficulty
                                        Coordis = AIHard(grid,counter);
                                        break;
                                    case 3://Medium difficulty
                                        Random rand = new Random();
                                        if (rand.Next(1, 5) == 1)// 1/4 chance it will do an easy move
                                        {
                                            Coordis = AIEasy(grid);
                                        }
                                        else
                                        {
                                            Coordis = AIHard(grid, counter);// 2/3 chance it will do a hard move
                                        }
                                        break;
                                    default:
                                        Coordis = AIEasy(grid);//Easy difficulty
                                        break;
                                }
                                
                                try
                                {
                                    coords = new List<int> { fullCoords[Coordis[1]], fullCoords[Coordis[0]] };
                                    grid[Coordis[0]][Coordis[1]].Content = "1";
                                    Draw(coords, naughtCross);
                                }
                                catch
                                {
                                    lblMain.Content = "Draw!";

                                    playFlag = false;
                                    songFlag = false;
                                    playSong("Kahoot!Christmas");
                                    counter = 0;
                                }
                                
                                if (WinCheck(grid, naughtCross))
                                {
                                    songFlag = false;
                                    playSong("Kahoot!Christmas");
                                    lblMain.Content = "AI wins!";
                                    playFlag = false;//Sets the play flag to false because the game is over
                                    counter = 0;//resets the counter
                                }
                            }
                            else
                            {
                                lblMain.Content = "Draw!";
                                playFlag = false;
                                playSong("Kahoot!Christmas");
                                counter = 0;
                            }
                            

                        }
                    }

                }
            }
        }
        private List<int> AIHard(List<List<Button>> btnBoard,int count)
        {
            //Uses a minmax recursion algorithm to find the best possible move for a given board
            int bestScore=1;
            int score;
            List<int> BestMove = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    //if spot is available
                    if (btnBoard[i][j].Content.ToString() == "0")
                    {
                        btnBoard[i][j].Content = "1";
                        score=Minimax(btnBoard,true,count);//Runs minimax algorithm to see if it is a 
                        //winning,drawing or losing move assuming the opponent plays the best possible
                        //move
                        btnBoard[i][j].Content = "0";
                        if (score <= bestScore)//Compares the score to the current best score
                        {
                            bestScore = score;//If the score is lower it becomes the new best score
                            BestMove = new List<int>();
                            BestMove.Add(i);//Adds the coordinates of the loop to the list to be returned
                            BestMove.Add(j);
                        }
                    }
                }
            }
            return BestMove;
        }
        private int Minimax(List<List<Button>>btnGrid,bool flag,int count)
        {
            //Algorithm used to find the best possible move assuming the opponent plays the best
            //possible move
            int scor;
            int bestScore;
            bool win;
            bool flag1 = true;
            if (flag)
            {
                flag1 = false;
            }
            
            win = (WinCheck(btnGrid, flag1));
            if (win == true&flag)
            {
                scor = -1;
                return scor;
            }
            else if (win == true & flag1){
                scor = 1;
                return scor;
            }
            else if (count == 9)
            {
                scor = 0;
                return scor;
            }
            if (flag)
            {
                bestScore = -1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //if spot is available
                        if (btnGrid[i][j].Content.ToString() == "0")
                        {
                            btnGrid[i][j].Content = "10";
                            scor = Minimax(btnGrid, false, count + 1);

                            btnGrid[i][j].Content = "0";
                            if (scor > bestScore)
                            {
                                bestScore = scor;
                            }
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                bestScore = 1;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //if spot is available
                        if (btnGrid[i][j].Content.ToString() == "0")
                        {
                            btnGrid[i][j].Content = "1";
                            scor = Minimax(btnGrid, true, count + 1);
                            btnGrid[i][j].Content = "0";
                            if (scor < bestScore)
                            {
                                bestScore = scor;
                            }
                        }
                    }
                }
                return bestScore;
            }
        }
            
    
        private void bntReset_Click(object sender, RoutedEventArgs e)//A subroutine dedicated to resetting all variables and display so a new game can be played
        {
                chkAI.IsEnabled = true;
                if (songFlag)
            {
                playSong("Kahoot!Christmas");
            }
                counter = 0;
                for (int i = myCanvas.Children.Count - 1; i >= 0; i--)//Loops through the canvas backwards
                {
                    UIElement Child = myCanvas.Children[i];
                    if (Child is Button)//Removes everything that isnt a button (ellispes and lines)
                    {
                        continue;
                    }
                    else
                    {
                        myCanvas.Children.Remove(Child);
                    }

                }

                reset = false;
                List<List<Button>> list = new List<List<Button>>(); //Creates a 2d list of the  button objects
                List<Button> row1 = new List<Button> { btn1, btn2, btn3 };
                List<Button> row2 = new List<Button> { btn4, btn5, btn6 };
                List<Button> row3 = new List<Button> { btn7, btn8, btn9 };
                list.Add(row1);
                list.Add(row2);
                list.Add(row3);
                for (int i = 0; i < 3; i++)//Loops through the list of buttons
                {
                    for (int j = 0; j < 3; j++)
                    {
                        list[i][j].Content = "0"; //Sets every button content to zero 
                    }
                }
                lblMain.Content = ""; //Clears the display
                playFlag = false; //Sets the play flag to false because the game has been reset
            
        }
        private void bntPlay_Click(object sender, RoutedEventArgs e)
        {
            if (playFlag == false & reset == false)//play flag can only be false when the reset button is pressed
            {
                counter = 0;
                playSong("20Second");
                if (lblPlayer1.Text != lblPlayer2.Text)
                {
                    if (ai == false)
                    {
                        scores = DownloadCSV("Files//Scores.csv");

                        for (int i = 0; i < scores.Count; i++)
                        {
                            if (scores[i][0] == lblPlayer1.Text)
                            {
                                playerFlag[0] = i;
                            }
                            if (scores[i][0] == lblPlayer2.Text)
                            {
                                playerFlag[1] = i;
                            }
                        }
                        if (playerFlag[0] == -1)
                        {
                            List<string> tempScore = new List<string> { lblPlayer1.Text, "0", "0" };
                            scores.Add(tempScore);
                            playerFlag[0] = scores.Count - 1;
                        }
                        if (playerFlag[1] == -1)
                        {
                            List<string> tempScore = new List<string> { lblPlayer2.Text, "0", "0" };
                            scores.Add(tempScore);
                            playerFlag[1] = scores.Count - 1;
                        }
                    }
                    chkAI.IsEnabled = false;
                    lblMain.Content = $"{lblPlayer1.Text}'s turn"; //Sets the display to who'se turn it is
                    playFlag = true; //Sets the play flag to true because the game has just started
                }
            }
            else
            {
                MessageBox.Show("Please press the reset button before starting a new game", "AAAAAAHHHHHH!!!", MessageBoxButton.OK, MessageBoxImage.Warning);//If the game has not been reset and the player tries to start a new game they are told to reset the game
            }
        }
        //Button object passed so the X or O can be drawn on the button
        private void Draw(List<int> coordinates, bool NaughtOrCross, Color? colour = null)//A subroutine dedicated to drawing the nought or cross
        {
            if (colour == null)//If the colour paramater is not used (the user has not chosen a color) it will default to black
            {
                colour = Color.FromArgb(255, 200, 200, 200);//Black in the FromArgb format (opacity,r,g,b)
            }
            Brush myBrush = new SolidColorBrush((Color)colour);//Sets myBrush to either black or the chosen colour
            if (NaughtOrCross)//Drawing an X because the boolean is set to true so it was X's turn
            {
                //Draws a cross
                Line myLine1 = new Line();
                Line myLine2 = new Line();
                myLine1.Stroke = myBrush;
                myLine1.X1 = coordinates[0];
                myLine1.X2 = coordinates[0] + 74;
                myLine1.Y1 = coordinates[1];
                myLine1.Y2 = coordinates[1] + 74;
                myLine1.HorizontalAlignment = HorizontalAlignment.Left;
                myLine1.VerticalAlignment = VerticalAlignment.Center;
                myLine1.StrokeThickness = 6;
                myCanvas.Children.Add(myLine1); //The line is drawn with a thickness of 6
                myLine2.Stroke = myBrush;
                myLine2.X1 = coordinates[0];
                myLine2.X2 = coordinates[0] + 74;
                myLine2.Y1 = coordinates[1] + 74;
                myLine2.Y2 = coordinates[1];
                myLine2.HorizontalAlignment = HorizontalAlignment.Left;
                myLine2.VerticalAlignment = VerticalAlignment.Center;
                myLine2.StrokeThickness = 6;
                myCanvas.Children.Add(myLine2); //The line is drawn with a thickness of 6
                label.Content = myCanvas.Children.Count;
            }
            else //Drawing a circle because the boolean is set to false so it was O's turn
            {
                Ellipse circle = new Ellipse();
                circle.Height = 96;
                circle.Width = 96;
                // Set Ellipse's width and color    
                circle.StrokeThickness = 6;
                circle.Stroke = myBrush;
                circle.Margin = new Thickness(coordinates[0], coordinates[1], 0, 0);
                // Fill rectangle with blue color    
                // Add Ellipse to the Grid.    
                myCanvas.Children.Add(circle);
            }
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings(this);//Creates the settings form and shows it
            settings.Show();
        }
        public void ButtonWasClicked()
        {
            btnSettings.IsEnabled = true;
        }
        private void bntExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();//Shuts down all applications so nothing is running in memory
        }

        private void lblPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lblChanged = e.Source as TextBox;
            lblChanged.Text = lblChanged.Text.ToString().Replace(",", "");//Removes comma and carrige return from the player name text boxes
            lblChanged.Text = lblChanged.Text.ToString().Replace(@"\n", "");
            while (true)
            {
                if (lblChanged.Text.ToString().Length > 13)//Maximum length of text box is 13
                {
                    lblChanged.Text = lblChanged.Text.ToString().Remove(13);//Removes last character from text box
                }
                else
                {
                    break;
                }
            }

        }
        private void lblPlayer_enter(object sender, RoutedEventArgs e)
        {
            TextBox lblPressed = e.Source as TextBox;
            if (lblPressed.Text == "Player1" || lblPressed.Text == "Player2")//Clears the textbox when it is clicked
            {
                lblPressed.Text = "";
            }
        }
        private void chkAI_click(object sender, RoutedEventArgs e)
        {
            lblPlayer2.IsEnabled = false;//When the ai checkbox is checked you are unable to enter the name for player 2 
            ai = true;//Ai flag set to true
        }
        private void chkAI_uncheck(object sender, RoutedEventArgs e)
        {
            lblPlayer2.IsEnabled = true;//When the ai checkbox is unchecked you are able to enter the name for player 2 
            ai = false;//Ai flag set to false
        }
        private void btnLb_Click(object sender, RoutedEventArgs e)
        {
            Leaderboad lb = new Leaderboad(this);//Creates the leaderboard form and shows it
            lb.Show();
        }
        private List<int> AIEasy(List<List<Button>> Board)
        {
            //Picks the first position it can find and returns it
            List<int> answer = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i][j].Content.ToString() == "0")
                    {
                        answer.Add(i);
                        answer.Add(j);
                        break;
                    }
                }
            }
            return answer;
        }
        
    }
}