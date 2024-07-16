using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EmployeeManagement.Services
{
    public class SoapResponseService : ISoapResponseService
    {
        public string GenerateSoapResponse()
        {
            var soapEnvelope = new SoapEnvelope
            {
                Header = new SoapHeader { Title = "SOAP Response" },
                Body = new SoapBody { Content = "This is a SOAP response." }
            };

            var xmlSerializer = new XmlSerializer(typeof(SoapEnvelope));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, soapEnvelope);
                return stringWriter.ToString();
            }
        }
    }

    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapEnvelope
    {
        [XmlElement("Header")]
        public SoapHeader Header { get; set; }

        [XmlElement("Body")]
        public SoapBody Body { get; set; }
    }

    public class SoapHeader
    {
        public string Title { get; set; }
    }

    public class SoapBody
    {
        public string Content { get; set; }
    }
}