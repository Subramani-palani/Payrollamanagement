using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace School.Models;

public class User{
    [Key]
    public int Id{get; set;} 
    
    [Required]
    public string Name{get; set;}
    
    public string? Email{get; set;}

    public string? MobileNumber{get;set;}

    public string? Password{get; set;}

    


    
}