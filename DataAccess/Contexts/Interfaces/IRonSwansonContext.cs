using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace DataAccess.Contexts.Interfaces
{
    public interface IRonSwansonContext<TContextType>
        where TContextType : DbContext 
    {
        DbSet<RonSwansonQuote> RonSwansonQuotes { get; set; }
    }
}