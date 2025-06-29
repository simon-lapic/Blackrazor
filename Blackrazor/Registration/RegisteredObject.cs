using Blackrazor.Initiative;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blackrazor.Registration
{
    /// <summary>
    /// Represents an object that exists in the <see cref="ObjectRegistry"/>
    /// </summary>
    public abstract class RegisteredObject
    {
        /// <summary>
        /// The <see cref="Guid"/> of this <see cref="RegisteredObject"/>
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Constructs a new <see cref="RegisteredObject"/> and registers it the <see cref="ObjectRegistry"/>
        /// </summary>
        protected RegisteredObject()
        {
            ID = Guid.NewGuid();
            ObjectRegistry.Register(this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is CharacterEntity)
                return ID == ((CharacterEntity)obj).ID;
            return false;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        #region Operators

        public static bool operator ==(RegisteredObject object1, RegisteredObject object2)
        {
            return object1.ID == object2.ID;
        }

        public static bool operator !=(RegisteredObject object1, RegisteredObject object2)
        {
            return object1.ID != object2.ID;
        }

        #endregion

    }
}
