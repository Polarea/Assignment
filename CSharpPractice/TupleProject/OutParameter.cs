using System;

public class Class1
{
	string _name;
	int _age;
	double _salary;
	string _city;
	public Class1(string name, int age, double salary, string city)
	{
		_name = name;
		_age = age;
		_salary = salary;
		_city = city;
	}
	public void Deconstruct(out string name, out int age, out double salary, out string city)
	{
		name = _name;
		age = _age;
		salary = _salary;
		 city = _city;
	}

	
}
