using System;
using Volo.Abp.EventBus;

namespace DesafioBackend.Mottu.Events
{
    [Serializable]
    [EventName("DesafioBackend.Mottu.OrderAvailable")]
    public class OrderAvailableEvent
    {
        public Guid OrderId { get; set; }
        public decimal Value { get; set; }
        public DateTime CreationTime { get; set; }

        public OrderAvailableEvent(Guid orderId, decimal value, DateTime creationTime)
        {
            OrderId = orderId;
            Value = value;
            CreationTime = creationTime;
        }
    }
}