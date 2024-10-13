using MLAPP.DTOs.Requests;
using MLAPP.Services;
using PuppeteerSharp;
using Collections = System.Collections.Generic;


#region NodeModel
/*

IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://www.google.com/");
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
var button =
    driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[3]/span/div/div/div/div[3]/div[1]/button[2]"));
button.Click();
var input = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/textarea"));
//WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//wait.Until(ExpectedConditions.(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/textarea")));
input.SendKeys("allintext:Coca Cola Zero 33cl kr site:.se");
input.SendKeys(Keys.Enter);
var linkElements = driver.FindElements(By.XPath("//*[@id=\"rso\"]/div/div/div/div/div[1]/div/div/span/a"));
var list = new List<string>();

foreach (var link in linkElements)
{
    list.Add(link.GetAttribute("href"));
}
linkElements = driver.FindElements(By.XPath("//*[@id=\"rso\"]/div/div/div/div[1]/div/div/span/a"));

foreach (var link in linkElements)
{
    list.Add(link.GetAttribute("href"));
}

var trainingData = new List<TrainingData>();
list.ForEach(l => trainingData.AddRange(GetTrainingData(l)));

var dbContext = new AppDbContext();


await dbContext.TrainingData.AddRangeAsync(trainingData);
await dbContext.SaveChangesAsync();


// Add input data

//var sampleData = new SentimentModel.ModelInput()
//{
//    Col0 = ""
//};

//// Load model and predict output of sample data
//var result = SentimentModel.Predict(sampleData);

//// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
//var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
//Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");

static IEnumerable<TrainingData> GetTrainingData(string url)
{
    HtmlWeb web = new HtmlWeb();

    var htmlDoc = web.Load(url);

    if (url == "https://karnimart.se/ur/products/coca-cola-zero-33cl")
    {
        var node = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"ProductPrice-7867938078911\"]");
    }

    var nodes = htmlDoc.DocumentNode.Descendants();

    var data = nodes.Where(n => !string.IsNullOrWhiteSpace(n.InnerHtml) && n.InnerHtml != "\n").Select(n => new TrainingData
    {
        Content = n.InnerHtml,
        IsPrice = 0,
        Url = url,
        NodeId = n.Id
    });

    return data;
}

*/
#endregion

#region ImageModel

class Program
{
    static async Task Main(string[] args)
    {
        var browserService = new BrowserService();

        var requestDtos = new List<FormRequestRequestDto>
        {
            new FormRequestRequestDto
            {
                ProductName = "Coca Cola Zero",
                Size = "33cl",
                Currency = "kr",
                Site = ".se"
            }
        };

        var urls = new List<string>();

        requestDtos.ForEach(r => urls.AddRange(browserService.SearchRequestAndGetUrlList(r)));


        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        await using var page = await browser.NewPageAsync();

        var index = 1;

        foreach (var u in urls)
        {
            await browserService.MadeAndSaveScreenshotAsync(u,
                @"C:\D\TrainingImages\PriceDetectionWithoutMarks\screenshot" + index++ + ".png", page);
        }

        await browser.CloseAsync();
        Console.ReadLine();
    }
}
#endregion