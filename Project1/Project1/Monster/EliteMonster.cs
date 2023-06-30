using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class EliteMonster
    {


        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();

        Variable v = new Variable();
        MonsterCreate mc = new MonsterCreate();
        //Character ch = new Character();
        AttackSystem att = new AttackSystem();
        GamePrint g = new GamePrint();

        public void Get(Variable v, MonsterCreate monsterCreate_, AttackSystem attack_,
            GamePrint print_)
        {
            this.v = v;
            this.mc = monsterCreate_;
            //this.ch = character_;
            this.att = attack_;
            this.g = print_;  
        }

        public void MonsterAdd()
        {
            Random random = new Random();
            int mRandomIndex = random.Next(0, 3);
            switch (mRandomIndex)
            {
                case 0:
                    {

                        mc.MonsterInit("오크", 8, 40, 100, 3);
                        mc.EliteMonsterPrint("오크", 8, 40, 3);
                    }
                    break;
                case 1:
                    {
                        // 스톤골렘 특수효과로 스턴
                        mc.MonsterInit("스톤 골렘", 5, 100, 150, 5);
                        mc.EliteMonsterPrint("스톤 골렘", 5, 100, 5);

                    }
                    break;
                case 2:
                    {
                        // 와이번 특수효과로 회피
                        mc.MonsterInit("와이번", 15, 30, 120, 2);
                        mc.EliteMonsterPrint("와이번", 15, 30, 2);
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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0}", mc.monsterName);
            Console.ResetColor();
            Console.Write("와(과) 전투를 시작합니다!]");
            Console.SetCursorPosition(20, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Press Any Key To Fight]");
            Console.ResetColor();
            _getch();
            _getch();

            int golemStun = 0;

            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {
                if (golemStun == 0 && mc.monsterName == "오크")
                {
                    // 평소
                    Console.Clear();
                    g.GameMapPrint();
                    g.GameInfoPrint();
                    Console.SetCursorPosition(5, 28);
                    Console.WriteLine("                                        ");

                    att.AttackControl();
                    mc.MonsterDamage();
                    Thread.Sleep(1000);
                    v.spaceBar = false;
                    v.index = 0;
                }

                if (golemStun == 0 && mc.monsterName == "스톤 골렘")
                {
                    // 스톤골렘
                    Console.Clear();

                    g.GameMapPrint();

                    g.GameInfoPrint();
                    g.stoneGolemPrint();
                    Console.SetCursorPosition(26, 5);
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("스톤 골렘");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(21, 17);
                    Console.Write("[몬스터체력 : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0}", mc.monsterHP);
                    Console.ResetColor();
                    Console.Write("/");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("100");
                    Console.ResetColor();
                    Console.Write("]");

                    Console.SetCursorPosition(5, 28);
                    Console.WriteLine("                                        ");


                    att.AttackControl();
                    mc.MonsterDamage();
                    Thread.Sleep(1000);
                    v.spaceBar = false;
                    v.index = 0;
                }

                // 골렘 스턴
                if (golemStun == 1)
                {

                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    g.GameMapPrint();
                    g.GameMonsterPrint();
                    Console.ResetColor();

                    Console.SetCursorPosition(68, 15);
                    Console.Write("[");
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.Write("골렘 스턴");
                    Console.ResetColor();
                    Console.Write("]");
                    mc.MonsterDamage();
                    Thread.Sleep(1500);
                    v.index = 0;
                    v.spaceBar = false;
                    golemStun--;
                    Console.Clear();
            
                }
                if (mc.monsterName == "스톤 골렘")
                {
                    Random random = new Random();
                    int stoneRandom = random.Next(0, 10);
                    // 30%의 확률
                    if (stoneRandom >= 5)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed; 
                        g.GameMapPrint();
                        Console.SetCursorPosition(14, 5);
                        Console.Write("[골렘의 특수효과 : 스턴]");
                        Console.SetCursorPosition(14, 7);
                        Console.Write("유저는 다음 턴 공격할 수 없습니다.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        Console.Clear();
                        golemStun++;
                    }
                }
                if (mc.monsterName == "와이번")
                {
                    Random random = new Random();
                    int wyvernRandom = random.Next(0, 10);
                    // 40%의 확률
                    if (wyvernRandom >= 6)
                    {
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();


                        Console.SetCursorPosition(26, 5);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("와이번");
                        Console.ResetColor();
                        Console.Write("]");

                        Console.SetCursorPosition(21, 17);
                        Console.Write("[몬스터체력 : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0}", mc.monsterHP);
                        Console.ResetColor();
                        Console.Write("/");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("30");
                        Console.ResetColor();
                        Console.Write("]");
                        g.WyvernPrint();

                        // 결과에 생산하지않는 더미
                        att.Copy();
                        att.RandomUserDamage();
                        att.Spacebar();
                        att.ResultDelete();

                        
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        g.GameMapPrint();
                        g.GameMonsterPrint();
                        Console.ResetColor();

                        //g.wMovePrint();




                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        Console.SetCursorPosition(21, 5);
                        Console.Write("[와이번의 특수효과 : 회피]");
                        Console.SetCursorPosition(14, 6);
                        Console.Write("유저의 공격을 와이번이 회피했습니다.");
                        Console.ResetColor();


                        Console.SetCursorPosition(68, 15);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("와이번 회피");
                        Console.ResetColor();
                        Console.Write("]");

                        mc.MonsterDamage();
                        Thread.Sleep(1700);
                        v.index = 0;
                        v.spaceBar = false;
                        Console.Clear();

                    }
                    else 
                    {
                        // 평소
                        Console.Clear();
                        g.GameMapPrint();
                        g.GameInfoPrint();

                        g.WyvernPrint();


                        Console.SetCursorPosition(26, 5);
                        Console.Write("[");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("와이번");
                        Console.ResetColor();
                        Console.Write("]");

                        Console.SetCursorPosition(21, 17);
                        Console.Write("[몬스터체력 : ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0}", mc.monsterHP);
                        Console.ResetColor();
                        Console.Write("/");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("30");
                        Console.ResetColor();
                        Console.Write("]");
                        Console.SetCursorPosition(5, 28);
                        Console.WriteLine("                                        ");


                        att.AttackControl();
                        Thread.Sleep(1000);
                        mc.MonsterDamage();
                        v.spaceBar = false;
                        v.index = 0;
                    }
                }


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
