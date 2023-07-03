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
        #region 인스턴스화
        Heal h;
        Event e;
        Shop s;
        Item i;
        NormalMonster nm;
        EliteMonster em;
        BossMonster bm;
        Variable v;
        GamePrint g;
        #endregion

        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region Enum
        enum MapNum
        {
            heal, normal, elite, randomEvent
        }
        #endregion

        #region 객체 초기화 메소드
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
        #endregion

        #region 지역변수
        public string move;
        #endregion

        #region 맵 초기화 메소드
        public void MapCreate()
        {

            v.mapCreate[11] = v.userPosition;
            v.mapCreate[0] = v.boss;
            Random random = new Random();
            for (int i = 1; i < 11; i++)
            {
                int randomNumber = random.Next(0, 100); // 0부터 99 사이의 랜덤 값 생성

                if (randomNumber < 35)
                {
                    v.mapCreate[i] = v.normal; // 35% 확률로 normal
                }
                else if (randomNumber < 60)
                {
                    v.mapCreate[i] = v.elite; // 25% 확률로 elite
                }
                else if (randomNumber < 85) 
                {
                    v.mapCreate[i] = v.randomEvent; // 25% 확률로 randomEvent
                }
                else
                {
                    v.mapCreate[i] = v.heal; // 나머지 15% 확률로 heal
                }
            }
        }
        #endregion

        #region 테스트용 맵 메소드
        public void TestMap()
        {
            v.mapCreate[0] = v.boss;
            v.mapCreate[11] = v.userPosition;
            v.mapCreate[1] = v.heal;
            v.mapCreate[2] = v.elite;
            v.mapCreate[3] = v.randomEvent;
            v.mapCreate[4] = v.elite;
            v.mapCreate[5] = v.randomEvent;
            v.mapCreate[6] = v.elite;
            v.mapCreate[7] = v.normal;
            v.mapCreate[8] = v.randomEvent;
            v.mapCreate[9] = v.normal;
            v.mapCreate[10] = v.normal;
        }
        #endregion

        #region 맵 출력 메소드
        public void MapPrint()
        {

            g.GameMapPrint();
            g.GameInfoPrint();
            g.GameEventPrint();
            MapInfo();
            int printCount = 1;
            int barCount = 2;
            // enum을 이용한 맵 출력
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

                if (str == v.clearStage)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(str);
                    Console.ResetColor();

                }


                if (str == v.heal)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(str);
                    Console.ResetColor();

                }

                // 중간에 bar를 삽입해서 게임의 가독성 증가
                if (str != v.mapCreate[11])
                {
                    Console.SetCursorPosition(30,barCount);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("│");
                    Console.ResetColor();
 
                    barCount += 2;
                }
                printCount += 2;
            }
        }
        #endregion

        #region 맵 이동과 이벤트 메소드
        public void MapMove()
        {


            Console.SetCursorPosition(14, 28);
            Console.WriteLine("[아무키나 눌러 다음스테이지로 이동]");
            Console.SetCursorPosition(13, 29);
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
                        // 중복없는 4개의 아이템 랜덤 프린트 메써드
                        s.AddRandomItemsToShop();
                        // 리세마라 방지 카운트
                        v.resetCount++;
                    }
                    // 상점에서
                    while (v.outCount == 0) // 상점에서 필요한 만큼 구매 카운트
                    {
                        // 아이템 이름 프린트 메써드
                        s.PrintShop();
                        // 아이템 설명 프린트 메써드
                        s.ExplainItem();
                        // 상점에 구매 메써드
                        s.BuyFromShop();

                    }

                    // 인벤 강제 활성화
                    i.ItemEffectOnInven();
                    v.outCount--;
                    break;
                case ConsoleKey.E:
                    // 인벤에서 아이템 효과 설명 메써드
                    i.ItemEffectOnInven();                                      
                    Console.SetCursorPosition(20, 28);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;

                    Console.WriteLine("Press Any Key To Continue");
                    Console.ResetColor();

                    _getch();
                    break;
                case ConsoleKey.T:
                    // 유저의 스텟을 출력하는 메써드
                    v.Stat();
                    Console.SetCursorPosition(20, 28);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Press Any Key To Continue");
                    Console.ResetColor();
                    _getch();
                    break;
                default:
                    // move를 정의를 통해 리펙토링
                    move = v.mapCreate[v.moveCount - 1];
                    if (move == v.heal)
                    {
                        h.HealHP(); // 힐 이벤트 메써드
                    }
                    else if (move == v.normal)
                    {
                        nm.Fight(); // 노멀 몬스터 이벤트 메써드
                    }
                    else if (move == v.elite)
                    {
                        em.Fight(); // 엘리트 몬스터 이벤트 메써드
                    }
                    else if (move == v.randomEvent)
                    {
                        e.RandomEvent(); // 랜덤 이벤트 메써드
                    }
                    else if (move == v.boss)
                    {
                        bm.Fight(); // 보스 몬스터 이벤트 메써드
                    }

                    // 이벤트가 끝나면 moveCount++ 해서 한칸 위로(-) 플레이어를 옮김
                    v.moveCount--;
                    v.mapCreate[v.moveCount + 1] = v.clearStage;
                    v.mapCreate[v.moveCount] = v.userPosition;
                    // 리세마라 방지 메써드
                    ResetShop();
                    break;
            }


        }
        #endregion

        #region 리세마라 방지 메소드
        public void ResetShop()
        {
            // 리롤을 위한 카운트
            v.resetCount = 0;
            // 새 아이템을 위해 shopList를 지움
            v.shopList.Clear();
        }
        #endregion

        #region 맵 정보를 위한 출력 메소드
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
        #endregion
    }
}
