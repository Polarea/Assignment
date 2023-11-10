using System.Reflection;

namespace Inversion_of_Control_Container.Classes
{
	public class IoCContainer
	{
		Dictionary<Type, Type> _map = new();
		MethodInfo? _resolveMethod;

		public void Register<TContract, TImplementation>()
		{
			if (!_map.ContainsKey(typeof(TContract)))
			{
				_map.Add(typeof(TContract), typeof(TImplementation));
			}
		}

		public TContract Resolve<TContract>()
		{
			if (!_map.ContainsKey(typeof(TContract)))
			{
				throw new ArgumentException($"No registration found for {typeof(TContract)}");
			}
			return Create<TContract>(_map[typeof(TContract)]);
		}

		private TContract Create<TContract>(Type implementationType)
		{
			if (_resolveMethod == null)
			{
				_resolveMethod = typeof(IoCContainer).GetMethod("Resolve");
			}
			var constructorParam = implementationType.GetConstructors()
				.OrderByDescending(x => x.GetParameters().Length)
				.First()
				.GetParameters()
				.Select(p =>
				{
					var genericResolveMethod = _resolveMethod?.MakeGenericMethod(p.ParameterType);
					return genericResolveMethod?.Invoke(this, null);
				})
				.ToArray();
			return (TContract)Activator.CreateInstance(implementationType, constructorParam);
		}
	}
}
