namespace CachedRepository.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ResourceTypeConfiguration : IEntityTypeConfiguration<ResourceType>
    {
        public void Configure(EntityTypeBuilder<ResourceType> resourceType)
        {
            resourceType.HasKey(r => r.Id);

            resourceType
                .Property(r => r.Name)
                .IsRequired();
        }
    }
}
