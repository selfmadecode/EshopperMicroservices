using System;

namespace EventBus.Message.Events
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public IntegrationBaseEvent()
        {
            Id = new Guid();
            CreatedOn = DateTime.Now;
        }

        public IntegrationBaseEvent(Guid id, DateTime createdOn)
        {
            Id = id;
            CreatedOn = createdOn;
        }
    }
}
