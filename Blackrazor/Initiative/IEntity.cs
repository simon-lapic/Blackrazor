using System;
using System.Collections.Generic;
using System.Text;

namespace Blackrazor.Initiative
{
    public interface IEntity : IComparable<IEntity>
    {
        /// <summary>
        /// The display name of this <see cref="IEntity"/>
        /// </summary>
        public string DisplayName { get; set; }
    }
}
