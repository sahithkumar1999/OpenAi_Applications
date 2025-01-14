using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Applications
{
    internal class Program
    {
        // Retrieve the OpenAI API key from environment variables
        private static readonly string? apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        // Define the API endpoint URL for image generation
        private static readonly string apiUrl = "https://api.openai.com/v1/images/generations";

        static async Task Main()
        {
            // Check if the API key is set
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("Error: OPENAI_API_KEY environment variable is not set.");
                return;
            }

            // Prompt the user to enter a description for the image
            Console.Write("Enter a description for the image: ");            
            string? prompt = Console.ReadLine();
            if (string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine("Error: The prompt cannot be empty.");
                return;
            }
            // Call the method to generate the image
            await GenerateImage(prompt);
        }

        /// <summary>
        /// Generates an image using OpenAI's API based on the provided prompt.
        /// </summary>
        /// <param name="prompt">The description for the image to be generated.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public static async Task GenerateImage(string prompt)
        {
            // Create an instance of HttpClient
            using HttpClient client = new();
            // Set the authorization header with the API key
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Create the request body with prompt, number of images, and size
            var requestBody = new
            {
                prompt,
                n = 1,
                size = "1024x1024"
            };

            // Serialize the request body to JSON
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            // Create the HTTP content with the JSON body
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send a POST request to the OpenAI API
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            // Handle the API response
            if (response.IsSuccessStatusCode)
            {
                // Read and parse the response JSON

                // Read the response content as a string
                string result = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                JObject json = JObject.Parse(result);

                // Extract the URL of the generated image
                string imageUrl = json["data"][0]["url"].ToString();

                Console.WriteLine($"Image URL: {imageUrl}");
                // Download the generated image
                string binPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "generated_image.png");
                await DownloadImage(imageUrl, binPath);
                Console.WriteLine($"Image downloaded as {binPath}");
            }
            else
            {
                // Print the error if the request failed
                Console.WriteLine($"Error: {response.StatusCode}\n{await response.Content.ReadAsStringAsync()}");
            }
        }

        /// <summary>
        /// Downloads the image from the specified URL and saves it locally.
        /// </summary>
        /// <param name="imageUrl">The URL of the image to be downloaded.</param>
        /// <param name="fileName">The local file path where the image will be saved.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private static async Task DownloadImage(string imageUrl, string fileName)
        {
            using HttpClient client = new();
            // Download the image as a byte array
            byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
            // Write the image bytes to a file
            await File.WriteAllBytesAsync(fileName, imageBytes);
        }
    }
}
