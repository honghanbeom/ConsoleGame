using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GameStart
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            // 인스턴스화
            Variable myVariable = new Variable();
            GamePrint myGamePrint = new GamePrint();
            AttackSystem myAttackSystem = new AttackSystem();   
            Heal myHeal = new Heal();
            Shop myShop = new Shop();
            Event myEvent = new Event();
            Item myItem = new Item();
            MonsterCreate myMonsterCreate = new MonsterCreate();
            NormalMonster myNormalMonster = new NormalMonster();
            EliteMonster myEliteMonster = new EliteMonster();
            BossMonster myBossMonster = new BossMonster();

            Map myMap = new Map();


            // 변수
            myMap.Get(myVariable, myHeal, myNormalMonster, myEvent,
                       myEliteMonster, myBossMonster, myShop, myItem, myGamePrint);
            myNormalMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                             , myGamePrint);
            myEliteMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                             , myGamePrint);
            myBossMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                            , myGamePrint);
            myHeal.Get(myVariable, myGamePrint);
            myAttackSystem.Get(myVariable, myMonsterCreate, myGamePrint);
            myMonsterCreate.Get(myVariable, myGamePrint);
            myShop.Get(myVariable, myItem, myGamePrint);
            myItem.Get(myVariable, myGamePrint);
            myEvent.Get(myVariable, myGamePrint);
            myVariable.Get(myGamePrint);



            Console.Title = "Slay The Vampire";
            Console.SetWindowSize(100, 40); 

            // 키 눌러서 시작
            myGamePrint.Title();
            Console.Clear();
            // 캐릭터 선택
   
            myVariable.Select();

            //맵 생성
            Console.WriteLine();
            myMap.MapCreate();

            // 아이템 생성
            myItem.AddItem();

            Console.Clear();

            while (true)
            {
                // 맵 출력


                myMap.MapPrint();


                // 이동


                myMap.MapMove();
                Console.Clear() ;


            }



        }
    }
}
