namespace CachedRepository.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CachedRepository.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class DataSeeder : ISeeder
    {
        private const int MaxAuthors = 1000;
        private const int MaxResourcesPerAuthor = 10;

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!await dbContext.ResourceTypes.AnyAsync())
            {
                var resourceTypes = GetResourceTypes();

                await dbContext.ResourceTypes.AddRangeAsync(resourceTypes);
                await dbContext.SaveChangesAsync();
            }

            IEnumerable<Author> authors = new List<Author>();

            if (!await dbContext.Authors.AnyAsync())
            {
                authors = GetAuthors().ToList();

                await dbContext.Authors.AddRangeAsync(authors);
                await dbContext.SaveChangesAsync();
            }

            if (!await dbContext.Resources.AnyAsync())
            {
                var resources = GetResources(authors);

                await dbContext.Resources.AddRangeAsync(resources);
                await dbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<ResourceType> GetResourceTypes()
        {
            return new List<ResourceType>
            {
                new() { Name = "Book" },
                new() { Name = "Magazine Article" },
                new() { Name = "Online Course" },
                new() { Name = "Podcast Episode" }
            };
        }

        private static IEnumerable<Author> GetAuthors()
        {
            var list = new List<Author>
            {
                new()
                {
                    Name = "Zdravko Zdravkov"
                }
            };

            for (var i = 0; i < MaxAuthors; i++)
            {
                list.Add(new Author
                {
                    Name = $"Another Author + {i}"
                });
            }

            return list;
        }

        private static IEnumerable<Resource> GetResources(IEnumerable<Author> authors)
        {
            var list = new List<Resource>()
            {
                new()
                {
                    ResourceTypeId = 1,
                    AuthorId = 1, 
                    Name = "ASP.NET By Example", 
                    Url = "https://www.amazon.com/ASP-NET-Example-Steven-Smith/dp/0789725622", 
                    Description = "ASP developers need to understand how ASP.NET can help them solve business problems better than any prior product. ASP.NET by Example is designed to provide a 'crash course' on ASP.NET and quickly help the reader start using this new technology."
                },
                new()
                {
                    ResourceTypeId = 2, 
                    AuthorId = 1, 
                    Name = "What's New in ASP.NET Core 2.1", 
                    Url = "https://msdn.microsoft.com/en-us/magazine/mt829706.aspx", 
                    Description = "Microsoft recently released ASP.NET Core 2.1 along with .NET Core 2.1 and Entity Framework (EF) Core 2.1. Combined, these releases offer some great improvements in performance, as well as additional features for .NET Core developers. Microsoft is also offering Long-Term Support (LTS) with this release, meaning it will remain supported for three years. This article provides an overview of the improvements in ASP.NET Core 2.1."
                },
                new()
                {
                    ResourceTypeId = 3, 
                    AuthorId = 1, 
                    Name = "SOLID Principles of Object-Oriented Design", 
                    Url = "https://www.pluralsight.com/courses/principles-oo-design", 
                    Description = "The SOLID principles are fundamental to designing effective, maintainable, object-oriented systems. Whether you've only just begun writing software or have been doing so for years, these principles, when used appropriately, can improve the encapsulation and coupling of your application, making it more malleable and testable in the face of changing requirements."
                }
            };

            foreach (var author in authors)
            {
                for (var i = 0; i < MaxResourcesPerAuthor; i++)
                {
                    list.Add(new Resource
                    {
                        ResourceTypeId = i % 4 + 1, 
                        AuthorId = author.Id, 
                        Name = "Random Resource", 
                        Url = "https://pirocorp.com", 
                        Description = "Description would go here."
                    });
                }

            }

            return list;
        }
    }
}
