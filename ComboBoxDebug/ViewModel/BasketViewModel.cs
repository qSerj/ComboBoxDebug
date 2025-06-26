using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media;
using ComboBoxDebug.Model;
using ComboBoxDebug.Service;
using Prism.Mvvm;

namespace ComboBoxDebug.ViewModel;

public class BasketViewModel : BindableBase
{
    private readonly Basket _basket;
    private readonly BatchUpdateService _batchUpdateService;

    public BasketViewModel(Basket basket, BatchUpdateService batchUpdateService)
    {
        _basket = basket;
        _batchUpdateService = batchUpdateService;
        
        Items = new ObservableCollection<Thing>(basket.Things);
        Colors = new ObservableCollection<ColorOption>(_basket.SelectedThing?.Colors ?? new List<ColorOption>());
        _selectedThing = _basket.SelectedThing;
        _selectedColor = _basket.SelectedColor;
    }

    public ObservableCollection<Thing> Items { get; }
   
    private Thing? _selectedThing;
    public Thing? SelectedThing
    {
        get => _selectedThing;
        set
        {
            if (_batchUpdateService.IsBatch && value == null)
                return; // Игнорируем null от UI во время программного обновления
            if (SetProperty(ref _selectedThing, value))
            {
                using (_batchUpdateService.BeginBatch())
                {
                    Colors.Clear();
                    if (_selectedThing != null)
                    {
                        foreach (var color in _selectedThing.Colors)
                            Colors.Add(color);
                        SelectedColor = _selectedThing.Colors.FirstOrDefault();
                    }
                    else
                    {
                        SelectedColor = null;
                    }
                    _basket.SelectedThing = value; // Сохраняем в модель
                }
            }
        }
    }
    
    public ObservableCollection<ColorOption> Colors { get; }
    
    private ColorOption? _selectedColor;
    public ColorOption? SelectedColor
    {
        get => _selectedColor;
        set
        {
            if (_batchUpdateService.IsBatch && value == null)
                return; // Игнорируем null от UI
            if (SetProperty(ref _selectedColor, value))
            {
                _basket.SelectedColor = value; // Сохраняем в модель
            }
        }
    }
    
    public string Name => _basket.Name;
}