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

        /// <summary>
        /// --------------------------------------------------
        /// 방향성
        /// --------------------------------------------------
        /// Slay the Spire 게임진행방식
        /// UnderTale 전투방식
        /// Vampire Survivors 아이디어
        /// --------------------------------------------------
        /// 개발 목표 
        /// --------------------------------------------------
        /// Shop : 횟수제한 아이템을 적용한 중복 아이템 제거 △ 
        /// Shop : 리세마라 방지 O
        /// Shop : 인벤토리에서 아이템 설명 구현 O
        /// AttackSystem : 전투방식의 구현 O
        /// Normal : 드롭아이템 구현 O
        /// Elite : 특수효과 & UI 구현 O
        /// Boss : 성공/실패 칸 실명 스킬 O
        /// ---------------------------------------------------
        /// Hot Fix
        /// ---------------------------------------------------
        /// (*) AttackSystem : index 초과 버그 O
        /// (*) Shop : 아이템의 효과 적용 타이밍 X
        /// (*) Event : 야수의 심장 O
        /// (*) Shop : 첫 상점 비활성화 버그 O
        /// ---------------------------------------------------
        /// 보완점
        /// ---------------------------------------------------
        /// System : StreamReader, StreamWriter를 사용한 점수 저장 시스템 (가능?)
        /// System : 삼항연산자, bool 사용
        /// System : Class, variables 통일성
        /// Shop : 중복 제거 예외처리 로직
        /// Map : 유저 선택이 가능한 Map 구현 (알고리즘)
        /// </summary>


        static void Main(string[] args)
        {

            #region 콘솔초기화
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.Title = "Slay The Vampire";
            Console.SetWindowSize(100, 40);
            #endregion

            #region 인스턴스화
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
            #endregion

            #region 메소드 호출/ 메소드 간 상호작용
            myMap.Get(myVariable, myHeal, myNormalMonster, myEvent,
                       myEliteMonster, myBossMonster, myShop, myItem, myGamePrint);
            myNormalMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                             , myGamePrint, myItem);
            myEliteMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                             , myGamePrint);
            myBossMonster.Get(myVariable, myMonsterCreate, myAttackSystem
                            , myGamePrint);
            myHeal.Get(myVariable, myGamePrint);
            myAttackSystem.Get(myVariable, myMonsterCreate, myGamePrint);
            myMonsterCreate.Get(myVariable);
            myShop.Get(myVariable, myGamePrint);
            myItem.Get(myVariable, myGamePrint);
            myEvent.Get(myVariable, myGamePrint);
            myVariable.Get(myGamePrint);
            #endregion

            #region 게임로직
            // 타이틀 프린트 메소드
            myGamePrint.Title();
            Console.Clear();

            // 캐릭터 선택 메소드
            myVariable.Select();

            //맵 초기화 메소드
            Console.WriteLine();
            //myMap.TestMap(); // 테스트 맵
            myMap.MapCreate();

            // 아이템 등록 메소드
            myItem.AddItem();
            Console.Clear();

            //게임시작
            while (true)
            {
                // 맵 출력
                myMap.MapPrint();

                // 이동& 이동에 따른 결과 출력
                myMap.MapMove();
                Console.Clear();
            }
            #endregion
        }
    }
}
