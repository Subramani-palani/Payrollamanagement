using System.ComponentModel.DataAnnotations;

namespace EFinheritance.Models;

public class User {
    public string? Name{get;set;}
    [Key]
    public string? EmployeeID{get;set;}

}

public class RegularUser:User{
    public string? UserLevel{get;set;}
}

public class Admin : User{
    public string? AdminRole{get;set;}
}
