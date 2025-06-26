using System.Collections.Generic;
using System.Linq;

namespace ComboBoxDebug.Model;

public class Basket
{
    public string Name { get; set; }
    
    public List<Thing> Things { get; set; }
    
    public Thing? SelectedThing { get; set; }
    
    public ColorOption? SelectedColor { get; set; }

    public Basket(string name, params Thing[] items)
    {
        Name = name;
        Things = items.ToList();
        SelectedThing = items.FirstOrDefault();
        SelectedColor = SelectedThing?.Colors.FirstOrDefault();
    }
    
    public override string ToString() => Name;
}