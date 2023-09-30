using System;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Api.Common;

// Create an XML document
var person = new Person()
{
    Id = 2,
    Name = "sample name",
    Age = 99
};

var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Person));

var stringWriter = new StringWriter();
var writerSettings = new XmlWriterSettings()
{
    OmitXmlDeclaration = true,
    Encoding = Encoding.UTF8
};
XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings);
serializer.Serialize(xmlWriter, person);
string xmlPerson = stringWriter.ToString();
Console.WriteLine(xmlPerson);

var content = new StringContent(xmlPerson, Encoding.UTF8, "application/xml");

//Setup HTTP client and send data.
var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
string url = "https://localhost:7118/api/Xml";
HttpResponseMessage response = await httpClient.PostAsync(url, content);
if (response.IsSuccessStatusCode)
{
    string responseContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent);
}
else
{
    Console.WriteLine($"Error: {response.StatusCode}");
}
return;

