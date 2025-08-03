namespace Blackrazor.Dice
{
    public interface IDiceStringParser
    {
        /// <summary>
        /// Gets an <see cref="IDiceRoll"/> that represents the provided <paramref name="diceString"/>
        /// </summary>
        /// <param name="diceString"></param>
        /// <returns></returns>
        public IDiceRoll GetDice(string diceString);
    }
}
