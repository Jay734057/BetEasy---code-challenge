using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using Constants = dotnet_code_challenge.Test.Helpers.Constants;
using Xunit;
using System.IO;
using System.Xml;

namespace dotnet_code_challenge.Test
{
    public class XmlParserTests
    {
        [Fact]
        public void Parse_ValidXmlFile_OutputXmlObject()
        {
            var doc = XmlParser<Meeting>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.VALID_XML_FILE_NAME}");

            Assert.IsType<Meeting>(doc);
            Assert.Equal(Constants.VALID_XML_FILE_ID, doc.Id);
        }

        [Fact]
        public void Parse_InvalidXmlFileName_ThrowsExceptions()
        {
            var exception = Assert.Throws<FileNotFoundException>(
                 () => XmlParser<Meeting>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.INVALID_XML_FILE_NAME}")
             );
        }

        [Fact]
        public void Parse_ValidXmlFile_OutputNullObject()
        {
            var exception = Assert.Throws<XmlException>(
                 () => XmlParser<Meeting>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.EMPTY_XML_FILE_NAME}")
             );

            Assert.Equal("Root element is missing.", exception.Message);
        }
    }
}
