namespace CachedRepository.Data.Models
{
    using Infrastructure.Exceptions;

    public class Resource : BaseEntity
    {
        private ResourceType? resourceType;

        private Author? author;

        public string Name { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        public Author Author { 
            get => this.author ?? throw new UninitializedPropertyException(nameof(Resource), nameof(this.Author)); 
            set => this.author = value;
        }

        public int ResourceTypeId { get; set; }

        public ResourceType ResourceType
        {
            get => this.resourceType ?? throw new UninitializedPropertyException(nameof(Resource), nameof(this.ResourceType)); 
            set => this.resourceType = value;
        }
    }
}
