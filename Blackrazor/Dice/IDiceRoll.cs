using System;

namespace Blackrazor.Dice
{
    /// <summary>
    /// An interface that can be implemented to represent an object that 
    /// can store, roll, and reroll a set of dice
    /// </summary>
    public interface IDiceRoll : IFormattable
    {
        /// <summary>
        /// True if the die roll value is negated when calculated 
        /// (multiplied by <c>-1</c>) when calculated, otherwise false
        /// </summary>
        public bool IsNegative { get; }

        /// <summary>
        /// A string representation of the dice
        /// </summary>
        public string DiceString { get; }

        /// <summary>
        /// The last result of rolling the dice
        /// </summary>
        public int Result { get; }

        /// <summary>
        /// A string representation of the last result of rolling the dice
        /// </summary>
        public string ResultString { get; }

        /// <summary>
        /// Rolls the dice
        /// </summary>
        /// <returns></returns>
        public int Roll();

        /// <summary>
        /// Rolls the dice, and sets the value of <paramref name="rollString"/> 
        /// to the result of the roll
        /// </summary>
        /// <returns></returns>
        public int Roll(out string rollString);

        /// <summary>
        /// Returns a string representation of the <see cref="IDiceRoll"/>
        /// </summary>
        /// <param name="includeResult">
        /// True if the string representation should include the last result of 
        /// rolling the dice, otherwise false
        /// </param>
        /// <returns></returns>
        public string ToString(bool includeResult);
    }
}
