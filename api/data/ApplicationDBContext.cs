using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDBContext : DbContext
    {
        #region Constructors
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion

        #region DB Sets
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }
        #endregion


    }
}