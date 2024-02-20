using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Prism_Practice.Event;

namespace WPF_Prism_Practice.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        public ViewBViewModel(IEventAggregator eventAggregator) 
        {
            eventAggregator.GetEvent<UpdateEvent>().Subscribe(Updated);
        }

        private void Updated(string obj)
        {
            ButtonContent = obj;
        }

        private string _buttonContent;

        public string ButtonContent
        {
            get { return _buttonContent; }
            set { SetProperty(ref _buttonContent, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //ButtonContent = navigationContext.Parameters.GetValue<string>(nameof(ButtonContent));
        }
    }
}
