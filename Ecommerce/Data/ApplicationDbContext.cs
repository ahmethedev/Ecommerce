using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
	public class ApplicationDbContext : DbContext

	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
			
		
		}
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                
                new Category {CategoryId = 1, Name = "Tech", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Dress", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Book", DisplayOrder = 3 }

                );
        }

    }
}
