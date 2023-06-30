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
        Item i = new Item();
        Variable v = new Variable();
        GamePrint g = new GamePrint();
        public void Get(Variable var_, Item i_, GamePrint g_ )
        { 
            this.v = var_;
            this.i = i_;
            this.g = g_;
        }

        public void AddRandomItemsToShop()
        {
            // 중복을 제외한 아이템 선택을 위한 HashSet
            v.shopListAll = new List<string>(v.itemAll.Keys);

            // itemAll 리스트에서 중복되지 않는 4개의 아이템 선택
            Random random = new Random();
            int shopCount = 0;
            while (shopCount < 4)
            {
                int randomInput = random.Next(0, v.shopListAll.Count);
                string item = v.shopListAll[randomInput];

                // 중복된 아이템이 없는 경우에만 추가
                if (!v.shopList.Contains(item))
                {
                    v.shopList.Add(item);
                    shopCount++;
                }
            }
        }


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
            for (int i = 0; i < v.shopList.Count; i++)
            {

                if (v.shopList[i] != "[Sold Out]")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(3, i + 5);
                    Console.Write("[{0}]", i + 1);
                    Console.SetCursorPosition(6, i + 5);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[{0}]", v.shopList[i]);
                    Console.ResetColor();
                }
                if (v.shopList[i] =="[Sold Out]")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(3, i + 5);
                    Console.Write("[{0}]", i + 1);
                    Console.SetCursorPosition(6, i + 5);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[{0}]", v.shopList[i]);
                    Console.ResetColor();

                }
            }
            Console.WriteLine();
        }

        public void FindValues(string name)
        {
            if (v.shopList.Contains(name))
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("[아이템 가격 :", v.itemAll[name]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("{0}]", v.itemAll[name]);
                Console.ResetColor();
            }
        }

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
                if (v.shopList[j] == "성공 포션")
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
                else if (v.shopList[j] == "철갑 방어구")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[방어력 +1]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                     y += 4;
                }
                else if (v.shopList[j] == "미스릴 방어구")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[방어력 +3]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                    y += 4;
                }
                else if (v.shopList[j] == "아이언 메이스")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[공격력 +10]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                    y += 4;
                }
                else if (v.shopList[j] == "마검")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[공격력 +20]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                    y += 4;
                }
                else if (v.shopList[j] == "고기")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[HP가 50% 이하면 HP+50]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                     y += 4;
                }
                else if (v.shopList[j] == "배")
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
                    Console.WriteLine("[돈 +10]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                     y += 4;
                }
                else if (v.shopList[j] == "신기한 버섯")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[랜덤 성공+3 or 실패 -3]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                     y += 4;
                }
                else if (v.shopList[j] == "불가침")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[미구현]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                    y += 4;
                }
                else if (v.shopList[j] == "바람의 목걸이")
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.WriteLine("[{0}]", v.shopList[j]);
                    Console.SetCursorPosition(x, y + 2);
                    Console.WriteLine("[바의 이동속도 +0.1초 느려짐]");
                    Console.SetCursorPosition(x, y + 3);
                    FindValues(v.shopList[j]);
                    y += 4;
                }

            }
        


        }

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

            ConsoleKeyInfo shopSel = Console.ReadKey(true);

            int itemIndex = -1; // 선택된 아이템의 인덱스를 저장할 변수

            switch (shopSel.Key)
            {
                case ConsoleKey.D1:
                    itemIndex = 0; // 1번 아이템의 인덱스
                    break;
                case ConsoleKey.D2:
                    itemIndex = 1; // 2번 아이템의 인덱스
                    break;
                case ConsoleKey.D3:
                    itemIndex = 2; // 3번 아이템의 인덱스
                    break;
                case ConsoleKey.D4:
                    itemIndex = 3; // 4번 아이템의 인덱스
                    break;
                case ConsoleKey.N:
                    v.outCount++;
                    return; // 나가기
            }


            if (itemIndex != -1 && itemIndex < v.shopList.Count)
            {
                string selectedItem = v.shopList[itemIndex]; // 선택된 아이템

                if (v.itemAll.ContainsKey(selectedItem)) // 선택된 아이템이 itemAll에 있는지 확인
                {
                    int itemPrice = v.itemAll[selectedItem]; // 선택된 아이템의 가격

                    if (v.userGold >= itemPrice)
                    {
                        g.GameShopPrint();
                        v.userGold -= itemPrice;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(68,15);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[{0} 구매]", selectedItem);
                        Console.ResetColor();
                        Console.SetCursorPosition(68, 17);
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("[소지금: {0}]", v.userGold);
                        Console.ResetColor();
                        v.itemInven.Add(selectedItem);
                        v.shopList.RemoveAt(itemIndex);
                        v.shopList.Insert(itemIndex, "[Sold Out]");
                        Thread.Sleep(1000);
                        Console.Clear();
 
                    }
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





    }
}
