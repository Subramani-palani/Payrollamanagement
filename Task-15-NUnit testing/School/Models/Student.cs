using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace School.Models;

public class Student{
    [Key]
    public int Id{get; set;} 
    
    [Required]
    public string Name{get; set;}
    
    public string? Address{get; set;} 

    public string? PhoneNumber{get; set;}  

    public string? Email{get; set;}

    public static explicit operator Student(ActionResult<Student> v)
    {
        throw new NotImplementedException();
    }
}