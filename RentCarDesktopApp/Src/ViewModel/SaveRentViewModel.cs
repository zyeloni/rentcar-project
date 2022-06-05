using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class SaveRentViewModel : ObservableObject
{
    private RentService _rentService;
    private ContractorService _contractorService;
    private CarService _carService;
    private Task Initialize;

    private IEnumerable<Car> _cars;
    private IEnumerable<Contractor> _contractors;
    private Car _selectedCar;
    private Contractor _selectedContractor;
    private DateTime _dateStart;
    private DateTime _dateEnd;
    
    public RelayCommand SaveCommand { get; set; }
    public Task SaveTask { get; set; }

    public DateTime DateStart
    {
        get { return _dateStart; }
        set
        {
            _dateStart = value;
            OnPropertyChanged(nameof(DateStart));
        }
    }

    public DateTime DateEnd
    {
        get { return _dateEnd; }
        set
        {
            _dateEnd = value;
            OnPropertyChanged(nameof(DateEnd));
        }
    }

    public IEnumerable<Car> Cars
    {
        get { return _cars; }
        set
        {
            _cars = value;
            OnPropertyChanged(nameof(Cars));
        }
    }

    public IEnumerable<Contractor> Contractors
    {
        get { return _contractors; }
        set
        {
            _contractors = value;
            OnPropertyChanged(nameof(Contractors));
        }
    }

    public Car SelectedCar
    {
        get { return _selectedCar; }
        set
        {
            _selectedCar = value;
            OnPropertyChanged(nameof(SelectedCar));
        }
    }

    public Contractor SelectedContractor
    {
        get { return _selectedContractor; }
        set
        {
            _selectedContractor = value;
            OnPropertyChanged(nameof(SelectedContractor));
        }
    }

    private SaveType _saveType;
    private int Id;

    public SaveRentViewModel()
    {
        _rentService = new RentService();
        _contractorService = new ContractorService();
        _carService = new CarService();
        
        SaveCommand = new RelayCommand(o => { SaveTask = SaveRent(); });
    }

    private async Task SaveRent()
    {
        Rent modelToSave = new Rent()
        {
            Car = SelectedCar,
            Contractor = SelectedContractor,
            DateEnd = DateEnd,
            DateStart = DateStart
        };
        
        if (_saveType == SaveType.Add)
        {
            await _rentService.Add(modelToSave);
        }
        else
        {
            modelToSave.Id = Id;
            await _rentService.Edit(modelToSave);
        }

        foreach (Window item in Application.Current.Windows)
        {
            if (item.DataContext == this) item.Close();
        }
    }

    private async Task LoadAllData()
    {
        Cars = await _carService.GetAll();
        Contractors = await _contractorService.GetAll();
    }

    public void Init(Rent model)
    {
        Initialize = LoadAllData();
        Id = model.Id;
        DateStart = model.DateStart.Year != 1 ? model.DateStart : DateTime.Now;
        DateEnd = model.DateEnd.Year != 1 ? model.DateEnd : DateTime.Now.AddDays(1);

        Task continuTask = Initialize.ContinueWith(t =>
        {
            if (model.Car != null)
            {
                SelectedCar = Cars.Where(x => x.Id == model.Car.Id).FirstOrDefault();
            }
            else
            {
                SelectedCar = Cars.First();
            }

            if (model.Contractor != null)
            {
                SelectedContractor = Contractors.Where(x => x.Id == model.Contractor.Id).FirstOrDefault();
            }
            else
            {
                SelectedContractor = Contractors.First();
            }
        });

        if (model.Id == 0)
        {
            _saveType = SaveType.Add;
            return;
        }

        _saveType = SaveType.Update;
    }
}