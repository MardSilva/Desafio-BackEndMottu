namespace DesafioBackend.Mottu.Permissions;

public static class MottuPermissions
{
    public const string GroupName = "Mottu";

    public static class Motorcycle
    {
        public const string Default = GroupName + ".Motorcycle";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class DeliveryPerson
    {
        public const string Default = GroupName + ".DeliveryPerson";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string UpdateCnhImage = Default + ".UpdateCnhImage";
    }

    public static class MotorcycleRental
    {
        public const string Default = GroupName + ".MotorcycleRental";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string CompleteRental = Default + ".CompleteRental";
    }

    public static class Orders
    {
        public const string Default = GroupName + ".Orders";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}