using School.Data;
using School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using Twilio;
using Twilio.Exceptions;
using System.Collections.Generic;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.AspNetCore.Http;
using School.AppConfigModels;
using Microsoft.Extensions.Options;
using School.Repository;
using School.Services;


namespace School.Controllers;


[ApiController]
[Route("/[controller]/[action]")]
public class StudentController:Controller{
    private readonly AppDbContext data;
    private readonly TwilioSettings _configuration;

    private  IAuthenticationService _authentication;
   
    public StudentController(AppDbContext Context, IOptions<TwilioSettings> configuration,IAuthenticationService authentication)
    {
        data = Context;
        this._configuration = configuration.Value;
        this._authentication = authentication;
    }
    [HttpPost]
    [ActionName("Register")]
    public async Task<IActionResult> register(User user)
    {
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }   

        
        
        
        string Status = HttpContext.Session.GetString("status");
        Console.WriteLine(Status);
        if(Status != "logged in"){
            string[] AllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string RandomOTP = this._authentication.generateOtp(4,AllowedCharacters);
            Console.WriteLine(RandomOTP);
            HttpContext.Session.SetString("otp",RandomOTP);
            string content = "Your OTP is " + RandomOTP;
            this._authentication.sendOtp(user.MobileNumber,content);

            return BadRequest("Please do otp verification");
            
        }
   
        
        if (Status == "logged in")
        {
            await this._authentication.addUser(user);
            var result = await data.SaveChangesAsync();
            if(result>0)
            {
                HttpContext.Session.SetString("status","");
                return  Ok("Registered");
            }
            
        }
        
            
        return BadRequest("Registration failed");
    }

    [HttpPost]
    [ActionName("verifyOtp")]
    public async Task<IActionResult> verifyOtp(string userOtp){
        string systemOtp= HttpContext.Session.GetString("otp");
        
        if(this._authentication.verifyOtp(systemOtp,userOtp) == "ok"){
            HttpContext.Session.SetString("status","logged in");
            return Ok("verified");
        }
        return BadRequest("otp not verified");
    }

    
    [HttpPost]
    [ActionName("Login")]
    public async Task<IActionResult> login(User user){
        
        var User = await data.UserInfo.FindAsync(user.Email);

        if(User is null){
            return NotFound();
        }
        if(User.Name == user.Name && User.Password == user.Password){
            return Ok("Logged in");
        }
        return BadRequest("Log in failed");
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> getStudents(){
        var student = await data.StudentDetails.AsNoTracking().ToListAsync();
        return student;
    }

    [HttpPost]
    [ActionName("Add students")]
    public async Task<IActionResult> addStudents(Student student){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        await data.AddAsync(student);
        var result = await data.SaveChangesAsync();
        if (result > 0){
            return  Ok();
        }
        return BadRequest();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> getStudentDetails(int id)
    {
        var student = await data.StudentDetails.FindAsync(id);

        if(student is null){
            return NotFound();
        }
        return Ok(student);

    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> deleteStudent(int id)
    {
        var student = await data.StudentDetails.FindAsync(id);
        if (student is null)
            return NotFound();
        data.StudentDetails.Remove(student);
        var result = await data.SaveChangesAsync();
        if(result > 0){
            return Ok("student details deleted");
        }
        return BadRequest("Unable to delete student");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> updateDetails(int id,Student student){
        var StudentInfo = await data.StudentDetails.FindAsync(id);

        if(StudentInfo is null)
            return BadRequest("No details found");
        
        StudentInfo.Name = student.Name;
        StudentInfo.PhoneNumber = student.PhoneNumber;
        StudentInfo.Address = student.Address;
        StudentInfo.Email = student.Email;
        StudentInfo.Id = student.Id;

        var result = await data.SaveChangesAsync();
        if(result > 0){
            return Ok("student details updated");
        }
        return BadRequest("Unable to update student");

    }
    



}