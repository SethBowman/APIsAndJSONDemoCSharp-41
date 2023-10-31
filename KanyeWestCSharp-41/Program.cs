using Newtonsoft.Json.Linq;

//Create an HTTPClient instance, this is what actually makes the api call

var client = new HttpClient();


for (int i = 1; i <= 5; i++)
{
    //Build an api URL from where the api call comes from
    var kanyeURL = "https://api.kanye.rest/";

    //Using the HTTPClient instance we created above
    //Send a GET request to the url created above, this will give us back a string of JSON
    var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

    //Parse the JSON response we just got back into a JObject, we do this so we can access certain pieces of the JSON
    //In this case we will be getting the value of "quote" which will be the actual quote itself and not the whole JSON body
    //Without ToString() it will be of type JToken, so we could never use it as a string
    //var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
    var kanyeQuote = JObject.Parse(kanyeResponse)["quote"].ToString();
    Console.WriteLine("Kanye says:");
    Console.WriteLine(kanyeQuote);
}

//using an api key

//Grab appsettings file
var apiKeyObj = File.ReadAllText("appsettings.json");

//Get the api key from the appsettings file using the name "apiKey"
var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

//Build the api URL using the provided params you chose along with the apiKey instead of your actual key
//Build an api url from where the call comes from
var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?zip=35091&appid={apiKey}";