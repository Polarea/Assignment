using System;

public class Class1
{
	public int a;
	public int b;
	public Class1(int x, int y, out a, out b)
	{
		a = x + y;
		b = x * y;
	}

	static void Main()
	{
		Class1 cl = new Class1(5, 10);
		Console.WriteLine(cl.a);
		Console.WriteLine(cl.b);
	}
}
