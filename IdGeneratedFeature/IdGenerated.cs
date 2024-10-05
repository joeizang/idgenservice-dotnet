using System;
using System.ComponentModel.DataAnnotations;

namespace idgenapi.IdGeneratedFeature;

public sealed class IdGenerated
{
    public Guid Id { get; private set; }

    [MinLength(5)]
    public string ServerName { get; private set; }

    public string ServerIp { get; private set; }

    public string UlidString { get; private set; }

    public string UUIDString { get; private set; }

    public DateTime CreatedOn { get; private set; } = DateTime.Today.ToLocalTime();

    public IdGenerated(string serverName, string serverIp, string ulidString, string uuidString)
    {
        Id = Ulid.NewUlid().ToGuid();
        ServerName = serverName;
        ServerIp = serverIp;
        UlidString = ulidString;
        UUIDString = uuidString;
    }

    private IdGenerated() {}
}

public static class IdExtensions
{
    public static IdCreatedDto MapToDto(this IdGenerated idGenerated)
    {
        return new IdCreatedDto(idGenerated.Id, idGenerated.ServerName, idGenerated.ServerIp, idGenerated.UlidString, idGenerated.UUIDString, idGenerated.CreatedOn);
    }
}

public record IdCreatedDto(Guid Id, string ServerName, string ServerIp, string UlidString, string UUIDString, DateTime CreatedOn);

public record IdCreateDto(string ServerName, string ServerIp);
