using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class GameStart
    {
        static void Main(string[] args)
        {
            // 인스턴스화
            Variable myVariable = new Variable();
            GamePrint myGamePrint = new GamePrint();
            Character myCharacter = new Character();
            Map myMap = new Map();
            Heal myHeal = new Heal();
            NormalMonster myMonster = new NormalMonster();
            MonsterCreate myMonsterCreate = new MonsterCreate();
            AttackSystem myAttackSystem = new AttackSystem();
            Event myEvent = new Event();





            // 변수
            myMap.Get(myVariable);
            myAttackSystem.Get(myVariable);
            myCharacter.Get(myVariable);
            myMonster.Get(myMonsterCreate, myCharacter);
            myHeal.Get(myVariable);
            myEvent.Get(myVariable);
            




            //실행


            // 키 눌러서 시작
            myGamePrint.PressKey();
            // 캐릭터 선택
            myCharacter.Select();
            Console.WriteLine();
            // 맵 생성
            myMap.MapCreate();
            // 맵 출력
            myMap.MapPrint();


            // 데미지 방식 출력
            myAttackSystem.AttackControl();

        }
    }
}
