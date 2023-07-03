using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Item
    {
        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region 인스턴스화
        Variable v = new Variable();
        GamePrint g = new GamePrint();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable var_, GamePrint g_)
        {
            this.v = var_;
            this.g = g_;
        }
        #endregion

        #region 아이템 등록 메소드
        public void AddItem()
        {
            v.itemAll.Add("퇴마의 성배", 50); // 성공 +1 *
            v.itemAll.Add("체력 포션", 50); // 체력 +20 * 
            v.itemAll.Add("은빛 갑옷", 50); // 방어구 +1
            v.itemAll.Add("빛의 갑옷", 100); // 방어구 +3
            v.itemAll.Add("나무 십자가", 100); // 공격력 +10
            v.itemAll.Add("신성한 창", 150); // 공격력 + 20
            v.itemAll.Add("성수", 100); // 체력이 50% 이하 -> 체력 +50 *
            v.itemAll.Add("생명의 팬던트", 70); // 최대체력 +10
            v.itemAll.Add("꾸깃한 복권", 0); // +10원 *
            v.itemAll.Add("운명의 반지", 30); // 랜덤 성공+3, 실패 -3
            v.itemAll.Add("밤의 사냥꾼", 250); // 공격력 + 25, 방어력 +2
            v.itemAll.Add("어둠의 봉인주문서", 200); // userDelay 증가
        }
        #endregion

        #region 지역 변수
        public int userSuccessCount;
        public int userFailCount;
        #endregion

        #region 인벤에서 아이템 효과 설명 & 적용 메소드
        public void ItemEffectOnInven()
        {
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(23,2);
            Console.WriteLine("[소지한 아이템]");
            Console.ResetColor();

            // 커서 위치 
            int cursorLeft = 2;
            int cursorTop = 4;

            // 모든 아이템에 대해
            foreach (string n in v.itemInven)
            {
                // 아이템 설명 출력 위치 제어 1
                if (cursorTop < 20)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(n);
                    Console.ResetColor();
                    cursorTop += 1;

                }
                // 아이템 설명 위치 제어 2
                else if (cursorTop >= 20)
                {
                    cursorLeft = 30;
                    cursorTop = 4;

                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(n);
                    Console.ResetColor();
                    cursorTop += 1;
                }

                // 아이템 1
                if (n == "퇴마의 성배")
                {
                    // 효과 적용 로직
                    if (v.itemOn1 < 3 && v.initialCount1 == 0)
                    {
                        int index = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                        if (index != -1) // v.success가 발견되었을 경우
                        {
                            v.userProb.Insert(index + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                        }
                        v.itemOn1++;
                        v.initialCount1++;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop+1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[성공확률 +1]");

                    // 성공 갯수 카운트
                    userSuccessCount = v.userProb.Count(x => x == v.success);
                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);

                    // 다음 출력 위해 +
                    cursorTop += 4;
                }

                // 아이템 2
                else if (n == "체력 포션")
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[체력 +20]");

                    // 아이템 효과 제어
                    if (v.userMaxHP < v.userCurrentHP + 20)
                    {
                        // 효과 적용 로직
                        if (v.itemOn2 < 3 && v.initialCount2 == 0)
                        {
                            v.userCurrentHP = v.userMaxHP;
                            v.itemOn2++;
                            v.initialCount2++;
                        }

                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                    }
                    else
                    {
                        // 효과 적용 로직
                        if (v.itemOn2 < 3 && v.initialCount2 == 0)
                        {
                            v.userCurrentHP += 20;
                            v.itemOn2++;
                            v.initialCount2++;
                        }
                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                    }
                    cursorTop += 4;

                }
                // 아이템 3
                else if (n == "은빛 갑옷")
                {
                    // 효과 적용 로직
                    if (v.itemOn3 == false)
                    {

                        v.userArmor += 1;
                        v.itemOn3 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[방어력 +1]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
                    cursorTop += 4;

                }

                // 아이템 4
                else if (n == "빛의 갑옷")
                {
                    // 효과 적용 로직
                    if (v.itemOn4 == false)
                    {
                        v.userArmor += 3;
                        v.itemOn4 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[방어력 +3]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
                    cursorTop += 4;

                }

                // 아이템 5
                else if (n == "나무 십자가")
                {
                    // 효과 적용 로직
                    if (v.itemOn5 == false)
                    {

                        v.userDamage += 10;
                        v.itemOn5 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[공격력 +10]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);
                    cursorTop += 4;

                }
                // 아이템 6
                else if (n == "신성한 창")
                {
                    // 효과 적용 로직
                    if (v.itemOn6 == false)
                    {
                        v.userDamage += 20;
                        v.itemOn6 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[공격력 +20]");
                   
                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);
                    cursorTop += 4;

                }

                // 아이템 7
                else if (n == "성수")
                {

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[HP가 50%이하면 HP +50]");

                    // 아이템 효과 제어
                    if (v.userMaxHP >= v.userCurrentHP * 2)
                    {
                       // 효과 적용 로직
                        if (v.itemOn7 < 3 && v.initialCount3 == 0)
                        {

                            v.userCurrentHP += 50;
                            v.itemOn7++;
                            v.initialCount3++;
                        }

                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                    }

                    // 아이템 효과 제어
                    else
                    {
                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[50%이상에서는 적용X]");

                        // 효과 적용 로직
                        if (v.itemOn7 < 3 && v.initialCount3 == 0)
                        {
                            v.itemOn7++;
                            v.initialCount3++;
                        }
                    }
                    cursorTop += 4;

                }

                // 아이템 8
                else if (n == "생명의 팬던트")
                {
                    // 효과 적용 로직
                    if (v.itemOn8 == false)
                    {
                        v.userMaxHP += 10;
                        v.itemOn8 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[최대 체력 +10]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);

                    Console.SetCursorPosition(cursorLeft, cursorTop + 4);
                    Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
                    cursorTop += 5;

                }
                // 아이템 9
                else if (n == "꾸깃한 복권")
                {
                    // 효과 제어 로직
                    if (v.itemOn9 < 3 && v.initialCount4 == 0)
                    {

                        v.userGold += 100;
                        v.itemOn9++;
                        v.initialCount4++;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[골드 + 100]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[유저 골드  : {0}]", v.userGold);
                    cursorTop += 4;

                }

                // 아이템 10
                else if (n == "운명의 반지")
                {

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[랜덤으로 성공+3 or 실패 -3]");

                    // 랜덤한 효과 적용
                    Random random = new Random();
                    int mushroomRandom = random.Next(0, 2); // 50%

                    // Fail
                    if (mushroomRandom == 0)
                    {
                        // 효과 적용 로직
                        if (v.itemOn10 == false)
                        {
                            v.userProb.Add(v.fail);
                            v.userProb.Add(v.fail);
                            v.userProb.Add(v.fail);
                            v.itemOn10 = true;
                        }

                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[실패확률 + 3]");

                        userFailCount = v.userProb.Count(x => x == v.fail);
                        Console.SetCursorPosition(cursorLeft, cursorTop + 4);
                        Console.WriteLine("[유저 실패 갯수 : {0}]", userFailCount);
                        cursorTop += 5;

                    }

                    // Success
                    else
                    {
                        // 효과 적용 로직
                        if (v.itemOn11 == false && mushroomRandom == 1)
                        {
                            int index = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                            if (index != -1) // v.success가 발견되었을 경우
                            {
                                v.userProb.Insert(index + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                                v.userProb.Insert(index + 2, v.success); // 발견된 인덱스의 두 칸 뒤에 v.success를 삽입
                                v.userProb.Insert(index + 3, v.success); // 발견된 인덱스의 세 칸 뒤에 v.success를 삽입
                            }
                            v.itemOn11 = true;
                        }

                        Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                        Console.WriteLine("[성공확률 + 3]");

                        userSuccessCount = v.userProb.Count(x => x == v.success);
                        Console.SetCursorPosition(cursorLeft, cursorTop + 4);
                        Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);
                        cursorTop += 5;

                    }
                }

                // 아이템 11
                else if (n == "밤의 사냥꾼")
                {
                    // 효과 적용 로직
                    if (v.itemOn12 == false)
                    {
                        v.userArmor += 3;
                        v.userDamage += 20;
                        v.itemOn12 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[공격력 +25]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[방어력 +3]");
                    cursorTop += 4;

                }

                // 아이템 12
                else if (n == "어둠의 봉인주문서")
                {
                    // 효과 적용 로직
                    if (v.itemOn13 == false)
                    {
                        v.userDelay += 100;
                        v.itemOn13 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[바의 이동속도  0.05초 증가]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[바 이동 속도 : {0}]", v.userDelay);
                    cursorTop += 4;
                }

                // 아이템 13
                else if (n == "스켈레톤 갑옷")
                {
                    // 효과 적용 로직
                    if (v.itemOn14 == false)
                    {
                        v.userArmor += 6;
                        v.itemOn14 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[방어력 +6]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
                    cursorTop += 4;
                }

                // 아이템 14
                else if (n == "영혼의 망토")
                {
                    // 효과 적용 로직
                    if (v.itemOn15 == false)
                    {
                        v.userArmor += 3;
                        v.userDelay += 30;
                        v.itemOn15 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[방어력 +3]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[바 이동속도 +0.03초 증가]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 4);
                    Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);

                    Console.SetCursorPosition(cursorLeft, cursorTop + 5);
                    Console.WriteLine("[바 이동 속도 : {0}]", v.userDelay);
                    cursorTop += 6;

                }

                // 아이템 15
                else if (n == "마늘")
                {
                    // 효과 적용 로직
                    if (v.itemOn16 == false)
                    {
                        int index = v.userProb.IndexOf(v.success); // v.success의 첫 번째 발견된 인덱스를 찾기
                        if (index != -1) // v.success가 발견되었을 경우
                        {
                            v.userProb.Insert(index + 1, v.success); // 발견된 인덱스의 한 칸 뒤에 v.success를 삽입
                        }
                        v.userDamage += 20;
                        v.itemOn16 = true;
                    }

                    Console.SetCursorPosition(cursorLeft, cursorTop + 1);
                    Console.WriteLine("[아이템 효과]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 2);
                    Console.WriteLine("[성공확률 +1]");

                    userSuccessCount = v.userProb.Count(x => x == v.success);
                    Console.SetCursorPosition(cursorLeft, cursorTop + 3);
                    Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);

                    Console.SetCursorPosition(cursorLeft, cursorTop + 4);
                    Console.WriteLine("[공격력 +20]");

                    Console.SetCursorPosition(cursorLeft, cursorTop + 5);
                    Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);
                    cursorTop += 6;
                }
            }
        }
        #endregion
    }
}

#region LEGACY
//public void ItemEffectOnInven()
//{
//    Console.WriteLine("[소지한 아이템]");
//    for (int i = 0; i < v.itemInven.Count; i++)
//    {
//        switch (v.shopList[i])
//        //--------------------------상점목록-------------------------------------
//        //v.itemAll.Add("성공 포션"); // 성공 +1
//        //v.itemAll.Add("체력 포션"); // 체력 +20
//        //v.itemAll.Add("철갑 방어구"); // 방어구 +1
//        //v.itemAll.Add("미스릴 방어구 "); // 방어구 +3
//        //v.itemAll.Add("아이언 메이스"); // 공격력 +10
//        //v.itemAll.Add("마검"); // 공격력 + 20
//        //v.itemAll.Add("고기"); // 체력이 50% 이하 -> 체력 +50
//        //v.itemAll.Add("배"); // 최대체력 +10
//        //v.itemAll.Add("꾸깃한 복권"); // +10원
//        //v.itemAll.Add("신기한 버섯"); // 랜덤 성공+3, 실패 -3
//        //v.itemAll.Add("바람의 목걸이"); // userDelay 증가
//        //----------------------------------------------------------------------
//        //v.itemAll.Add("노예 상인의 목걸이"); // Elite, Boss 공격력+5,방어구+2(되면)
//        //----------------------------------------------------------------------
//        {
//            case "성공 포션":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[성공확률 +1]");
//                v.userProb.Insert(1, v.success);
//                int userSuccessCount = v.userProb.Count(x => x == v.success);
//                Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);
//                break;
//            case "체력 포션":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[체력 +20]");
//                if (v.userMaxHP < v.userCurrentHP + 20)
//                {
//                    v.userCurrentHP = v.userMaxHP;
//                    Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
//                }
//                else
//                {
//                    v.userCurrentHP = +20;
//                    Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
//                }

//                break;
//            case "철갑 방어구":
//                Console.WriteLine("[아이템 효과]");

//                Console.WriteLine("[방어력 +1]");
//                v.userArmor += 1;
//                Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);


//                break;
//            case "미스릴 방어구":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[방어력 +3]");
//                v.userArmor += 3;
//                Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);

//                break;
//            case "아이언 메이스":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[공격력 +10]");
//                v.userDamage += 10;
//                Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);
//                break;
//            case "마검":
//                Console.WriteLine("[아이템 효과]");

//                Console.WriteLine("[공격력 +20]");
//                v.userDamage += 20;
//                Console.WriteLine("[현재 공격력  : {0}]", v.userDamage);

//                break;
//            case "고기":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[체력이 50% 이하 -> 체력 +50]");
//                if (v.userMaxHP >= v.userCurrentHP * 0.5)
//                {
//                    v.userCurrentHP += 50;
//                    Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);
//                }
//                else
//                {
//                    Console.WriteLine("[체력이 50%이상임으로 적용되지 않습니다.]");
//                }

//                break;
//            case "배":
//                Console.WriteLine("[아이템 효과]");

//                Console.WriteLine("[최대 체력 +10]");
//                v.userMaxHP += 10;
//                Console.WriteLine("[최대 체력  : {0}]", v.userMaxHP);
//                Console.WriteLine("[현재 체력  : {0}]", v.userCurrentHP);

//                break;
//            case "꾸깃한 복권":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[골드 + 10]");

//                v.userGold += 10;
//                Console.WriteLine("[유저 골드  : {0}]", v.userGold);

//                break;
//            case "신기한 버섯":
//                Console.WriteLine("[아이템 효과]");

//                Console.WriteLine("[50% 확률로 랜덤 성공+3 or 실패 -3]");
//                Random random = new Random();
//                int mushroomRandom = random.Next(0, 1);
//                if (mushroomRandom == 0)
//                {
//                    Console.WriteLine("3개의 실패확률+.");
//                    v.userProb.Add(v.fail);
//                    v.userProb.Add(v.fail);
//                    v.userProb.Add(v.fail);
//                }
//                else
//                {
//                    v.userProb.Insert(1, v.success);
//                    v.userProb.Insert(1, v.success);
//                    v.userProb.Insert(1, v.success);
//                    Console.WriteLine("[성공확률 + 3]");
//                    userSuccessCount = v.userProb.Count(x => x == v.success);
//                    Console.WriteLine("[유저 성공 갯수 : {0}]", userSuccessCount);

//                }

//                break;
//            case "노예 상인의 목걸이":
//                Console.WriteLine("[아이템 효과]");

//                Console.WriteLine("[Elite, Boss 공격력+5,방어구+2]");
//                Console.WriteLine("아직 미구현임!");

//                break;
//            case "바람의 목걸이":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[바의 이동속도  0.1초 증가]");
//                v.userDelay += 100;
//                Console.WriteLine("[바 이동 속도 : {0}]",v.userDelay);

//                break;
//            case "스켈레톤 갑옷":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[방어력 +6]");
//                v.userArmor += 6;
//                Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
//                break;
//            case "물컹물컹 장화":
//                Console.WriteLine("[아이템 효과]");
//                Console.WriteLine("[방어력 +3]");
//                Console.WriteLine("[바 이동속도 +0.05초 증가]");
//                v.userArmor += 3;
//                Console.WriteLine("[현재 방어력  : {0}]", v.userArmor);
//                v.userDelay += 50;
//                Console.WriteLine("[바 이동 속도 : {0}]", v.userDelay);
//                break;
//        }


//    }
//}
#endregion