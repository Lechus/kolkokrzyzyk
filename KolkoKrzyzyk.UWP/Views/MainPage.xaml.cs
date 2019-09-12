using KolkoKrzyzyk.UWP.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

namespace KolkoKrzyzyk.UWP.Views
{
    using Windows.UI.Xaml;

    public sealed partial class MainPage : Page
    {
        bool _turn = true; // true = X turn; false = O turn;
        int _turnCount = 0;
        string _winnerText = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Content = this._turn ? "X" : "O";
            b.IsEnabled = false;

            this._turn = !this._turn;
            this._turnCount++;
            this.CheckForWinner();
        }

         private void CheckForWinner()
        {
            bool thereIsAWinner = false;

            //horizontal checks
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                thereIsAWinner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                thereIsAWinner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                thereIsAWinner = true;
            
            //vertical checks
            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                thereIsAWinner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                thereIsAWinner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                thereIsAWinner = true;

            //diagonal checks
            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                thereIsAWinner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                thereIsAWinner = true;


            if (thereIsAWinner)
            {
                this.DisableButtons();
                string winner = "";
                if (this._turn)
                {
                    if (PlayerBName.Text == "Enter Name")
                        winner = "Player O";
                    else
                        winner = PlayerBName.Text;
                    TotalScoreB.Text = (Int32.Parse(TotalScoreB.Text) + 1).ToString();
                }
                else
                {
                    if (PlayerAName.Text == "Enter Name")
                        winner = "Player X";
                    else
                        winner = PlayerAName.Text;
                    TotalScoreA.Text = (Int32.Parse(TotalScoreA.Text) + 1).ToString();
                }

                this._winnerText = winner + " is winner!";
                winText.Text = this._winnerText;
                ShowAnimation();
            }
            else
            {
                if (this._turnCount == 9)
                {
                    winText.Text = "It's a draw.";
                    ShowAnimation();
                }
            }
        }

         private void DisableButtons()
         {
             A1.IsEnabled = false;
             A2.IsEnabled = false;
             A3.IsEnabled = false;
             B1.IsEnabled = false;
             B2.IsEnabled = false;
             B3.IsEnabled = false;
             C1.IsEnabled = false;
             C2.IsEnabled = false;
             C3.IsEnabled = false;
         }
         
         private void ShowAnimation()
         {
             Canvas.SetZIndex(WinTextButton, 0);
             NewGame2.IsEnabled = true;
             WinTextShow.Begin();
         }

         private void HideAnimation()
         {
             WinTextHide.Begin();
             NewGame2.IsEnabled = false;
             Canvas.SetZIndex(WinTextButton, -1);
         }
         
         private void NewGame_Click(object sender, RoutedEventArgs e)
         {
             Button b = (Button)sender;

             this._turn = true;
             this._turnCount = 0;

             A1.IsEnabled = true;
             A2.IsEnabled = true;
             A3.IsEnabled = true;
             B1.IsEnabled = true;
             B2.IsEnabled = true;
             B3.IsEnabled = true;
             C1.IsEnabled = true;
             C2.IsEnabled = true;
             C3.IsEnabled = true;

             A1.Content = "";
             A2.Content = "";
             A3.Content = "";
             B1.Content = "";
             B2.Content = "";
             B3.Content = "";
             C1.Content = "";
             C2.Content = "";
             C3.Content = "";

             if (b.Name == "NewGame2" || WinTextButton.Opacity > 0.1)
             {
                 HideAnimation();
             }
         }

         private void ResetGame_Click(object sender, RoutedEventArgs e)
         {
             TotalScoreA.Text = "0";
             TotalScoreB.Text = "0";
         }
    }
}
