using Microsoft.EntityFrameworkCore;

namespace cohesionIB.Models
{
    public class ServiceRequestContext:DbContext
    {
        public ServiceRequestContext(DbContextOptions options):base(options)
        {}   

      
        
        public DbSet<ServiceRequest> ServiceRequests {get; set;}
    }
}