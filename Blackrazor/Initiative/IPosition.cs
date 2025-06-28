using System;
using System.Collections.Generic;
using System.Text;

namespace Blackrazor.Initiative
{
    public interface IPosition : IComparable<IPosition>
    {
        /// <summary>
        /// The unique GUID associated with the <see cref="IPosition"/>
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// The display name of this <see cref="IPosition"/>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The next <see cref="IPosition"/> in this <see cref="IPosition"/>'s <see cref="IOrder"/> parent
        /// </summary>
        public IPosition Next { get; }

        /// <summary>
        /// The previous <see cref="IPosition"/> in this <see cref="IPosition"/>'s <see cref="IOrder"/> parent
        /// </summary>
        public IPosition Previous { get; }

        /// <summary>
        /// An <see cref="IEnumerable{IEntity}"/> that contains all the <see cref="IEntity"/> objects in this position
        /// </summary>
        public IEnumerable<IEntity> Entities { get; }

        /// <summary>
        /// The currently active <see cref="IEntity"/> in this <see cref="IPosition"/>, 
        /// or <see langword="null"/> if no entity is active in this position
        /// </summary>
        public IEntity? CurrentEntity { get; }
    }
}
