using School.Models;

namespace School.Services;
public interface IAuthenticationService{
    public string generateOtp(int iOTPLength,string[] AllowedCharacters);
    public void sendOtp(string userMobileNumber,string content);
    public string verifyOtp(string systemOtp,string userOtp);

    public  Task addUser(User user);

}