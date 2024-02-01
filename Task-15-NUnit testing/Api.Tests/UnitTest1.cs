using System.Net;
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using School.Controllers;
using School.Models;

namespace ServerApi.Tests
{
    public class WeatherForecastControllerTests
    {
        
        private WebApplicationFactory<StudentController> _factory;
        

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<StudentController>();
            
           
        }

        [Test]
        public async Task GetStudent()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Student/getStudents");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task verifyStudentid()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("Student/getStudentDetails/0");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
           

        }

        [Test]
        public async Task verify_Studentname()
        {
            // Arrange
            var client = _factory.CreateClient();
            var id = 2;
            // Act
            var response= await client.GetAsync($"/Student/getStudentDetails/{id}");
            
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Student>(stringResponse);

            
            // Assert
            Assert.AreEqual("saran",result.Name);
        }
        [Test]

        public async Task addStudentTest()
        {
            var client = _factory.CreateClient();

            var model = new {
                                id= 0,
                                name= "Arunesh",
                                address= "kelambakkam",
                                phoneNumber = "9655667214",
                                email = "arun@gmail.com"
                            };
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            // Act
            var response = await client.PostAsync("/Student/Add students", content);

            // Assert
            response.EnsureSuccessStatusCode();


        }

        [Test]
        public async Task updateStudentTest()
        {
            var client = _factory.CreateClient();
            int Id =4;
            var model = new {
                                id= Id,
                                name= "Arunesh",
                                address= "kelambakkam",
                                phoneNumber = "9655667214",
                                email = "arun@gmail.com"
                            };
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            // Act
            var response = await client.PutAsync($"/Student/updateDetails/{Id}", content);

            // Assert
            response.EnsureSuccessStatusCode();


        }
    }


}

