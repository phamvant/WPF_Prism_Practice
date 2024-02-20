using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Prism_Practice.Views;

namespace WPF_Prism_Practice.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private readonly IDialogService _dialogService;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;

            _dialogService = dialogService;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                var p = new NavigationParameters();

                switch (navigatePath)
                {
                    case "ViewB":
                        //p.Add("Type", "This is a button");
                        break;
                    case "ViewC":
                        _dialogService.ShowDialog(nameof(ViewC), null, null);
                        return;
                    default:
                        break;
                }

                _regionManager.RequestNavigate("ContentRegion", navigatePath, p);
            }
        }
    }
}
