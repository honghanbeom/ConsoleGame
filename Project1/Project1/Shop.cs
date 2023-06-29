using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.SetCursorPosition(2,3);
            Console.WriteLine("[판매 목록]");
            Console.ResetColor();
            for (int i = 0; i < v.shopList.Count; i++)
            {
                Console.SetCursorPosition(2, i + 5);
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("[{0}]", i + 1);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[{0}]", v.shopList[i]);
                Console.ResetColor();
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
            for (int j = 0; j < v.shopList.Count; j++)
            {
                int y = 4; int x = 30;


                Console.SetCursorPosition(x,y);
                switch (v.shopList[j])
                //v.itemAll.Add("성공 포션"); // 성공 +1
                //v.itemAll.Add("체력 포션"); // 체력 +20
                //v.itemAll.Add("철갑 방어구"); // 방어구 +1
                //v.itemAll.Add("미스릴 방어구 "); // 방어구 +3
                //v.itemAll.Add("아이언 메이스"); // 공격력 +10
                //v.itemAll.Add("마검"); // 공격력 + 20
                //v.itemAll.Add("고기"); // 체력이 50% 이하 -> 체력 +50
                //v.itemAll.Add("배"); // 최대체력 +10
                //v.itemAll.Add("꾸깃한 복권"); // +10원
                //v.itemAll.Add("신기한 버섯"); // 랜덤 성공+3, 실패 -3
                //v.itemAll.Add("노예 상인의 목걸이"); // Elite, Boss 공격력+5,방어구+2(되면)
                //v.itemAll.Add("바람의 목걸이"); // userDelay 증가

                {
                    case "성공 포션":
                        Console.SetCursorPosition(x, y+1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y+2);

                        Console.WriteLine("[성공 +1]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;
                        break;
                    case "체력 포션":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[체력 +20]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;




                        break;
                    case "철갑 방어구":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[방어력 +1]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;

                        break;
                    case "미스릴 방어구":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[방어력 +3]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);

                        y += 4;

                        break;
                    case "아이언 메이스":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[공격력 +10]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);

                        y += 4;

                        break;
                    case "마검":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[공격력 +20]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;


                        break;
                    case "고기":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[체력이 50% 이하 -> 체력 +50]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);

                        y += 4;

                        break;
                    case "배":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[최대체력 +10]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;


                        break;
                    case "꾸깃한 복권":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[돈 +10]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;


                        break;
                    case "신기한 버섯":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[50% 확률로 랜덤 성공+3 or 실패 -3]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;


                        break;
                    case "노예 상인의 목걸이":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);

                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[Elite, Boss 공격력+5,방어구+2]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y += 4;


                        break;
                    case "바람의 목걸이":
                        Console.SetCursorPosition(x, y + 1);

                        Console.WriteLine("[{0}]", v.shopList[j]);
                        Console.SetCursorPosition(x, y + 2);

                        Console.WriteLine("[바의 이동속도 +0.1초 느려짐]");
                        Console.SetCursorPosition(x, y + 3);

                        FindValues(v.shopList[j]);
                        y+= 4;  


                        break;
                }
            }


        }

        public void BuyFromShop()
        {
            Console.WriteLine("구매하실 아이템 번호를 입력해주세요");
            Console.WriteLine("[소지금 : {0}]",v.userGold);
            Console.WriteLine("[나가기 : N]");
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
                        v.userGold -= itemPrice;
                        Console.WriteLine("[{0}를 구매했습니다.]", selectedItem);
                        Console.WriteLine("[유저 소지금: {0}]", v.userGold);
                        v.itemInven.Add(selectedItem);
                        v.shopList.RemoveAt(itemIndex);
                        Console.ForegroundColor = ConsoleColor.Red;
                        v.shopList.Insert(itemIndex, "[Sold Out]");
                        Console.ResetColor();
 
                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다!");
                    }
                }
                else
                {
                    Console.WriteLine("선택한 아이템이 존재하지 않습니다!");
                }

            }
            else
            {
                Console.WriteLine("잘못된 선택입니다!");
            }
        }





    }
}
