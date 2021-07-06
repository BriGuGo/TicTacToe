using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static string showtable(string[] currentboard)
        {
            /* Function to Show the Game Board based off the array data
             */
            string[] boardvalue = currentboard;
            string board = (boardvalue[0] + "|" + boardvalue[1] + "|" + boardvalue[2] + "\n" + "------\n" + boardvalue[3] + "|" + boardvalue[4] + "|" + boardvalue[5] + "\n" + "------\n" + boardvalue[6] + "|" + boardvalue[7] + "|" + boardvalue[8]);
            return board;
        }
        static bool checkarray(int key, string[] array)
        {
            /* Function to Check if there is a current Player at the placement
            */
            if (array[key] != " ")
            {
                Console.WriteLine($"Invalid Move, make another move");
                return true;
            }
            else
            {
                return false;
            }
        }
        static string[] makemove(string player, string[] currentboard)
        {
            /* Function to make a move based on the player and board given
            */
            int boardmove = 0;
            string[] newboard = currentboard;
            bool loop = true;
            /* While Loop to makes sure a valid move is made
            */
            while (loop)
            {
                Console.WriteLine($"-------------------\nPlayer {player} make a move");
                string move = Console.ReadLine();
                /* Makes sure the User Input is Valid
                */
                if (move == "LT")
                {
                    boardmove = 0;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "MT")
                {
                    boardmove = 1;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "RT")
                {
                    boardmove = 2;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "LC")
                {
                    boardmove = 3;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "MC")
                {
                    boardmove = 4;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "RC")
                {
                    boardmove = 5;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "LB")
                {
                    boardmove = 6;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "MB")
                {
                    boardmove = 7;
                    loop = checkarray(boardmove, newboard);
                }
                else if (move == "RB")
                {
                    boardmove = 8;
                    loop = checkarray(boardmove, newboard);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    loop = true;
                }
            }
            /* Outputs the new Array that contains the moves of previous and adds the new move
            */
            newboard[boardmove] = player;
            Console.WriteLine($"-------------------");
            return newboard;
        }
        static bool wincondition(string p, string[] cb)
        {
            /* Checks if the current Board has any winners. Determines it by which player to check for and the current boards's values. Returns True if Win and False if Nothing happens.
             */
            if (cb[0] == p)
            {
                if (cb[1] == p)
                {
                    if (cb[2] == p)
                    {
                        return true;
                    }
                }
                else if (cb[4] == p)
                {
                    if (cb[8] == p)
                    {
                        return true;
                    }
                }
                else if (cb[3] == p)
                {
                    if (cb[6] == p)
                    {
                        return true;
                    }
                }
            }
            else if (cb[3] == p)
            {
                if (cb[4] == p)
                {
                    if (cb[5] == p)
                    {
                        return true;
                    }
                }
            }
            else if (cb[2] == p)
            {
                if (cb[5] == p)
                {
                    if (cb[8] == p)
                    {
                        return true;
                    }
                }
            }
            else if (cb[1] == p)
            {
                if (cb[4] == p)
                {
                    if (cb[7] == p)
                    {
                        return true;
                    }
                }
            }
            else if (cb[6] == p)
            {
                if (cb[4] == p)
                {
                    if (cb[2] == p)
                    {
                        return true;
                    }
                }
                else if (cb[7] == p)
                {
                    if (cb[8] == p)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            /* Introduction Stuff
            */
            string[] boardvalue = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            Console.WriteLine("Welcome to Brian's Tic Tac Toe");
            Console.WriteLine("How to Play: \nL = Left Column | M = Middle Column | R = Right Column \nB = Bottom Row | C = Center Row | T = Top Row");
            Console.WriteLine("To Enter a Move: Type in Captials (Column)(Row)\nExample: Left Top = LT");
            Console.WriteLine("--------------------------------------------------------------");
            /* Calls functions to play, One to make the move into the system and one for the GUI through the console
            */
            Console.WriteLine(showtable(boardvalue));
            boardvalue = makemove("X", boardvalue);
            Console.WriteLine(showtable(boardvalue));
            boardvalue = makemove("O", boardvalue);
            Console.WriteLine(showtable(boardvalue));
            boardvalue = makemove("X", boardvalue);
            Console.WriteLine(showtable(boardvalue));
            boardvalue = makemove("O", boardvalue);
            Console.WriteLine(showtable(boardvalue));
            /* First four moves result in no win no matter what, so no need to check for win
            */
            int x = 1;
            /* A little Complex thinking here... There can be 2 moves each before X takes one more move to finish the board. Do a while loop that itterates twice -> 2 x ( X move + O move)
            */
            while (x <= 2)
            {
                boardvalue = makemove("X", boardvalue);
                Console.WriteLine(showtable(boardvalue));
                /* Checks Win Condition now because it is possible for X or O to win
                */
                if (wincondition("X", boardvalue) == true)
                {
                    Console.WriteLine("Player X Wins, Game Over\nPress Button to Leave Game");
                    x = 5;
                    /* Exits loop as the x value no longer satisfies requirments
                    */
                }
                if (x != 5)
                {
                    boardvalue = makemove("O", boardvalue);
                    Console.WriteLine(showtable(boardvalue));
                    if (wincondition("O", boardvalue) == true)
                    {
                        Console.WriteLine("Player O Wins, Game Over");
                        x = 5;
                    }
                }
                /* Adds 1 so the system knwos its been through once
                */
                x = x + 1;
                /* For when X has the last move after 8 moves take place
                */
                if (x == 3)
                {
                    boardvalue = makemove("X", boardvalue);
                    Console.WriteLine(showtable(boardvalue));
                    /* Checks only X as this determines if X wins or not, if it does not, then the whole game is a draw
                    */
                    if (wincondition("X", boardvalue) == true)
                    {
                        Console.WriteLine("Player X Wins, Game Over\nPress Button to Leave Game");
                    }
                    else
                    {
                        Console.WriteLine("This is a Draw, Game Over\nPress Button to Leave Game");
                    }
                }
            }
            /* Added this so the console does not quit right away
             */
            Console.ReadLine();
        }

    }
}
