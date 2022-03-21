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
using TicTacToe.Models;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private Random rnd;

        private int player1Symbol;

        private int player2Symbol;

        private int AI1Symbol;

        private int AI2Symbol;

        private WhichStep step;

        private IsAIMove _AImove;

        public PlayDesk PlSt;

        public PlayDesk AIst;

        private Modes _mode;

        int[] table = new int[9];

        public Game(Modes mode)
        {
            InitializeComponent();

            _mode = mode;

            rnd = new Random();

            switch (mode)
            {
                case Modes.WithPlayer:
                    player1Symbol = rnd.Next(0, 2);  // 0 - O, 1 - X
                    player2Symbol = player1Symbol == 1 ? 0 : 1;
                    step = player1Symbol == 0 ? WhichStep.FirstPlayer : WhichStep.SecondPlayer;
                    break;
                case Modes.WithAI:
                    player1Symbol = rnd.Next(0, 2);  // 0 - O, 1 - X
                    AI1Symbol = player1Symbol == 1 ? 0 : 1;
                    if (player1Symbol == 0)
                    {
                        UnblockButtons();
                    }
                    step = player1Symbol == 0 ? WhichStep.FirstPlayerWithAI : WhichStep.AI;
                    if(step==WhichStep.AI)
                    {
                        RunAI();
                        step = WhichStep.FirstPlayerWithAI;
                        UnblockButtons();
                    }
                    break;
                case Modes.AItoAI:
                    AI1Symbol = rnd.Next(0, 2);  // 0 - O, 1 - X
                    AI2Symbol = player1Symbol == 1 ? 0 : 1;
                    RunAI();
                    break;
            }

                       
        }

        private void RunAI()
        {
            _AImove = IsAIMove.AIMove;
            int sum1 = table[0] + table[1] + table[2];
            int sum2 = table[3] + table[4] + table[5];
            int sum3 = table[6] + table[7] + table[8];
            int sum4 = table[0] + table[3] + table[6];
            int sum5 = table[1] + table[4] + table[7];
            int sum6 = table[2] + table[5] + table[8];
            int sum7 = table[0] + table[4] + table[8];
            int sum8 = table[2] + table[4] + table[6];

            if (sum1 == 6 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            else if (sum2 == 6  && _AImove == IsAIMove.AIMove)
            {
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum3 == 6 && _AImove == IsAIMove.AIMove)
            {
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum4 == 6  && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum5 == 6 && _AImove == IsAIMove.AIMove)
            {
                if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum6 == 6  && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum7 == 6 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum8 == 6  && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            if (sum1==2&&_AImove==IsAIMove.AIMove)
            {
                if(table[0]==0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            else if (sum2 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum3 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum4 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum5 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum6 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum7 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum8 == 2 && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            if(_AImove==IsAIMove.AIMove)
            {
                int random= rnd.Next(0, 9);
                while (table[random] != 0)
                {
                    random = rnd.Next(0, 9);
                } 
                table[random] = 3;
                if (random == 0) Btn_1.Content = AIsymbol();
                if (random == 1) Btn_2.Content = AIsymbol();
                if (random == 2) Btn_3.Content = AIsymbol();
                if (random == 3) Btn_4.Content = AIsymbol();
                if (random == 4) Btn_5.Content = AIsymbol();
                if (random == 5) Btn_6.Content = AIsymbol();
                if (random == 6) Btn_7.Content = AIsymbol();
                if (random == 7) Btn_8.Content = AIsymbol();
                if (random == 8) Btn_9.Content = AIsymbol();

            }

            _AImove = IsAIMove.NextStep;

            if (_mode == Modes.AItoAI)
            {

                if (CheckWin() == "")
                    RunSecondAI();
                else return;
            }
            else return;
        }

        private void RunSecondAI()
        {


            int random = rnd.Next(0, 9);
            while (table[random] != 0)
            {
                random = rnd.Next(0, 9);
            }
            table[random] = 1;
            if (random == 0) Btn_1.Content = AI2symbol();
            if (random == 1) Btn_2.Content = AI2symbol();
            if (random == 2) Btn_3.Content = AI2symbol();
            if (random == 3) Btn_4.Content = AI2symbol();
            if (random == 4) Btn_5.Content = AI2symbol();
            if (random == 5) Btn_6.Content = AI2symbol();
            if (random == 6) Btn_7.Content = AI2symbol();
            if (random == 7) Btn_8.Content = AI2symbol();
            if (random == 8) Btn_9.Content = AI2symbol();

            _AImove = IsAIMove.AIMove;

            RunAI();
        }

        private string AI2symbol()
        {
            if (AI2Symbol == 0) return "O";
            else return "X";
        }

        private string AIsymbol()
        {
            if (AI1Symbol == 0) return "O";
            else return "X";
        }

       

        private void Player_step(object sender, RoutedEventArgs e)
        {
            // 0 - main player, 1 - second player;
            if (step==WhichStep.FirstPlayer)
            {
                if (player1Symbol == 0)
                {
                    var btn = (Button)sender;
                    btn.Content = "O";
                    step = WhichStep.SecondPlayer;
                }
                else if (player1Symbol == 1)
                {
                    var btn = (Button)sender;
                    btn.Content = "X";
                    step = WhichStep.SecondPlayer;
                }
            }
            else if(step==WhichStep.SecondPlayer)
            {
                if (player2Symbol == 0)
                {
                    var btn = (Button)sender;
                    btn.Content = "O";
                    step = WhichStep.FirstPlayer;
                }
                else if (player2Symbol == 1)
                {
                    var btn = (Button)sender;
                    btn.Content = "X";
                    step = WhichStep.FirstPlayer;
                }
            }
    
            else if(step == WhichStep.FirstPlayerWithAI)
            {
                var btn = (Button)sender;

                if (player1Symbol == 0)
                {
                    btn.Content = "O";
                }
                else if (player1Symbol == 1)
                {
                    btn.Content = "X";
                }
                AddToTable(btn.Name);
                BlockButtons();
                RunAI();
            }

            UnblockButtons();
            CheckWin();
        }

        private void AddToTable(string btnName)
        {
            if (btnName == "Btn_1") table[0] = 1;
            if (btnName == "Btn_2") table[1] = 1;
            if (btnName == "Btn_3") table[2] = 1;
            if (btnName == "Btn_4") table[3] = 1;
            if (btnName == "Btn_5") table[4] = 1;
            if (btnName == "Btn_6") table[5] = 1;
            if (btnName == "Btn_7") table[6] = 1;
            if (btnName == "Btn_8") table[7] = 1;
            if (btnName == "Btn_9") table[8] = 1;

            Console.Write(table[0]+" "+table[1]+" "+table[2]+"\n");
            Console.Write(table[3] + " " + table[4] + " " + table[5] + "\n");
            Console.Write(table[6] + " " + table[7] + " " + table[8] + "\n");
        }


      
        private string CheckWin()
        {
            if ((Btn_1.Content == "O" && Btn_2.Content == "O" && Btn_3.Content == "O") ||
                (Btn_1.Content == "O" && Btn_4.Content == "O" && Btn_7.Content == "O") ||
                (Btn_3.Content == "O" && Btn_6.Content == "O" && Btn_9.Content == "O") ||
                (Btn_7.Content == "O" && Btn_8.Content == "O" && Btn_9.Content == "O") ||
                (Btn_3.Content == "O" && Btn_5.Content == "O" && Btn_7.Content == "O") ||
                (Btn_1.Content == "O" && Btn_5.Content == "O" && Btn_9.Content == "O") ||
                (Btn_2.Content=="O"&&Btn_5.Content=="O"&&Btn_8.Content=="O")||
                (Btn_4.Content=="O"&&Btn_5.Content=="O"&&Btn_6.Content=="O")
                )
            {
                WhoWin.Content = "O - win!";
                BlockButtons();
                return "O";
            }
            else if ((Btn_1.Content == "X" && Btn_2.Content == "X" && Btn_3.Content == "X") ||
                (Btn_1.Content == "X" && Btn_4.Content == "X" && Btn_7.Content == "X") ||
                (Btn_3.Content == "X" && Btn_6.Content == "X" && Btn_9.Content == "X") ||
                (Btn_7.Content == "X" && Btn_8.Content == "X" && Btn_9.Content == "X") ||
                (Btn_3.Content == "X" && Btn_5.Content == "X" && Btn_7.Content == "X") ||
                (Btn_1.Content == "X" && Btn_5.Content == "X" && Btn_9.Content == "X") ||
                (Btn_2.Content == "X" && Btn_5.Content == "X" && Btn_8.Content == "X") ||
                (Btn_4.Content == "X" && Btn_5.Content == "X" && Btn_6.Content == "X"))
            {
                WhoWin.Content = "X - win!";
                BlockButtons();
                return "X";
            }
            else if(table[0]!=0&& table[1] != 0 && table[2] != 0 && table[3] != 0 && table[4] != 0 && table[5] != 0 && table[6] != 0 && table[7] != 0 && table[8] != 0 )
            {
                WhoWin.Content = "No one won!";
                return "Nobody";
            }
            return "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 _settings = new Window1();
            _settings.ShowDialog();
        }

        private void BlockButtons()
        {
            Btn_1.IsEnabled = false;
            Btn_2.IsEnabled = false;
            Btn_3.IsEnabled = false;
            Btn_4.IsEnabled = false;
            Btn_5.IsEnabled = false;
            Btn_6.IsEnabled = false;
            Btn_7.IsEnabled = false;
            Btn_8.IsEnabled = false;
            Btn_8.IsEnabled = false;
            Btn_9.IsEnabled = false;
        }

        private void UnblockButtons()
        {
            Btn_1.IsEnabled = Btn_1.Content!=""? false : true;
            Btn_2.IsEnabled = Btn_2.Content != "" ? false : true;
            Btn_3.IsEnabled = Btn_3.Content != "" ? false : true;
            Btn_4.IsEnabled = Btn_4.Content != "" ? false : true;
            Btn_5.IsEnabled = Btn_5.Content != "" ? false : true;
            Btn_6.IsEnabled = Btn_6.Content != "" ? false : true;
            Btn_7.IsEnabled = Btn_7.Content != "" ? false : true;
            Btn_8.IsEnabled = Btn_8.Content != "" ? false : true;
            Btn_9.IsEnabled = Btn_9.Content != "" ? false : true;
        }
    }
}
