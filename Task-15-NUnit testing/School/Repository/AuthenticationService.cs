using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using School.AppConfigModels;
using School.Data;
using School.Models;
using School.Services;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

namespace School.Repository;

public class AuthenticationService : IAuthenticationService
{
    private readonly TwilioSettings _configuration;
    private readonly AppDbContext data;
    public AuthenticationService(IOptions<TwilioSettings> configuration,AppDbContext database )
    {     
    
        this._configuration = configuration.Value;
        this.data = database;
    }
    
    public string generateOtp(int iOTPLength,string[] AllowedCharacters)
    {
        
        string sOTP = String.Empty;
        string sTempChars = String.Empty;
        Random rand = new Random();
        for (int i = 0; i < iOTPLength; i++)
        {
            int p = rand.Next(0,AllowedCharacters.Length);
            sTempChars = AllowedCharacters[rand.Next(0, AllowedCharacters.Length)];
            sOTP += sTempChars;
        }
        return sOTP;
    

    }



    public void sendOtp(string userMobileNumber,string content)
    {
        string accountSid = _configuration.accountSid;
            string authToken = _configuration.authToken;
            string code = "+91";
            
            string number = code+userMobileNumber;

            Console.WriteLine(number);
            TwilioClient.Init(accountSid, authToken);
        
        
            try
            {
                var message = MessageResource.Create(
                    body: content,
                    from: new Twilio.Types.PhoneNumber(_configuration.phoneNumber),
                    to: new Twilio.Types.PhoneNumber(number)
                );
                
                
            }
            catch (ApiException error)
            {
                Console.WriteLine(error.Message);
                
            }
            catch(Exception error){
                Console.WriteLine(error.Message);
            }

    }

    public string verifyOtp(string systemOtp,string userOtp)
    {
        if(Convert.ToInt16(systemOtp) == Convert.ToInt16(userOtp))
            return "ok";
        return "not ok";

        
    }

    public async Task addUser(User user){
        data.UserInfo.AddAsync(user);
    }
}