using ReflectionLearning;

namespace ConfigFile
{
	public static class Program
	{
		public static void Main()
		{
			Console.Title = "Making a self-configuring program";
			
			var dictType = typeof(Dictionary<,>);
			foreach (var genTypeArg in dictType.GetGenericArguments())
			{
				Console.WriteLine(genTypeArg);
			}

			var createdInstance = Activator.CreateInstance(typeof(List<Person>));
			Console.WriteLine(createdInstance?.GetType());

			var openResultType = typeof(Result<>);
			var closedResultType = openResultType.MakeGenericType(typeof(Person));
			var createdResult = Activator.CreateInstance(closedResultType);
			Console.WriteLine(createdResult?.GetType());

			//var openResultType = Type.GetType("ReflectionLearning.Result`1");
			////var closedResultType = openResultType.MakeGenericType(Type.GetType("ReflectionLearning.Person"));
			////var createdResult = Activator.CreateInstance(closedResultType);
			//Console.WriteLine(createdResult.GetType());
			//NetworkMonitorExample();

			var methodInfo = closedResultType.GetMethod("AlterAndReturnValue");
			Console.WriteLine(methodInfo);
			var genericMethod = methodInfo.MakeGenericMethod(typeof(Person));
			genericMethod.Invoke(createdResult, new object[] { new Person() });
		}
		
		static void NetworkMonitorExample()
		{
			NetworkMonitor.BootstrapFromConfiguration();
			Console.WriteLine("Monitoring network...something went wrong.");
			NetworkMonitor.Warn();
		}
		
	}
}
