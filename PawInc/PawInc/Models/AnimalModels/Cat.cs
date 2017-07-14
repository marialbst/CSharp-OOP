public class Cat : Animal
{
	private int iq;
	public Cat(string name, int age, int iq) 
		: base(name, age)
	{
		this.iq = iq;
	}
}