using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Media;

using System.Windows.Shapes;


namespace vierOpeenRij.libb
{
    public class GameManager // william -> todo : laat de spelers hun eigen naam kiezen.
    {
        
        Player Player1 = new Player
        {
            Name = "Speler 1 (Geel)",
                Color = 1
        };
        Player Player2 = new Player
        {
                Name = "Speler 2 (Rood)",
                Color = 2 
        };

        enum color : int
        {
            empty = 0,
            yellow = 1,
            red = 2
        }

        int lastCoinColumn = 0,
            lastCoinRow = 0;



        public int CurrentColor = (int)color.yellow; // begint met speler 1

               

        int[,] gameGrid = new int[7,7]; // de Multidimensional Array
        
       
        public void CreateEmptyGameGrid()
        {
            for(int column = 1; column < 7; column++)
			{
			    for (int rij = 0; rij < 7; rij++)
			    {
                    gameGrid[column, rij] = 0; // Alle hokjes leegmaken   
			    }
			}
        }

        public void NextTurn()
        {
            if (CurrentColor <= (int)color.yellow)
            {
                CurrentColor = (int)color.red;
            }
            else
            {
                CurrentColor = (int)color.yellow;
            }
        }


        public string CurrentPlayer() //  William -> todo : font kleur overeen laten komen met het rondje.
        {
            if (CurrentColor <= (int)color.yellow)
            {
                return Player1.Name;
            }
            else
            {
                return Player2.Name;
            }
            
        }

        public void InsertCoin(int columnPara) 
        {

            for (int i = 6; i > 0; i--)
            {
                if (gameGrid[columnPara, i] == 0)
                {
                    gameGrid[columnPara, i] = CurrentColor;     //voegt het rondje toe 
                    lastCoinColumn = columnPara; // zet de column van het laatste rondje vast.
                    lastCoinRow = i;            // zet de Row van het laatste rondje vast.
                    return;
                }
            }
        }
       
        public bool VerticalCheck() //WILLIAM
        {
            return false;
        }

        public bool HorizontalCheck()
        {
            int counter = 0;
            int Column = lastCoinColumn,
                Row = lastCoinRow;
                                     
            for (int column = 0; column <= 6; column++)
            {

                if(gameGrid[column, Row] == CurrentColor){
                    counter++;
                }

                else
                {
                    counter = 0;
                }

                if (counter == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DiagonalCheck() 
        {
            int counter = 1;
           
            int Column = lastCoinColumn,
                Row = lastCoinRow; 

            for (int i = Column; i <= 6; i++) // Van beneden naar boven /                   //i++ is goed
            { // Start loop 1

                if (Column < 6)
                {
                    Column++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }
                if (Row > 1)    // als de rij 0 is, dan schuift hij hier niet meer op en trackt hij enkel de coin rechts van lastcoin, moet hier ook geen else break komen?     en moet het niet row > 1 zijn?
                {
                    Row--;
                }
                else ////////////////////////
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (gameGrid[Column, Row] == CurrentColor)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (counter == 4)
                {
                    return true;
                }          
            } // End loop 1

            for (int i = Column; i >= 0; i--) // Van boven naar beneden /                //hier ga je naar links, is het niet beter om met i-- te werken? geeft die ++ geen infinite loop? want i blijft sowieso >=0
            { // Start loop 2

                if (Column > 0)    // als de kolom 0 is, dan schuift hij hier niet meer op en trackt hij enkel de coin eronder, moet hier ook geen break komen?
                {
                    Column--;
                }
                else  //////////////////////
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (Row < 6)
                {
                    Row++;
                }
                else // verandert van >=7 voor leesbaarheid
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }
                
                if (gameGrid[Column, Row] == CurrentColor)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (counter == 4)
                {
                    return true;
                }
            } // End loop 2

            for (int i = Column; i >= 0; i--) // Van beneden naar boven \
            { // Start loop 3

                if (Column > 0)
                {
                    Column--;
                }
                else    //////////////////
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }
                if (Row > 1)
                {
                    Row--;
                }
                else /////////////////
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                } 

                if (gameGrid[Column, Row] == CurrentColor)
                {
                    counter++;
                }

                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (counter == 4)
                {
                    return true;
                }
            } // End loop 3

            for (int i = Column; i <= 6; i++) // Van boven naar beneden \
            { // Start loop 4

                if (Column<6)
                {
                    Column++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (Row<6)
                {
                    Row++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (gameGrid[Column, Row] == CurrentColor)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (counter == 4)
                {
                    return true;
                }
            } 

            return false;
        }       

        /// <summary>
        /// Geeft de gamegrid data door aan de UI.
        /// Te gebruiken in MainWindow
        /// </summary>
        /// <returns></returns>
        public int[,] GetGameGrid()
        {
            return gameGrid;
        }


        //private void ResetCounter()
        //{
        //    counter = 1;
        //    Column = lastCoinColumn;
        //    Row = lastCoinRow;
        //}
    }
}
