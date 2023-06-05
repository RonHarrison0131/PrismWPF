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
    public class IndexAViewModel
    {
        private readonly IEventAggregator _aggregator;
        public IndexAViewModel(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            _aggregator.GetEvent<MessageEvent>().Subscribe(ShowMessage);
        }

        private void ShowMessage(MessageEvent.MessageModel model)
        {
            MessageBox.Show($"Hello {model.result}!");
        }
    }
}
