﻿namespace MyAutoTrack.Modules.Users.Domain.Users;

public sealed class Permission
{
    public static readonly Permission GetUser = new("users:read");
    public static readonly Permission ModifyUser = new("users:update");
    // // Aqui: Adicionar mais permissions a cada modulo

    public Permission(string code)
    {
        Code = code;
    }

    public string Code { get; }
}
