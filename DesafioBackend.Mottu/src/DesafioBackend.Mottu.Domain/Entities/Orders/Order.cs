using DesafioBackend.Mottu.Entities.DeliveryPersons;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

public class Order : AuditedAggregateRoot<Guid>, IMultiTenant
{
    public DateTime CreationTime { get; private set; }
    public decimal Value { get; private set; }
    public OrderStatus Status { get; private set; }
    public Guid? DeliveryPersonId { get; private set; }
    public Guid? TenantId { get; private set; }
    public DeliveryPerson DeliveryPerson { get; private set; }

    protected Order() { }

    public Order(Guid id, decimal value, Guid? tenantId, Guid? deliveryPersonId) : base(id)
    {
        CreationTime = DateTime.Now;
        Value = value;
        Status = OrderStatus.Available;
        TenantId = tenantId;
        DeliveryPersonId = deliveryPersonId;
    }

    public void AcceptBy(DeliveryPerson deliveryPerson)
    {
        if (Status != OrderStatus.Available)
        {
            throw new BusinessException("Only available orders can be accepted.");
        }

        DeliveryPersonId = deliveryPerson.Id;
        Status = OrderStatus.Accepted;
    }

    public void Complete()
    {
        if (Status != OrderStatus.Accepted)
        {
            throw new BusinessException("Only accepted orders can be delivered.");
        }

        Status = OrderStatus.Delivered;
    }

    public void AssignToDeliveryPerson(DeliveryPerson deliveryPerson)
    {
        DeliveryPersonId = deliveryPerson.Id;
        DeliveryPerson = deliveryPerson;
    }
}