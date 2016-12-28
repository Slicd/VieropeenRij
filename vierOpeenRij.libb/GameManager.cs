using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vierOpeenRij.libb
{
    public class GameManager
    {
        
        Player Player1 = new Player
        {
            Name = "Speler 1",
                Color = 1 // geel
        };
        Player Player2 = new Player
        {
                Name = "Speler 2",
                Color = 2 // rood
        };

        

        int[,] gameGrid = new int[7,7]; // de Multidimensional Array
        
       
        public void ResetGameGrid()
        {
            for(int column = 0; column < 7; column++)
			{
			    for (int rij = 1; rij < 7; rij++)
			    {
                    gameGrid[column, rij] = 0; // Alle hokjes leegmaken
			    }
			}
        }

        public int CurrentTurnChecker(int CurrentTurn)
        {
            if (CurrentTurn <= 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }


        public string CurrentPlayer(int CurrentTurn) 
        {
            if(CurrentTurn <= 1)
            {
                return Player1.Name;
            }
            else
            {
                return Player2.Name;
            }
            
        }

        public void InsertCoin() // William
        {

        }

        public void HorizontalCheck()
        {

        }

        public void VerticalCheck()
        {

        }

        public void DiagonalCheck()
        {

        }
    }
}
