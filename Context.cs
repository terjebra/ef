using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }
    }
}
