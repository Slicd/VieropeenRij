using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        public void InsertCoin(int columnPara) // William -> variabele bijhouden met positie van laatst ingeworpen muntje
        {
            for(int i = 6; i > 1; i--)
            {
                if (gameGrid[columnPara, i]==0)
                {
                    gameGrid[columnPara, i] = CurrentColor;     //voegt het rondje toe 
                    
                    return;
                }
            }

             
        }

       
        public void VerticalCheck(/*positie van laatst ingeworpen muntje meegeven*/) //WILLIAM
        {
            //voorgestelde aanpak (probeer gerust iets anders als je iets anders bedenkt)

                //onthou de laatste column waar is geInsert.
                //gebruik een for loop om door de kolom het kleur te checken
                //als het de waarde niet nul is, hou het aantal opeenvolgende kleur bij
                //als het kleur verandert, reset de counter
                //if counter = 4, victory!
        }

        public void HorizontalCheck(/*zie hierboven*/) // WILLIAM
        {

        }


        public void DiagonalCheck(/*zie hierboven*/) 
        {

        }

       
    }
}
