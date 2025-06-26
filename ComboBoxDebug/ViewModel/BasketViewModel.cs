using System.Collections.ObjectModel;
using Avalonia.Media;
using ComboBoxDebug.Model;
using Prism.Mvvm;

namespace ComboBoxDebug.ViewModel;

public class BasketViewModel : BindableBase
{
    private Basket _basket;
    
    public BasketViewModel(Basket basket)
    {
        _basket = basket;
        
        Items = new ObservableCollection<Thing>(basket.Things);
        _selectedThing = Items[0];
        
        Colors = new ObservableCollection<ColorOption>(_selectedThing.Colors);
        _selectedColor = _selectedThing.Colors[0];
    }

    public ObservableCollection<Thing> Items { get; set; }
   
    Thing _selectedThing;
    public Thing SelectedThing
    {
        get => _selectedThing;
        set
        {
            if (SetProperty(ref _selectedThing, value))
            {
                Colors = new ObservableCollection<ColorOption>(_selectedThing.Colors);
                SelectedColor = _selectedColor;
            }
            
        }
    }
    
    public ObservableCollection<ColorOption> Colors { get; set; }
    
    private ColorOption _selectedColor;
    public ColorOption? SelectedColor
    {
        get => _selectedColor;
        set => SetProperty(ref _selectedColor, value);
    }
    
    public string Name => _basket.Name;
}