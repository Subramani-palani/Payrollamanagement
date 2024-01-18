using Microsoft.AspNetCore.Mvc;
using EFinheritance.Efdata;
 namespace EFinheritance.Controllers;

 [ApiController]
 [Route("[controller]")] 

 public class HomeController:ControllerBase
 {
    private readonly WebDbContext _context;

    public HomeController(){

    }
 }