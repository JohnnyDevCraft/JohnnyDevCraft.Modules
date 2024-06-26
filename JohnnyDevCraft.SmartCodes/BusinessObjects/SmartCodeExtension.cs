using Microsoft.EntityFrameworkCore;

namespace JohnnyDevCraft.SmartCodes.BusinessObjects;

public static class ModelExtensions
{
    public static ModelBuilder AddSmartCodesModel(this ModelBuilder mb)
    {

        mb.Entity<SmartType>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity.HasMany(e => e.SmartCodes)
                .WithOne()
                .HasForeignKey(e => e.SmartTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasIndex(e => e.Name).IsUnique();
        });

        mb.Entity<SmartCode>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.HasIndex(sc => new {sc.Code, sc.SmartTypeId}).IsUnique();    
        });
        return mb;
    }
}
