using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Message
    {
        public string Text { get; set; }

        public Guid? ThreadId { get; set; }

        public Guid QuoteId { get; set; }

        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public User Receiver { get; set; }

        public User Sender { get; set; }

        public Quotation Quote { get; set; }
        public bool IsSender { get; set; }
    }
}
