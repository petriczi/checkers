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
    public partial class ROUND : Window
    {       

        public static Button [,] round_table = new Button[8, 8]; //main table for pawns(buttons)
        public static Grid[] grid_contener = new Grid[1];// table for grid. Grid is defined in xaml file - ROUND.xaml.cs. Table for grid is for using grid beetwen *.cs files
        WARCAB warcab = new WARCAB();
        public bool isBonus_p2;   
        public bool bonus_p2
        {
            get { return this.isBonus_p2; }
            set { isBonus_p2 = value; }
        }
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
        public ROUND(PLAYER player1, PLAYER player2)
        {
            InitializeComponent();
            p1_show_name_textbox.Text = player1.p_name;//showing player 1 name declarated before you start round in game.cs, p1_show_name_textbox.Text- defined in game.xaml.cs
            p2_show_name_textbox.Text = player2.p_name;
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            sw.Start();
            dt.Start();
            set_checker();
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

        private void p1_resign_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Białe przegrały");
            System.Windows.Application.Current.Shutdown();
        }

        private void p2_resign_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Czarne przegrały");
            System.Windows.Application.Current.Shutdown();
        }
    }

}