using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Prism_Practice.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public ViewCViewModel() { }

        private string _viewCText;

        public event Action<IDialogResult> RequestClose;

        public string ViewCText
        {
            get { return _viewCText; }
            set { SetProperty(ref _viewCText, value); }
        }

        public string Title => "View 3 Dialog";
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
