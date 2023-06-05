using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace PrismWPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;

        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoNextCommand { get; private set; }
        public DelegateCommand<string> NavigationCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager, IRegionNavigationJournal journal)
        {
            this._regionManager = regionManager;
            this._journal = journal;
            NavigationCommand = new DelegateCommand<string>(navigation);
            GoBackCommand = new DelegateCommand(goBack);
            GoNextCommand = new DelegateCommand(goNext);

        }

        private void goNext()
        {
            if (_journal.CanGoForward)
            {
                _journal.GoForward();
            }
        }

        private void goBack()
        {
            if (_journal.CanGoBack)
            {
                _journal.GoBack();
            }
        }

        private void navigation(string obj)
        {
            _regionManager.Regions["IndexViewRegion"].RequestNavigate(obj, callback =>
            {
                if (callback.Result!=null&&(bool)callback.Result)
                {
                    _journal = callback.Context.NavigationService.Journal;
                }
            });
            Console.WriteLine(obj);
        }
    }
}
