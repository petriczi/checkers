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
using System.Media;


namespace warcaby
{

    public partial class GAME : Window
    {
        PLAYER player1 = new PLAYER(1);
        PLAYER player2 = new PLAYER(2);
        public GAME()
        {
            InitializeComponent();
            using (var soundPlayer = new SoundPlayer(@"files/menu.wav"))
            {
                soundPlayer.Play();
            }
        }

        private void game_time_textbox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void round_bonus_textbox_TextChanged(object sender, TextChangedEventArgs e) { }
        private void temp_TextChanged(object sender, TextChangedEventArgs e) { }
        public void next_button_Click(object sender, RoutedEventArgs e)
        {
          
                player1.create_name(p1_name_input.Text);//argument is name entered in game window
                player2.create_name(p2_name_input.Text);
                ROUND round = new ROUND(this.player1, this.player2);
                this.Close();//closing first findow after run program
                round.ShowDialog();//showing round window        
        }         
            
    }
}
