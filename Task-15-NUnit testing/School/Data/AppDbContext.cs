using Microsoft.EntityFrameworkCore;
using School.Models;
namespace School.Data;

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

    public DbSet<Student> StudentDetails{get; set;} 
    public DbSet<User> UserInfo{get; set;}
}