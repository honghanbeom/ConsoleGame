using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Character
    {

        Variable v = new Variable();

        public void Get(Variable var_)
        {
            this.v = var_;
        }



        AttackSystem att = new AttackSystem();

        public void Get(AttackSystem att_)
        { 
            this.att = att_;   
        }


        public void CharacterInit(string userJob, int userMaxHP, int userDamage, int userGold, int userDelay)
        {
            this.v.userJob = userJob;
            this.v.userMaxHP = userMaxHP;
            this.v.userDamage = userDamage;
            this.v.userGold = userGold;
            this.v.userDelay = userDelay;     
        }



        public void CharacterPrint(string userJob, int userMaxHP, int userDamage, int userGold, int userDelay)
        {
            Console.WriteLine("[직업 : {0}]",userJob);
            Console.WriteLine("[체력 : {0}]",userMaxHP);
            Console.WriteLine("[공격력 : {0}]",userDamage);
            Console.WriteLine("[골드 : {0}]",userGold);
            Console.WriteLine("[바 속도 : {0}]",userDelay);
            v.userHP = userMaxHP;
        }

        public void Select()
        {
            while (v.userSelectCount != 1)
            {
                Console.WriteLine("[1. 전사]");
                Console.WriteLine("원하시는 직업을 보시려면 번호를 눌러주세요");
                ConsoleKeyInfo charInfo = Console.ReadKey(true);
                switch (charInfo.Key)
                {
                    case ConsoleKey.D1:
                        CharacterPrint("전사", 100, 10, 100, 1000);
                        Console.WriteLine("[직업확정 : Y] [리턴 : N]");
                        ConsoleKeyInfo charSelect = Console.ReadKey(true);
                        switch (charSelect.Key)
                        {
                            case ConsoleKey.Y:
                                CharacterInit("전사", 100, 10, 100, 1000);
                                WarriorAdd();
                                v.userSelectCount++;
                                break;
                            case ConsoleKey.N:
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    default:
                        Console.WriteLine("잘못된 입력값입니다.");
                        break;
                }
            }
        }

        public void WarriorAdd()
        {
            v.userProb.Add(v.userSelect);
            v.userProb.Add(v.success);
            v.userProb.Add(v.success);
            v.userProb.Add(v.success);
            v.userProb.Add(v.success);
            v.userProb.Add(v.fail);
            v.userProb.Add(v.fail);
            v.userProb.Add(v.fail);
            v.userProb.Add(v.fail);
        }


    }
}
