using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Project1
{

    public class Event
    {
        Variable v = new Variable();
        GamePrint g = new GamePrint();

        


        public void Get(Variable var_, GamePrint g_)
        { 
            this.v = var_;
            this.g = g_;
        }

        public void RandomEvent()
        {
            Random random = new Random();
            int ranEventnumber = random.Next(0,5);
            switch (ranEventnumber)
            {
                case 0:
                    {
                        // 모닥불 정령들 실패 비례 공격력 +

                        Event0();
                    }
                    break;
                case 1:
                    {
                        // 체력회복, 최대체력 +

                        Event1();

                    }
                    break;
                case 2:
                    {
                        // 마상 시합 랜덤 돈 건 만큼 획득 

                        Event2();

                    }
                    break;
                case 3:
                    {
                        // 피의 돌림판 반드시 체력-, 랜덤 최대 체력+,방어력+,성공+,골드+,잭팟(전부 획득)

                        Event3();

                    }
                    break;
                case 4:
                    {
                        // 야수의 심장

                        Event4();

                    }
                    break;

            }
        }

        //    Console.SetCursorPosition(23, 2); 콘솔 중앙
        //    Console.SetCursorPosition(12, 28); 유저 출력 중앙
        
        public void Event0()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.ResetColor();
            // 모닥불 정령들 실패 비례 공격력 +
            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[이벤트]");
            Console.ResetColor();
            Console.SetCursorPosition(18, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("'붉은빛의 불의 정령'");
            Console.ResetColor();
            Console.SetCursorPosition(11, 5);

            Console.Write("처럼 보이는 무리가 커다란 모닥불 주위에서");
            Console.SetCursorPosition(12, 6);

            Console.Write("조그만 부스러기를 던지며 춤추고 있다.");
            Console.SetCursorPosition(9, 7);

            Console.Write("불에 넣은 부스러기는 빛이 나더니 소멸해버린다.");

            Console.SetCursorPosition(20, 8);

            Console.Write("[ 바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  1");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();
            Console.SetCursorPosition(20, 9);

            Console.Write("[ 바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  2");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();
            Console.SetCursorPosition(20, 10);

            Console.Write("[ 바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  3");
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(20, 11);

            Console.Write("[ 바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  4");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();

            Console.SetCursorPosition(20, 12);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ 나가기 : N]");
            Console.ResetColor();
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.D1:
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(12, 28);
                    Console.WriteLine("1개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("공격력 +10");
                    v.userDamage += 10;
                    break;
                case ConsoleKey.D2:
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(12, 28);
                    Console.WriteLine("2개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("공격력 +20");
                    v.userDamage += 20;
                    break;
                case ConsoleKey.D3:
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(12, 28);
                    Console.WriteLine("3개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("공격력 +30");
                    v.userDamage += 30;
                    break;
                case ConsoleKey.D4:
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(12, 28);
                    Console.WriteLine("4개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.SetCursorPosition(12, 29);

                    Console.WriteLine("공격력 +40");
                    v.userDamage += 40;
                    break;
                case ConsoleKey.N:
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(12, 28);

                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event1()
        {
            Console.Clear();

            g.GameMapPrint();
            g.GameInfoPrint();
            // 고양이 구하기
            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[이벤트]");
            Console.ResetColor();
            Console.SetCursorPosition(16, 3);

            Console.Write("귀여운 "); 
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("고양이");
            Console.ResetColor();
            Console.Write("가 덫에 걸려있다.");

            Console.ForegroundColor= ConsoleColor.Cyan;
            g.CatPrint();
            Console.ResetColor();

            Console.SetCursorPosition(12, 28);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[구한다 :Y]");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Write("[지나간다 :N]");




            Console.ResetColor();

            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    Random random = new Random();
                    int catRandom = random.Next(0, 2);
                    if (catRandom == 0)
                    {
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();

                        Console.SetCursorPosition(23, 2);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("[고양이의 보은]");
                        Console.ResetColor();

                        Console.SetCursorPosition(23, 3);

                        Console.WriteLine("고양이를 구하셨습니다!");


                        Console.SetCursorPosition(24, 4);
                        Console.Write("[성공확률 ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.Write("+3");
                        Console.ResetColor();
                        Console.Write("]"); Thread.Sleep(1000);


                        Console.SetCursorPosition(18, 5);

                        v.userProb.Insert(1, v.success);
                        v.userProb.Insert(1, v.success);
                        v.userProb.Insert(1, v.success);
                        int userSuccessCount = v.userProb.Count(x => x == v.success);
                        Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);

                    }
                    if (catRandom == 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        g.GameMapPrint();
                        g.GameInfoPrint();
                        Console.ResetColor();

                        Console.SetCursorPosition(23, 2);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("[고양이의 저주]");
                        Console.ResetColor();

                        Console.SetCursorPosition(23, 3);

                        Console.WriteLine("고양이를 구하다 당신도 덫에 빠졌습니다!");


                        Console.SetCursorPosition(23, 4);
                        Thread.Sleep(1000);

                        Console.Write("[실패확률 ");
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write("+2");
                        Console.ResetColor();
                        Console.Write("]");
                        Console.Write("  [체력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("- 10");
                        Console.ResetColor();
                        Console.Write("]");

                        Console.SetCursorPosition(23, 5);

                        v.userProb.Insert(1, v.fail);
                        v.userProb.Insert(1, v.fail);
                        v.userCurrentHP -= 10;
                        int userFailCount = v.userProb.Count(x => x == v.fail);
                        Console.WriteLine("[유저 실패 갯수 : {0}]", userFailCount);
                        Console.WriteLine("[현재 체력 : {0}]", v.userCurrentHP);

                    }
                    break;
                case ConsoleKey.N:
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event2()
        {
            Console.Clear();

            g.GameMapPrint();
            g.GameInfoPrint();
            // 마상 시합 랜덤 돈 건 만큼 획득 
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(27, 2);
            Console.Write("[이벤트]");
            Console.ResetColor();
            Console.SetCursorPosition(23, 4);
            Console.WriteLine("두 기사가 서로 마주보고 있는곳을 지나가려다가");
            Console.SetCursorPosition(23, 5);

            Console.WriteLine("한 기사가 창으로 길을 막고 오늘은 애완동물을 살해한 나쁜놈을 죽이는 날이라");
            Console.SetCursorPosition(23, 6);

            Console.WriteLine("그때까지는 플레이어가 못 지나갈수도 있다고 하며, ");
            Console.SetCursorPosition(23, 7);

            Console.WriteLine("이길것 같은 사람에게 배팅해보지 않겠냐는 제안을 한다.");
            Random random = new Random();
            // 0 = 살해범승리 1= 주인승리
            int randomIdx = random.Next(0, 2);

            Console.SetCursorPosition(12, 29);
            Console.WriteLine("[살해범 : A][주인 : S][나가기 :N]");
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {

                case ConsoleKey.A:
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("거실 금액을 입력해주세요");
                    Console.SetCursorPosition(12, 30);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                    Console.ResetColor();
                    ConsoleKeyInfo key = Console.ReadKey();
                    int x = int.Parse(key.KeyChar.ToString());
                    if (x <= v.userGold)
                    {
                        if (randomIdx == 0)
                        {
                            Console.Clear();
                            g.GameMapPrint();
                            g.GameInfoPrint();
                            Console.SetCursorPosition(23, 4);
                            Console.WriteLine("살해범의 승리");
                            v.userGold = v.userGold + x*2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(23, 5);

                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.ResetColor();
                            Console.CursorVisible = false;

                        }
                        else if (randomIdx == 1)
                        {
                            Console.Clear();
                            g.GameMapPrint();
                            g.GameInfoPrint();
                            Console.SetCursorPosition(23, 4);

                            Console.WriteLine("주인의 승리");
                            v.userGold -= x;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(23, 5);

                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.ResetColor(); Console.CursorVisible = false;

                        }
                    }
                    break;
                case ConsoleKey.S:
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("거실 금액을 입력해주세요");
                    Console.SetCursorPosition(12, 30);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                    Console.ResetColor();
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    int y = int.Parse(key2.KeyChar.ToString());
                    if (y <= v.userGold)
                    {
                        if (randomIdx == 0)
                        {
                            Console.Clear();
                            g.GameMapPrint();
                            g.GameInfoPrint();
                            Console.SetCursorPosition(23, 4);
                            Console.WriteLine("살해범의 승리");
                            v.userGold = v.userGold -= y;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(23, 5);

                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.ResetColor();
                            Console.CursorVisible = false;

                        }
                        else if (randomIdx == 1)
                        {
                            Console.Clear();
                            g.GameMapPrint();
                            g.GameInfoPrint();
                            Console.SetCursorPosition(23, 4);

                            Console.WriteLine("주인의 승리");
                            v.userGold += y*2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(23, 5);

                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.ResetColor(); Console.CursorVisible = false;

                        }
                    }

                    break;
                case ConsoleKey.N:
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event3()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(27, 2);
            Console.Write("[이벤트]");
            Console.ResetColor();
            // 피의 돌림판 반드시 체력-, 랜덤 최대 체력+,방어력+,성공+,골드+,잭팟(전부 획득)
            Console.SetCursorPosition(23, 4);

            Console.WriteLine("그렘린의 돌림판을 돌린다. 다음 5개 중 하나가 나온다.");
            Console.SetCursorPosition(23, 5);

            Console.Write("[대가 : ");
            Console.Write("최대 체력");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("- 5");
            Console.ResetColor();
            Console.Write("]");
            v.userMaxHP -= 5;
            if (v.userMaxHP == v.userCurrentHP)
            {
                v.userCurrentHP -= 5;
            }
            Console.SetCursorPosition(23, 7);

            Thread.Sleep(1000);
            Console.Write("[현재체력 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}",v.userCurrentHP);
            Console.ResetColor();
            Console.Write("/ 최대체력  : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}",v.userMaxHP);
            Console.ResetColor();
            Console.Write("]");

            Random random = new Random();
            // 0 = 최대체력 1= 방어력 2= 성공 3= 골드 4= 잭팟
            int randomIdx2 = random.Next(0, 5);
            switch (randomIdx2)
            {
                case 0:

                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    v.userMaxHP += 5;
                    Console.SetCursorPosition(23, 4);

                    Console.Write("[최대 체력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 5);

                    Console.Write("[현재체력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userCurrentHP);
                    Console.ResetColor();
                    Console.Write("/ 최대체력  : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userMaxHP);
                    Console.ResetColor();
                    Console.Write("]");
                    Thread.Sleep(1500);


                    break;
                case 1:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    v.userArmor += 5;
                    Console.SetCursorPosition(23, 4);

                    Console.Write("[방어력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 5);

                    Console.Write("[방어력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userArmor);
                    Console.ResetColor();
                    Console.Write("]");
                    Thread.Sleep(1500);

                    break;
                case 2:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    v.userArmor += 5;
                    Console.SetCursorPosition(23, 4);

                    v.userProb.Insert(1, v.success);
                    Console.Write("[성공확률 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 1");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 5);

                    int userSuccessCount = v.userProb.Count(x => x == v.success);
                    Console.Write("[유저 성공 갯수 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", userSuccessCount);
                    Console.ResetColor();
                    Console.Write("]");
                    Thread.Sleep(1500);



                    break;
                case 3:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    v.userGold += 100;
                    Console.SetCursorPosition(23, 4);

                    Console.Write("[골드");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 5);

                    Console.Write("[소지금 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userGold);
                    Console.ResetColor();
                    Console.Write("]");

                    Thread.Sleep(1500);


                    break;
                case 4:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    v.userMaxHP += 5;
                    v.userArmor += 5;
                    v.userProb.Add(v.success);
                    v.userGold += 100;
                    Console.SetCursorPosition(23, 4);

                    Console.WriteLine("잭팟!");

                    Console.SetCursorPosition(23, 5);

                    Console.Write("[최대 체력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 6);

                    Console.Write("[현재체력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userCurrentHP);
                    Console.ResetColor();
                    Console.Write("/ 최대체력  : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userMaxHP);
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 7);

                    Console.Write("[방어력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 8);

                    Console.Write("[방어력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userArmor);
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(23, 9);

                    v.userProb.Insert(1, v.success);
                    Console.Write("[성공확률 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 1");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 10);

                    int userSuccessCount3 = v.userProb.Count(x => x == v.success);
                    Console.Write("[유저 성공 갯수 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", userSuccessCount3);
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(23, 11);

                    Console.Write("[골드");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(23, 12);

                    Console.Write("[소지금 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userGold);
                    Console.ResetColor();
                    Console.Write("]");
                    Thread.Sleep(1500);





                    break;

            }
        }
        public void Event4()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(27, 2);
            Console.Write("[이벤트]");
            Console.ResetColor();
            // 야수의 심장
            Console.SetCursorPosition(23, 3);

            Console.WriteLine("[야수의 심장]");
            Console.SetCursorPosition(23, 4);

            Console.WriteLine("[ 받기 :Y][ 떠나기 :N]");

            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    Thread.Sleep(1000);
                    v.userProb.Clear();
                    v.userProb.Add(v.userSelect);
                    v.userProb.Add(v.success);
                    v.userProb.Add(v.fail);
                    v.userDelay = 100;
                    v.userDamage = 1000;
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("야수의 심장");
                    Console.ResetColor();
                    Console.Write("]을 획득하셨습니다.");
                    Console.Write("[성공확률 1개][실패확률 1개]");
                    Console.Write("[바 이동 속도 :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("0.1초");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.Write("[데미지 : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write("1000");
                    Console.ResetColor();

                    Console.Write("]");
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(12, 29);
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }


    }
}
