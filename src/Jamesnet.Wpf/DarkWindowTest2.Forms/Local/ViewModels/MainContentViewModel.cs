using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using Prism.Services.Dialogs;

namespace DarkWindowTest2.Forms.Local.ViewModels;

public partial class MainContentViewModel : ObservableBase
{
    private readonly IDialogService _dialogService;

    public MainContentViewModel(IDialogService dialogService)
    {
        this._dialogService = dialogService;
    }

    [RelayCommand]
    private void ShowDialog()
    {
        this._dialogService.ShowDialog ("PopupContent");
    }
}