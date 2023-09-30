using System;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

// Create an XML document
var person = new Person()
{
    Id = 2,
    Name = "sample name",
    Age = 99
};
var xs = new System.Xml.Serialization.XmlSerializer(typeof(Person));
var hc = new HttpClient();
hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
var sw = new System.IO.StringWriter();
// 先頭の <?xml ... をカットする
var settings = new System.Xml.XmlWriterSettings() { OmitXmlDeclaration = true, Encoding = Encoding.UTF8 };
var xw = System.Xml.XmlWriter.Create(sw, settings);
xs.Serialize(xw, person);
var xml = sw.ToString();
var cont = new StringContent(xml, Encoding.UTF8, "application/xml");
var res = await hc.PostAsync($"https://localhost:7118/api/Xml", cont);
var str = await res.Content.ReadAsStringAsync();

return;



XmlDocument xmlDoc = new XmlDocument();
xmlDoc.Load(@"E:\development\googletest_gui\sample\bin\SampleTest_NG.xml");

//// Create the root element
//XmlElement root = xmlDoc.CreateElement("data");
//xmlDoc.AppendChild(root);

//// Create child elements and add data
//XmlElement valueElement = xmlDoc.CreateElement("value");
//valueElement.InnerText = "Your XML content here";
//root.AppendChild(valueElement);

// Convert the XML document to a string
string xmlData = xmlDoc.InnerXml;
//xmlData = "\'" + xmlData + "\'";
Console.WriteLine(xmlData);

// Create an instance of HttpClient
using HttpClient httpClient = new HttpClient();

// Set the URL
string url = "https://localhost:7118/api/Xml";

var content = new StringContent(xmlData, Encoding.UTF8, "text/xml");
content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml");

// Send the POST request
HttpResponseMessage response = await httpClient.PostAsync(url, content);
if (response.IsSuccessStatusCode)
{
    // Request was successful
    string responseContent = await response.Content.ReadAsStringAsync();
    // Process the server's response if necessary
}
else
{
    // Handle errors (e.g., server error, network issue)
    Console.WriteLine($"Error: {response.StatusCode}");
}
return;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
