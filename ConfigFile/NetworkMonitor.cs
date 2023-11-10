using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ConfigFile
{
	public static class NetworkMonitor
	{
		private static NetworkMonitorSettings _networkMonitorSettings = new();
		private static Type? _warningServiceType;
		private static MethodInfo? _warningServiceMethod;
		private static List<object> _warningServiceParameterValues = new List<object>();
		private static object? _warningService;

		public static void Warn()
		{
			if (_warningService == null)
			{
				_warningService = Activator.CreateInstance(_warningServiceType!);
			}
			foreach (var propertyBagItem in _networkMonitorSettings.PropertyBag)
			{
				_warningServiceParameterValues.Add(propertyBagItem.Value);
			}
			_warningServiceMethod?.Invoke(_warningService, _warningServiceParameterValues.ToArray());
		}
		
		public static void BootstrapFromConfiguration()
		{
			var appSettingsConfig = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json",false,true)
				.Build();
			appSettingsConfig.Bind("NetworkMonitorSettings", _networkMonitorSettings);
			_warningServiceType = Assembly.GetExecutingAssembly()
				.GetType(_networkMonitorSettings.WarningService);
			if (_warningServiceType == null)
			{
				throw new Exception("Configuration is invalid - warning service not found");
			}
			_warningServiceMethod = _warningServiceType?
				.GetMethod(_networkMonitorSettings.MethodToExecute);
			if (_warningServiceMethod == null)
			{
				throw new Exception("Configuration is invalid - method to execute on warning service not found");
			}
			foreach (var parameterInfo in _warningServiceMethod.GetParameters())
			{
				if (!_networkMonitorSettings.PropertyBag.TryGetValue(parameterInfo.Name!, out object? parameterValue))
				{
					throw new Exception($"Configuration is invalid - parameter {parameterInfo.Name} not found.");
				}

				try
				{
					var typedValue = Convert.ChangeType(parameterValue, parameterInfo.ParameterType);
				}
				catch
				{
					throw new Exception($"Configuration is invalid - parameter {parameterInfo.Name} cannot be converted into expected type {parameterInfo.ParameterType}");
				}
			}
		}
	}
}
