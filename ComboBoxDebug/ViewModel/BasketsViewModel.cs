using System.Collections.ObjectModel;
using System.Linq;
using ComboBoxDebug.Model;
using ComboBoxDebug.Service;
using Prism.Mvvm;

namespace ComboBoxDebug.ViewModel;

public class BasketsViewModel : BindableBase
{
    private readonly BatchUpdateService _batchUpdateService = new();
    
    public ObservableCollection<BasketViewModel> Baskets { get; }
    
    private BasketViewModel? _selectedBasket;
    public BasketViewModel? SelectedBasket
    {
        get => _selectedBasket;
        set
        {
            using (_batchUpdateService.BeginBatch()) // Подавляем события UI
            {
                if (SetProperty(ref _selectedBasket, value))
                {
                }
            }
        }
    }

    public BasketsViewModel()
    {
        Baskets = new ObservableCollection<BasketViewModel>
        {
            new BasketViewModel(
                new Basket("Коробка1",
                    new Thing("Мяч", "Красный", "Зелёный"),
                    new Thing("Куб", "Оранжевый", "Зелёный")),
                _batchUpdateService),
            new BasketViewModel(
                new Basket("Коробка2",
                    new Thing("Банан", "Жёлтый", "Зелёный"),
                    new Thing("Телефон", "Зелёный", "Жёлтый", "Синий")),
                _batchUpdateService)
        };
            
        SelectedBasket = Baskets.FirstOrDefault();
    }
}