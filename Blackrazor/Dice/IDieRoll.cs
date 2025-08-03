namespace Blackrazor.Utils
{
    /// <summary>
    /// An interface that can be implemented to represent an object that 
    /// can store, roll, and reroll a set of dice
    /// </summary>
    public interface IDieRoll
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
        public int Value { get; }

        /// <summary>
        /// A string representation of the last result of rolling the dice
        /// </summary>
        public string ValueString { get; }

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
        /// Sets the value of each die in the die roll 
        /// </summary>
        /// <param name="dieValues"></param>
        /// <returns></returns>
        public int SetRoll(params int[] dieValues);
    }
}
