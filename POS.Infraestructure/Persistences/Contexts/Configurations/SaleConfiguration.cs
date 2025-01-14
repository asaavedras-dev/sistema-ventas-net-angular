﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Contexts.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Sales__ClientId__6C190EBB");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales__UserId__6D0D32F4");
        }
    }
}
