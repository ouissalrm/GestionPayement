using Microsoft.EntityFrameworkCore;

namespace GestionPayment.Models
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}
