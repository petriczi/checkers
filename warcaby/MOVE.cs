﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace warcaby
{
    class MOVE//class to checking possibilities to move
    {
        Grid grid = new Grid();
        WARCAB warcab = new WARCAB();
        public MOVE()
        {     
            grid = ROUND.grid_contener[0];
        }

        public bool check_possibilities(int i_position, int j_position, int i_position_target, int j_position_target)
        {
            bool possible = true;            
            string p1 = WARCAB.click_table[0].Content.ToString();
            string p2 = WARCAB.click_table[1].Content.ToString();
            int fight_i_position = i_position;
            int fight_j_position = j_position;
            int fight_i_position_target = i_position_target;
            int figt_j_position_target = j_position_target;   

            if (p1 == p2) //próba zamian warcaba tego samego gracza
            {
                possible = false;
            }
            if((p1!="0") && (p2!="0"))//próba zamiany pionków przeciwnych graczy
            {
                possible = false;
            }      
           return possible;
        }

        public bool find_neighbor(int fight_first_validation,string player_1_or_2, int i_position, int j_position,int i_position_target, int j_position_target)//szuka sąsiada do bicia
        {
            string right_up, right_down, left_up, left_down;

            bool neighbor = false;
            if ((i_position>=0) && (i_position<=7) &&(j_position>=0) &&(j_position<=7) && (i_position_target>=0) && (i_position_target<=7) &&(j_position_target>=0) && (j_position_target<=7))
            {
                string actual_position = ROUND.round_table[i_position, j_position].Content.ToString();
                if (fight_first_validation == 1)                
                    if (actual_position == "1")
                        actual_position = "2";
                    else
                        actual_position = "1";               

                if ((i_position_target - 1 >= 0) && ((j_position_target +1) <= 7))
                    right_up = ROUND.round_table[i_position_target - 1, j_position_target + 1].Content.ToString(); //expected positions for neighbor
                else
                    right_up = "0";
                if (((i_position_target + 1) <= 7) && ((j_position_target + 1) <= 7))
                    right_down = ROUND.round_table[i_position_target + 1, j_position_target + 1].Content.ToString();
                else
                    right_down = "0";
                if (((i_position_target - 1) >= 0) && ((j_position_target - 1) >= 0))
                    left_up = ROUND.round_table[i_position_target - 1, j_position_target - 1].Content.ToString();
                else
                    left_up = "0";
                if (((i_position_target + 1) <= 7) && ((j_position_target - 1) >= 0))
                    left_down = ROUND.round_table[i_position_target + 1, j_position_target -1].Content.ToString();
                else
                    left_down = "0";
                if (((right_up != actual_position) && (right_up != "0")) || ((right_down != actual_position) && (right_down != "0")) || ((left_up != actual_position) && (left_up != "0")) || ((left_down != actual_position) && (left_down != "0")))//najpierw czy jest jakikolwiek sąsiad
                    neighbor = true;
            }
            return neighbor;
        }
        public bool empty_move(string player_1_or_2,int i_position, int j_position, int i_position_target, int j_position_target)
        {
            bool possible = false;
            if(player_1_or_2=="1")            
                if (
                    ((i_position_target == (i_position - 1)) && (j_position_target == (j_position + 1))) ||
                    ((i_position_target == (i_position - 1)) && (j_position_target == (j_position - 1)))
                    )
                        possible=true;// right up ||  left up

                if (player_1_or_2 == "2")
                    if (
                    ((i_position_target == (i_position + 1)) && (j_position_target == (j_position + 1))) ||
                    ((i_position_target == (i_position + 1)) && (j_position_target == (j_position - 1)))
                    )
                        possible = true;// right down||  left down
            return possible;
        }
        public void queen_possibility()
        {
            for (int a = 1; a <= 7;)//searching p1 queen on p2 area
            {
                if (ROUND.round_table[0, a].Content.ToString() == "1")
                {
                    grid.Children.Remove(ROUND.round_table[0, a]);
                    ROUND.round_table[0, a] = warcab.create_warcab(0, a, 11);
                    grid.Children.Add(ROUND.round_table[0, a]);
                }
                a = a + 2;
            }
            for (int a = 0; a <= 6;)
            {
                if (ROUND.round_table[7, a].Content.ToString() == "2")
                {
                    grid.Children.Remove(ROUND.round_table[7, a]);
                    ROUND.round_table[7, a] = warcab.create_warcab(7, a, 22);
                    grid.Children.Add(ROUND.round_table[7, a]);
                }
                a = a + 2;
            }
            ROUND.grid_contener[0] = grid;
        }
        public void queen_multi_move(int value_to_target, int i_position, int j_position, int  i_position_target, int j_position_target)
        { 
                if ((i_position < i_position_target) && (j_position < j_position_target)) //right down
                {
                    grid.Children.Remove(ROUND.round_table[i_position_target - 1, j_position_target - 1]);
                    ROUND.round_table[i_position_target - 1, j_position_target - 1] = warcab.create_warcab(i_position_target - 1, j_position_target - 1, 0);
                    grid.Children.Add(ROUND.round_table[i_position_target - 1, j_position_target - 1]);
                }
                if ((i_position > i_position_target) && (j_position < j_position_target)) //right up
                {
                    grid.Children.Remove(ROUND.round_table[i_position_target + 1, j_position_target - 1]);
                    ROUND.round_table[i_position_target + 1, j_position_target - 1] = warcab.create_warcab(i_position_target + 1, j_position_target - 1, 0);
                    grid.Children.Add(ROUND.round_table[i_position_target + 1, j_position_target - 1]);
                }
                if ((i_position > i_position_target) && (j_position > j_position_target)) //left up
                {
                    grid.Children.Remove(ROUND.round_table[i_position_target + 1, j_position_target + 1]);
                    ROUND.round_table[i_position_target + 1, j_position_target + 1] = warcab.create_warcab(i_position_target + 1, j_position_target + 1, 0);
                    grid.Children.Add(ROUND.round_table[i_position_target + 1, j_position_target + 1]);
                }
                if ((i_position < i_position_target) && (j_position > j_position_target)) //left down
                {
                    grid.Children.Remove(ROUND.round_table[i_position_target - 1, j_position_target + 1]);
                    ROUND.round_table[i_position_target - 1, j_position_target + 1] = warcab.create_warcab(i_position_target - 1, j_position_target + 1, 0);
                    grid.Children.Add(ROUND.round_table[i_position_target - 1, j_position_target + 1]);
                }
            
        }
        public bool fight(string player_1_or_2, int i_position, int j_position, int i_position_target, int j_position_target)// function for checking possibility to make pawn
        {
            bool fight = false;
            MOVE move = new MOVE();         

            if ((i_position - 2 >= 0) && (j_position + 2 <= 7))//right up
            {
                if (

                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position - 1, j_position + 1) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position - 2, j_position + 2, i_position - 1, j_position + 1) == true) &&
                    ((i_position - 2 == i_position_target) && (j_position + 2 == j_position_target)))
                    &&
                    (ROUND.round_table[i_position - 1, j_position +1].Content.ToString() != "0")
                    )
                {
                    if (WARCAB.click_table[0].Content.ToString() == ROUND.round_table[i_position - 1, j_position + 1].Content.ToString())
                        fight = false;
                    else
                    {
                        fight = true;
                        grid.Children.Remove(ROUND.round_table[i_position - 1, j_position + 1]);
                        ROUND.round_table[i_position - 1, j_position + 1] = warcab.create_warcab(i_position - 1, j_position + 1, 0);
                        grid.Children.Add(ROUND.round_table[i_position - 1, j_position + 1]);
                    }
                }
            }
            if ((i_position + 2 <= 7) && (j_position + 2 <= 7))//right down
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position + 1, j_position + 1) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position + 2, j_position + 2, i_position + 1, j_position + 1) == true) &&
                    ((i_position + 2 == i_position_target) && (j_position + 2 == j_position_target)))
                    &&
                    (ROUND.round_table[i_position +1, j_position + 1].Content.ToString() != "0")
                    )
                {
                    if (WARCAB.click_table[0].Content.ToString() == ROUND.round_table[i_position + 1, j_position + 1].Content.ToString())
                        fight = false;
                    else
                    {
                        fight = true;
                        
                        grid.Children.Remove(ROUND.round_table[i_position + 1, j_position + 1]);
                        ROUND.round_table[i_position + 1, j_position + 1] = warcab.create_warcab(i_position + 1, j_position + 1, 0);
                        grid.Children.Add(ROUND.round_table[i_position + 1, j_position + 1]);
                    }
                }
            }
            if ((i_position - 2 <= 7) && (j_position - 2 <= 7))//left up
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position - 1, j_position - 1) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position - 2, j_position - 2, i_position - 1, j_position - 1) == true) &&
                    ((i_position - 2 == i_position_target) && (j_position - 2 == j_position_target)))
                    &&
                    (ROUND.round_table[i_position - 1, j_position - 1].Content.ToString() != "0")
                    )
                {
                    if (WARCAB.click_table[0].Content.ToString() == ROUND.round_table[i_position - 1, j_position - 1].Content.ToString())
                        fight = false;
                    else
                    {
                        fight = true;
                        grid.Children.Remove(ROUND.round_table[i_position - 1, j_position - 1]);
                        ROUND.round_table[i_position - 1, j_position - 1] = warcab.create_warcab(i_position - 1, j_position - 1, 0);
                        grid.Children.Add(ROUND.round_table[i_position - 1, j_position - 1]);
                    }
                }
            }
            if ((i_position + 2 <= 7) && (j_position - 2 <= 7))//left up
            {
                if (
                    ((move.find_neighbor(1, player_1_or_2, i_position, j_position, i_position + 1, j_position - 1) == true) &&
                    (move.find_neighbor(0, player_1_or_2, i_position + 2, j_position - 2, i_position + 1, j_position - 1) == true) &&
                    ((i_position + 2 == i_position_target) && (j_position - 2 == j_position_target)))
                    &&
                    (ROUND.round_table[i_position + 1, j_position - 1].Content.ToString() != "0")
                    )
                {
                    if (WARCAB.click_table[0].Content.ToString() == ROUND.round_table[i_position + 1, j_position - 1].Content.ToString())
                        fight = false;
                    else
                    {
                        fight = true;
                        grid.Children.Remove(ROUND.round_table[i_position + 1, j_position - 1]);
                        ROUND.round_table[i_position + 1, j_position - 1] = warcab.create_warcab(i_position + 1, j_position - 1, 0);
                        grid.Children.Add(ROUND.round_table[i_position + 1, j_position - 1]);
                    }
                }
            }

            return fight;
        }
    }
}
