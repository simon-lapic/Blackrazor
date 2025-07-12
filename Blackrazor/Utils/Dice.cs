using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Blackrazor.Utils
{
    public class Dice
    {
        /// <summary>
        ///  The static <see cref="RandomNumberGenerator"/> used by the class to generate random numbers
        /// </summary>
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        /// <summary>
        /// The <see cref="Regex"/> pattern used to validate dice strings
        /// </summary>
        private static readonly Regex _diceStringPattern = new Regex(@"^([\+\-]\d+(?:d\d+)?)+$");

        /// <summary>
        /// The <see cref="Regex"/> pattern used to parse dice strings
        /// </summary>
        private static readonly Regex _diceStringParser = new Regex(@"[\+\-]\d+(?:d\d+)?");

        /// <summary>
        /// Rolls a single die of the provided size and returns the value
        /// </summary>
        /// <param name="diceSize"></param>
        /// <returns></returns>
        public static int RollDie(int diceSize)
        {
            byte[] bytes = new byte[16];
            _rng.GetBytes(bytes);
            return (BitConverter.ToUInt16(bytes) % diceSize) + 1;
        }

        /// <summary>
        /// The dice added to the roll value
        /// </summary>
        private Dictionary<int, int> AddedDice { get; }

        /// <summary>
        /// The dice subtracted from the roll value
        /// </summary>
        private Dictionary<int, int> SubtractedDice { get; }

        /// <summary>
        /// The modifier applied to the roll value
        /// </summary>
        private List<int> Modifiers { get; }

        /// <summary>
        /// The result of the roll
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        ///  A string representation of the deice result
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// Constructs a new <see cref="Utils.Dice"/> object
        /// </summary>
        /// <param name="diceString"></param>
        public Dice(string diceString)
        {
            AddedDice = [];
            SubtractedDice = [];
            Modifiers = [];
            Value = 0;
            Result = "";

            string parseable = diceString;
            if (!parseable.StartsWith("-") && !parseable.StartsWith("+"))
                parseable = "+" + parseable;

            if (!_diceStringPattern.IsMatch(parseable))
                throw new ArgumentException("Dice string is not valid", nameof(diceString));

            Match match = _diceStringParser.Match(parseable);
            while (match.Success)
            {
                string die = match.Value;
                bool positive = die[0] == '+';
                die = die[1..];

                if (!die.Contains("d"))
                {
                    Modifiers.Add(int.Parse(die));
                    match = match.NextMatch();
                    continue;
                }

                int[] dieInfo = [.. die.Split("d").Select(int.Parse)];

                if (positive)
                    AddedDice[dieInfo[1]] = dieInfo[0];
                else
                    SubtractedDice[dieInfo[1]] = dieInfo[0];

                match = match.NextMatch();
            }

            Roll();
        }

        /// <summary>
        /// Rerolls the dice,  
        /// </summary>
        /// <returns></returns>
        public Dice Roll()
        {
            Result = "";
            Value = 0;

            // Roll added dice
            foreach (int dieSize in AddedDice.Keys.OrderBy(k => -k).ToList())
            {
                List<string> results = [];
                for (int i = 0; i < AddedDice[dieSize]; i++)
                {
                    int val = RollDie(dieSize);
                    results.Add(val.ToString());
                    Value += val;
                }
                Result += $" + ({string.Join(", ", results)})";
            }

            // Roll subtracted dice
            foreach (int dieSize in SubtractedDice.Keys.OrderBy(k => -k).ToList())
            {
                List<string> results = [];
                for (int i = 0; i < SubtractedDice[dieSize]; i++)
                {
                    int val = RollDie(dieSize);
                    results.Add(val.ToString());
                    Value -= val;
                }
                Result += $" - ({string.Join(", ", results)})";
            }

            // Add modifiers
            foreach (int modifier in Modifiers)
            {
                Value += modifier;
                if (modifier < 0)
                    Result += $" - {modifier * -1}";
                else
                    Result += $" + {modifier}";
            }

            if (Result.StartsWith(" + "))
                Result = Result[3..];
            else if (Result.StartsWith(" - "))
                Result = "-" + Result[3..];

            Result += $" = {Value}";
            return this;
        }

        public override string ToString()
        {
            string diceString = "";
            foreach (int dieSize in AddedDice.Keys.OrderBy(k => -k).ToList())
                diceString += $"+{AddedDice[dieSize]}d{dieSize}";
            foreach (int dieSize in SubtractedDice.Keys.OrderBy(k => -k).ToList())
                diceString += $"-{SubtractedDice[dieSize]}d{dieSize}";
            foreach (int modifier in Modifiers)
                diceString += (modifier >= 0 ? "+" : "") + $"{modifier}";
            return diceString.StartsWith("+") ? diceString[1..] : diceString;
        }

        public static Dice operator +(Dice other)
        {
            throw new NotImplementedException();
        }

        public static Dice operator -(Dice other)
        {
            throw new NotImplementedException();
        }
    }
}
