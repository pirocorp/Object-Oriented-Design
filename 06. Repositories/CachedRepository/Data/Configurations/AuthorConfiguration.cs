namespace CachedRepository.Data.Configurations
{
    using CachedRepository.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author.HasKey(a => a.Id);

            author
                .Property(a => a.Name)
                .IsRequired();
        }
    }
}
