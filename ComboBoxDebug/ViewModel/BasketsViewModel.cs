using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ComboBoxDebug.Model;
using Prism.Mvvm;

namespace ComboBoxDebug.ViewModel;

public class BasketsViewModel : BindableBase
{
    public ObservableCollection<Basket> Baskets { get; }
    private Basket? _selectedBasket;
    public Basket? SelectedBasket
    {
        get => _selectedBasket;
        set
        {
            if (SetProperty(ref _selectedBasket, value))
            {
                RaisePropertyChanged(nameof(Items));
                SelectedItem = _selectedBasket?.SelectedItem ?? Items.FirstOrDefault();
            }
        }
    }

    public ObservableCollection<Item> Items => new(SelectedBasket?.Items ?? new List<Item>());

    private Item? _selectedItem;
    public Item? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetProperty(ref _selectedItem, value))
            {
                if (SelectedBasket != null)
                {
                    SelectedBasket.SelectedItem = value;
                    RaisePropertyChanged(nameof(Colors));
                    SelectedColor = value?.Colors.FirstOrDefault();
                }
            }
        }
    }

    public ObservableCollection<ColorOption> Colors => new(SelectedItem?.Colors ?? new List<ColorOption>());

    private ColorOption? _selectedColor;
    public ColorOption? SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (SetProperty(ref _selectedColor, value))
            {
                if (SelectedBasket != null)
                    SelectedBasket.SelectedColor = value;
            }
        }
    }

    public BasketsViewModel()
    {
        Baskets = new ObservableCollection<Basket>
        {
            new Basket("Корзина 1",
                new Item("Яблоко", "Красный", "Зелёный"),
                new Item("Апельсин", "Оранжевый", "Зелёный")),
            new Basket("Корзина 2",
                new Item("Банан", "Жёлтый", "Зелёный"),
                new Item("Груша", "Зелёный", "Жёлтый"))
        };
        SelectedBasket = Baskets.FirstOrDefault();
        SelectedItem = SelectedBasket?.SelectedItem ?? Items.FirstOrDefault();
        SelectedColor = SelectedItem?.Colors.FirstOrDefault();
    }
}
