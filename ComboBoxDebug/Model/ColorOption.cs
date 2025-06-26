namespace ComboBoxDebug.Model;

public class ColorOption
{
    public string Name { get; set; }
    public ColorOption(string name) => Name = name;
    
    public override string ToString() => Name;
}