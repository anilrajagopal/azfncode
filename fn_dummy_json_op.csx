#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string[] randomMessages = {
        "Hello from Azure Functions!",
        "Welcome to the serverless world!",
        "You have called serverless api",
        "Azure Functions is awesome!"
    };

    int randomIndex = new Random().Next(0, randomMessages.Length);
    string randomMessage = randomMessages[randomIndex];

    // Create a response object with the random content
    var responseObj = new {
        functionType = "HTTP trigger",
        message = randomMessage,
        timestamp = DateTime.UtcNow
    };

    // Serialize the response object to JSON
    string jsonResponse = JsonConvert.SerializeObject(responseObj);

    // Return the JSON response with a 200 status code
    return new ContentResult
    {
        Content = jsonResponse,
        ContentType = "application/json",
        StatusCode = (int)HttpStatusCode.OK
    };


}
