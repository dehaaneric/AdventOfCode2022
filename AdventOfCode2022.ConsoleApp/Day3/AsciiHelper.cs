﻿namespace AdventOfCode2022.ConsoleApp.Day3
{
    public static class AsciiHelper
    {
        public static int GetPuzzleAsciiValue(char c)
        {
            // Returns
            // 65  - A  (27)
            // 90  - Z  (52)
            // 97  - a  (1)
            // 122 - z  (26)
            int value = (int)c;

            if (Char.IsUpper(c))
            {
                return value - 38;
            }
            else
            {
                return value - 96;
            }
        }
    }
}
