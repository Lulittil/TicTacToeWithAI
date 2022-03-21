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
    /// Логика взаимодействия для Game5x5.xaml
    /// </summary>
    public partial class Game5x5 : Window
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

        int[] table = new int[25];

        public Game5x5(Modes mode)
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
                    if (step == WhichStep.AI)
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

        private void Player_step(object sender, RoutedEventArgs e)
        {
            if (step == WhichStep.FirstPlayer)
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
            else if (step == WhichStep.SecondPlayer)
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
            else if (step == WhichStep.FirstPlayerWithAI)
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

        private void RunAI()
        {
            _AImove = IsAIMove.AIMove;
            int sum1 = table[0] + table[1] + table[2] + table[3] + table[4];
            int sum2 = table[5] + table[6] + table[7] + table[8] +table[9];
            int sum3 = table[10] + table[11] + table[12] + table[13] + table[14];
            int sum4 = table[15] + table[16] + table[17] + table[18] + table[19];
            int sum5 = table[20] + table[21] + table[22] + table[23] + table[24];

            int sum6 = table[0] + table[5] + table[10] + table[15] + table[20];
            int sum7 = table[1] + table[6] + table[11] + table[16] + table[21];
            int sum8 = table[2] + table[7] + table[12] + table[17] + table[22];
            int sum9 = table[3] + table[8] + table[13] + table[18] + table[23];
            int sum10 = table[4] + table[9] + table[14] + table[19] + table[24];

            int sum11 = table[0] + table[6] + table[12] + table[18] + table[24];
            int sum12 = table[4] + table[8] + table[12] + table[16] + table[20];


            
            if (sum1 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            else if (sum2 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[9] == 0)
                {
                    Btn_10.Content = AIsymbol();
                    table[9] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum3 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[10] == 0)
                {
                    Btn_11.Content = AIsymbol();
                    table[10] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[11] == 0)
                {
                    Btn_12.Content = AIsymbol();
                    table[11] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[13] == 0)
                {
                    Btn_14.Content = AIsymbol();
                    table[13] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[14] == 0)
                {
                    Btn_15.Content = AIsymbol();
                    table[14] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum4 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[15] == 0)
                {
                    Btn_16.Content = AIsymbol();
                    table[15] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[17] == 0)
                {
                    Btn_18.Content = AIsymbol();
                    table[17] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[19] == 0)
                {
                    Btn_20.Content = AIsymbol();
                    table[19] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum5 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[21] == 0)
                {
                    Btn_22.Content = AIsymbol();
                    table[21] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[22] == 0)
                {
                    Btn_23.Content = AIsymbol();
                    table[22] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[23] == 0)
                {
                    Btn_24.Content = AIsymbol();
                    table[23] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum6 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[10] == 0)
                {
                    Btn_11.Content = AIsymbol();
                    table[10] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[15] == 0)
                {
                    Btn_16.Content = AIsymbol();
                    table[15] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum7 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[1] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[11] == 0)
                {
                    Btn_12.Content = AIsymbol();
                    table[11] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[21] == 0)
                {
                    Btn_22.Content = AIsymbol();
                    table[21] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum8 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[17] == 0)
                {
                    Btn_18.Content = AIsymbol();
                    table[17] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[22] == 0)
                {
                    Btn_23.Content = AIsymbol();
                    table[22] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum9 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[13] == 0)
                {
                    Btn_14.Content = AIsymbol();
                    table[13] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[23] == 0)
                {
                    Btn_24.Content = AIsymbol();
                    table[23] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum10 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[9] == 0)
                {
                    Btn_10.Content = AIsymbol();
                    table[9] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[14] == 0)
                {
                    Btn_15.Content = AIsymbol();
                    table[14] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[19] == 0)
                {
                    Btn_20.Content = AIsymbol();
                    table[19] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum11 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum12 == 12 && _AImove == IsAIMove.AIMove)
            {
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            if (sum1 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[1] == 0)
                {
                    Btn_2.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            else if (sum2 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[9] == 0)
                {
                    Btn_10.Content = AIsymbol();
                    table[9] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum3 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[10] == 0)
                {
                    Btn_11.Content = AIsymbol();
                    table[10] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[11] == 0)
                {
                    Btn_12.Content = AIsymbol();
                    table[11] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[13] == 0)
                {
                    Btn_14.Content = AIsymbol();
                    table[13] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[14] == 0)
                {
                    Btn_15.Content = AIsymbol();
                    table[14] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum4 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[15] == 0)
                {
                    Btn_16.Content = AIsymbol();
                    table[15] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[17] == 0)
                {
                    Btn_18.Content = AIsymbol();
                    table[17] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[19] == 0)
                {
                    Btn_20.Content = AIsymbol();
                    table[19] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum5 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[21] == 0)
                {
                    Btn_22.Content = AIsymbol();
                    table[21] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[22] == 0)
                {
                    Btn_23.Content = AIsymbol();
                    table[22] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[23] == 0)
                {
                    Btn_24.Content = AIsymbol();
                    table[23] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum6 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[5] == 0)
                {
                    Btn_6.Content = AIsymbol();
                    table[5] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[10] == 0)
                {
                    Btn_11.Content = AIsymbol();
                    table[10] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[15] == 0)
                {
                    Btn_16.Content = AIsymbol();
                    table[15] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum7 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[1] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[1] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[11] == 0)
                {
                    Btn_12.Content = AIsymbol();
                    table[11] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[21] == 0)
                {
                    Btn_22.Content = AIsymbol();
                    table[21] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum8 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[2] == 0)
                {
                    Btn_3.Content = AIsymbol();
                    table[2] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[7] == 0)
                {
                    Btn_8.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[17] == 0)
                {
                    Btn_18.Content = AIsymbol();
                    table[17] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[22] == 0)
                {
                    Btn_23.Content = AIsymbol();
                    table[22] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum9 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[3] == 0)
                {
                    Btn_4.Content = AIsymbol();
                    table[3] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[7] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[13] == 0)
                {
                    Btn_14.Content = AIsymbol();
                    table[13] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[23] == 0)
                {
                    Btn_24.Content = AIsymbol();
                    table[23] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum10 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[9] == 0)
                {
                    Btn_10.Content = AIsymbol();
                    table[9] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[14] == 0)
                {
                    Btn_15.Content = AIsymbol();
                    table[14] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[19] == 0)
                {
                    Btn_20.Content = AIsymbol();
                    table[19] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum11 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[0] == 0)
                {
                    Btn_1.Content = AIsymbol();
                    table[0] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[6] == 0)
                {
                    Btn_7.Content = AIsymbol();
                    table[6] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[18] == 0)
                {
                    Btn_19.Content = AIsymbol();
                    table[18] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[24] == 0)
                {
                    Btn_25.Content = AIsymbol();
                    table[24] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }
            else if (sum12 == 40 && _AImove == IsAIMove.AIMove)
            {
                if (table[4] == 0)
                {
                    Btn_5.Content = AIsymbol();
                    table[4] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[8] == 0)
                {
                    Btn_9.Content = AIsymbol();
                    table[8] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[12] == 0)
                {
                    Btn_13.Content = AIsymbol();
                    table[12] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[16] == 0)
                {
                    Btn_17.Content = AIsymbol();
                    table[16] = 3;
                    _AImove = IsAIMove.NextStep;
                }
                else if (table[20] == 0)
                {
                    Btn_21.Content = AIsymbol();
                    table[20] = 3;
                    _AImove = IsAIMove.NextStep;
                }
            }

            if (_AImove == IsAIMove.AIMove)
            {
                int random = rnd.Next(0, 25);
                while (table[random] != 0)
                {
                    random = rnd.Next(0, 25);
                }
                table[random] = 3;
                if (random == 0) Btn_1.Content = AIsymbol();
                else if (random == 1) Btn_2.Content = AIsymbol();
                else if (random == 2) Btn_3.Content = AIsymbol();
                else if (random == 3) Btn_4.Content = AIsymbol();
                else if (random == 4) Btn_5.Content = AIsymbol();
                else if (random == 5) Btn_6.Content = AIsymbol();
                else if (random == 6) Btn_7.Content = AIsymbol();
                else if (random == 7) Btn_8.Content = AIsymbol();
                else if (random == 8) Btn_9.Content = AIsymbol();
                else if (random == 9) Btn_10.Content = AIsymbol();
                else if (random == 10) Btn_11.Content = AIsymbol();
                else if (random == 11) Btn_12.Content = AIsymbol();
                else if (random == 12) Btn_13.Content = AIsymbol();
                else if (random == 13) Btn_14.Content = AIsymbol();
                else if (random == 14) Btn_15.Content = AIsymbol();
                else if (random == 15) Btn_16.Content = AIsymbol();
                else if (random == 16) Btn_17.Content = AIsymbol();
                else if (random == 17) Btn_18.Content = AIsymbol();
                else if (random == 18) Btn_19.Content = AIsymbol();
                else if (random == 19) Btn_20.Content = AIsymbol();
                else if (random == 20) Btn_21.Content = AIsymbol();
                else if (random == 21) Btn_22.Content = AIsymbol();
                else if (random == 22) Btn_23.Content = AIsymbol();
                else if (random == 23) Btn_24.Content = AIsymbol();
                else if (random == 24) Btn_25.Content = AIsymbol();


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


            int random = rnd.Next(0, 25);
            while (table[random] != 0)
            {
                random = rnd.Next(0, 25);
            }
            table[random] = 10;
            if (random == 0) Btn_1.Content = AI2symbol();
            else if (random == 1) Btn_2.Content = AI2symbol();
            else if (random == 2) Btn_3.Content = AI2symbol();
            else if (random == 3) Btn_4.Content = AI2symbol();
            else if (random == 4) Btn_5.Content = AI2symbol();
            else if (random == 5) Btn_6.Content = AI2symbol();
            else if (random == 6) Btn_7.Content = AI2symbol();
            else if (random == 7) Btn_8.Content = AI2symbol();
            else if (random == 8) Btn_9.Content = AI2symbol();
            else if (random == 9) Btn_10.Content = AI2symbol();
            else if (random == 10) Btn_11.Content = AI2symbol();
            else if (random == 11) Btn_12.Content = AI2symbol();
            else if (random == 12) Btn_13.Content = AI2symbol();
            else if (random == 13) Btn_14.Content = AI2symbol();
            else if (random == 14) Btn_15.Content = AI2symbol();
            else if (random == 15) Btn_16.Content = AI2symbol();
            else if (random == 16) Btn_17.Content = AI2symbol();
            else if (random == 17) Btn_18.Content = AI2symbol();
            else if (random == 18) Btn_19.Content = AI2symbol();
            else if (random == 19) Btn_20.Content = AI2symbol();
            else if (random == 20) Btn_21.Content = AI2symbol();
            else if (random == 21) Btn_22.Content = AI2symbol();
            else if (random == 22) Btn_23.Content = AI2symbol();
            else if (random == 23) Btn_24.Content = AI2symbol();
            else if (random == 24) Btn_25.Content = AI2symbol();
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


        private void AddToTable(string btnName)
        {
            if (btnName == "Btn_1") table[0] = 10;
            if (btnName == "Btn_2") table[1] = 10;
            if (btnName == "Btn_3") table[2] = 10;
            if (btnName == "Btn_4") table[3] = 10;
            if (btnName == "Btn_5") table[4] = 10;
            if (btnName == "Btn_6") table[5] = 10;
            if (btnName == "Btn_7") table[6] = 10;
            if (btnName == "Btn_8") table[7] = 10;
            if (btnName == "Btn_9") table[8] = 10;
            if (btnName == "Btn_10") table[9] = 10;
            if (btnName == "Btn_11") table[10] = 10;
            if (btnName == "Btn_12") table[11] = 10;
            if (btnName == "Btn_13") table[12] = 10;
            if (btnName == "Btn_14") table[13] = 10;
            if (btnName == "Btn_15") table[14] = 10;
            if (btnName == "Btn_16") table[15] = 10;
            if (btnName == "Btn_17") table[16] = 10;
            if (btnName == "Btn_18") table[17] = 10;
            if (btnName == "Btn_19") table[18] = 10;
            if (btnName == "Btn_20") table[19] = 10;
            if (btnName == "Btn_21") table[20] = 10;
            if (btnName == "Btn_22") table[21] = 10;
            if (btnName == "Btn_23") table[22] = 10;
            if (btnName == "Btn_24") table[23] = 10;
            if (btnName == "Btn_25") table[24] = 10;


        }

        private string CheckWin()
        {
            if ((Btn_1.Content == "O" && Btn_2.Content == "O" && Btn_3.Content == "O"&&Btn_4.Content=="O"&&Btn_5.Content=="O") ||
                (Btn_6.Content == "O" && Btn_7.Content == "O" && Btn_8.Content == "O" && Btn_9.Content == "O" && Btn_10.Content == "O") ||
                (Btn_11.Content == "O" && Btn_12.Content == "O" && Btn_13.Content == "O" && Btn_14.Content == "O" && Btn_14.Content == "O") ||
                (Btn_16.Content == "O" && Btn_17.Content == "O" && Btn_18.Content == "O" && Btn_19.Content == "O" && Btn_20.Content == "O") ||
                (Btn_21.Content == "O" && Btn_22.Content == "O" && Btn_23.Content == "O" && Btn_24.Content == "O" && Btn_25.Content == "O") ||
                (Btn_1.Content == "O" && Btn_6.Content == "O" && Btn_11.Content == "O" && Btn_16.Content == "O" && Btn_21.Content == "O") ||
                (Btn_2.Content == "O" && Btn_7.Content == "O" && Btn_12.Content == "O" && Btn_17.Content == "O" && Btn_22.Content == "O") ||
                (Btn_3.Content == "O" && Btn_8.Content == "O" && Btn_13.Content == "O" && Btn_18.Content == "O" && Btn_23.Content == "O") ||
                (Btn_4.Content == "O" && Btn_9.Content == "O" && Btn_14.Content == "O" && Btn_19.Content == "O" && Btn_24.Content == "O") ||
                (Btn_5.Content == "O" && Btn_10.Content == "O" && Btn_15.Content == "O" && Btn_20.Content == "O" && Btn_25.Content == "O") ||
                (Btn_1.Content == "O" && Btn_7.Content == "O" && Btn_13.Content == "O" && Btn_19.Content == "O" && Btn_25.Content == "O") ||
                (Btn_5.Content == "O" && Btn_9.Content == "O" && Btn_13.Content == "O" && Btn_17.Content == "O" && Btn_21.Content == "O")
                )
            {
                WhoWin.Content = "O - win!";
                BlockButtons();
                return "O";
            }
            else if ((Btn_1.Content == "O" && Btn_2.Content == "O" && Btn_3.Content == "O" && Btn_4.Content == "O" && Btn_5.Content == "O") ||
                (Btn_6.Content == "O" && Btn_7.Content == "O" && Btn_8.Content == "O" && Btn_9.Content == "O" && Btn_10.Content == "O") ||
                (Btn_11.Content == "O" && Btn_12.Content == "O" && Btn_13.Content == "O" && Btn_14.Content == "O" && Btn_14.Content == "O") ||
                (Btn_16.Content == "O" && Btn_17.Content == "O" && Btn_18.Content == "O" && Btn_19.Content == "O" && Btn_20.Content == "O") ||
                (Btn_21.Content == "O" && Btn_22.Content == "O" && Btn_23.Content == "O" && Btn_24.Content == "O" && Btn_25.Content == "O") ||
                (Btn_1.Content == "O" && Btn_6.Content == "O" && Btn_11.Content == "O" && Btn_16.Content == "O" && Btn_21.Content == "O") ||
                (Btn_2.Content == "O" && Btn_7.Content == "O" && Btn_12.Content == "O" && Btn_17.Content == "O" && Btn_22.Content == "O") ||
                (Btn_3.Content == "O" && Btn_8.Content == "O" && Btn_13.Content == "O" && Btn_18.Content == "O" && Btn_23.Content == "O") ||
                (Btn_4.Content == "O" && Btn_9.Content == "O" && Btn_14.Content == "O" && Btn_19.Content == "O" && Btn_24.Content == "O") ||
                (Btn_5.Content == "O" && Btn_10.Content == "O" && Btn_15.Content == "O" && Btn_20.Content == "O" && Btn_25.Content == "O") ||
                (Btn_1.Content == "O" && Btn_7.Content == "O" && Btn_13.Content == "O" && Btn_19.Content == "O" && Btn_25.Content == "O") ||
                (Btn_5.Content == "O" && Btn_9.Content == "O" && Btn_13.Content == "O" && Btn_17.Content == "O" && Btn_21.Content == "O"))
            {
                WhoWin.Content = "X - win!";
                BlockButtons();
                return "X";
            }
            else if (table[0] != 0 && table[1] != 0 && table[2] != 0 && table[3] != 0 && table[4] != 0 && table[5] != 0 && table[6] != 0 && table[7] != 0 && table[8] != 0 &&
                table[9]!=0 && table[10] != 0 && table[11] != 0 && table[12] != 0 && table[13] != 0 && table[14] != 0 && table[15] != 0 && table[16] != 0 && table[17] != 0 &&
                 table[18] != 0 && table[19] != 0 && table[20] != 0 && table[21] != 0 && table[22] != 0 && table[23] != 0 && table[24] != 0 )
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
            Btn_10.IsEnabled = false;
            Btn_11.IsEnabled = false;
            Btn_12.IsEnabled = false;
            Btn_13.IsEnabled = false;
            Btn_14.IsEnabled = false;
            Btn_15.IsEnabled = false;
            Btn_16.IsEnabled = false;
            Btn_17.IsEnabled = false;
            Btn_18.IsEnabled = false;
            Btn_19.IsEnabled = false;
            Btn_20.IsEnabled = false;
            Btn_21.IsEnabled = false;
            Btn_22.IsEnabled = false;
            Btn_23.IsEnabled = false;
            Btn_24.IsEnabled = false;
            Btn_25.IsEnabled = false;
        }

        private void UnblockButtons()
        {
            Btn_1.IsEnabled = Btn_1.Content != "" ? false : true;
            Btn_2.IsEnabled = Btn_2.Content != "" ? false : true;
            Btn_3.IsEnabled = Btn_3.Content != "" ? false : true;
            Btn_4.IsEnabled = Btn_4.Content != "" ? false : true;
            Btn_5.IsEnabled = Btn_5.Content != "" ? false : true;
            Btn_6.IsEnabled = Btn_6.Content != "" ? false : true;
            Btn_7.IsEnabled = Btn_7.Content != "" ? false : true;
            Btn_8.IsEnabled = Btn_8.Content != "" ? false : true;
            Btn_9.IsEnabled = Btn_9.Content != "" ? false : true;
            Btn_10.IsEnabled = Btn_10.Content != "" ? false : true;
            Btn_11.IsEnabled = Btn_11.Content != "" ? false : true;
            Btn_12.IsEnabled = Btn_12.Content != "" ? false : true;
            Btn_13.IsEnabled = Btn_13.Content != "" ? false : true;
            Btn_14.IsEnabled = Btn_14.Content != "" ? false : true;
            Btn_15.IsEnabled = Btn_15.Content != "" ? false : true;
            Btn_16.IsEnabled = Btn_16.Content != "" ? false : true;
            Btn_17.IsEnabled = Btn_17.Content != "" ? false : true;
            Btn_18.IsEnabled = Btn_18.Content != "" ? false : true;
            Btn_19.IsEnabled = Btn_19.Content != "" ? false : true;
            Btn_20.IsEnabled = Btn_20.Content != "" ? false : true;
            Btn_21.IsEnabled = Btn_21.Content != "" ? false : true;
            Btn_22.IsEnabled = Btn_22.Content != "" ? false : true;
            Btn_23.IsEnabled = Btn_23.Content != "" ? false : true;
            Btn_24.IsEnabled = Btn_24.Content != "" ? false : true;
            Btn_25.IsEnabled = Btn_25.Content != "" ? false : true;
        }
    }
}
