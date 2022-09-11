
using BankForm.Models;
using Microsoft.EntityFrameworkCore;

namespace BankForm.DataAccess;

public class ApplicationDbContext:DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
    {

    }

    public DbSet<Template>  Templates { get; set; }
    public DbSet<Section> Sections { get; set; }

}
