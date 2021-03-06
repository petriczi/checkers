﻿using System;
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

namespace warcaby
{
    public partial class WARCAB : Window
    {
        public static Button[] click_table = new Button[2];
        private static int _click_counter = 0;
        public static int click_counter
        {
            get
            {               
                return _click_counter;
            }
            set
            {
                _click_counter = value;
            }
        }
        Grid grid = new Grid();
        public WARCAB() { }  
        public Thickness get_coordinate(int i,int j)//coordinates for buttons on the board
        {                                           // i,j- positions on chessboard table
            Margin = new Thickness();
            if ((i == 0) && (j == 1))
            {
                Margin = new Thickness(68, 20, 315, 502);

            }
            if ((i == 0) && (j == 3))
            {
                Margin = new Thickness(163, 20, 220, 502);
            }
            if ((i == 0) && (j == 5))
            {
                Margin = new Thickness(258, 20, 125, 502);
            }
            if ((i == 0) && (j == 7))
            {
                Margin = new Thickness(354, 20, 29, 502);
            }
            if ((i == 1) && (j == 0))
            {
                Margin = new Thickness(20, 66, 363, 456);
            }
            if ((i == 1) && (j == 2))
            {
                Margin = new Thickness(115, 66, 268, 456);
            }
            if ((i == 1) && (j == 4))
            {
                Margin = new Thickness(211, 66, 172, 456);
            }
            if ((i == 1) && (j == 6))
            {
                Margin = new Thickness(306, 66, 77, 456);
            }
            if ((i == 2) && (j == 1))
            {
                Margin = new Thickness(67, 113, 316, 409);
            }
            if ((i == 2) && (j == 3))
            {
                Margin = new Thickness(163, 113, 220, 409);
            }
            if ((i == 2) && (j == 5))
            {
                Margin = new Thickness(258, 113, 125, 409);
            }
            if ((i == 2) && (j == 7))
            {
                Margin = new Thickness(354, 113, 29, 409);
            }
            if ((i == 3) && (j == 0))
            {
                Margin = new Thickness(14, 155, 357, 355);
            }

            if ((i == 3) && (j == 2))
            {
               Margin = new Thickness(110, 155, 261, 355);
            }
            if ((i == 3) && (j == 4))
            {
                Margin = new Thickness(205, 155, 166, 355);
            }

            if ((i == 3) && (j == 6))
            {
                Margin = new Thickness(300, 155, 71, 355);
            }

            if ((i == 4) && (j == 1))
            {
                Margin = new Thickness(62, 203, 309, 307);
            }    

            if ((i == 4) && (j == 3))
            {
                Margin = new Thickness(157, 203, 214, 307);
            }

            if ((i == 4) && (j == 5))
            {
                Margin = new Thickness(252, 203, 119, 307);
            }

            if ((i == 4) && (j == 7))
            {
               Margin = new Thickness(348, 203, 23, 307);
            }
            if ((i == 5) && (j == 0))
            {
                Margin = new Thickness(15, 251, 356, 259);
            }
            if ((i == 5) && (j == 2))
            {
                Margin = new Thickness(115, 257, 268, 265);
            }
           if ((i == 5) && (j == 4))
            {
                Margin = new Thickness(211, 257, 172, 265);
            }
            if ((i == 5) && (j == 6))
            {
                Margin = new Thickness(306, 257, 77, 265);
            }
            if ((i == 6) && (j == 1))
            {
                Margin = new Thickness(69, 304, 314, 218);
            }
            if ((i == 6) && (j == 3))
            {
                Margin = new Thickness(163, 304, 220, 218);
            }
            if ((i == 6) && (j == 5))
            {
                Margin = new Thickness(258, 304, 125, 218);
            }

            if ((i == 6) && (j == 7))
            {
                Margin = new Thickness(354, 304, 29, 218);
            }
            if ((i == 7) && (j == 0))
            {
                Margin = new Thickness(20, 352, 363, 170);
            }
            if ((i == 7) && (j == 2))
            {
                Margin = new Thickness(115, 352, 268, 170);
            }
            if ((i == 7) && (j == 4))
            {
                Margin = new Thickness(210, 352, 173, 170);
            }
            if ((i == 7) && (j == 6))
            {
                Margin = new Thickness(306, 352, 77, 170);
            }
              return Margin;
        }
        
        public  Button create_warcab(int i,int j,int player)//the function creates a pawns(buttons) for players
        {
            string p1_skin = "files/p1.png";
            string p2_skin = "files/p2.png";
            string p1_queen_skin = "files/p1queen.png";
            string p2_queen_skin = "files/p2queen.png";
            string empty_area = "files/empty_area.png";
            Thickness _margin = get_coordinate(i, j);
            Button button = new Button();            
            if (player==2)//secon player
            {
                button.Margin = _margin;
                button.Content = player.ToString();
                button.Width = 36;
                button.Height = 36;
                button.Name = "button_" +i.ToString() + j.ToString();
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(p2_skin, UriKind.Relative)) };
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Nbutton_Click));
                button.Foreground = new SolidColorBrush(Colors.Transparent);
            }
            if (player == 22)//queen second player
            {
                button.Margin = _margin;
                button.Content = player.ToString();
                button.Width = 36;
                button.Height = 36;
                button.Name = "button_" + i.ToString() + j.ToString();
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(p2_queen_skin, UriKind.Relative)) };
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Nbutton_Click));
                button.Foreground = new SolidColorBrush(Colors.Transparent);
            }
            if (player==0)//empty area
            {
                button.Margin = _margin;
                button.Content = player.ToString();
                button.Width = 46;
                button.Height = 46;
                button.Name = "button_" + i.ToString() + j.ToString();
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Nbutton_Click));
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(empty_area, UriKind.Relative)) };
                button.Foreground= new SolidColorBrush(Colors.Transparent);
            }
            
            if (player==1)//first player
            {
                button.Margin = _margin;
                button.Content = player.ToString();
                button.Width = 36;
                button.Height = 36;
                button.Name = "button_" + i.ToString() + j.ToString();
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(p1_skin, UriKind.Relative)) };
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Nbutton_Click));
                button.Foreground = new SolidColorBrush(Colors.Transparent);
            }
            if (player == 11)//queen first player
            {
                button.Margin = _margin;
                button.Content = player.ToString();
                button.Width = 36;
                button.Height = 36;
                button.Name = "button_" + i.ToString() + j.ToString();
                button.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(p1_queen_skin, UriKind.Relative)) };
                button.BorderBrush = new SolidColorBrush(Colors.Transparent);
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Nbutton_Click));
                button.Foreground = new SolidColorBrush(Colors.Transparent);
            }
            return button;           
        }
        
        public void Nbutton_Click(object sender, EventArgs e)//main function for moving a pawn for one position to another position
        {
            
            grid = ROUND.grid_contener[0];// table for grid. Grid is defined in xaml file - ROUND.xaml.cs. Table for grid is for using grid beetwen *.cs files
            click_counter++;
            if (click_counter == 1)//if player click on pawn
            {
                Button tmp_button1 = sender as Button;
                click_table[0] = tmp_button1;
            }
            else//if player click second time for position to move
            {
                click_counter = 0;               
                start_round(sender, click_counter);                    
                check_winner(1, "2", "22");               
                check_winner(2, "1", "11");

            }
            
        }
        public void check_winner(int who_player,string opponent_pawn, string opponent_queen)
        {
            int opponent_counter=0;
            for(int i=0;i<=7;i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if(ROUND.round_table[i, j] == null) { }
                    else
                        if ((ROUND.round_table[i, j].Content.ToString() == opponent_pawn) || (ROUND.round_table[i, j].Content.ToString() == opponent_queen))                        
                            opponent_counter++;
                        
                }
            }
            if((opponent_counter==0) && (who_player==1))
            {
                MessageBox.Show("Czarne przegrały");
                System.Windows.Application.Current.Shutdown();
            }
            else if ((opponent_counter == 0) && (who_player == 2))
            {
                MessageBox.Show("Białe przegrały");
                System.Windows.Application.Current.Shutdown();
            }
        }

        public void start_round(object sender, int tmp_click_counter)
        {
            MOVE move = new MOVE();
            Button tmp_button2 = sender as Button;
            click_table[1] = tmp_button2;
            click_counter = tmp_click_counter;
            string player_1_or_2 = click_table[0].Content.ToString();
            Thickness tmp_margin1 = WARCAB.click_table[0].Margin;
            int i_position = int.Parse(click_table[0].Name.Substring(7, 1));// i,j- actual positon of pawn
            int j_position = int.Parse(click_table[0].Name.Substring(8, 1));
            int i_position_target = int.Parse(click_table[1].Name.Substring(7, 1));
            int j_position_target = int.Parse(click_table[1].Name.Substring(8, 1));
            if ((move.check_possibilities(i_position, j_position, i_position_target, j_position_target)) == false)//checking possibility to move
                MessageBox.Show("Zły ruch");//message if not
            else if
                 (
                  ((click_table[0].Content.ToString() != "11") && (click_table[0].Content.ToString() != "22"))
                  && (move.fight(player_1_or_2, i_position, j_position, i_position_target, j_position_target) == true)
                 )//checking possibility to make a pawn
            {
                swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);   //function to swap two pawns
            }
            else if ((click_table[0].Content.ToString() == "11") || (click_table[0].Content.ToString() == "22")) //if player 1 or 2 queen's move
            {
                int value_to_target = Math.Abs(i_position_target - i_position);
                if ((i_position == i_position_target) || (j_position == j_position_target))
                    MessageBox.Show("Pojebało Cie?");
                else if (value_to_target==2)
                {
                    move.fight(player_1_or_2, i_position, j_position, i_position_target, j_position_target);
                    swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);
                }
                else
                {
                    move.queen_multi_move(value_to_target,i_position,j_position,i_position_target,j_position_target);
                    swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);
                }                
                click_counter = 0;
            }
            else//if move is possible, but not making pawn
            {
                if ((move.find_neighbor(0, player_1_or_2, i_position, j_position, i_position_target, j_position_target) == true) //looking for pawn opponent  && zabezpieczenie przed przeskokiem o dwie pozycje
                    && (move.empty_move(player_1_or_2, i_position, j_position, (i_position_target), (j_position_target)) == true))
                {
                    swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);

                }
                else//empty move
                {
                    if (move.empty_move(player_1_or_2, i_position, j_position, i_position_target, j_position_target) == true)//zabezpieczenie rzed robieniem kroku w tył
                    {
                        swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);//i robie pusty ruch
                    }
                    else
                        MessageBox.Show("Zly ruch");
                }
            }
            move.queen_possibility();
        }

        public void swap(Thickness tmp_margin1, int i_position, int j_position, int i_position_target, int j_position_target)//this function swaping your pawn with empty area
        {
            grid.Children.Remove(ROUND.round_table[i_position, j_position]);
            grid.Children.Remove(ROUND.round_table[i_position_target, j_position_target]);
            click_table[0].Margin = click_table[1].Margin;
            click_table[1].Margin = tmp_margin1;
            ROUND.round_table[i_position, j_position] = click_table[1];
            ROUND.round_table[i_position_target, j_position_target] = click_table[0];
            ROUND.round_table[i_position, j_position].Content = click_table[1].Content;
            ROUND.round_table[i_position_target, j_position_target].Content = click_table[0].Content;
            ROUND.round_table[i_position, j_position].Name = "button_" + i_position.ToString() + j_position.ToString();
            ROUND.round_table[i_position_target, j_position_target].Name = "button_" + i_position_target.ToString() + j_position_target.ToString();
            ROUND.round_table[i_position, j_position].Width = 46;
            ROUND.round_table[i_position, j_position].Height = 46;
            grid.Children.Add(ROUND.round_table[i_position, j_position]);
            grid.Children.Add(ROUND.round_table[i_position_target, j_position_target]);
        }
       
    }
}
