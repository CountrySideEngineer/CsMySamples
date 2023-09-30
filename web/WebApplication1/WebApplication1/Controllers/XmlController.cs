using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostXmlData([FromBody] Person xmlData)
        {
            try
            {
                //                var xmlDoc = XDocument.Parse(xmlData);
                Console.WriteLine($"Persom : Id = {xmlData.Id}, Name = {xmlData.Name}, Age = {xmlData.Age}");

                return Ok("XML data received and processed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error processing XML data: {ex.Message}");
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
