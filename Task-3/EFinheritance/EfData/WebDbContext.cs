using EFinheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace EFinheritance.Efdata;
public class WebDbContext :DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options):base(options){

        } 
        public DbSet<User> Userdata{get;set;}
        public DbSet<Admin> Admins{get;set;}
        public DbSet<RegularUser> Users{get;set;}

    

}