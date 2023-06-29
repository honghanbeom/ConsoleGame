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

        public void Get(Variable var_)
        { 
            this.v = var_;
        }

        public void RandomEvent()
        { 
            Random random = new Random();
            int ranEventnumber = random.Next(0,4);
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

        public void Event0()
        {
            // 모닥불 정령들 실패 비례 공격력 +
            Console.WriteLine("'보랏빛의 불의 정령처럼' 보이는 무리가 커다란 모닥불 주위에서" +
                " 조그만 부스러기를 던지며 춤추고 있다. 불에 넣은 부스러기는 빛이 나더니 소멸해버린다.");
            Console.WriteLine("[ 제물선택 : 1~4][ 나가기 : N]");
           
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("1개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    Console.WriteLine("공격력 +10");
                    v.userDamage += 10;
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("2개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.WriteLine("공격력 +20");
                    v.userDamage += 20;
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("3개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.WriteLine("공격력 +30");
                    v.userDamage += 30;
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("4개의 실패확률+.");
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    v.userProb.Add(v.fail);
                    Console.WriteLine("공격력 +40");
                    v.userDamage += 40;
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event1()
        {
            // 체력회복, 최대체력 +
            Console.WriteLine("샘물이 있다.");
            Console.WriteLine("[마신다 :Y][지나간다 :N]");

            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("유저의 체력 50%을 회복합니다.");
                    Console.WriteLine("최대체력 +5");
                    v.userMaxHP += 5;
                    if (v.userMaxHP < v.userCurrentHP * 1.4)
                    {
                        v.userCurrentHP = v.userMaxHP;
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                        Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);
                    }
                    else
                    {
                        v.userCurrentHP = (int)(v.userCurrentHP * 1.4);
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                        Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);
                    }
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event2()
        {
            // 마상 시합 랜덤 돈 건 만큼 획득 
            Console.WriteLine("마상시합");
            Console.WriteLine("두 기사가 서로 마주보고 있는곳을 지나가려다가 한 기사가" +
                " 창으로 길을 막고 오늘은 애완동물을 살해한 나쁜놈을 죽이는 날이라" +
                " 그때까지는 플레이어가 못 지나갈수도 있다고 하며, " +
                "이길것 같은 사람에게 배팅해보지 않겠냐는 제안을 한다.");
            Random random = new Random();
            // 0 = 살해범승리 1= 주인승리
            int randomIdx = random.Next(0, 1);


            Console.WriteLine("[살해범 : 1][주인 : 2][나가기 :N]");
            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {

                case ConsoleKey.D1:
                    Console.CursorVisible = true;

                    Console.WriteLine("거실 금액을 입력해주세요");
                    Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                    ConsoleKeyInfo key = Console.ReadKey();
                    int x = int.Parse(key.KeyChar.ToString());
                    if (x <= v.userGold)
                    {
                        if (randomIdx == 0)
                        {
                            Console.WriteLine("살해범의 승리");
                            v.userGold = v.userGold + x*2;
                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.CursorVisible = false;

                        }
                        else if (randomIdx == 1)
                        {
                            Console.WriteLine("주인의 승리");
                            v.userGold -= x;
                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.CursorVisible = false;

                        }
                        else
                        {
                            Console.WriteLine("돈을 가져와야지 뭐하는 짓이야?");
                            v.userGold = 0;
                            Console.WriteLine("[유저 소지금 : {0}]",v.userGold);
                            Console.CursorVisible = false;

                        }
                    }
                    break;
                case ConsoleKey.D2:
                    Console.CursorVisible = true;

                    Console.WriteLine("거실 금액을 입력해주세요");
                    Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                    ConsoleKeyInfo key2 = Console.ReadKey();
                    int y = int.Parse(key2.KeyChar.ToString());
                    if (y <= v.userGold)
                    {
                        if (randomIdx == 0)
                        {
                            Console.WriteLine("살해범의 승리");
                            v.userGold -= y;
                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.CursorVisible = false;

                        }
                        else if (randomIdx == 1)
                        {
                            Console.WriteLine("주인의 승리");
                            v.userGold = v.userGold + y * 2;
                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.CursorVisible = false;

                        }
                        else
                        {
                            Console.WriteLine("돈을 가져와야지 뭐하는 짓이야?");
                            v.userGold = 0;
                            Console.WriteLine("[유저 소지금 : {0}]", v.userGold);
                            Console.CursorVisible = false;

                        }
                    }

                    break;
                case ConsoleKey.N:
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
        public void Event3()
        {
            // 피의 돌림판 반드시 체력-, 랜덤 최대 체력+,방어력+,성공+,골드+,잭팟(전부 획득)
            Console.WriteLine("그렘린의 돌림판을 돌린다. 다음 5개 중 하나가 나온다.");
            Console.WriteLine("[대가 : 체력최대 -5]");
            v.userMaxHP -= 5;
            if (v.userMaxHP == v.userCurrentHP)
            {
                v.userCurrentHP -= 5;
            }
            Thread.Sleep(1000);
            Console.WriteLine("[현재체력 : {0}/ 최대체력  : {1}]",v.userCurrentHP,v.userMaxHP);

            Random random = new Random();
            // 0 = 최대체력 1= 방어력 2= 성공 3= 골드 4= 잭팟
            int randomIdx2 = random.Next(0, 4);
            switch (randomIdx2)
            {
                case 0:
                    v.userMaxHP += 5;
                    Console.WriteLine("[최대체력 + 5]");
                    Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);

                    break;
                case 1:
                    v.userArmor += 5;
                    Console.WriteLine("[방어력 + 5]");
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);


                    break;
                case 2:
                    v.userProb.Insert(1, v.success);
                    Console.WriteLine("[성공확률 + 1]");
                    int userSuccessCount = v.userProb.Count(x => x == v.success);
                    Console.WriteLine("[유저 성공 갯수 : {0}]",userSuccessCount);


                    break;
                case 3:
                    v.userGold += 100;
                    Console.WriteLine("[골드 + 100]");
                    Console.WriteLine("[유저 골드  : {0}]", v.userGold);


                    break;
                case 4:
                    v.userMaxHP += 5;
                    v.userArmor += 5;
                    v.userProb.Add(v.success);
                    v.userGold += 100;

                    Console.WriteLine("잭팟!");
                    Console.WriteLine("[최대체력 + 5]");
                    Console.WriteLine("[방어력 + 5]");
                    Console.WriteLine("[성공확률 + 1]");
                    Console.WriteLine("[골드 + 100]");
                    Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);
                    v.userProb.Insert(1, v.success);
                    userSuccessCount = v.userProb.Count(x => x == v.success);
                    Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
                    Console.WriteLine("[유저 골드  : {0}]", v.userGold);



                    break;

            }
        }
        public void Event4()
        {
            // 야수의 심장
            Console.WriteLine("[야수의 심장]");
            Console.WriteLine("[ 받기 :Y][ 떠나기 :N]");

            ConsoleKeyInfo sel = Console.ReadKey(true);
            switch (sel.Key)
            {
                case ConsoleKey.Y:
                    v.userProb.Clear();
                    v.userProb.Add(v.userSelect);
                    v.userProb.Add(v.success);
                    v.userProb.Add(v.fail);
                    v.userDelay = 100;
                    v.userDamage = 1000;
                    Console.WriteLine("야수의 심장을 획득하셨습니다.");
                    Console.WriteLine("[성공확률 1개][실패확률 1개]");
                    Console.WriteLine("[바 이동 속도 :  0.1초]");
                    Console.WriteLine("[데미지 : 1000]");
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("지나갑니다.");
                    break;
            }
        }
    }
}
