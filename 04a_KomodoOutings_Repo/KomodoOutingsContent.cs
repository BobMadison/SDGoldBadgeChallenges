using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04a_KomodoOutings_Repo
{
    public class KomodoOutingsContent
    {
        public EventType OutingEvent { get; set; }
        public int NumberAttending { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCostForEvent { get; set; }

        public KomodoOutingsContent() { }
      
        public KomodoOutingsContent(
            EventType outingEvent,
            int numberAttending,
            DateTime dateOfEvent,
            decimal costPerPerson) 
        { 
            OutingEvent = outingEvent;
            NumberAttending = numberAttending;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            TotalCostForEvent = numberAttending * costPerPerson;
        }
    }

    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
}
