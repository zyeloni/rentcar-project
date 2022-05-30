using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel
{
    public class SaveCarViewModel : ObservableObject
    {
        private CarService _carService;
        private SaveType _saveType;
        private int Id;
        private String _brand;
        private String _model;
        private String _year;

        public RelayCommand SaveCommand { get; set; }
        public Task SaveTask { get; set; }

        public SaveCarViewModel()
        {
            _carService = new CarService();
            SaveCommand = new RelayCommand(o => { SaveTask = SaveCar(); });
        }

        private async Task SaveCar()
        {
            Car modelToSave = new Car()
            {
                Brand = Brand,
                Model = Model,
                Year = new DateTime(Int32.Parse(Year), 1, 1)
            };

            if (_saveType == SaveType.Add)
            {
                await _carService.Add(modelToSave);
            }
            else
            {
                modelToSave.Id = Id;
                await _carService.Edit(modelToSave);
            }

            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }

        public String Brand
        {
            get { return _brand; }
            set
            {
                _brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public String Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public String Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public void Init(Car model)
        {
            Id = model.Id;
            Brand = model.Brand;
            Model = model.Model;
            Year = model.Year.Year.ToString();

            if (model.Id == 0)
            {
                _saveType = SaveType.Add;
                return;
            }

            _saveType = SaveType.Update;
        }
    }
}