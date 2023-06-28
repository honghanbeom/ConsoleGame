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
        GamePrint print = new GamePrint();

        public void Get(Variable v, MonsterCreate monsterCreate_, AttackSystem attack_,
            GamePrint print_)
        {
            this.v = v;
            this.mc = monsterCreate_;
            //this.ch = character_;
            this.att = attack_;
            this.print = print_;  
        }

        public void MonsterAdd()
        {
            Random random = new Random();
            int mRandomIndex = random.Next(0, 2);
            switch (mRandomIndex)
            {
                case 0:
                    {
                        // 오크 특수효과로 고블린 소환 넣기(되면)
                        mc.MonsterInit("오크", 8, 40, 100, 3);
                        mc.NormalMonsterPrint("오크", 8, 40, 3);
                    }
                    break;
                case 1:
                    {
                        // 스톤골렘 특수효과로 스턴 넣기(되면)
                        mc.MonsterInit("스톤 골렘", 5, 100, 150, 5);
                        mc.NormalMonsterPrint("스톤 골렘", 5, 100, 5);

                    }
                    break;
                case 2:
                    {
                        // 와이번 특수효과로 회피 넣기(되면)
                        mc.MonsterInit("와이번", 15, 30, 120, 2);
                        mc.NormalMonsterPrint("와이번", 15, 30, 2);
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
                v.index = 0;
                v.spaceBar = false;


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
