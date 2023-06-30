using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class NormalMonster
    {




        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();

        Variable v = new Variable();
        MonsterCreate mc = new MonsterCreate();
        AttackSystem att = new AttackSystem();
        GamePrint g = new GamePrint();

        public void Get(Variable v, MonsterCreate mc_, AttackSystem attack_,GamePrint print)
        { 
            this.v = v;
            this.att = attack_;
            this.g = print;
            this.mc = mc_;
        }

        public void MonsterAdd()
        {
            Random random = new Random();
            int mRandomIndex = random.Next(0,4);
            switch (mRandomIndex)
            {
                case 0:
                    {
                        mc.MonsterInit("고블린", 5, 20, 30, 1);
                        mc.NormalMonsterPrint("고블린", 5, 20, 1);
                    }
                    break;
                case 1:
                    {
                        // 말캉말캉한 장화 드롭
                        mc.MonsterInit("슬라임", 2, 10, 20, 0);
                        mc.NormalMonsterPrint("슬라임", 2, 10, 0);

                    }
                    break;
                case 2:
                    {
                        // 늑대무리 소환 (핫픽스 요함)
                        mc.MonsterInit("늑대", 7, 15, 15, 1);
                        mc.NormalMonsterPrint("늑대", 7, 15, 1);
                    }
                    break;
                case 3:
                    {
                        
                        mc.MonsterInit("박쥐", 3, 12, 12, 0);
                        mc.NormalMonsterPrint("박쥐", 3, 12, 0);

                    }
                    break;
                case 4:
                    {
                        // 스켈레톤 갑옷 드롭
                        mc.MonsterInit("스켈레톤", 6, 10, 15, 2);
                        mc.NormalMonsterPrint("스켈레톤", 6, 10, 2);

                    }
                    break;
            }
        }

        public void Fight()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();
            MonsterAdd();
            Console.SetCursorPosition(17, 2);
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mc.monsterName);
            Console.ResetColor();
            Console.Write("와(과) 전투를 시작합니다!]");
            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Fight]");
            Console.ResetColor();
            _getch();
            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {

                Console.SetCursorPosition(5, 28);
                Console.WriteLine("                                        ");

                att.AttackControl();
                Thread.Sleep(1000);
                mc.MonsterDamage();
                v.spaceBar = false;
                v.index = 0;


            }
            if (mc.monsterHP <= 0 && v.userCurrentHP > 0)
            {
                Console.Clear();
                g.GameMapPrint();
                g.GameInfoPrint();
                Console.SetCursorPosition(17, 5);
                Console.WriteLine("전투가 완료되었습니다.");
                v.userGold += mc.monsterMoney;

                Console.SetCursorPosition(21, 6);
                Console.Write("[유저 HP : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("{0}", v.userCurrentHP);
                Console.ResetColor();
                Console.Write("]");

                Console.SetCursorPosition(19, 7);

                Console.Write("[유저 골드 : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("{0}", v.userGold);
                Console.ResetColor();
                Console.Write("]");
                if (mc.monsterName == "스켈레톤")
                {
                    Random random = new Random();
                    int skeletonRandom = random.Next(0, 10);
                    // 30%의 확률
                    if (skeletonRandom >= 3)
                    {
                        Console.SetCursorPosition(10, 9);
                        Console.Write("[");
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.Write("스켈레톤");
                        Console.ResetColor();
                        Console.Write("이 아이템을 떨어뜨렸다!]");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(17, 10);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("스켈레톤 갑옷");
                        Console.ResetColor();
                        Console.Write(" 획득]");
                        v.itemInven.Add("[스켈레톤 갑옷]");
                        Console.SetCursorPosition(20, 28);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ResetColor();
                        _getch();

                    }
                }
                if (mc.monsterName == "슬라임")
                {
                    Random random = new Random();
                    int slimeRandom = random.Next(0, 10);
                    // 20%의 확률
                    if (slimeRandom >= 8)
                    {
                        Console.SetCursorPosition(10, 9);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("슬라임");
                        Console.ResetColor();
                        Console.Write("이 아이템을 떨어뜨렸다!]");
                        Thread.Sleep(1000);
                        Console.SetCursorPosition(17, 10);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("물컹물컹 장화");
                        Console.ResetColor();
                        Console.Write(" 획득]");
                        v.itemInven.Add("[물컹물컹 장화]");
                        Console.SetCursorPosition(20, 28);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press Any Key To Continue");
                        Console.ResetColor();
                        _getch();

                    }
                }
                Console.SetCursorPosition(20, 28);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press Any Key To Continue");
                Console.ResetColor();
                _getch();


            }
            if (v.userCurrentHP <= 0)
            {
                g.GameOver();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

        }


        

    }
}
