using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Map
    {
        enum MapNum
        {
            heal, shop, monster, elite, randomEvent
        }


        Variable v = new Variable();

        public void Get(Variable var_)
        { 
            this.v = var_;        
        }


        public void MapCreate()
        {
            v.mapCreate[11] = v.userPosition;
            v.mapCreate[0] = v.boss;
            Random random = new Random();
            for (int i = 1; i < 11; i++)
            {
                int randomNumber = random.Next(0, 4);
                v.mapCreate[i] = ((MapNum)randomNumber).ToString();
            }

        }

        public void MapPrint()
        {
            foreach (string str in v.mapCreate)
            { 
                Console.WriteLine(str);
                if (str != v.mapCreate[11])
                { 
                    Console.WriteLine("│");
                }
            }
        }

        // 이벤트가 끝나면 moveCount++ 해서 한칸 위로 플레이어를 옮김
        public void MapMove()
        {
            string move = v.mapCreate[v.moveCount - 1];
            if ( move == v.heal)
            {

            }
            else if (move == v.shop)
            {

            }
            else if (move == v.monster)
            {

            }
            else if (move == v.elite)
            {

            }
            else if (move == v.randomEvent)
            {

            }
            else if (move == v.boss)
            {

            }

            v.mapCreate[v.moveCount - 1] = v.userPosition;
            v.mapCreate[v.moveCount] = v.clearStage;
        }


    }
}
