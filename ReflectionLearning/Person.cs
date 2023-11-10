// See https://aka.ms/new-console-template for more information
using ReflectionLearning;
#region Practice
//Console.Title = "Learning Reflection";
//var personType = typeof(Person);
//var personConst = personType.GetConstructors(
//    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
    
//foreach (var constr in personConst)
//{
//    Console.WriteLine(constr);
//}

//var privateConst = personType.GetConstructor(
//    BindingFlags.Instance | BindingFlags.NonPublic,
//    new Type[] { typeof(string), typeof(int) });

//var person1 = personConst[1].Invoke(null);
//var person2 = personConst[0].Invoke(new object[] {"John", 50, "Director"});
//var person3 = Activator.CreateInstance(typeof(Person), BindingFlags.Instance | BindingFlags.NonPublic, null, new object []{"luke",50, "Accountant"},null);
//var assembly = Assembly.GetExecutingAssembly();
//var person4 = assembly.CreateInstance(typeof(Person).ToString(),true,BindingFlags.NonPublic| BindingFlags.Instance,null,new object[] {"Kevin", 45, "CEO"},null,null);
//var privateField = person4?.GetType().GetProperty("Name");

//Person person5 = new Person();
//person5.SetName("Michael").SetAge(52).SetOccupation("Manager");
//Console.WriteLine($"Name: {person5.Name} Age: {person5.Age} Occupation: {person5.Occupation}");
//var namePerson5 = person5?.GetType().GetField("Name");
//namePerson5?.SetValue(person5, "Jacob");
//Console.WriteLine(person5?.Name);
//person5?.GetType().InvokeMember("Name", BindingFlags.SetField,null, person5, new object[] {"Casper"});
//Console.WriteLine(person5?.Name);
//var personMethod = person5?.GetType().GetMethod("SetName");
//personMethod?.Invoke(person5,new object[] { "Patrik" });
//Console.WriteLine(person5?.Name);
//Console.ReadLine();
#endregion
public class Person : ReflectionLearning.Person
{
    public string? Name;
    public int Age;
    public string? Occupation;

    Person(string name, int age, string occupation)
    {
        (Name, Age, Occupation) = (name, age, occupation);
        Console.WriteLine($"Private constructor with name: {Name} and age: {Age} has been called.");
    }
    public Person()
    {
        (Name, Age, Occupation) = (null, 0, null);
        Console.WriteLine("Public constructor has been called.");
    }

	public ReflectionLearning.Person SetName(string name)
    {
        Name = name;
        return this;
    }
	public ReflectionLearning.Person SetAge(int age)
    {
        Age = age;
        return this;
    }
	public ReflectionLearning.Person SetOccupation(string occupation)
    {
        Occupation = occupation;
        return this;
    }

}
