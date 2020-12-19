using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using WooliesXAnswersAPI.Models;


namespace WooliesXTestCases
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestUser()
        {
            var client = new RestClient("https://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            var request = new RestRequest("user", Method.GET);
            // request.AddUrlSegment()
            var response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<User>(response);
           // var output = JsonConvert.SerializeObject(content);

            //verifying if response object has name and token
            /* if (!response.StatusCode.Equals(200))
                 Assert.Fail("Invalid response receieved");
            */
            //Verifying name is Swathi Maddali
            Assert.That(output.name, Is.EqualTo("Swathi Maddali"), "Name is incorrect");




        }

        [Test]
        public void StatusCodeTest()
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("user", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void ContentTypeTest()
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("user", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset = utf - 8"));
        }

        [TestCase("High", HttpStatusCode.OK, TestName = "Check sort by Price high to low")]

        public void highSortTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("sort");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }


        [TestCase("Low", HttpStatusCode.OK, TestName = "Check sort by Price low to high")]

        public void lowSortTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("sort");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [TestCase("Ascending", HttpStatusCode.OK, TestName = "Check sort by Ascending order Name")]

        public void ascendingSortTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("sort");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [TestCase("Descending", HttpStatusCode.OK, TestName = "Check sort by Descending order Name")]

        public void descendingSortTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("sort");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [TestCase("Recommended", HttpStatusCode.OK, TestName = "Check sort by Recommended order Name")]

        public void StatusCodeTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("sort");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [TestCase("TrolleyTotal", HttpStatusCode.OK, TestName = "Get Trolley Total")]

        public void trolleyCodeTest(string sortOption, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            var client = new RestClient("http://wooliesxanswerapi.azurewebsites.net/WooliesXAPI");
            RestRequest request = new RestRequest("");
            request.AddParameter(sortOption, sortOption);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }


    }
}