using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;

namespace RentCarDesktopApp.Src.ViewModel
{
    public class SaveCarViewModel : ObservableObject
    {
        private SaveType _saveType;
        private int Id;
        private String _brand;
        private String _model;
        private DateTime _year;

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

        public DateTime Year
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
            Year = model.Year;

            if (model.Id == 0)
            {
                _saveType = SaveType.Add;
                return;
            }

            _saveType = SaveType.Update;
        }
    }
}
