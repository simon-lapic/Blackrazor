using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackrazor.Registration
{
    public static class ObjectRegistry
    {
        private static Dictionary<Guid, RegisteredObject> Registry { get; } = [];

        /// <summary>
        /// Registers the provided object in the <see cref="ObjectRegistry"/>
        /// </summary>
        /// <param name="regisrtyObject"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void Register(RegisteredObject regisrtyObject)
        {
            Registry.Add(regisrtyObject.ID, regisrtyObject);
        }

        /// <summary>
        /// Gets the <see cref="RegisteredObject"/> from the <see cref="ObjectRegistry"/> 
        /// with the provided <see cref="Guid"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public static RegisteredObject Get(Guid id)
        {
            return Registry[id];
        }

        /// <summary>
        /// Gets the <see cref="RegisteredObject"/> from the <see cref="ObjectRegistry"/> 
        /// with the provided <see cref="Guid"/> and casts it as a <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public static T Get<T>(Guid id) where T : RegisteredObject
        {
            return (T)Get(id);
        }

        /// <summary>
        /// Gets a <see cref="List{T}"/> that contains all the <see cref="RegisteredObject"/>s 
        /// in the <see cref="ObjectRegistry"/> that can be cast as <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetAll<T>() where T : RegisteredObject
        {
            return [.. Registry.Values.Where(obj => (obj as T) != null).Cast<T>()];
        }

        /// <summary>
        /// Removes the <see cref="RegisteredObject"/> from the <see cref="ObjectRegistry"/>
        /// with the provided <see cref="Guid"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The removed object</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public static RegisteredObject Remove(Guid id)
        {
            RegisteredObject registered = Registry[id];
            Registry.Remove(id);
            return registered;
        }

        /// <summary>
        /// Removes the <see cref="RegisteredObject"/> from the <see cref="ObjectRegistry"/>
        /// with the provided <see cref="Guid"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The removed object, cast as <typeparamref name="T"/></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public static T Remove<T>(Guid id) where T : RegisteredObject
        {
            return (T)Remove(id);
        }
    }
}
