using HamzaAssignment.Model;
using Microsoft.EntityFrameworkCore;
using static HamzaAssignment.DataBContext;

namespace HamzaAssignment
{
    public class DataBContext : DbContext
    {
        public DataBContext(DbContextOptions<DataBContext> options)
            : base(options)
        {
        }

        public DbSet<Bill_Model> bills { get; set; }
    }
}
