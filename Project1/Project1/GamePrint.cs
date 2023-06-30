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
        // _getch()
        [DllImport("msvcrt.dll")]
        static extern char _getch();


        // 33, 13 정중앙





        public void GameClear()
        {
            Console.WriteLine("축하합니다! 승리하셨습니다.");
        }

        public char topLeftCorner = '┏';
        public char topRightCorner = '┓';
        public char bottomLeftCorner = '┗';
        public char bottomRightCorner = '┛';
        public char horizontalLine = '━';
        public char verticalLine = '┃';
        public char space = ' ';

        public void GameOver()
        {
            Console.WriteLine("패배하셨습니다.");
        }

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


        // 전체프린트
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


        // 윗칸 출력
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
            // 원래 height - 12
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

        // 밑칸 출력
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



        //public char topLeftCorner = '┏';
        //public char topRightCorner = '┓';
        //public char bottomLeftCorner = '┗';
        //public char bottomRightCorner = '┛';
        //public char horizontalLine = '━';
        //public char verticalLine = '┃';
        //public char space = ' ';


        // 맵 정보칸
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


        // 결제내역
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



        public void CatPrint()
        {
            Console.SetCursorPosition(16, 5);
            Console.Write("   /\\__/\\");
            Console.SetCursorPosition(16, 6);
            Console.Write(" ꒰ ˶• ༝ •˶꒱ ~♡︎");
            Console.SetCursorPosition(16, 7);
            Console.Write("   / v v \\");
            Console.SetCursorPosition(16, 8);
            Console.Write("   |     |");
            Console.SetCursorPosition(16, 9);
            Console.Write("   づ__づ");

        }



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

        public void wMovePrint()
        {

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(22,6);
            Console.Write("⠀⠀⠀⡘⢆⠀⢘⣢⣳⣶⣶⣤⣄⠀⠀⠀⠀⠀⠀⣠⣀⣀");
            Console.SetCursorPosition(22, 7);

            Console.Write("⠀⠀⢰⢸⣄⣾⣿⣿⡇⣿⣿⣿⣿⣿⣦⠀⠀⠀⢰⣿⣿⣇");
            Console.SetCursorPosition(22, 8);

            Console.Write("⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⡿⢻⣿⣿⣿⣦⡄⠀⠈⢹⡏⠀");
            Console.SetCursorPosition(22, 9);

            Console.Write("⠀⠀⠀⣿⣿⣿⣿⣿⣿⢷⡇⣴⣿⣿⣿⣿⣇⠀⣀⣼⡇⠀");
            Console.SetCursorPosition(22, 10);

            Console.Write("⠀⠈⣿⣿⣿⣿⣿⣿⡿⠃⣿⣝⣿⣿⣿⣿⣿⣿⣿⡟⠁⠀");
            Console.SetCursorPosition(22, 11);

            Console.Write("⠀⡼⣿⣿⣿⣿⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀");
            Console.SetCursorPosition(22, 12);

            Console.Write("⠀⠀⠹⣿⠏⠀⠀⠀⠀⠀⠀⠛⢿⣿⣿⣿⠿⠋⠀⠀⠀⠀");
            Console.SetCursorPosition(22, 13);

            Console.Write("⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⡟⠀⠀⠀⠀⠀");
            Console.SetCursorPosition(22, 14);

            Console.Write("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠀⠀⠀⠀⠀");
            Console.ResetColor();

        }

    }


}
