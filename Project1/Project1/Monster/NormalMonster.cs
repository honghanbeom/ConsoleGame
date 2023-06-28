using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
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
        GamePrint print = new GamePrint();

        public void Get(Variable v, MonsterCreate mc_, AttackSystem attack_,GamePrint print)
        { 
            this.v = v;
            this.att = attack_;
            this.print = print;
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
                        mc.MonsterInit("슬라임", 2, 10, 20, 0);
                        mc.NormalMonsterPrint("슬라임", 2, 10, 0);

                    }
                    break;
                case 2:
                    {
                        mc.MonsterInit("늑대", 7, 15, 15, 1);
                        mc.NormalMonsterPrint("고블린", 7, 15, 1);
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
                        mc.MonsterInit("스켈레톤", 6, 10, 15, 2);
                        mc.NormalMonsterPrint("스켈레톤", 6, 10, 2);

                    }
                    break;
            }
        }

        public void Fight()
        {
            MonsterAdd();
            Console.WriteLine("[{0}와 전투를 시작합니다!]", mc.monsterName);
            Console.WriteLine("[Press Any Key To Fight]");
            _getch();
            while (mc.monsterHP > 0 && v.userCurrentHP > 0)
            {
                att.AttackControl();
                Thread.Sleep(1000);
                mc.MonsterDamage();
                v.spaceBar = false;
                v.index = 0;


            }
            if (mc.monsterHP <= 0 && v.userCurrentHP > 0)
            {
                Console.WriteLine("전투가 완료되었습니다.");
                v.userGold += mc.monsterMoney;
                Console.WriteLine("[플레이어 체력 : {0}]", v.userCurrentHP);
                Console.WriteLine("[유저 소지금 : {0}]", v.userGold);


            }
            if (v.userCurrentHP <= 0)
            {
                print.GameOver();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

        }
        

    }
}
