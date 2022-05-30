using System.Collections.Generic;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;

namespace RentCarDesktopApp.Src.ViewModel;

public class ContractorsViewModel : ObservableObject
{
    private ContractorService _contractorService;
    public Task Initialization { get; private set; }
    public Task DeleteContractorTask { get; private set; }

    private IEnumerable<Contractor> _contractors;
    private Contractor _selectedContractor;
    
    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }

    public IEnumerable<Contractor> Contractors
    {
        get { return _contractors; }
        set
        {
            _contractors = value;
            OnPropertyChanged(nameof(Contractors));
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
    
    public ContractorsViewModel()
    {
        _contractorService = new ContractorService();
        Initialization = LoadContractors();
        
        DeleteCommand = new RelayCommand(ob => { DeleteContractorTask = DeleteContractor(); }, IsSelected);
        AddCommand = new RelayCommand(ob => { ShowAddModal(); });
        EditCommand = new RelayCommand(ob => { ShowEditModal(); }, IsSelected);
    }

    private async Task LoadContractors()
    {
        Contractors = await _contractorService.GetAll();
        OnPropertyChanged(nameof(Contractors));
    }

    private bool IsSelected(object contractor)
    {
        return SelectedContractor != null;
    }

    private void ShowEditModal()
    {
        throw new System.NotImplementedException();
    }

    private void ShowAddModal()
    {
        throw new System.NotImplementedException();
    }

    private async Task DeleteContractor()
    {
        await _contractorService.Delete(SelectedContractor);
        await LoadContractors();
        OnPropertyChanged(nameof(Contractors));
        SelectedContractor = null;
    }
}