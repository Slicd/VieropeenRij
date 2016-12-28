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

        

        bool [,] grid; // de Multidimensional Array

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
