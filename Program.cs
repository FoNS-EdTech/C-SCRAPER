using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

class Program
{
    static void Main(string[] args)
    {
        // Set up EdgeDriver
        EdgeOptions options = new EdgeOptions();
        // Add any necessary options to the options object, if needed.
        IWebDriver driver = new EdgeDriver(options);

        // Navigate to the Panopto page
        driver.Navigate().GoToUrl("https://imperial.cloud.panopto.eu/Panopto/Pages/Sessions/List.aspx#folderID=%225da68cca-8d91-444d-a1e4-e09ff92145cc%22");

        // Find all elements with class "subfolder-item"
        var subfolderItems = driver.FindElements(By.CssSelector(".subfolder-item"));

        // Create a text file to store the data-ids
        string filePath = "output.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Loop through each element and get the data-id attribute
            foreach (var item in subfolderItems)
            {
                string dataId = item.GetAttribute("data-id");
                // Write the data-id to the text file
                writer.WriteLine(dataId);
            }
        }

        // Close the driver
        driver.Quit();
    }
}
