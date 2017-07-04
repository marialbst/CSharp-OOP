﻿public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        this.age = age;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public int Age
    {
        get { return this.age; }
    }


    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is a {this.age} years old";
    }
}

