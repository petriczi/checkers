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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace warcaby
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GAME : Window
    {
        int game_time, round_bonus;//max game time for one player and round bonus. Values are setting in game window
        PLAYER player1 = new PLAYER(1);
        PLAYER player2 = new PLAYER(2);

        public GAME()
        {
            InitializeComponent();
        }

        private void game_time_textbox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void round_bonus_textbox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void no_time_limit_checkBox_Checked(object sender, RoutedEventArgs e)//if user click checkbox in game window
        {
            game_time_textbox.Text = "brak";//game_time_textbox and round_bonus_textbox are defined in game.xaml
            round_bonus_textbox.Text = "brak";
        }
        private void no_time_limit_checkBox_unChecked(object sender, RoutedEventArgs e)//if user unclick checkbox in game window
        {
            game_time_textbox.Text = "10";
            round_bonus_textbox.Text = "10";
        }

        private void temp_TextChanged(object sender, TextChangedEventArgs e) { }
        public void next_button_Click(object sender, RoutedEventArgs e)
        {
            if (no_time_limit_checkBox.IsChecked == true)////if user click checkbox in game window
            {
                game_time = 0;
                round_bonus = 0;
                player1.create_name(p1_name_input.Text);//argument is name entered in game window
                player2.create_name(p2_name_input.Text);
                ROUND round = new ROUND(this.player1, this.player2, this.game_time, this.round_bonus);
                this.Close();//closing first findow after run program
                round.ShowDialog();//showing round window
            }
            else
            {
                string Str = game_time_textbox.Text.Trim();
                double Num;
                string Str2 = round_bonus_textbox.Text.Trim();
                double Num2;
                bool isNum = double.TryParse(Str, out Num);
                bool isNum2 = double.TryParse(Str2, out Num2);
                if (isNum && isNum2)
                {
                    game_time = int.Parse(game_time_textbox.Text);
                    round_bonus = int.Parse(round_bonus_textbox.Text);
                    player1.create_name(p1_name_input.Text);//argument is name entered in game window
                    player2.create_name(p2_name_input.Text);
                    ROUND round = new ROUND(this.player1, this.player2, this.game_time, this.round_bonus);
                    this.Close();//closing first findow after run program
                    round.ShowDialog();//showing round window
                }
                else
                    MessageBox.Show("WPROWADŹ CYFRĘ     dałnie!");               
            }
           
            
        }
    }
}