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

namespace warcaby
{
    public partial class WARCAB : Window
    {
        public static Button[] click_table = new Button[2];
        private static int _click_counter = 0;
        private static bool p1_was_moved = true;
        private static bool p2_was_moved = false;
        public static bool p1_moved
        {
            get { return p1_was_moved; }
            set { p1_was_moved = value; }
        }
        public static bool p2_moved
        {
            get { return p2_was_moved; }
            set { p2_was_moved = value; }
        }

        public static int click_counter
        {
            get
            {
                // Reads are usually simple
                return _click_counter;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
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
                if ((p1_moved == true && p2_moved == false) && (click_table[0].Content.ToString()=="1" || click_table[0].Content.ToString() == "11"))
                {
                    start_round(sender, click_counter);
                    p1_moved = false;
                    p2_moved = true;
                }
                else if ((p1_moved == false && p2_moved == true) && (click_table[0].Content.ToString() == "2" || click_table[0].Content.ToString() == "22"))
                {
                    start_round(sender, click_counter);
                    p1_moved = true;
                    p2_moved = false;
                }
                else
                    MessageBox.Show("Na chuj sie wpierdalasz kondomie jebany? Nie Twoja kolej");
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
                MessageBox.Show("Popierdolony jesteś ?");//message if not

            else if
                 (
                  ((click_table[0].Content.ToString() != "11") && (click_table[0].Content.ToString() != "22"))
                  && (fight(player_1_or_2, i_position, j_position, i_position_target, j_position_target, false) == true)
                 )//checking possibility to make a pawn
            {
                swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);   //function to swap two pawns
                if (click_table[0].Content.ToString() == "2") ROUND.bonus_table[1] = true;//it gives X seconds bonus time, declarated before you run game
                if (click_table[0].Content.ToString() == "1") ROUND.bonus_table[0] = true;
            }
            else if ((click_table[0].Content.ToString() == "11") || (click_table[0].Content.ToString() == "22")) //if player 1 or 2 queen's move
            {
                fight(player_1_or_2, i_position, j_position, i_position_target, j_position_target, true);
                swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);
                click_counter = 0;
            }
            else//if move is possible, but not making pawn
            {
                if ((move.find_neighbor(0, player_1_or_2, i_position, j_position, i_position_target, j_position_target, false) == true) //looking for pawn opponent  && zabezpieczenie przed przeskokiem o dwie pozycje
                    && (move.empty_move(player_1_or_2, i_position, j_position, (i_position_target), (j_position_target)) == true))
                {
                    swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);
                    if (click_table[0].Content.ToString() == "2") ROUND.bonus_table[1] = true;
                    if (click_table[0].Content.ToString() == "1") ROUND.bonus_table[0] = true;
                }
                else//empty move
                {
                    if (move.empty_move(player_1_or_2, i_position, j_position, i_position_target, j_position_target) == true)//zabezpieczenie rzed robieniem kroku w tył
                    {
                        swap(tmp_margin1, i_position, j_position, i_position_target, j_position_target);//i robie pusty ruch
                        if (click_table[0].Content.ToString() == "2")
                            ROUND.bonus_table[1] = true;
                        if (click_table[0].Content.ToString() == "1") ROUND.bonus_table[0] = true;
                    }
                    else
                        MessageBox.Show("Popierdolony jesteś ?");
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
        public bool fight(string player_1_or_2,int i_position, int j_position, int i_position_target, int j_position_target,bool queen_move)// function for checking possibility to make pawn
        {
            bool fight = false;
            MOVE move = new MOVE();
            int value_to_opponent = 0; 
            if (queen_move != true)
                value_to_opponent = 1;
            else
                value_to_opponent = (Math.Abs(i_position - i_position_target))-1;

            if ((i_position - 2 >= 0)  && (j_position + 2 <= 7))//right up
            {
                if (

                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position - value_to_opponent, j_position + value_to_opponent, queen_move) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position - (value_to_opponent+1), j_position + (value_to_opponent + 1), i_position - 1, j_position + 1, queen_move) == true) &&
                    ((i_position - (value_to_opponent + 1) == i_position_target) && (j_position + (value_to_opponent + 1) == j_position_target)))
                    && 
                    (ROUND.round_table[i_position- value_to_opponent, j_position+ value_to_opponent].Content.ToString()!="0")
                    )
                {
                    fight = true;
                    grid.Children.Remove(ROUND.round_table[i_position - value_to_opponent, j_position + value_to_opponent]);
                    ROUND.round_table[i_position - value_to_opponent, j_position + value_to_opponent] = create_warcab(i_position - value_to_opponent, j_position + value_to_opponent, 0);
                    grid.Children.Add(ROUND.round_table[i_position - value_to_opponent, j_position + value_to_opponent]);
                }
            }
            if ((i_position + 2 <= 7) && (j_position + 2 <= 7))//right down
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position + value_to_opponent, j_position + value_to_opponent, queen_move) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position + (value_to_opponent+1), j_position + (value_to_opponent+1), i_position + 1, j_position + 1, queen_move) == true) &&
                    ((i_position + (value_to_opponent+1) == i_position_target) && (j_position + (value_to_opponent+1) == j_position_target)))
                    &&
                    (ROUND.round_table[i_position + value_to_opponent, j_position + value_to_opponent].Content.ToString() != "0")
                    )
                {
                    fight = true;
                    grid.Children.Remove(ROUND.round_table[i_position + value_to_opponent, j_position + value_to_opponent]);
                    ROUND.round_table[i_position + value_to_opponent, j_position + value_to_opponent] = create_warcab(i_position + value_to_opponent, j_position + value_to_opponent, 0);
                    grid.Children.Add(ROUND.round_table[i_position + value_to_opponent, j_position + value_to_opponent]);
                }
            }
            if ((i_position -2 <= 7) && (j_position - 2 <= 7))//left up
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position - value_to_opponent, j_position - value_to_opponent, queen_move) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position - (value_to_opponent+1), j_position - (value_to_opponent+1), i_position - 1, j_position - 1, queen_move) == true) &&
                    ((i_position - (value_to_opponent+1) == i_position_target) && (j_position - (value_to_opponent+1) == j_position_target)))
                    &&
                    (ROUND.round_table[i_position - value_to_opponent, j_position - value_to_opponent].Content.ToString() != "0")
                    )
                {
                    fight = true;
                    grid.Children.Remove(ROUND.round_table[i_position - value_to_opponent, j_position - value_to_opponent]);
                    ROUND.round_table[i_position - value_to_opponent, j_position - value_to_opponent] = create_warcab(i_position - value_to_opponent, j_position - value_to_opponent, 0);
                    grid.Children.Add(ROUND.round_table[i_position - value_to_opponent, j_position - value_to_opponent]);
                }
            }
            if ((i_position + 2 <= 7) && (j_position - 2 <= 7))//left up
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position + value_to_opponent, j_position - value_to_opponent, queen_move) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position + (value_to_opponent+1), j_position - (value_to_opponent+1), i_position + 1, j_position - 1, queen_move) == true) &&
                    ((i_position + (value_to_opponent+1) == i_position_target) && (j_position - (value_to_opponent+1) == j_position_target)))
                    &&
                    (ROUND.round_table[i_position + value_to_opponent, j_position - value_to_opponent].Content.ToString() != "0")
                    )
                {
                    fight = true;
                    grid.Children.Remove(ROUND.round_table[i_position + value_to_opponent, j_position - value_to_opponent]);
                    ROUND.round_table[i_position + value_to_opponent, j_position - value_to_opponent] = create_warcab(i_position + value_to_opponent, j_position - value_to_opponent, 0);
                    grid.Children.Add(ROUND.round_table[i_position + value_to_opponent, j_position - value_to_opponent]);
                }
            }
            return fight;

        }
    }
}
