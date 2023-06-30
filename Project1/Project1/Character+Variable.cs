using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Variable
    {
        // Map
        public int moveCount = 11;
        public string heal = "♨";
        public string normal = "ⓜ";
        public string elite = "ⓔ";
        public string randomEvent = "♬";
        public string userPosition = "㉯";
        public string boss = "ⓑ";
        public string clearStage = "X";
        public string[] mapCreate = new string[12];






        // AttackSystem
        public string fail = "□";
        public string success = "■";
        public string userSelect = "┃";
        public int index;
        public bool spaceBar = false;





        // Character
        public int userCurrentHP;
        public int userDelay;
        public int userGold;
        public int userDamage;
        public int userArmor;
        public string userJob;
        public int userMaxHP;
        public int userCri;
        public int userSelectCount = 0;
        public List<string> userProb = new List<string>();
        public List<string> userCopy = new List<string>();



        // Shop
        public List<string> itemInven = new List<string>();
        public List<string> shopListAll;
        public List<string> shopList = new List<string>();
        public Dictionary<string, int> itemAll = new Dictionary<string, int>();
        public int outCount = 0;
        public int resetCount = 0;


        GamePrint g = new GamePrint();

        public void Get(GamePrint g_)
        { 
            this.g = g_;
        }

        public void CharacterInit(string userJob, int userMaxHP, int userDamage, int userGold, 
                                    int userDelay, int userCurrentHP, int userArmor)
        {
            this.userJob = userJob;
            this.userMaxHP = userMaxHP;
            this.userDamage = userDamage;
            this.userGold = userGold;
            this.userDelay = userDelay;  
            this.userCurrentHP = userCurrentHP;
            this.userArmor = userArmor;

        }



        public void CharacterPrint(string userJob, int userMaxHP, int userArmor, int userDamage, int userGold, int userDelay)
        {
            Console.SetCursorPosition(38, 11);

            Console.WriteLine("[직업 : {0}]", userJob);
            Console.SetCursorPosition(38, 12);

            Console.WriteLine("[체력 : {0}]", userMaxHP);
            Console.SetCursorPosition(38, 13);

            Console.WriteLine("[방어력 : {0}]", userArmor);
            Console.SetCursorPosition(38, 14);

            Console.WriteLine("[공격력 : {0}]", userDamage);
            Console.SetCursorPosition(38, 15);

            Console.WriteLine("[골드 : {0}]", userGold);
            Console.SetCursorPosition(34, 16);

            Console.WriteLine("[바 이동속도 : {0}초]", userDelay*0.001);
        }

        public void Select()
        {
            while (userSelectCount != 1)
            {
                g.GameConsolePrint();
                Console.SetCursorPosition(38, 5);
                Console.WriteLine("[캐릭터 선택창]");
                Console.SetCursorPosition(29, 6);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[1. 전사]  ");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("[2. 도적]  ");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.Write("[3. 마법사] ");
                Console.ResetColor();
                Console.WriteLine();
                Console.SetCursorPosition(24, 7);
                Console.WriteLine("원하시는 직업을 보시려면 번호를 눌러주세요");

                ConsoleKeyInfo charInfo = Console.ReadKey(true);

                switch (charInfo.Key)
                {

                    case ConsoleKey.D1:
                        Console.SetCursorPosition(38, 10);

                        CharacterPrint("전사", 100, 2 ,10, 100, 20) ;

                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("체력이 많고, 가장 무난한 초보자용 캐릭터입니다.");
                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();
                        ConsoleKeyInfo charSelect1 = Console.ReadKey(true);
                        switch (charSelect1.Key)
                        {
                            case ConsoleKey.Y:
                                WarriorAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.SetCursorPosition(38, 10);

                        CharacterPrint("도적", 80, 1, 7, 200, 15);
                        Console.SetCursorPosition(38, 17);
   
                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("성공확률, 골드가 높은 대신 공격력과 아머, 체력이 낮습니다.");
                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();
                        ConsoleKeyInfo charSelect2 = Console.ReadKey(true);
                        switch (charSelect2.Key)
                        {
                            case ConsoleKey.Y:
                                TheifAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();

                                break;
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.SetCursorPosition(38, 10);

                        CharacterPrint("마법사", 60, 0, 20, 120, 15);
                        Console.SetCursorPosition(38, 17);

                        Console.SetCursorPosition(22, 17);
                        Console.WriteLine("골드, 공격력이 높은 대신 아머와 체력, 성공확률이 낮습니다.");
                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();
                        ConsoleKeyInfo charSelect3 = Console.ReadKey(true);

                        switch (charSelect3.Key)
                        {
                            case ConsoleKey.Y:
                                MagicianAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;
                    case ConsoleKey.Tab:
                        Console.SetCursorPosition(38, 10);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("[개발자 모드]");
                        Console.ResetColor();
                        Console.SetCursorPosition(32, 18);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        Console.ResetColor();
                        ConsoleKeyInfo charSelect4 = Console.ReadKey(true);
                        switch (charSelect4.Key)
                        {
                            case ConsoleKey.Y:
                                DevelopAdd();
                                userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                Console.Clear();
                                break;
                        }
                        break;
                    default:
                        Console.SetCursorPosition(38, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("잘못된 입력값입니다.");
                        Console.ResetColor();
                        Console.Clear();
                        break;
                }
            }
        }


        //(string userJob, int userMaxHP, int userDamage, int userGold,
        //                            int userDelay, int userCurrentHP, int userArmor)
        public void WarriorAdd()
        {
            // 무난추
            CharacterInit("전사", 100, 10, 100, 20, 100, 2);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }

        public void TheifAdd()
        {
            // 바속도+, 골드+, 확률+, 데미지-, 아머-, 체력-
            CharacterInit("도적", 80, 7, 200, 15, 80, 1);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }

        public void MagicianAdd()
        {
            // 바속도+, 골드+, 확률+, 데미지+, 아머-, 체력-
            CharacterInit("마법사", 60, 20, 150, 30, 60, 5);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);
        }
        public void DevelopAdd()
        {
            // 바속도+, 골드+, 확률+, 데미지+, 아머-, 체력-
            CharacterInit("개발자", 1000, 10, 100_000, 150, 1000, 0);
            userProb.Add(userSelect);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(success);
            userProb.Add(fail);
            userProb.Add(fail);
            userProb.Add(fail);

        }

        public void Stat()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();
            Console.SetCursorPosition(23, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[유저 정보]");
            Console.ResetColor();
            Console.SetCursorPosition(18,5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[유저 직업 : ");
            Console.ResetColor();
            if (userJob == "전사")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");

            }
            if (userJob == "도적")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            if (userJob == "마법사")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            if (userJob == "개발자")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("{0}", userJob);
                Console.ResetColor();
                Console.Write("]");


            }
            Console.WriteLine();
            Console.SetCursorPosition(18, 6);

            Console.Write("[현재 체력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userCurrentHP);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 7);

            Console.Write("[최대 체력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userMaxHP);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 8);

            Console.Write("[공격력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userDamage);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 9);

            Console.Write("[방어력 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userArmor);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 10);

            int userSuccessCount = userProb.Count(x => x == success);
            int userfailCount = userProb.Count(x => x == fail);

            Console.Write("[성공 확률 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userSuccessCount);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 11);

            Console.Write("[실패 확률 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userfailCount);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 12);

            Console.Write("[바 이동속도 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userDelay*0.001);
            Console.ResetColor();
            Console.Write("]");
            Console.SetCursorPosition(18, 13);

            Console.Write("[소지금 :");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", userGold);
            Console.ResetColor();
            Console.Write("]");
        }

    


    }
}
