using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Project1
{
    public class Shop
    {
        #region 인스턴스화
        Variable v = new Variable();
        GamePrint g = new GamePrint();
        #endregion

        #region 객체 초기화 메소드
        public void Get(Variable var_,  GamePrint g_)
        { 
            this.v = var_;
            this.g = g_;
        }
        #endregion

        #region 아이템 중복 제외 메소드
        public void AddRandomItemsToShop()
        {
            // itemAll의 Key값을 shopListAll List로 (모든 아이템의 Key)
            v.shopListAll = new List<string>(v.itemAll.Keys);

            // itemAll 리스트에서 중복되지 않는 4개의 아이템 선택
            Random random = new Random();
            // 4개 선택을 위한 카운트
            int shopCount = 0;

            // 중복없이 4개 뽑을 때 까지
            while (shopCount < 4)
            {
                // 범위는 shopListAll의 갯수
                int randomInput = random.Next(0, v.shopListAll.Count);
                string item = v.shopListAll[randomInput];

                // shopList에서의 중복 허용 X
                if (!v.shopList.Contains(item))
                {
                    // itemInven에서도 중복확인
                    if (!v.itemInven.Contains(item)&&
                        (item != "체력 포션" && item != "성수" &&
                        item != "꾸깃한 복권" && item != "퇴마의 성배") ||
                        // 위의 4개를 제외하곤 중복 허용 X
                        (item == "체력 포션" && v.itemOn1 < 3) ||
                        (item == "성수" && v.itemOn2 < 3) ||
                        (item == "꾸깃한 복권" && v.itemOn7 < 3) ||
                        (item == "퇴마의 성배" && v.itemOn9 < 3))
                    {
                        v.shopList.Add(item);
                        shopCount++;
                    }
                }
            }
        }
        #endregion

        #region 상점 아이템 번호 & 이름 프린트 메소드
        public void PrintShop()
        {       
            Console.Clear();
            g.GameMapPrint();
            g.GameInfoPrint();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(23, 2);
            Console.WriteLine("[상점]");
            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.SetCursorPosition(3,3);
            Console.WriteLine("[판매 목록]");
            Console.ResetColor();

            Console.SetCursorPosition(6, 23);
            Console.Write("[물건 구매 후 반드시");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 인벤토리");
            Console.ResetColor();
            Console.Write("를 활성화 시켜주세요]");

            for (int i = 0; i < v.shopList.Count; i++)
            {
                // 구매 전 출력
                if (v.shopList[i] != "[Sold Out]")
                {
                    // 번호 출력
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(3, i + 5);
                    Console.Write("[{0}]", i + 1);
                    Console.ResetColor();

                    // 아이템 이름 출력
                    Console.SetCursorPosition(6, i + 5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[{0}]", v.shopList[i]);
                    Console.ResetColor();
                }
                // 구매 후 출력
                if (v.shopList[i] =="[Sold Out]")
                {
                    // 번호 출력
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(3, i + 5);
                    Console.Write("[{0}]", i + 1);
                    Console.ResetColor();

                    // 아이템 이름 출력
                    Console.SetCursorPosition(6, i + 5);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[{0}]", v.shopList[i]);
                    Console.ResetColor();

                }
            }
            Console.WriteLine();
        }
        #endregion

        #region 상점 아이템 가격 프린트 메소드
        public void FindValues(string name)
        {
            if (v.shopList.Contains(name))
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("[아이템 가격 :", v.itemAll[name]);
                Console.Write("{0}]", v.itemAll[name]);
                Console.ResetColor();
            }
        }
        #endregion

        #region 상점 아이템 효과 설명 메소드 
        public void ExplainItem()
        {
            Console.SetCursorPosition(30,3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[아이템 설명]");
            Console.ResetColor();

            int y = 4; int x = 30;
            for (int j = 0; j < v.shopList.Count; j++)
            {
                Console.SetCursorPosition(x, y);
                if (v.shopList[j] == "퇴마의 성배")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[성공 +1]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "체력 포션")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[체력 +20]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "은빛 갑옷")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[방어력 +1]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "빛의 갑옷")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[방어력 +3]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
                else if (v.shopList[j] == "나무 십자가")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[공격력 +10]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
                else if (v.shopList[j] == "신성한 창")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[공격력 +20]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
                else if (v.shopList[j] == "성수")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[HP가 50% 이하면 HP+50]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "생명의 팬던트")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[최대체력 +10]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
                else if (v.shopList[j] == "꾸깃한 복권")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[돈 +100]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "운명의 반지")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[랜덤 성공+3 or 실패 -3]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                     y += 4;
                }
                else if (v.shopList[j] == "밤의 사냥꾼")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[공격력 +25, 방어력 +3]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
                else if (v.shopList[j] == "어둠의 봉인주문서")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);

                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[바의 이동속도 +0.03초 느려짐]");

                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);

                    y += 4;
                }
            }
        }
        #endregion

        #region 상점 아이템 번호 입력 후 구매 메소드
        public void BuyFromShop()
        {
            Console.SetCursorPosition(12, 28);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[소지금 : {0}]",v.userGold);
            Console.ResetColor();

            Console.SetCursorPosition(12, 29);
            Console.WriteLine("구매하실 아이템 번호를 입력해주세요");

            Console.SetCursorPosition(12, 30);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[나가기 : N]");
            Console.ResetColor();

            // 유저 키 입력
            ConsoleKeyInfo shopSel = Console.ReadKey(true);

            int itemIndex = -1; // 선택된 아이템의 인덱스를 저장할 변수

            // v.resetCount 리세마라 방지 카운트
            switch (shopSel.Key)
            {
                case ConsoleKey.D1:
                    itemIndex = 0; // 1번 아이템의 인덱스
                    v.resetCount++;
                    break;
                case ConsoleKey.D2:
                    itemIndex = 1; // 2번 아이템의 인덱스
                    v.resetCount++;
                    break;
                case ConsoleKey.D3:
                    itemIndex = 2; // 3번 아이템의 인덱스
                    v.resetCount++;
                    break;
                case ConsoleKey.D4:
                    itemIndex = 3; // 4번 아이템의 인덱스
                    v.resetCount++;
                    break;
                case ConsoleKey.N:
                    v.outCount++;
                    return; // 나가기
            }

            // 구매 로직
            if (itemIndex != -1 && itemIndex < v.shopList.Count)
            {
                string selectedItem = v.shopList[itemIndex]; // 선택된 아이템

                if (v.itemAll.ContainsKey(selectedItem)) // 선택된 아이템이 itemAll에서 확인
                {
                    int itemPrice = v.itemAll[selectedItem]; // 선택된 아이템의 가격

                    if (v.userGold >= itemPrice)
                    {
                        g.GameShopPrint();
                        v.userGold -= itemPrice;


                        Console.SetCursorPosition(68,15);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[{0} 구매]", selectedItem);
                        Console.ResetColor();

                        Console.SetCursorPosition(68, 17);
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("[소지금: {0}]", v.userGold);
                        Console.ResetColor();

                        // itemInven에 추가 후 shopList에서 제거
                        v.itemInven.Add(selectedItem);
                        v.shopList.RemoveAt(itemIndex);
                        // shopList index에 [Sold Out] 추가
                        v.shopList.Insert(itemIndex, "[Sold Out]");
 

                        // 횟수 제한이 있는 아이템 효과적용 제어
                        if (selectedItem == "퇴마의 성배" && v.initialCount1 != 0)
                        {
                            v.initialCount1--;
                        }
                        else if (selectedItem == "체력 포션" && v.initialCount2 != 0)
                        {
                            v.initialCount2--;
                        }
                        else if (selectedItem == "성수" && v.initialCount3 != 0)
                        {
                            v.initialCount3--;
                        }
                        else if (selectedItem == "꾸깃한 복권" && v.initialCount4 != 0)
                        {
                            v.initialCount4--;
                        }

                        Thread.Sleep(1000);
                        Console.Clear();
                    
                    // 구매 실패 로직
                    }
                    // 잔액 부족
                    else
                    {
                        g.GameShopPrint();

                        Console.SetCursorPosition(68, 15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[잔액 부족]");
                        Console.ResetColor();

                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            }
            // 번호 입력 오류
            else
            {
                g.GameShopPrint();

                Console.SetCursorPosition(68, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[번호입력 오류]");
                Console.ResetColor();

                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        #endregion
    }
}
