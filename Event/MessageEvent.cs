using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrismWPF.Event.MessageEvent;

namespace PrismWPF.Event
{
    public class MessageEvent : PubSubEvent<MessageModel>
    {
        public class MessageModel
        {
            public int code { get; set; }
            public string message { get; set; }
            public object result { get; set; }
        }
    }
}
