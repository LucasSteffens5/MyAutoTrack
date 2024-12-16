namespace MyAutoTrack.Modules.Users.Domain.Users;

public sealed class Permission
{
    public static readonly Permission GetUser = new("users:read");
    public static readonly Permission ModifyUser = new("users:update");
    public static readonly Permission ModifyVehicles = new("vehicles:update");
    public static readonly Permission GetVehicles = new("vehicles:read");
    public static readonly Permission GetMaintenance = new("maintenance:read");
    public static readonly Permission ModifyMaintenance = new("maintenance:update");
    // TODO: Aqui: Adicionar mais permissions a cada modulo

    public Permission(string code)
    {
        Code = code;
    }

    public string Code { get; }
}
