using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blackrazor.Initiative
{
    public interface IOrder : IEnumerable<IPosition>
    {
        /// <summary>
        /// The display name of this <see cref="IOrder"/>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The starting <see cref="IPosition"/> of the <see cref="IOrder"/>
        /// </summary>
        public IPosition First { get; }

        /// <summary>
        /// The current <see cref="IPosition"/> of the <see cref="IOrder"/>
        /// </summary>
        public IPosition Current { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable"/> that represents the entire <see cref="IOrder"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPosition> GetOrder();

        /// <summary>
        /// Adds an <see cref="IEntity"/> object to this <see cref="IOrder"/>
        /// </summary>
        /// <param name="entity">The <see cref="IEntity"/> to add</param>
        /// <param name="positioner">
        ///     A function that takes an <see cref="IOrder"/> object and 
        ///     returns an <see cref="IPosition"/>. Called by the function
        ///     to decide what <see cref="IPosition"/> in this <see cref="IOrder"/> 
        ///     the <see cref="IEntity"/> should be placed
        /// </param>
        /// <returns></returns>
        public IPosition AddEntity(IEntity entity, Func<IOrder, IPosition> positioner);
    }
}
