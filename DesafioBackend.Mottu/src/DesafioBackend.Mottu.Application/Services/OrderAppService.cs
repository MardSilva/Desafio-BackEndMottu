using DesafioBackend.Mottu.DTO.Orders;
using DesafioBackend.Mottu.Entities.DeliveryPersons;
using DesafioBackend.Mottu.Events;
using DesafioBackend.Mottu.Interface;
using DesafioBackend.Mottu.Permissions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

public class OrderAppService : CrudAppService<Order, OrderDto, Guid, 
                               PagedAndSortedResultRequestDto, CreateOrderDto, OrderDto>, IOrderAppService
{
    private readonly IEventBus _eventBus;
    private readonly IRepository<DeliveryPerson, Guid> _deliveryPersonRepository;

    public OrderAppService(IRepository<Order, Guid> repository, IEventBus eventBus, 
                           IRepository<DeliveryPerson, Guid> deliveryPersonRepository) : base(repository)
    {
        _eventBus = eventBus;
        _deliveryPersonRepository = deliveryPersonRepository;

        GetPolicyName = MottuPermissions.Orders.Default;
        GetListPolicyName = MottuPermissions.Orders.Default;
        CreatePolicyName = MottuPermissions.Orders.Create;
        UpdatePolicyName = MottuPermissions.Orders.Update;
        DeletePolicyName = MottuPermissions.Orders.Delete;
    }

    public async Task NotifyDeliveryPersonsAsync(Guid orderId, decimal value, DateTime creationTime)
    {
        // Lógica para obter detalhes do pedido, se necessário
        var orderNotificationEvent = new OrderAvailableEvent(orderId, value, creationTime);

        await _eventBus.PublishAsync(orderNotificationEvent);
    }

    public async Task AcceptOrderAsync(Guid orderId, Guid deliveryPersonId)
    {
        var order = await Repository.GetAsync(orderId);

        if (order.Status != OrderStatus.Available)
        {
            throw new BusinessException(L["Error:OrderDeliveryAccept"]);
        }

        var deliveryPerson = await _deliveryPersonRepository.GetAsync(deliveryPersonId);

        //check if the delivery person can accept the order
        if (!deliveryPersonCanAcceptOrder(deliveryPerson))
        {
            throw new BusinessException(L["Error:OrderDeliveryCannotAcceptAtMoment"]);
        }

        // logic to assign the order to the delivery person
        order.AssignToDeliveryPerson(deliveryPerson);
        order.AcceptBy(deliveryPerson);

        await Repository.UpdateAsync(order);
    }

    public async Task CompleteOrderAsync(Guid orderId)
    {
        var order = await Repository.GetAsync(orderId);

        if (order.Status != OrderStatus.Accepted)
        {
            throw new BusinessException(L["Error:OrderDeliveryComplete"]);
        }

        order.Complete();

        await Repository.UpdateAsync(order);
    }

    private bool deliveryPersonCanAcceptOrder(DeliveryPerson deliveryPerson)
    {
        // check if the delivery person has a valid license
        bool hasValidLicense = deliveryPerson.CnhType == "A";

        // check if the delivery person has no accepted orders
        var hasNoAcceptedOrders = !deliveryPerson.Orders.Any(order => order.Status == OrderStatus.Accepted);

        return hasValidLicense && hasNoAcceptedOrders;
    }
}