using System.ComponentModel.Design;
using DataAccess.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace DataAccess
 {
     public class RonSwansonContext : DbContext
     {
         public RonSwansonContext(DbContextOptions<RonSwansonContext> options): base(options)
         { }
         
         public virtual DbSet<RonSwansonQuote> RonSwansonQuotes { get; set; }
     }
 }