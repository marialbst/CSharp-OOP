using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        var elem = this.data.Last();
        this.data.Remove(elem);
        return elem;
    }

    public string Peek()
    {
        return this.data.Last();
    }

    public bool IsEmpty()
    {
        return this.data.Count > 0;
    }
}
