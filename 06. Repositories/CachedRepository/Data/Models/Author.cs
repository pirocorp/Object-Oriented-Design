namespace CachedRepository.Data.Models
{
    using System.Collections.Generic;

    public class Author : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public List<Resource> Resources { get; set; } = new ();
    }
}
