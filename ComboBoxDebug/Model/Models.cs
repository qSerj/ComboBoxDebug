using System.Collections.Generic;
using System.Linq;

namespace ComboBoxDebug.Model;

public class ColorOption
{
    public string Name { get; set; }
    public ColorOption(string name) => Name = name;
    
    public override string ToString() => Name;
}

public class Item
{
    public string Name { get; set; }
    public List<ColorOption> Colors { get; set; }
    public Item(string name, params string[] colors)
    {
        Name = name;
        Colors = colors.Select(c => new ColorOption(c)).ToList();
    }
    
    public override string ToString() => Name;
}

public class Basket
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }

    // Запоминаем выбор внутри каждой корзины
    public Item? SelectedItem { get; set; }
    public ColorOption? SelectedColor { get; set; }

    public Basket(string name, params Item[] items)
    {
        Name = name;
        Items = items.ToList();
        SelectedItem = Items.FirstOrDefault();
        SelectedColor = SelectedItem?.Colors.FirstOrDefault();
    }
    
    public override string ToString() => Name;
}
