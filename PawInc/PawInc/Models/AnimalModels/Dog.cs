public class Dog : Animal
{
	private int commandsAmount;
	public Dog(string name, int age, int commandsAmount) 
		: base(name, age)
	{
		this.commandsAmount = commandsAmount;
	}
}