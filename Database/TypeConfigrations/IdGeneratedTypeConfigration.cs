using System;
using idgenapi.IdGeneratedFeature;
using Microsoft.EntityFrameworkCore;

namespace idgenapi.Database.TypeConfigrations;

public class IdGeneratedTypeConfigration : IEntityTypeConfiguration<IdGenerated>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdGenerated> builder)
    {
        builder.ToTable("idsgenerated");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ServerIp)
            .IsRequired()
            .HasMaxLength(18)
            .HasColumnName("serverip");
        builder.Property(x => x.ServerName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("servername");
        builder.Property(x => x.UlidString)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("ulidstring");
        builder.Property(x => x.UUIDString)
            .IsRequired()
            .HasMaxLength(36)
            .HasColumnName("uuidstring");
        builder.Property(x => x.CreatedOn)
            .IsRequired()
            .HasColumnName("createdon");
    }
}
