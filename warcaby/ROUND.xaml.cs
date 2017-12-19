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
using System.Windows.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace warcaby
{
    /// <summary>
    /// Interaction logic for round.xaml
    /// </summary>

    public partial class ROUND : Window
    {
        int game_time, round_bonus;//max time for move by one player in minutes and value of bonus in seconds
        public static Button [,] round_table = new Button[8, 8]; //main table for pawns(buttons)
        public static Grid[] grid_contener = new Grid[1];// table for grid. Grid is defined in xaml file - ROUND.xaml.cs. Table for grid is for using grid beetwen *.cs files
        public static bool [] bonus_table = new bool[2];//table for checking who can get bonus

        WARCAB warcab = new WARCAB();
        public bool isBonus_p2;
        
        public bool bonus_p2
        {
            get { return this.isBonus_p2; }
            set { isBonus_p2 = value; }
        }
        //timers fo player1, player2 and total game time
        DispatcherTimer _timer1, _timer2;
        TimeSpan _time1, _time2;
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string currentTime = string.Empty;
       

        public void bunus_test_Click(object sender, RoutedEventArgs e)//wyjebać potem to
        {
            bonus_p2 = true;
        }
        public ROUND()
        {
        }
        public ROUND(PLAYER player1, PLAYER player2, int Game_time, int Round_bonus)
        {
            InitializeComponent();
            p1_show_name_textbox.Text = player1.p_name;//showing player 1 name declarated before you start round in game.cs, p1_show_name_textbox.Text- defined in game.xaml.cs
            p2_show_name_textbox.Text = player2.p_name;
            game_time = Game_time;
            round_bonus = Round_bonus;
            player1_timer(game_time);
            player2_timer(game_time);

            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            sw.Start();
            dt.Start();
            set_checker();
        }

        public void player1_timer(int game_time)//timer for player1 displayed on round window
        {
            _time1 = TimeSpan.FromMinutes(game_time);            
            _timer1 = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                countdown_textBlock_p1.Text = _time1.ToString("c");
                if (_time1 == TimeSpan.Zero) _timer1.Stop();
                if (bonus_table[0] == true)
                {
                    _time1 = _time1.Add(TimeSpan.FromSeconds(round_bonus)); bonus_table[0] = false;
                }
                else { _time1 = _time1.Add(TimeSpan.FromSeconds(-1)); }
                _time1 = _time1.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer1.Start();
        }
        public void player2_timer(int game_time)//timer for player2 displayed on round window
        {
            _time2 = TimeSpan.FromMinutes(game_time);
            _timer2 = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                countdown_textBlock_p2.Text = _time2.ToString("c");
                if (_time2 == TimeSpan.Zero) _timer2.Stop();
                if (bonus_table[1] == true) {
                    _time2 = _time2.Add(TimeSpan.FromSeconds(round_bonus)); bonus_table[1] = false;} else { _time2 = _time2.Add(TimeSpan.FromSeconds(-1)); }
            }, Application.Current.Dispatcher);

            _timer2.Start();           
        }
        void dt_Tick(object sender, EventArgs e)//displaying game time in round window
        {            
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                timer_textBlock.Text = currentTime;            
        }
        public void set_checker()//function setting chessboard for first round
        {            
            for(int i=0;i<=2;i++)//second player
            {
                for(int j=0;j<=7;j++)
                {
                    if (i == 1)
                    {
                        round_table[i, j] = warcab.create_warcab(i, j, 2);
                        grid.Children.Add(round_table[i, j]);
                        j++;
                    }
                    else
                    {                       
                            j++;
                        if (j == 8) { }
                        else
                        {
                            round_table[i, j] = warcab.create_warcab(i, j, 2);
                            grid.Children.Add(round_table[i, j]);                           
                        }
                    }
                }
            }

            for(int i=3;i<=4;i++)//empty area beetween players
            {
                for(int j = 0; j <= 7; j++)
                {
                    if((i==3)&&(j<8))
                    {
                        round_table[i, j] = warcab.create_warcab(i, j, 0);
                        grid.Children.Add(round_table[i, j]);
                        j++;
                    }
                    if ((i == 4) && (j < 8))
                    {
                        j++;
                        round_table[i, j] = warcab.create_warcab(i, j, 0);
                        grid.Children.Add(round_table[i, j]);                        
                    }
                }
            }
            for (int i = 5; i <= 7; i++)//first player
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (i == 5)
                    {
                        round_table[i, j] = warcab.create_warcab(i, j, 1);
                        grid.Children.Add(round_table[i, j]);
                        j++;
                    }
                    else if(i==6)
                    {
                        j++;
                        round_table[i, j] = warcab.create_warcab(i, j, 1);
                        grid.Children.Add(round_table[i, j]);
                    }
                    else
                    {                       
                        if (j == 8) { }
                        else
                        {
                            round_table[i, j] = warcab.create_warcab(i, j, 1);
                            grid.Children.Add(round_table[i, j]);
                            j++;
                        }
                    }
                }
            }

            grid_contener[0] = grid;//put grid to table to call to another class
        }        
    }

}