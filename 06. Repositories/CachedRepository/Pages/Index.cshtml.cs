namespace CachedRepository.Pages
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Data;
    using Data.Models;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly IReadOnlyRepository<Author> authorRepository;

        public IndexModel(IReadOnlyRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public List<Author> Authors { get; set; } = new();

        public long ElapsedTimeMilliseconds { get; set; }

        public async Task OnGet()
        {
            var timer = Stopwatch.StartNew();
            Authors = (await authorRepository.List()).ToList();
            timer.Stop();
            ElapsedTimeMilliseconds = timer.ElapsedMilliseconds;
        }
    }
}
