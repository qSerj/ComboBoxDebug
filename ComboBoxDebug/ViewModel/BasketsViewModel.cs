using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ComboBoxDebug.Model;
using Prism.Mvvm;

namespace ComboBoxDebug.ViewModel;

public class BasketsViewModel : BindableBase
{
    public ObservableCollection<BasketViewModel> Baskets { get; }
    
    private BasketViewModel? _selectedBasket;
    public BasketViewModel? SelectedBasket
    {
        get => _selectedBasket;
        set
        {
            if (SetProperty(ref _selectedBasket, value))
            {
                //RaisePropertyChanged(nameof(Items));
                //RaisePropertyChanged(nameof(Colors));
            }
        }
    }

    public ObservableCollection<Thing> Items
    {
        get => SelectedBasket?.Items;
    }

    public Thing SelectedThing
    {
        get => _selectedBasket.SelectedThing;
        set => _selectedBasket.SelectedThing = value;
    }

    public ObservableCollection<ColorOption> Colors
    {
        get => _selectedBasket.Colors;
    }

    public ColorOption SelectedColor
    {
        get => _selectedBasket.SelectedColor;
        set => _selectedBasket.SelectedColor = value;
    }

    public BasketsViewModel()
    {
        Baskets = new ObservableCollection<BasketViewModel>
        {
            new BasketViewModel(
                new Basket("Коробка1",
                    new Thing("Мяч", "Красный", "Зелёный"),
                    new Thing("Куб", "Оранжевый", "Зелёный"))),
            new BasketViewModel(
                new Basket("Коробка2",
                    new Thing("Банан", "Жёлтый", "Зелёный"),
                    new Thing("Телефон", "Зелёный", "Жёлтый", "Синий")))
        };
            
        SelectedBasket = Baskets.FirstOrDefault();
    }
}
