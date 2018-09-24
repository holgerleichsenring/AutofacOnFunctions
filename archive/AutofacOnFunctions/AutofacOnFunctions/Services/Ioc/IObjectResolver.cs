using System;
using System.Collections.Generic;
using Autofac.Core;

namespace AutofacOnFunctions.Services.Ioc
{
    /// <summary>
    ///     Contract for releasing class instances.
    /// </summary>
    public interface IObjectResolver
    {
        /// <summary>
        ///     Resolves the specified class instance. 
        /// </summary>
        /// <typeparam name="T">type of object to be resolved</typeparam>
        /// <param name="arguments">ctor arguments in right order (dependencies will be added automatically)</param>
        /// <returns>instance of T</returns>
        T Resolve<T>(IEnumerable<Parameter> arguments);

        /// <summary>
        ///     Resolves the specified class instance. 
        /// </summary>
        /// <typeparam name="T">type of object to be resolved</typeparam>
        /// <returns>instance of T</returns>
        T Resolve<T>();

        /// <summary>
        ///     Creates the specified class instance. 
        /// </summary>
        /// <param name="service">type of object to be resolved</param>
        /// <returns>instance of specified type</returns>
        object Resolve(Type service);

        /// <summary>
        ///     Resolves the specified class instance. 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        object Resolve(Type service, string name);
    }
}