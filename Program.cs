using System;
using System.Threading;

namespace SimpleReactionTimeTest
{
    internal static class Program
    {
        public static int ChoiceNumber
        { get; set; }

        private static void Main()
        {
            ConsoleWindowSettings();
            Program.ChoiceNumber = 1;

            while (true)
            {
                Console.Clear();
                ConsoleColorSettings();
                Menu();
                ConsoleColorSettings();
            }
        }

        private static void FindCenter(string _, int Y = 0)
        {
            int value = (Console.WindowWidth / 2) - (_.Length / 2);
            Console.SetCursorPosition((value), Y);
            Console.WriteLine(_);
        }

        private static void Menu()
        {
            string menuTitle = "Select option to begin the test.";
            FindCenter(menuTitle);

            string buttonReaction = "1.Button reaction";
            string soundReaction = "2.Sound reaction";
            string exitLabel = "Exit";

            if (Program.ChoiceNumber != 1)
                FindCenter(buttonReaction, 2);
            if (Program.ChoiceNumber != 2)
                FindCenter(soundReaction, 3);
            if (Program.ChoiceNumber != 3)
                FindCenter(exitLabel, 4);

            SelectedConsoleColorSettings();

            if (Program.ChoiceNumber == 1)
                FindCenter(buttonReaction, 2);
            else if (Program.ChoiceNumber == 2)
                FindCenter(soundReaction, 3);
            else if (Program.ChoiceNumber == 3)
                FindCenter(exitLabel, 4);

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                if (Program.ChoiceNumber == 1)
                {
                    Program.ChoiceNumber = 3;
                }
                else
                {
                    Program.ChoiceNumber--;
                }
            }
            if (key == ConsoleKey.DownArrow)
            {
                if (Program.ChoiceNumber == 3)
                    Program.ChoiceNumber = 0;
                Program.ChoiceNumber++;
            }
            if (key == ConsoleKey.D1)
                Program.ChoiceNumber = 1;

            if (key == ConsoleKey.D2)
                Program.ChoiceNumber = 2;

            if (key != ConsoleKey.D1 && key != ConsoleKey.D2 &&
                key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow
                && key != ConsoleKey.Escape && key != ConsoleKey.Enter)
                Program.ChoiceNumber = 3;

            if (key == ConsoleKey.Enter)
            {
                ConsoleColorSettings();
                Console.Clear();
                if (Program.ChoiceNumber == 1)
                {
                    ButtonReactionTest();
                }
                if (Program.ChoiceNumber == 2)
                {
                    SoundReactionTest();
                }
                if (Program.ChoiceNumber == 3)
                {
                    Environment.Exit(0);
                }
            }
            if (key == ConsoleKey.Escape)
            {
                Exit();
            }
        }

        public static void Exit()
        {
            ConsoleColorSettings();
            Console.Clear();
            Environment.Exit(0);
        }

        private static void ConsoleWindowSettings()
        {
            Console.Title = "Simple Reaction Time Test";
            Console.CursorVisible = false;
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;
            Console.WindowHeight = 20;
            Console.BufferHeight = 20;
        }

        private static void SelectedConsoleColorSettings()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
        }

        private static void ConsoleColorSettings()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ButtonReactionTest()
        {
            string buttonTest = "Button";
            FindCenter(buttonTest);
            Thread.Sleep(1000);
        }

        public static void SoundReactionTest()
        {
            string soundTest = "Sound";
            FindCenter(soundTest);
            Thread.Sleep(1000);
        }
    }
}