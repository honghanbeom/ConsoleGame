using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Map
    {
        Heal h;
        Event e;
        Shop s;
        Item i;

        NormalMonster nm;
        //MonsterCreate mc = new MonsterCreate();
        EliteMonster em;
        BossMonster bm;
        AttackSystem a;
        Variable v;

        public string move;

        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        enum MapNum
        {
            heal, normal, elite, randomEvent
        }
 

        public void Get(Variable v, Heal heal_, NormalMonster nm_, Event e_,
             EliteMonster em_, BossMonster bm_, Shop s_, Item i_)
        {
            this.v = v;
            this.h = heal_;
            this.nm = nm_;
            this.e = e_;
            this.em = em_;
            this.bm = bm_;
            this.s = s_;
            this.i = i_;
        }


        public void MapCreate()
        {
            v.mapCreate[11] = v.userPosition;
            v.mapCreate[0] = v.boss;
            Random random = new Random();
            for (int i = 1; i < 11; i++)
            {
                int randomNumber = random.Next(0, 100); // 0부터 99 사이의 랜덤 값 생성

                if (randomNumber < 50)
                {
                    v.mapCreate[i] = v.normal; // 50% 확률로 normal
                }
                else if (randomNumber < 70)
                {
                    v.mapCreate[i] = v.elite; // 20% 확률로 elite
                }
                else if (randomNumber < 85)
                {
                    v.mapCreate[i] = v.randomEvent; // 15% 확률로 randomEvent
                }
                else
                {
                    v.mapCreate[i] = v.heal; // 나머지 15% 확률로 heal
                }
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
            Console.WriteLine("아무키나 눌러 다음스테이지로 이동");
            Console.WriteLine("[S : 상점]  [E : 인벤토리]");
            ConsoleKeyInfo userMove = Console.ReadKey(true);
            switch (userMove.Key)
            {
                case ConsoleKey.S:
                    i.AddItem();
                    s.AddRandomItemsToShop();
                    s.PrintShop();
                    s.ExplainItem();
                    s.BuyFromShop();
                    break;
                case ConsoleKey.E:
                    i.ItemEffectOnInven();
                    break;
                default:
                    move = v.mapCreate[v.moveCount - 1];
                    if (move == v.heal)
                    {
                        h.HealHP();
                    }
                    else if (move == v.normal)
                    {
                        nm.Fight();
                    }
                    else if (move == v.elite)
                    {
                        em.Fight();
                    }
                    else if (move == v.randomEvent)
                    {
                        e.RandomEvent();
                    }
                    else if (move == v.boss)
                    {
                        bm.Fight();
                    }

                    v.mapCreate[v.moveCount - 1] = v.userPosition;
                    v.mapCreate[v.moveCount] = v.clearStage;
                    v.moveCount--;
                    break;
            }

        }
    }
}
