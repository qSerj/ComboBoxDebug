using System.Collections.Generic;
using System.Linq;

namespace ComboBoxDebug.Model;

public class Thing
{
    public string Name { get; set; }
    
    public List<ColorOption> Colors { get; set; }
    
    public Thing(string name, params string[] colors)
    {
        Name = name;
        Colors = colors.Select(c => new ColorOption(c)).ToList();
    }
    
    public override string ToString() => Name;
}