namespace CachedRepository.Data.Models
{
    using System.Collections.Generic;

    public class ResourceType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int SortOrder { get; set; }

        public List<Resource> Resources { get; set; } = new ();
    }
}
