using System;
using System.Collections.Generic;

namespace LatteDB
{
	/// <summary>
	/// This is a simple service locator (a.k.a. Inversion of Control container or Dependency Injection container) which
	/// lets you register concrete types to be returned when asking for an instance of a base class/interface.
	/// 
	/// For more information on this pattern, see http://en.wikipedia.org/wiki/Inversion_of_control
	/// </summary>
	public static class ServiceLocator
	{
		private static Dictionary<Type, object> instances = new Dictionary<Type, object>();
		
		/// <summary>
		/// Adds a new instance for the specified type. If an instance for the type already exists, it is replaced.
		/// </summary>
		/// <param name="instance">
		/// A <see cref="TService"/> instance that will be returned when GetInstance is called for this type.
		/// </param>
		public static void RegisterInstance<TService>(TService instance)
		{
			if(instances.ContainsKey(typeof(TService))){
				instances.Remove(typeof(TService));
			}
			
			instances.Add(typeof(TService), instance);
		}
		
		/// <summary>
		/// Returns an instance of the type requested.
		/// </summary>
		/// <returns>
		/// A <see cref="TService"/> instance.
		/// </returns>
		public static TService GetInstance<TService>()
		{
			return (TService)instances[typeof(TService)];
		}
    }
}