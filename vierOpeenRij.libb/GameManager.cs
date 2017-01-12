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

        

        public int CurrentColor = 1; // begint met speler 1

               

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
            if (CurrentColor <= 1)
            {
               CurrentColor = 2;
            }
            else
            {
                CurrentColor = 1;
            }
        }


        public string CurrentPlayer() //  William -> todo : font kleur overeen laten komen met het rondje.
        {
            if(CurrentColor <= 1)
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
       
        public void VerticalCheck() //WILLIAM
        {
   
        }

        public int HorizontalCheck()

        {
            int counter = 0;
            int Column = lastCoinColumn,
                Row = lastCoinRow;
            int Victory = 0;
           

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
                    Victory = 1;
                    return Victory;
                }


            }

            return Victory;
        }

        
        public int DiagonalCheck() 
        {
            int counter = 1;
            int Victory = 0;
            int Column = lastCoinColumn,
                Row = lastCoinRow; 

            for (int i = lastCoinColumn; i < 6; i++) // Van beneden naar boven /
            { // Start loop 1

                Column++;
                if(Row > 0)
                {
                    Row--;
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
                    Victory = 1;
                    return Victory;
                }          
            } // End loop 1

            for (int i = lastCoinColumn; i >= 0; i++) // Van boven naar beneden /
            { // Start loop 2

                if(Column > 0)
                {
                    Column--;
                }
                
                Row++;
                if(Row >= 7)
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
                    Victory = 1;
                    return Victory;
                }
            } // End loop 2

            for (int i = lastCoinColumn; i < 6; i++) // Van beneden naar boven \
            { // Start loop 3

                Column++;
                Row++;
                if (Row >= 7)
                {
                    counter = 1;
                    Column = lastCoinColumn;
                    Row = lastCoinRow;
                    break;
                }

                if (Row >= 7)
                {
                    Row = 6;
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
                    Victory = 1;
                    return Victory;
                }
            } // End loop 3

            for (int i = lastCoinColumn; i >= 0; i++) // Van boven naar beneden \
            { // Start loop 4

                if (Column > 0)
                {
                    Column--;
                }
                if (Row > 0)
                {
                    Row--;
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
                    Victory = 1;
                    return Victory;
                }
            } // End loop 4

            return Victory;
        }       

        public int[,] GetGameGrid()
        {
            return gameGrid;
        }
    }
}
