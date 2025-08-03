using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackrazor.Dice
{

    public class DieRoll : IDiceRoll
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool IsNegative { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string DiceString { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public int Result { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ResultString { get; private set; }

        /// <summary>
        /// An <see cref="IRandomnessProvider"/> for this <see cref="DieRoll"/> to use to 
        /// generate the random numbers for its rolls
        /// </summary>
        private IRandomnessProvider RNG { get; }

        /// <summary>
        /// The size of die this <see cref="DieRoll"/> uses
        /// </summary>
        private int DieSize { get; }

        /// <summary>
        /// The number of dice this <see cref="DieRoll"/> uses
        /// </summary>
        private int DieCount { get; }

        /// <summary>
        /// The modifier applied to this <see cref="DieRoll"/>
        /// </summary>
        private int? Modifier { get; }

        /// <summary>
        /// Constructs a new <see cref="DieRoll"/> object
        /// </summary>
        /// <param name="rng">
        /// An <see cref="IRandomnessProvider"/> that can be used to generate 
        /// random numbers for this <see cref="DieRoll"/>'s rolls
        /// </param>
        /// <param name="dieSize"></param>
        /// <param name="dieCount"></param>
        /// <param name="modifier"></param>
        /// <param name="isNegative"></param>
        public DieRoll(IRandomnessProvider rng, int dieCount, int dieSize, int? modifier = null, bool isNegative = false)
        {
            RNG = rng;

            IsNegative = isNegative;
            DieSize = dieSize;
            DieCount = dieCount;
            Modifier = modifier;

            DiceString = ToString();
            ResultString = "";
            Result = Roll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            List<int> results = [.. Enumerable.Range(0, DieCount).Select(i => RNG.GetRandomNumber(DieSize) + 1)];
            string resultString = string.Join(", ", results);

            string prefix = IsNegative ? "-" : "";
            ResultString = $"{prefix}{DieCount}d{DieSize} ({resultString})";
            if (Modifier is not null)
                ResultString += (Modifier < 0 ? " - " : " + ") + $"{Math.Abs(Modifier.Value)}";

            Result = (results.Sum() + (Modifier ?? 0)) * (IsNegative ? -1 : 1);
            return Result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="rollString"></param>
        /// <returns></returns>
        public int Roll(out string rollString)
        {
            int result = Roll();
            rollString = ResultString;
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(DiceString))
                return DiceString;

            string prefix = IsNegative ? "-" : "";
            string diceString = $"{prefix}{DieCount}d{DieSize}";
            if (Modifier is not null)
                diceString += (Modifier < 0 ? " - " : " + ") + $"{Math.Abs(Modifier.Value)}";
            return diceString;
        }

        /// <summary>
        /// Returns a string representation of this <see cref="DieRoll"/>
        /// </summary>
        /// <param name="includeResult">True if the result of the roll should be included, otherwise false</param>
        /// <returns></returns>
        public string ToString(bool includeResult)
        {
            if (!includeResult)
                return ToString();
            return ResultString + $" = {Result}";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="format">Includes the result of the roll if set to <c>"r"</c>, <c>"res"</c>, 
        /// or <c>"result"</c></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
            => ToString(format == "r" || format == "res" || format == "result");
    }
}
