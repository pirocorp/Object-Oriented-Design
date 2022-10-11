namespace CachedRepository.Data.Configurations
{
    using CachedRepository.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource.HasKey(r => r.Id);

            resource
                .Property(r => r.Name)
                .IsRequired();

            resource
                .Property(r => r.Url)
                .IsRequired();

            resource
                .Property(r => r.Description)
                .IsRequired();

            resource
                .HasOne(r => r.Author)
                .WithMany(a => a.Resources)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            resource
                .HasOne(r => r.ResourceType)
                .WithMany(rt => rt.Resources)
                .HasForeignKey(r => r.ResourceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
