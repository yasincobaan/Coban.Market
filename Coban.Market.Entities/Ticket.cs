using System;
using Coban.Market.Entities.Enums;

namespace Coban.Market.Entities
{
    public class Ticket : MyEntityBase
    {
        public int CurrentSession { get; set; }
        public int TicketSubject { get; set; }
        public DateTime NotificationTime { get; set; }
        public TicketTypes TicketType { get; set; }
        public Priority Priority { get; set; }
        public TicketStatus Status { get; set; }

        public string Problem { get; set; }
        public string Solution { get; set; }
    }
}
