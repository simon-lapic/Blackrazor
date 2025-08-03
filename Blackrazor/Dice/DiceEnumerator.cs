using System;
using System.Collections;
using System.Collections.Generic;

namespace Blackrazor.Dice
{
    public class DiceEnumerator(IDiceRoll[] dice) : IEnumerator<IDiceRoll>
    {
        /// <summary>
        /// The array of <see cref="IDiceRoll"/> used to manage the position internally
        /// </summary>
        private IDiceRoll[] _dice = dice;

        /// <summary>
        /// The position of the <see cref="Current"/> <see cref="IDiceRoll"/>
        /// </summary>
        private int _position = -1;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IDiceRoll Current
        {
            get
            {
                try
                {
                    return _dice[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        object IEnumerator.Current => Current;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public bool MoveNext() => ++_position < _dice.Length;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Reset() => _position = -1;
    }
}
