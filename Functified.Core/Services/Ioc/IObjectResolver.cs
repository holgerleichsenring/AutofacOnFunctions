using System;
using System.Collections.Generic;
using Autofac.Core;

namespace Functified.Core.Services.Ioc
{
    /// <summary>
    ///     Contract for releasing class instances.
    /// </summary>
    public interface IObjectResolver
    {
        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <param name="arguments">ctor arguments in right order (dependencies will be added automatically)</param>
        /// <returns>instance of T</returns>
        T Resolve<T>(IEnumerable<Parameter> arguments);

        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <typeparam name="T">type of object to be created</typeparam>
        /// <returns>instance of T</returns>
        T Resolve<T>();

        /// <summary>
        ///     Creates the specified class instance. Uses ctor injection to populate the dependencies.
        /// </summary>
        /// <param name="service">type of object to be created</param>
        /// <returns>instance of specified type</returns>
        object Resolve(Type service);
    }
}