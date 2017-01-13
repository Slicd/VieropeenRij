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
    public class GameManager 
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

        public enum color : int
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
            for(int column = 0; column < 7; column++)
			{
			    for (int rij = 1; rij < 7; rij++)
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


        public string CurrentPlayer(Player Player1, Player Player2) 
        {
            if (CurrentColor <= 1)
            {
                return Player1.Name;
            }
            else
            {
                return Player2.Name;
            }
            
        }
        
        public bool InsertCoin(int columnPara) 
        {

            for (int i = 6; i > 0; i--)
            {
                    if (gameGrid[columnPara, 1] > 0)
                {
                    return true;
                }
                    if (gameGrid[columnPara, i] == 0)
                {
                    gameGrid[columnPara, i] = CurrentColor;     //voegt het rondje toe 
                    lastCoinColumn = columnPara; // zet de column van het laatste rondje vast.
                    lastCoinRow = i;            // zet de Row van het laatste rondje vast.
                    return false;
                }                                
            }
            return false;
        }

        public bool Tzitvol()
        {
            int counter = 0;
            
            for (int column = 0; column <= 6; column++)
            {

                if (gameGrid[column, 1] > 0)
                {
                    counter++;
                }

                else
                {
                    counter = 0;
                }

                if (counter == 7)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerticalCheck() 
        {
            int column = lastCoinColumn;

            int counter = 0;


            for (int row = 1; row <= 6; row++)
            {

                if (gameGrid[column, row] == CurrentColor)
                {
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

            for (int i = Column; i <= 6; i++) // Van beneden naar boven /                 
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
                if (Row > 1)    
                {
                    Row--;
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
            } // End loop 1

            for (int i = Column; i >= 0; i--) // Van boven naar beneden /                
            { // Start loop 2

                if (Column > 0)    
                {
                    Column--;
                }
                else  
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
            } // End loop 2

            for (int i = Column; i >= 0; i--) // Van beneden naar boven \
            { // Start loop 3

                if (Column > 0)
                {
                    Column--;
                }
                else    
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


        
    }
}
