using System;
using System.Collections.Generic;
using System.Text;

namespace Blackrazor.Initiative
{
    public interface IEffect
    {
        /// <summary>
        /// The display name of this <see cref="IEffect"/>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A description of this <see cref=""/>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The remaining number of turns before this <see cref="Effect"/>
        /// </summary>
        public int Duration { get; set; }
    }
}
