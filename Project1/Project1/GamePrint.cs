using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class GamePrint
    {
        #region P/Invoke 선언
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();
        #endregion

        #region 변수 선언
        public char topLeftCorner = '┏';
        public char topRightCorner = '┓';
        public char bottomLeftCorner = '┗';
        public char bottomRightCorner = '┛';
        public char horizontalLine = '━';
        public char verticalLine = '┃';
        public char space = ' ';
        #endregion

        #region 게임 클리어 출력 메소드
        public void GameClear()
        {
            Console.Clear();
            GameConsolePrint();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 10);
            Console.Write("________________________________________________________________________\n");

            Console.SetCursorPosition(10, 11);
            Console.Write("      __                                  __                            \n");

            Console.SetCursorPosition(10, 12);
            Console.Write("    /    )                              /    )    /                     \n");

            Console.SetCursorPosition(10, 13);
            Console.Write("---/----------__----_--_-----__--------/---------/-----__-----__----)__-\n");

            Console.SetCursorPosition(10, 14);
            Console.Write("  /  --,    /   )  / /  )  /___)      /         /    /___)  /   )  /   )\n");

            Console.SetCursorPosition(10, 15);
            Console.Write("_(____/____(___(__/_/__/__(___ ______(____/____/____(___ __(___(__/_____\n");

            Console.SetCursorPosition(10, 16);
            Console.Write("                                                                        \n");

            Console.SetCursorPosition(10, 17);
            Console.Write("                                                                        \n");
            Console.ResetColor();
        }
        #endregion

        #region 게임 오버 출력 메소드
        public void GameOver()
        {
            Console.Clear();

            GameConsolePrint();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 10);
            Console.Write("__________________________________________________________________\n");

            Console.SetCursorPosition(10, 11);
            Console.Write("      __                                  __                      \n");

            Console.SetCursorPosition(10, 12);
            Console.Write("    /    )                              /    )                    \n");

            Console.SetCursorPosition(10, 13);
            Console.Write("---/----------__----_--_-----__--------/----/-----------__----)__-\n");

            Console.SetCursorPosition(10, 14);
            Console.Write("  /  --,    /   )  / /  )  /___)      /    /    | /   /___)  /   )\n");

            Console.SetCursorPosition(10, 15);
            Console.Write("_(____/____(___(__/_/__/__(___ ______(____/_____|/___(___ __/_____\n");

            Console.SetCursorPosition(10, 16);
            Console.Write("                                                                  \n");

            Console.SetCursorPosition(10, 17);
            Console.Write("                                                                  \n");

            Console.ResetColor();
        }
        #endregion

        #region 게임 타이틀 출력 메소드
        public void Title()
        {
            GameConsolePrint();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 3);
            Console.Write("_____________________________________________________");

            Console.SetCursorPosition(20, 4);
            Console.Write("      __                                             ");

            Console.SetCursorPosition(20, 5);
            Console.Write("    /    )    /                            /         ");

            Console.SetCursorPosition(20, 6);
            Console.Write("----\\--------/-----__--------------_/_----/__-----__-");

            Console.SetCursorPosition(20, 7);
            Console.Write("     \\      /    /   )  /   /      /     /   )  /___)");

            Console.SetCursorPosition(20, 8);
            Console.Write("_(____/____/____(___(__(___/______(_ ___/___/__(___ _");

            Console.SetCursorPosition(20, 9);
            Console.Write("                          /                          ");

            Console.SetCursorPosition(20, 10);
            Console.Write("                      (_ /                           ");

            Console.SetCursorPosition(20, 10);
            Console.Write("___________________________________________________");

            Console.SetCursorPosition(20, 11);
            Console.Write("  _    _                                           ");

            Console.SetCursorPosition(20, 12);
            Console.Write("  |   /                             ,              ");

            Console.SetCursorPosition(20, 13);
            Console.Write("--|--/------__----_--_-------__---------)__-----__-");

            Console.SetCursorPosition(20, 14);
            Console.Write("  | /     /   )  / /  )    /   )  /    /   )  /___)");

            Console.SetCursorPosition(20, 15);
            Console.Write("__|/_____(___(__/_/__/____/___/__/____/______(___ _");

            Console.SetCursorPosition(20, 16);
            Console.Write("                         /                         ");

            Console.SetCursorPosition(20, 17);
            Console.Write("                        /                          ");

            Console.SetCursorPosition(33, 20);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press Any Key To Start");
            Console.ResetColor();
            _getch();
        }
        #endregion

        #region 게임 콘솔 출력 메소드
        public void GameConsolePrint()

        {
            int width = 100;
            int height = 40;

            // 보이는 영역
            Console.SetWindowSize(width, height - 5);
            // 출력 영역
            Console.SetBufferSize(width, height - 5);

            // Draw top line
            Console.Write(topLeftCorner);
            for (int i = 0; i < width - 12; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(topRightCorner);

            // Draw middle lines
            for (int i = 0; i < height - 12; i++)
            {
                Console.Write(verticalLine);
                for (int j = 0; j < width - 12; j++)
                {
                    Console.Write(space);
                }
                Console.WriteLine(verticalLine);
            }

            // Draw bottom line
            Console.Write(bottomLeftCorner);
            for (int i = 0; i < width - 12; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(bottomRightCorner);
        }
        #endregion

        #region 게임 메인 화면 출력 메소드
        public void GameMapPrint()
        {
            int width = 100;
            int height = 40;

            // 보이는 영역
            Console.SetWindowSize(width, height - 5);
            // 출력 영역
            Console.SetBufferSize(width, height - 5);

            // Draw top line
            Console.Write(topLeftCorner);
            for (int i = 0; i < width - 40; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(topRightCorner);

            // Draw middle lines
            for (int i = 0; i < height - 16; i++)
            {
                Console.Write(verticalLine);
                for (int j = 0; j < width - 40; j++)
                {
                    Console.Write(space);
                }
                Console.WriteLine(verticalLine);
            }

            // Draw bottom line
            Console.Write(bottomLeftCorner);
            for (int i = 0; i < width - 40; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(bottomRightCorner);
        }
        #endregion

        #region 게임 설명 화면 출력 메소드
        public void GameInfoPrint()
        {
            int width = 100;
            int height = 40;

            // 보이는 영역
            Console.SetWindowSize(width, height - 5);
            // 출력 영역
            Console.SetBufferSize(width, height - 5);

            // Draw top line
            Console.Write(topLeftCorner);
            for (int i = 0; i < width - 40; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(topRightCorner);

            // Draw middle lines
            // 원래 height - 12
            for (int i = 30; i < height - 5; i++)
            {
                Console.Write(verticalLine);
                for (int j = 0; j < width - 40; j++)
                {
                    Console.Write(space);
                }
                Console.WriteLine(verticalLine);
            }
            // Draw bottom line
            Console.Write(bottomLeftCorner);
            for (int i = 0; i < width - 40; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine(bottomRightCorner);
        }
        #endregion

        #region 게임 맵 설명 출력 메소드
        public void GameEventPrint()
        {
            Console.SetCursorPosition(65, 3);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━┓");

            Console.SetCursorPosition(65, 4);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 5);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 6);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 7);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 8);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 9);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 10);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 11);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 12);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 13);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 14);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 15);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 16);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 17);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 18);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 19);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 20);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 21);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 22);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 23);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 24);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 25);
            Console.Write("┃                   ┃");

            Console.SetCursorPosition(65, 26);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━┛");
        }
        #endregion

        #region 게임 상점 결제내역 출력 메소드
        public void GameShopPrint()
        {
            Console.SetCursorPosition(65, 13);
            Console.Write("┏━━━━━━━[결제내역]━━━━━━━┓");
            Console.SetCursorPosition(65, 14);
            Console.Write("┃                        ┃");
            Console.SetCursorPosition(65, 15);
            Console.Write("┃                        ┃");
            Console.SetCursorPosition(65, 16);
            Console.Write("┃                        ┃");
            Console.SetCursorPosition(65, 17);
            Console.Write("┃                        ┃");
            Console.SetCursorPosition(65, 18);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        #endregion

        #region 게임 몬스터 효과 출력 메소드
        public void GameMonsterPrint()
        {
            Console.SetCursorPosition(65, 13);
            Console.Write("┏━━━━━━━━[몬스터]━━━━━━━━━┓");
            Console.SetCursorPosition(65, 14);
            Console.Write("┃                         ┃");
            Console.SetCursorPosition(65, 15);
            Console.Write("┃                         ┃");
            Console.SetCursorPosition(65, 16);
            Console.Write("┃                         ┃");
            Console.SetCursorPosition(65, 17);
            Console.Write("┃                         ┃");
            Console.SetCursorPosition(65, 18);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        #endregion

        #region 이벤트 고양이 출력 메소드
        public void CatPrint()
        {
            Console.SetCursorPosition(17, 6);
            Console.Write("⠀⠀⠀⠀⡖⠒⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡤⠶⣆⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 7);
            Console.Write("⠀⠀⠀⢨⠀⠀⠀⠈⠳⠒⣾⣿⣾⣿⣶⠖⠉⠀⠀⠀⡸⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 8);
            Console.Write("⠀⠀⠀⠈⡄⠀⠀⠀⠀⠀⠿⠋⡍⢹⠿⠀⠀⠀⠀⠀⠃⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 9);
            Console.Write("⠀⠀⠀⠀⠰⠀⠀⠀⠀⠀⠀⢿⣿⠇⠀⣀⣀⠀⠀⢸⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 10);
            Console.Write("⠀⠀⠀⠀⢸⡶⠆⣿⣯⣿⣧⠀⠀⢠⣿⣽⣿⠧⢴⣼⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 11);
            Console.Write("⠀⠀⠀⠀⠸⡇⠀⣨⠛⠛⠉⠀⣀⠈⠉⢛⡋⠀⠀⡟⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 12);
            Console.Write("⠀⠀⠀⠀⠀⠱⣄⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⢉⡟⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 13);
            Console.Write("⠀⠀⠀⠀⠀⠀⡟⢷⣀⡀⠀⠀⠀⠀⠠⠤⢶⡿⡇⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 14);
            Console.Write("⠀⠀⠀⠀⠀⢸⡀⠀⠈⠉⠉⠀⠀⠛⠛⠛⠁⠀⣿⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 15);
            Console.Write("⠀⠀⠀⠀⠀⣿⣿⣶⣖⠀⠀⠀⠀⠀⠀⢀⣠⣴⣿⣇⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 16);
            Console.Write("⠀⠀⠀⠀⠀⣿⣿⣿⡿⢧⡀⠀⠀⠀⠀⢀⠴⢿⢿⣿⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 17);
            Console.Write("⠀⠀⠀⠀⠀⣿⣿⣿⣷⣤⡁⠀⠀⠀⢰⣤⣀⣽⣿⣿⣆⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 18);
            Console.Write("⠀⠀⠀⢀⣼⣿⣿⣿⠟⠛⢿⣀⣀⢀⣸⡿⠻⠟⠉⢻⣿⣷⣄⠀⠀");

            Console.SetCursorPosition(17, 19);
            Console.Write("⠀⡠⠊⠁⠙⣻⣿⠟⠀⠀⠀⢯⣽⣿⡏⠀⠀⠀⠀⢸⣽⡟⠛⠦⡀");
            
            Console.SetCursorPosition(17, 20);
            Console.Write("⠸⢄⣠⣀⣼⣿⡇⠀⢀⠀⡀⢸⣿⣿⣇⣀⡀⠀⠀⣠⣇⣠⣀⣤⡼");
        }
        #endregion

        #region 이벤트 거지 출력 메소드
        public void BeggarPrint()
        {
            Console.SetCursorPosition(12, 7);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠠⣄⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 8);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠊⢘⠄⠀⠀⠀⠈⢻⣷⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 9);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣷⣶⣦⣤⣄⡀⢸⣿⣿⣧⠁⠀⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 10);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⣿⠿⢟⠘⣿⡿⢿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 11);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣦⣤⣶⢏⣘⠤⣿⣋⢝⣈⠎⣿⣿⣿⣷⡆⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 12);
            Console.Write("⢠⣶⡑⠔⡍⢆⠀⠀⠀⠀⠀⣺⣿⣿⣿⣿⣯⣤⣶⣿⣿⣷⣆⠀⣸⣿⣿⣟⡃⠀⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 13);
            Console.Write("⠈⠳⣍⠀⠙⠀⠁⠲⣠⣀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢷⡀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 14);
            Console.Write("⠀⠀⠀⠉⠙⠓⠒⣦⡀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 15);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 16);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠈⣹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 17);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 18);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 19);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀\n");

            Console.SetCursorPosition(12, 20);
            Console.Write("⠀⠀⠀⠀⠀⠀⢀⣠⣤⣴⣶⣶⣶⣶⣶⣶⣶⣤⣤⣤⣀⠀⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\n");
        }
        #endregion

        #region 이벤트 야수의 심장 출력 메소드
        public void LionPrint()
        {
            Console.SetCursorPosition(17, 6);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣶⣤⣄⣠⣤⣶⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 7);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⢤⣶⣯⣽⣿⣿⣿⣿⣿⣿⣯⣽⣶⡤⠀⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 8);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⢺⣞⣿⣿⣿⠛⠁⠈⠁⠈⠛⣿⣿⣿⣳⡗⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 9);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⡿⠁⣿⡧⠀⠀⢼⣿⠈⢿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 10);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠛⣿⣿⣿⣆⠉⢦⣶⣶⡴⠉⣰⣿⣿⣿⠛⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 11);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⠀⠀⢸⡇⠀⠀⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 12);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠈⠉⣿⣿⣿⡌⠒⠛⠛⠒⢡⣿⣿⣿⠉⠁⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 13);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⠋⢿⣿⣶⣤⣤⣴⣿⣿⠙⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(17, 14);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠉⠈⠙⠛⠁⠉⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        }
        #endregion

        #region 몬스터 스톤 골렘 출력 메소드
        public void stoneGolemPrint()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(22, 6);
            Console.Write("⣤⣶⣶⣶⣶⣆⠀⣠⣬⣴⣂⢠⣴⣶⣶⣶⣦⡀");

            Console.SetCursorPosition(22, 7);
            Console.Write("⢠⡧⡅⠜⣿⣿⣿⡾⣿⣟⡿⣿⣾⢡⡧⠥⠿⣿⣷");

            Console.SetCursorPosition(22, 8);
            Console.Write("⠘⢃⣶⣃⣿⣯⣵⣩⣭⣭⣯⣽⣿⠸⠉⠏⢡⣿⣿⠄");

            Console.SetCursorPosition(22, 9);
            Console.Write("⠀⠑⠒⠚⣟⡛⣿⣿⣿⣿⣿⣽⣿⡶⠚⢒⢚⠛⠁⠀");

            Console.SetCursorPosition(22, 10);
            Console.Write("⠀⠀⢤⣴⣚⡃⠠⢲⠸⣻⣿⣧⣤⠢⣄⢑⠛⠢⢤⡀");

            Console.SetCursorPosition(22, 11);
            Console.Write("⠀⢈⡲⢚⣿⢇⠂⢻⣥⣜⣭⡿⠋⢲⣿⠠⡟⣛⡧⣿");

            Console.SetCursorPosition(22, 12);
            Console.Write("⢐⡯⡄⣽⡏⠘⣶⣿⣷⠄⠀⠙⣶⣿⠟⠀⢰⣨⢡⣿");

            Console.SetCursorPosition(22, 13);
            Console.Write("⢏⣘⣴⡿⠀⠆⠀⣶⣶⠀⠀⠆⠤⣴⣶⠀⣾⡒⣈⣿");
            
            Console.SetCursorPosition(22, 14);
            Console.Write("⠸⠿⠿⠁⢀⠬⠭⣿⣿⣆⠀⣀⠀⣼⣿⣆⠙⠿⠿⠋");
            Console.ResetColor();
        }
        #endregion

        #region 몬스터 가고일 출력 메소드
        public void WyvernPrint()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(22, 6);
            Console.Write("⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⡀⠀⢀⣀⡤⠶⠒⠚⠛⠃⠀⠀");

            Console.SetCursorPosition(22, 7);
            Console.Write("⠀⢀⡄⣠⣶⣿⣿⡇⠀⢐⣷⣶⡋⠁⠀⠀⢀⢀⠐⠀⠀⠀");

            Console.SetCursorPosition(22, 8);
            Console.Write("⠀⢠⣿⣿⣿⣿⣿⣧⣬⠿⣿⣿⣟⠛⠳⠦⣌⡀⠀⠀⠀⠀");

            Console.SetCursorPosition(22, 9);
            Console.Write("⠀⠈⠙⠻⣿⣿⣿⣿⡟⠁⣿⠀⢈⠳⡄⠀⠀⢙⡪⡄⠀⠀");

            Console.SetCursorPosition(22, 10);
            Console.Write("⠀⠀⠀⠄⣸⢳⣿⣿⣷⣿⡿⠠⠔⠀⠙⡆⡈⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(22, 11);
            Console.Write("⠀⠀⢰⣾⣧⣿⣿⣿⣿⣿⣶⣶⡄⠀⠀⠘⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(22, 12);
            Console.Write("⠀⠀⣾⣿⣿⢿⣿⣋⠋⠙⢿⣿⣿⠀⠀⠀⢀⣀⡀⠀⠀⠀");

            Console.SetCursorPosition(22, 13);
            Console.Write("⠀⠰⣿⡿⣿⣻⣿⠆⣧⣀⣼⣿⣿⣦⣶⣾⠿⠛⠛⠆⠀⠀");

            Console.SetCursorPosition(22, 14);
            Console.Write("⠀⠀⠈⠉⠉⠉⠀⠈⠿⣿⡽⣿⣿⡛⠉⠁⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(22, 15);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠲⠿⠇⢴⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.ResetColor();
        }
        #endregion

        #region 몬스터 좀비 오크 출력 메소드
        public void OakPrint()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(12, 6);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(12, 7);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣾⣿⣿⣮⣿⣤⣀⣤⣶⣤⡆⠀⠀⠀⠀⠀");

            Console.SetCursorPosition(12, 8);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⠆⠀⠀⠀");

            Console.SetCursorPosition(12, 9);
            Console.Write("⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠓⠀⠀⠀");

            Console.SetCursorPosition(12, 10);
            Console.Write("⠀⣴⡀⠀⢰⣶⣦⣀⡀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣄⠀");

            Console.SetCursorPosition(12, 11);
            Console.Write("⠀⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦");

            Console.SetCursorPosition(12, 12);
            Console.Write("⠀⢿⣿⣿⣿⣿⡿⠿⣿⣄⠀⠀⢀⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(12, 13);
            Console.Write("⠀⠈⠛⣿⣿⣿⡇⠀⠈⠻⣷⣤⣾⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿");

            Console.SetCursorPosition(12, 14);
            Console.Write("⠀⠀⠀⠀⠉⠛⠓⠀⠀⠀⠙⢿⣯⡀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠁");

            Console.SetCursorPosition(12, 15);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠋⠘⢿⣿⣿⢟⠃⠙⠛⣿⣿⠋⠉⠁⠀⠀⠀");

            Console.SetCursorPosition(12, 16);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣿⡇⠀⠀⠀⠀⠈⣿⣇⠀⠀⠀⠀⠀");
            Console.ResetColor();
        }
        #endregion

        #region 힐 이벤트 출력 메소드
        public void HealPrint()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(17, 7);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 8);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 9);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 10);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 11);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 12);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 13);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 14);
            Console.Write("⣿⣿⣿⣿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⠀⠻⠿⠿⠿⠿⠿⠿⠿⠿⠿⠿⢻⣿⣿");

            Console.SetCursorPosition(17, 15);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣶⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 16);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 17);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 18);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 19);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 20);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 21);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 22);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(17, 23);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");
            Console.ResetColor();
        }
        #endregion

        #region 보스 몬스터 등장 출력 메소드
        public void BossPrint()
        {
            Console.Clear();
            GameMapPrint();
            Console.SetCursorPosition(25,10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("! WARNNING !");
            Console.ResetColor();
            Thread.Sleep(500);

            Console.Clear();
            GameMapPrint();
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("! WARNNING !");
            Console.ResetColor();
            Thread.Sleep(500);

            Console.Clear();
            GameMapPrint();
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("! WARNNING !");
            Console.ResetColor();
            Thread.Sleep(500);

            Console.Clear();
            GameMapPrint();
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("! WARNNING !");
            Console.ResetColor();
            Thread.Sleep(500);


            Console.Clear();
            GameMapPrint();
            GameInfoPrint();
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 4; i <= 15; i++)
            {
                Console.SetCursorPosition(25, i);
                Console.Write("! WARNNING !");
            }
            Console.ResetColor();     
        }
        #endregion

        #region 몬스터 드라큘라 출력 메소드
        public void DraculaPrint()
        {       
            Console.Clear();
            GameMapPrint();
            GameInfoPrint();

            Console.SetCursorPosition(15, 4);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(15, 5);
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(15, 6);
            Console.Write("⣿⣿⣿⠿⠟⠛⠛⠛⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠛⠛⠛⠻⠿⣿⣿⣿");

            Console.SetCursorPosition(15, 7);
            Console.Write("⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⣿⣿⣿⣿⠟⠉⠀⠀⠀⠀⠀⠀⠀ ⠈⠙⢿");

            Console.SetCursorPosition(15, 8);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀    ⠀⠀⠀⠀");

            Console.SetCursorPosition(15, 9);
            Console.Write("⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀    ⠀⠀⠀");

            Console.SetCursorPosition(15, 10);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("⠀⠀⠀⣠⣿⠋⠛⠲⢦⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⠴⠖⢿⣿⣷⣄⠀  ⠀⠀");

            Console.SetCursorPosition(15, 11);
            Console.Write("⠀⠀⠀⣿⣿⣄⡀⣀⣾⣿⣿⡇⠀⠀⠀⠀⠀⠀⢸⣿⡄⠀⠀⣸⣿⣿⣿⠀⠀⠀  ");

            Console.SetCursorPosition(15, 12);
            Console.Write("⠀⠀⠀⠹⣿⣿⣿⣥⣼⣿⡿⠁⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣤⣿⣿⠏⠀⠀⠀ ");

            Console.SetCursorPosition(15, 13);
            Console.Write("⠀⠀⠀⠀⠈⠛⠛⠛⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠀⠀⠀  ");

            Console.SetCursorPosition(15, 14);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ⠀");

            Console.SetCursorPosition(15, 15);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⢹⠿⠿⠿⠟⠏⠙⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠀");

            Console.SetCursorPosition(15, 16);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢿⠺⠀⠀⠀⠀⠔⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠀");

            Console.SetCursorPosition(15, 17);
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀    ");
        }
        #endregion
    }
}
