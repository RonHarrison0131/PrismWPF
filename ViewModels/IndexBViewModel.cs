using Prism.Events;
using PrismWPF.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrismWPF.ViewModels
{
    public class IndexBViewModel
    {
        private readonly IEventAggregator _aggregator;
        public IndexBViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            _aggregator.GetEvent<MessageEvent>().Subscribe(ShowMessage);
        }

        private void ShowMessage(MessageEvent.MessageModel model)
        {
            HandyControl.Controls.MessageBox.Show($"Hello {model.result}!");
        }
    }
}
