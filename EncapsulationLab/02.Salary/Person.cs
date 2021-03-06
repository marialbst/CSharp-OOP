﻿public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.age = age;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public int Age
    {
        get { return this.age; }
    }


    public void IncreaseSalary(double percent)
    {
        if(this.age > 30)
        {
            this.salary += this.salary * percent / 100;
        }
        else
        {
            this.salary += (this.salary * percent / 100) / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} get {this.salary:f2} leva";
    }
}

