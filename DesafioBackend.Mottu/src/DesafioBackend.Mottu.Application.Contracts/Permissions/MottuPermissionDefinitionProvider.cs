using DesafioBackend.Mottu.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DesafioBackend.Mottu.Permissions;

public class MottuPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var mottuGroup = context.AddGroup(MottuPermissions.GroupName, L("Permission:Mottu"));

        var motorcyclePermission = mottuGroup.AddPermission(MottuPermissions.Motorcycle.Default, L("Permission:Motorcycle"));
        motorcyclePermission.AddChild(MottuPermissions.Motorcycle.Create, L("Permission:Motorcycle.Create"));
        motorcyclePermission.AddChild(MottuPermissions.Motorcycle.Update, L("Permission:Motorcycle.Update"));
        motorcyclePermission.AddChild(MottuPermissions.Motorcycle.Delete, L("Permission:Motorcycle.Delete"));

        var deliveryPersonPermission = mottuGroup.AddPermission(MottuPermissions.DeliveryPerson.Default, L("Permission:DeliveryPerson"));
        deliveryPersonPermission.AddChild(MottuPermissions.DeliveryPerson.Create, L("Permission:DeliveryPerson.Create"));
        deliveryPersonPermission.AddChild(MottuPermissions.DeliveryPerson.Update, L("Permission:DeliveryPerson.Update"));
        deliveryPersonPermission.AddChild(MottuPermissions.DeliveryPerson.Delete, L("Permission:DeliveryPerson.Delete"));
        deliveryPersonPermission.AddChild(MottuPermissions.DeliveryPerson.UpdateCnhImage, L("Permission:DeliveryPerson.UpdateCnhImage"));

        var motorcycleRentalPermission = mottuGroup.AddPermission(MottuPermissions.MotorcycleRental.Default, L("Permission:MotorcycleRental"));
        motorcycleRentalPermission.AddChild(MottuPermissions.MotorcycleRental.Create, L("Permission:MotorcycleRental.Create"));
        motorcycleRentalPermission.AddChild(MottuPermissions.MotorcycleRental.Update, L("Permission:MotorcycleRental.Update"));
        motorcycleRentalPermission.AddChild(MottuPermissions.MotorcycleRental.Delete, L("Permission:MotorcycleRental.Delete"));
        motorcycleRentalPermission.AddChild(MottuPermissions.MotorcycleRental.CompleteRental, L("Permission:MotorcycleRental.CompleteRental"));

        var ordersPermission = mottuGroup.AddPermission(MottuPermissions.Orders.Default, L("Permission:Orders"));
        ordersPermission.AddChild(MottuPermissions.Orders.Create, L("Permission:Orders.Create"));
        ordersPermission.AddChild(MottuPermissions.Orders.Update, L("Permission:Orders.Update"));
        ordersPermission.AddChild(MottuPermissions.Orders.Delete, L("Permission:Orders.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MottuResource>(name);
    }
}