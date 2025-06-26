using System.Collections.Generic;
using System.Linq;

namespace ComboBoxDebug.Model;

public class Basket
{
    public string Name { get; set; }
    
    public List<Thing> Things { get; set; }

    public Basket(string name, params Thing[] items)
    {
        Name = name;
        Things = items.ToList();
    }
    
    public override string ToString() => Name;
}