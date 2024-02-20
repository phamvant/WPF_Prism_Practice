using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Prism_Practice.Event;

namespace WPF_Prism_Practice.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _firstname = "test";

        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        private string _lastname;

        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }

        private DateTime _lastUpdated;

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                SetProperty(ref _lastUpdated, value);
            }
        }

        private IEventAggregator _eventAggregator { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
        }

        private bool CanExecute()
        {
            return !String.IsNullOrEmpty(LastName) && !String.IsNullOrEmpty(LastName);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
            _eventAggregator.GetEvent<UpdateEvent>().Publish(LastUpdated.ToString());
        }
    }
}
