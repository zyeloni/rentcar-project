using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using RentCarDesktopApp.Core;
using RentCarDesktopApp.Model;
using RentCarDesktopApp.Services;
using RentCarDesktopApp.Windows;

namespace RentCarDesktopApp.Src.ViewModel;

public class ContractorsViewModel : ObservableObject, IViewModel
{
    private ContractorService _contractorService;
    public Task Initialization { get; private set; }
    public Task DeleteContractorTask { get; private set; }

    private IEnumerable<Contractor> _contractors;
    private Contractor _selectedContractor;
    
    public RelayCommand DeleteCommand { get; set; }
    public RelayCommand AddCommand { get; set; }
    public RelayCommand EditCommand { get; set; }

    public IEnumerable<Contractor> Items
    {
        get { return _contractors; }
        set
        {
            _contractors = value;
            OnPropertyChanged(nameof(Items));
        }
    }
    
    private IEnumerable<Contractor> AllData { get; set; }
    
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
        Items = await _contractorService.GetAll();
        AllData = Items;
    }

    private bool IsSelected(object contractor)
    {
        return SelectedContractor != null;
    }

    private void ShowEditModal()
    {
        SaveContractorWindow save = new SaveContractorWindow();
        save.Init(SelectedContractor);
        save.Show();
        save.Closed += OnSaveClose;
    }

    private void ShowAddModal()
    {
        SaveContractorWindow save = new SaveContractorWindow();
        save.Init();
        save.Show();
        save.Closing += OnSaveClose;

    }

    private void OnSaveClose(object? sender, EventArgs e)
    {
        Initialization = LoadContractors();
    }

    private async Task DeleteContractor()
    {
        await _contractorService.Delete(SelectedContractor);
        await LoadContractors();
        SelectedContractor = null;
    }

    public void Search(string query)
    {
        if (query.Equals(String.Empty))
            Items = AllData;

        Items = (Items as List<Contractor>).Where(x => x.FirstName.Contains(query) || x.SurName.Contains(query)).ToList();
    }

    public void ResetSearch()
    {
        Items = AllData;
    }
}