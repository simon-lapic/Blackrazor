namespace Blackrazor.Utils
{
    /// <summary>
    /// An interface that can be implemented to represent an object that 
    /// can store, roll, and reroll a set of dice
    /// </summary>
    public interface IDieRoll
    {
        /// <summary>
        /// A string representation of the dice
        /// </summary>
        public string DiceString { get; }

        /// <summary>
        /// The last result of rolling the dice
        /// </summary>
        public int Value { get; protected set; }

        /// <summary>
        /// A string representation of the last result of rolling the dice
        /// </summary>
        public string ValueString { get; protected set; }

        /// <summary>
        /// Rolls the dice
        /// </summary>
        /// <returns></returns>
        public int Roll();

        /// <summary>
        /// Sets the value of each die in the die roll 
        /// </summary>
        /// <param name="dieValues"></param>
        /// <returns></returns>
        public int SetRoll(params int[] dieValues);
    }
}
