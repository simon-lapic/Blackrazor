namespace Blackrazor.Dice
{
    public interface IRandomnessProvider
    {
        /// <summary>
        /// Gets a random number in the range <c>[0, <paramref name="maximum"/>)</c>
        /// </summary>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public int GetRandomNumber(int maximum);
    }
}
