using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace Project1
{

    public class Event
    {
        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region 인스턴스화
        Variable v = new Variable();
        GamePrint g = new GamePrint();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable var_, GamePrint g_)
        { 
            this.v = var_;
            this.g = g_; 
        }
        #endregion

        #region 랜덤 이벤트 발생 메소드
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
                        // 고양이 이벤트
                        Event1();
                    }
                    break;
                case 2:
                    {
                        // 마늘 획득
                        Event2();
                    }
                    break;
                case 3:
                    {
                        // 피의 돌림판 반드시 체력-
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
        #endregion

        #region E0) 모닥불 정령 이벤트 메소드 
        public void Event0()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.ResetColor();

            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[이벤트]");
            Console.ResetColor();

            Console.SetCursorPosition(20, 4);
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
            Console.Write("[바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  1");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();

            Console.SetCursorPosition(20, 9);
            Console.Write("[바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  2");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();

            Console.SetCursorPosition(20, 10);
            Console.Write("[바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  3");
            Console.ResetColor();
            Console.Write("]");

            Console.SetCursorPosition(20, 11);
            Console.Write("[바칠 제물 수 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  4");
            Console.ResetColor();
            Console.Write("]");
            Console.ResetColor();

            Console.SetCursorPosition(24, 28);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[나가기 : N]");
            Console.ResetColor();

            // 유저 입력
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.D1:
                    Console.SetCursorPosition(22, 14);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write("개의 실패확률");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.ResetColor();

                    v.userProb.Add(v.fail);

                    Console.SetCursorPosition(22, 15);
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+10");
                    Console.ResetColor();

                    v.userDamage += 10;

                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D2:

                    Console.SetCursorPosition(22, 14);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("2");
                    Console.ResetColor();
                    Console.Write("개의 실패확률");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.ResetColor();

                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);

                    Console.SetCursorPosition(22, 15);
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+20");
                    Console.ResetColor();

                    v.userDamage += 20;

                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D3:
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(22, 14);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("3");
                    Console.ResetColor();
                    Console.Write("개의 실패확률");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.ResetColor();

                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);

                    Console.SetCursorPosition(22, 15);
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+30");
                    Console.ResetColor();

                    v.userDamage += 30;

                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.D4:

                    Console.SetCursorPosition(22, 14);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("4");
                    Console.ResetColor();
                    Console.Write("개의 실패확률");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("+");
                    Console.ResetColor();

                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);

                    Console.SetCursorPosition(22, 15);
                    Console.Write("공격력 ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("+40");
                    Console.ResetColor();

                    v.userDamage += 40;

                    Thread.Sleep(1000);
                    break;
                case ConsoleKey.N:

                    Thread.Sleep(1000);
                    break;
            }
            // (17,28)위치에 있던 단어 지우기
            Console.SetCursorPosition(17, 28);
            Console.Write("                                 ");

            Console.SetCursorPosition(24, 29);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[지나갑니다]");
            Console.ResetColor();

            Console.SetCursorPosition(20, 30);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Continue]");
            Console.ResetColor();

            _getch();
        }
        #endregion

        #region E1) 고양이 이벤트 메소드
        public void Event1()
        {
            Console.Clear();

            g.GameMapPrint();
            g.GameInfoPrint();

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

            Console.SetCursorPosition(15, 28);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[구한다 :Y]");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[지나간다 :N]");
            Console.ResetColor();

            // 유저 입력 로직
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    Random random = new Random();
                    int catRandom = random.Next(0, 2);
                    // 성공 로직
                    if (catRandom == 0)
                    {
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();

                        Console.SetCursorPosition(23, 2);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("[고양이의 보은]");
                        Console.ResetColor();

                        Console.SetCursorPosition(18, 3);
                        Console.WriteLine("고양이를 구하셨습니다!");

                        Console.SetCursorPosition(24, 4);
                        Console.Write("[성공확률 ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("+3");
                        Console.ResetColor();
                        Console.Write("]");

                        int index = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                        if (index != -1) // v.success가 발견되었을 경우
                        {
                            v.userProb.Insert(index + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                            v.userProb.Insert(index + 2, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                            v.userProb.Insert(index + 3, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                        }


                        // 유저 성공 갯수 카운트
                        int userSuccessCount = v.userProb.Count(x => x == v.success);

                        Console.SetCursorPosition(21, 5);
                        Console.Write("[유저 성공 갯수 : ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", userSuccessCount);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    // 실패 로직
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

                        Console.SetCursorPosition(13, 3);
                        Console.WriteLine("고양이를 구하다 당신도 덫에 빠졌습니다!");


                        Thread.Sleep(1000);

                        Console.SetCursorPosition(23, 4);
                        Console.Write("[실패확률 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+2");
                        Console.ResetColor();
                        Console.Write("]");

                        Console.SetCursorPosition(23, 5);
                        Console.Write("  [체력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("- 10");
                        Console.ResetColor();
                        Console.Write("]");


                        v.userProb.Add(v.fail);
                        v.userProb.Add(v.fail);
                        v.userCurrentHP -= 10;

                        // 실패 갯수 카운트
                        int userFailCount = v.userProb.Count(x => x == v.fail);

                        Console.SetCursorPosition(21, 6);
                        Console.Write("[유저 실패 갯수 : ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", userFailCount);
                        Console.ResetColor();
                        Console.Write("]");

                        Console.SetCursorPosition(23, 7);
                        Console.Write("[현재 체력 : ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0}", v.userCurrentHP);
                        Console.ResetColor();
                        Console.Write("]");
                    }
                    break;
                case ConsoleKey.N:
                    Thread.Sleep(1000);

                    // (5,28) 위치에 있던 단어 지우기
                    Console.SetCursorPosition(5, 28);
                    Console.Write("                                               ");

                    Console.SetCursorPosition(23, 29);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[지나갑니다]");
                    Console.ResetColor();
                    break;
            }
            Console.SetCursorPosition(17, 30);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Continue]");
            Console.ResetColor();
            _getch();
        }
        #endregion

        #region E2) 기부 이벤트 메소드
        public void Event2()
        {
            // 마늘 획득 이벤트
            Console.Clear();

            g.GameMapPrint();
            g.GameInfoPrint();

            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[이벤트]");
            Console.ResetColor();

            g.BeggarPrint();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(27, 5);
            Console.Write("[거지]");
            Console.ResetColor();

            Console.SetCursorPosition(12, 22);
            Console.Write("거지가 당신에게 ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("50 Gold");
            Console.ResetColor();
            Console.Write(" 기부를 요청합니다!");

            Console.SetCursorPosition(18, 29);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[기부 : A]");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[지나간다 : N]");
            Console.ResetColor();

            // 기부 출력 카운트, 기부 확인 bool
            int donateCount = 0;
            bool isDonating = true;

            ConsoleKeyInfo sel;

            while (isDonating && donateCount <= 3 && v.userGold>=50)
            {
                sel = Console.ReadKey(true);
                if (sel.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    g.GameShopPrint();

                    // 1기부 감사 출력
                    if (donateCount == 0)
                    {
                        Console.SetCursorPosition(8,8);
                        Console.Write("감사!");

                        Console.SetCursorPosition(70, 15 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        donateCount++;
                        v.userGold -= 50;
                    }
                    // 2기부 감사 출력
                    else if (donateCount == 1)
                    {
                        Console.SetCursorPosition(8, 8);
                        Console.Write("감사!");

                        Console.SetCursorPosition(40, 6);
                        Console.Write("감사!");

                        Console.SetCursorPosition(70, 14 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        Console.SetCursorPosition(70, 15 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        donateCount++;
                        v.userGold -= 50;

                    }
                    // 3기부 감사 출력
                    else if (donateCount == 2)
                    {
                        Console.SetCursorPosition(8, 8);
                        Console.Write("감사!");

                        Console.SetCursorPosition(40, 6);
                        Console.Write("감사!");

                        Console.SetCursorPosition(43, 17);
                        Console.Write("감사!");

                        Console.SetCursorPosition(70, 13 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        Console.SetCursorPosition(70, 14 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        Console.SetCursorPosition(70, 15 + donateCount);
                        Console.Write("[기부금액 : 50]");

                        donateCount++;
                        v.userGold -= 50;
                        Thread.Sleep(1500);

                    }
                    Console.ResetColor();

                    // 3기부 후 아이템 추가
                    if (donateCount == 3 && !v.itemInven.Contains("마늘"))
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        g.GameMapPrint();
                        g.GameInfoPrint();
                        Console.ResetColor();

                        Console.SetCursorPosition(27, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[HIDDEN QUEST]");
                        Console.ResetColor();

                        g.BeggarPrint();

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(27, 5);
                        Console.Write("[거지]");
                        Console.ResetColor();

                        Console.SetCursorPosition(25, 22);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("거지");
                        Console.ResetColor();
                        Console.Write("가 아이템을 준다]");
                        Thread.Sleep(1500);

                        Console.SetCursorPosition(27, 23);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("마늘");
                        Console.ResetColor();
                        Console.Write(" 획득]");

                        v.itemInven.Add("마늘");
                        Thread.Sleep(1000);
                        isDonating = false;
                    }
                }
                else if (sel.Key == ConsoleKey.N)
                {
                    isDonating = false;

                    Thread.Sleep(1000);
                    Console.SetCursorPosition(25, 29);
                    Console.WriteLine("[지나갑니다]");
                }
            }
            if (v.userGold < 50)
            {
                Console.SetCursorPosition(8, 8);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("ㅉㅉ 거지쉑!");
                Console.ResetColor();
            }
            // (17, 28)위치에 있던 단어 지우기
            Console.SetCursorPosition(17, 28);
            Console.Write("                                 ");

            // (17, 29)위치에 있던 단어 지우기
            Console.SetCursorPosition(17, 29);
            Console.Write("                                 ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(17, 28);
            Console.WriteLine("[Press Any Key To Continue]");
            Console.ResetColor();
            _getch();
        }
        #endregion

        #region E3) 돌림판 이벤트 메소드
        public void Event3()
        {
            Console.Clear();

            g.GameMapPrint();
            g.GameInfoPrint();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(27, 2);
            Console.Write("[이벤트]");
            Console.ResetColor();

            Console.SetCursorPosition(22, 4);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[그렘린의 돌림판]");
            Console.ResetColor();

            Console.SetCursorPosition(22, 5);
            Console.Write("[대가 : ");
            Console.Write("체력");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("- 5");
            Console.ResetColor();
            Console.Write("]");

            v.userCurrentHP -= 5;

            // 피가 0이 되면 죽음
            if (v.userCurrentHP - 5 <= 0)
            {
                g.GameOver();
            }

            Console.SetCursorPosition(18, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Roll]");
            Console.ResetColor();

            _getch();

            Random random = new Random();
            // 0 = 최대체력 1= 방어력 2= 성공 3= 골드 4= 잭팟
            int randomIdx2 = random.Next(0, 5);
            switch (randomIdx2)
            {
                case 0:
                    Thread.Sleep(1000);
                    v.userMaxHP += 5;

                    Console.SetCursorPosition(23, 9);
                    Console.Write("[최대 체력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(16, 10);
                    Console.Write("[현재체력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userCurrentHP);
                    Console.ResetColor();
                    Console.Write("/ 최대체력  : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userMaxHP);
                    Console.ResetColor();
                    Console.Write("]");

                    break;
                case 1:
                    Thread.Sleep(1000);

                    v.userArmor += 5;

                    Console.SetCursorPosition(23, 9);
                    Console.Write("[방어력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(23, 10);
                    Console.Write("[방어력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userArmor);
                    Console.ResetColor();
                    Console.Write("]");

                    break;
                case 2:
                    Thread.Sleep(1000);
                    int index = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                    if (index != -1) // v.success가 발견되었을 경우
                    {
                        v.userProb.Insert(index + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                    }
                    v.userArmor += 5;
                    v.userProb.Insert(1, v.success);

                    Console.SetCursorPosition(23, 9);
                    Console.Write("[성공확률 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 1");
                    Console.ResetColor();
                    Console.Write("]");

                    // 유저 성공 카운트
                    int userSuccessCount = v.userProb.Count(x => x == v.success);

                    Console.SetCursorPosition(20, 10);
                    Console.Write("[유저 성공 갯수 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", userSuccessCount);
                    Console.ResetColor();
                    Console.Write("]");

                    break;
                case 3:
                    Thread.Sleep(1000);

                    v.userGold += 50;

                    Console.SetCursorPosition(27, 9);
                    Console.Write("[골드");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 50");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(22, 10);
                    Console.Write("[소지금 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}",v.userGold);
                    Console.ResetColor();
                    Console.Write("]");

                    break;
                case 4:
                    Thread.Sleep(1000);
                    int index2 = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                    if (index2 != -1) // v.success가 발견되었을 경우
                    {
                        v.userProb.Insert(index2 + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                    }
                    v.userMaxHP += 5;
                    v.userArmor += 5;
                    v.userGold += 50;

                    Console.SetCursorPosition(26, 9);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[JACKPOT]");
                    Console.ResetColor();


                    Console.SetCursorPosition(23, 10);
                    Console.Write("[최대 체력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(16, 15);
                    Console.Write("[현재체력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userCurrentHP);
                    Console.ResetColor();
                    Console.Write("/ 최대체력  : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userMaxHP);
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(23, 11);
                    Console.Write("[방어력");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 5");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(23, 16);
                    Console.Write("[방어력 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userArmor);
                    Console.ResetColor();
                    Console.Write("]");


                    Console.SetCursorPosition(23, 12);
                    Console.Write("[성공확률 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 1");
                    Console.ResetColor();
                    Console.Write("]");
                    Console.SetCursorPosition(20, 17);

                    // 유저 성공 갯수 카운트
                    int userSuccessCount3 = v.userProb.Count(x => x == v.success);

                    Console.Write("[유저 성공 갯수 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", userSuccessCount3);
                    Console.ResetColor();
                    Console.Write("]");


                    Console.SetCursorPosition(25, 13);
                    Console.Write("[골드");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("+ 50");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(22, 18);
                    Console.Write("[소지금 : ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0}", v.userGold);
                    Console.ResetColor();
                    Console.Write("]");
                    break;

            }
            Console.SetCursorPosition(17, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Continue]");
            Console.ResetColor();

            _getch();
        }
        #endregion

        #region E4) 야수의 심장 메소드
        public void Event4()
        {
            Console.Clear();

            g.GameMapPrint();

            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[이벤트]");
            Console.ResetColor();

            Console.SetCursorPosition(23, 3);
            Console.WriteLine("[야수의 심장]");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            g.LionPrint();
            Console.ResetColor();

            Console.SetCursorPosition(20, 17);
            Console.Write("[ 받기 :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y");
            Console.ResetColor();
            Console.Write("][ 떠나기 :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("N");
            Console.ResetColor();
            Console.Write("]");

            // 유저 입력
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    // 야수의 심장 특성
                    v.userProb.Clear();
                    v.userProb.Add(v.userSelect);
                    v.userProb.Add(v.fail);
                    v.userProb.Insert(1,v.success);
                    v.userDelay = 10;
                    v.userDamage = 100;

                    Console.SetCursorPosition(17, 6);
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("야수의 심장");
                    Console.ResetColor();
                    Console.Write("]을 획득하셨습니다.");

                    Console.SetCursorPosition(19, 9);
                    Console.Write("[성공확률 ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write("개][실패확률 ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("1");
                    Console.ResetColor();
                    Console.Write("개]");

                    Console.SetCursorPosition(19,10);
                    Console.Write("[바 이동 속도 :  ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("0.01초");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(19, 11);
                    Console.Write("[데미지 : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("100");
                    Console.ResetColor();
                    Console.Write("]");

                    break;
                case ConsoleKey.N:
                    Console.Clear();

                    g.GameMapPrint();
                    g.GameInfoPrint();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(27, 2);
                    Console.Write("[이벤트]");
                    Console.ResetColor();


                    Console.SetCursorPosition(23, 3);
                    Console.Write("[야수의 심장]");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    g.LionPrint();
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    Console.SetCursorPosition(20, 28);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[지나갑니다]");
                    Console.ResetColor();

                    break;
            }

            Console.SetCursorPosition(17, 29);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[Press Any Key To Continue]");
            Console.ResetColor();

            _getch();
        }
        #endregion
    }
}
