using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        Variable v;
        GamePrint g;

        public string move;

        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        enum MapNum
        {
            heal, normal, elite, randomEvent
        }
 

        public void Get(Variable v, Heal heal_, NormalMonster nm_, Event e_,
             EliteMonster em_, BossMonster bm_, Shop s_, Item i_, GamePrint g_)
        {
            this.v = v;
            this.h = heal_;
            this.nm = nm_;
            this.e = e_;
            this.em = em_;
            this.bm = bm_;
            this.s = s_;
            this.i = i_;
            this.g = g_;
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

            g.GameMapPrint();
            g.GameInfoPrint();
            g.GameEventPrint();
            MapInfo();
            int printCount = 1;
            int barCount = 2;
            foreach (string str in v.mapCreate)
            {
                Console.SetCursorPosition(30,printCount);
                if (str == v.normal)
                { 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(str);
 
     
                }
                Console.ResetColor();
                if (str == v.elite)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(str);


                }
                Console.ResetColor();

                if (str == v.boss)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(str);
                    Console.ResetColor();

                }


                if (str == v.userPosition)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(str);
                    Console.ResetColor();

                }

                if (str == v.randomEvent)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(str);
                    Console.ResetColor();

                }


                if (str == v.heal)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(str);
                    Console.ResetColor();

                }


                if (str != v.mapCreate[11])
                {
                    Console.SetCursorPosition(30,barCount);

                    Console.WriteLine("│");
 
                    barCount += 2;
                }
                printCount += 2;
            }
        }

        // 이벤트가 끝나면 moveCount++ 해서 한칸 위로 플레이어를 옮김
        public void MapMove()
        {
            Console.SetCursorPosition(14, 28);
            Console.WriteLine("아무키나 눌러 다음스테이지로 이동");
            Console.SetCursorPosition(12, 29);
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.Write("[S : 상점]  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            Console.Write("[E : 인벤토리] ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.Write("[T : 스텟]");
            Console.ResetColor ();
            ConsoleKeyInfo userMove = Console.ReadKey(true);
            switch (userMove.Key)
            {
                case ConsoleKey.S:
                    // 동일 라운드 한번만 아이템 추가
                    if (v.resetCount == 0)
                    {
                        s.AddRandomItemsToShop();
                        v.resetCount++;
                    }
                    // 동일 라운드 상점 리셋 불가
                    while (v.outCount == 0)
                    {

                        s.PrintShop();
                        s.ExplainItem();
                        s.BuyFromShop();
                    }
                    // 상점초기화
                    v.shopList.Clear();
                    v.shopListAll.Clear();
                    v.resetCount--;
                    v.outCount--;
                    break;
                case ConsoleKey.E:

                    i.ItemEffectOnInven();
                    Console.SetCursorPosition(17, 28);
                    Console.WriteLine("Press Any Key To Continue");
                    _getch();
                    break;
                case ConsoleKey.T:
                    v.Stat();
                    Console.SetCursorPosition(17, 28);
                    Console.WriteLine("Press Any Key To Continue");
                    _getch();
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

                    // 이동
                    v.mapCreate[v.moveCount - 1] = v.userPosition;
                    v.mapCreate[v.moveCount] = v.clearStage;
                    v.moveCount--;
                    break;
            }

            

        }
        public void MapInfo()
        {
            Console.SetCursorPosition(71, 5);
            Console.WriteLine("[나의 위치]");

            Console.SetCursorPosition(75, 6);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("㉯");

            Console.SetCursorPosition(70, 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[일반 몬스터]");

            Console.SetCursorPosition(75, 9);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ⓜ");

            Console.SetCursorPosition(69, 11);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[엘리트 몬스터]");

            Console.SetCursorPosition(75, 12);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("ⓔ");

            Console.SetCursorPosition(70, 14);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[보스 몬스터]");

            Console.SetCursorPosition(75, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ⓑ");

            Console.SetCursorPosition(70, 17);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[랜덤 이벤트]");

            Console.SetCursorPosition(75, 18);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("♬");

            Console.SetCursorPosition(74, 20);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[힐]");

            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("♨");

            Console.SetCursorPosition(67, 23);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[완료한 스테이지]");

            Console.SetCursorPosition(75, 24);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("X");
            Console.ResetColor();




        }
    }
}
