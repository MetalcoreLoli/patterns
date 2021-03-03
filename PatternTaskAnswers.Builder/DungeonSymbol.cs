using System;

namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Символ, который описывает часть подземелья
    /// </summary>
    public readonly struct DungeonSymbol
    {
        public char Symbol { get; }
        public ConsoleColor Color { get; }

        public DungeonSymbol(char symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }
    }
}