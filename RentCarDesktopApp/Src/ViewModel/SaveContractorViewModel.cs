using System;
using System.Threading.Tasks;
using System.Windows;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class SaveContractorViewModel : ObservableObject
{
    private ContractorService _contractorService;
    private SaveType _saveType;
    private int Id;
    private String _fristName;
    private String _surName;

    public RelayCommand SaveCommand { get; set; }
    public Task SaveTask { get; set; }

    public SaveContractorViewModel()
    {
        _contractorService = new ContractorService();
        SaveCommand = new RelayCommand(o => { SaveTask = SaveContractor(); });
    }

    private async Task SaveContractor()
    {
        Contractor modelToSave = new Contractor()
        {
            FirstName = FristName,
            SurName = SurName,
        };

        if (_saveType == SaveType.Add)
        {
            await _contractorService.Add(modelToSave);
        }
        else
        {
            modelToSave.Id = Id;
            await _contractorService.Edit(modelToSave);
        }

        foreach (Window item in Application.Current.Windows)
        {
            if (item.DataContext == this) item.Close();
        }
    }

    public String FristName
    {
        get { return _fristName; }
        set
        {
            _fristName = value;
            OnPropertyChanged(nameof(FristName));
        }
    }

    public String SurName
    {
        get { return _surName; }
        set
        {
            _surName = value;
            OnPropertyChanged(nameof(SurName));
        }
    }

    public void Init(Contractor model)
    {
        Id = model.Id;
        FristName = model.FirstName;
        SurName = model.SurName;

        if (model.Id == 0)
        {
            _saveType = SaveType.Add;
            return;
        }

        _saveType = SaveType.Update;
    }
}