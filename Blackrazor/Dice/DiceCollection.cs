using System;
using System.Collections;
using System.Collections.Generic;

namespace Blackrazor.Dice
{
    public class DiceCollection : IDiceRoll, IEnumerable<IDiceRoll>
    {
        public bool IsNegative { get; }

        public string DiceString { get; private set; }

        public IDiceRoll[] Dice { get; }

        public int Result { get; private set; }

        public string ResultString { get; private set; }

        public DiceCollection(IEnumerable<IDiceRoll> dice, bool isNegative = false)
        {
            Dice = [.. dice];
            IsNegative = isNegative;

            DiceString = ToString();
            ResultString = "";
            Result = Roll();
        }

        public int Roll()
        {
            if (Dice.Length == 0)
                return 0;

            int result = Dice[0].Roll(out string resultString);
            for (int i = 1; i < Dice.Length; i++)
            {
                if (Dice[i].IsNegative)
                {
                    result += Dice[i].Roll();
                    resultString += " - " + Dice[i].ResultString.TrimStart('-');
                }
                else
                {
                    result += Dice[i].Roll();
                    resultString += " + " + Dice[i].ResultString;
                }
            }

            ResultString = IsNegative ? $"-({resultString})" : resultString;
            return result * (IsNegative ? -1 : 1);
        }

        public int Roll(out string rollString)
        {
            int result = Roll();
            rollString = ResultString;
            return result;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(DiceString))
                return DiceString;

            if (Dice.Length == 0)
                return "";

            string diceString = Dice[0].DiceString;
            for (int i = 1; i < Dice.Length; i++)
            {
                if (Dice[i].IsNegative)
                    diceString += " - " + Dice[i].DiceString.TrimStart('-');
                else
                    diceString += " + " + Dice[i].DiceString;
            }
            return diceString;
        }

        public string ToString(bool includeResult)
        {
            if (!includeResult)
                return ToString();
            return ResultString + $" = {Result}";
        }

        public string ToString(string format, IFormatProvider formatProvider)
            => ToString(format == "r" || format == "res" || format == "result");

        public IEnumerator<IDiceRoll> GetEnumerator()
        {
            return new DiceEnumerator(Dice);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
