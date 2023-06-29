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
                        // 말캉말캉한 장화 드롭
                        mc.MonsterInit("슬라임", 2, 10, 20, 0);
                        mc.NormalMonsterPrint("슬라임", 2, 10, 0);

                    }
                    break;
                case 2:
                    {
                        // 늑대무리 소환
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
                if (mc.monsterName == "늑대")
                {
                    Random random = new Random();
                    int wolfRandom = random.Next(0, 10);
                    // 30%의 확률
                    if (wolfRandom >= 7)
                    {
                        Console.WriteLine("늑대가 늑대무리를 불렀다!");
                        _getch();
                        WolfEvent();
                        Fight();
                    }
                }
                if (mc.monsterName == "스켈레톤")
                {
                    Random random = new Random();
                    int skeletonRandom = random.Next(0, 10);
                    // 20%의 확률
                    if (skeletonRandom >= 8)
                    {
                        Console.WriteLine("스켈레톤이 아이템을 떨어뜨렸다!");
                        Thread.Sleep(1000);
                        Console.WriteLine("[스켈레톤 갑옷을 획득했다!]");
                        v.itemInven.Add("[스켈레톤 갑옷]");
                        Console.WriteLine("Press Any Key To Continue");
                        _getch();

                    }
                }
                if (mc.monsterName == "슬라임")
                {
                    Random random = new Random();
                    int slimeRandom = random.Next(0, 10);
                    // 10%의 확률
                    if (slimeRandom >= 9)
                    {
                        Console.WriteLine("슬라임이 아이템을 떨어뜨렸다!");
                        Thread.Sleep(1000);
                        Console.WriteLine("[물컹물컹 장화를 획득했다!]");
                        v.itemInven.Add("[물컹물컹 장화]");
                        Console.WriteLine("Press Any Key To Continue");
                        _getch();

                    }
                }


            }
            if (v.userCurrentHP <= 0)
            {
                print.GameOver();
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

        }

        public void WolfEvent()
        {
            mc.MonsterInit("늑대무리", 12, 25, 25, 1);
            mc.NormalMonsterPrint("늑대무리", 12, 25, 1);
        }
        

    }
}
