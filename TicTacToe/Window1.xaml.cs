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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Modes mode;

        public Window1()
        {
            InitializeComponent();

            CB_Mode1.IsChecked = true;
            CB_Size1.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CB_Size1.IsChecked==true)
            {
                this.Hide();
                Game _game = new Game(mode);
                _game.ShowDialog();
            }
           else
            {
                this.Hide();
                Game5x5 _game = new Game5x5(mode);
                _game.ShowDialog();
            }
        }


        private void CB_Mode1_Checked(object sender, RoutedEventArgs e)
        {
            mode = Modes.WithPlayer;
            CB_Mode2.IsChecked = false;
            CB_Mode3.IsChecked = false;
        }

        private void CB_Mode2_Checked(object sender, RoutedEventArgs e)
        {
            mode = Modes.WithAI;
            CB_Mode1.IsChecked = false;
            CB_Mode3.IsChecked = false;
        }

        private void CB_Mode3_Checked(object sender, RoutedEventArgs e)
        {
            mode = Modes.AItoAI;
            CB_Mode2.IsChecked = false;
            CB_Mode1.IsChecked = false;
        }

        private void CB_Size1_Checked(object sender, RoutedEventArgs e)
        {
            CB_Size2.IsChecked = false;
        }

        private void CB_Size2_Checked(object sender, RoutedEventArgs e)
        {
            CB_Size1.IsChecked = false;
        }
    }
}
