using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using Constants = dotnet_code_challenge.Test.Helpers.Constants;
using Xunit;
using System.IO;

namespace dotnet_code_challenge.Test
{
    public class JsonParserTests
    {
        [Fact]
        public void Parse_ValidJsonFile_OutputJsonObject()
        {
            var doc = JsonParser<WolferhamptonRace>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.VALID_JSON_FILE_NAME}");

            Assert.IsType<WolferhamptonRace>(doc);
            Assert.Equal(Constants.VALID_JSON_FILE_ID, doc.FixtureId);
        }

        [Fact]
        public void Parse_InvalidJsonFileName_ThrowsExceptions()
        {
           var exception = Assert.Throws<FileNotFoundException>(
                () => JsonParser<Meeting>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.INVALID_JSON_FILE_NAME}")
            );
        }

        [Fact]
        public void Parse_ValidJsonFile_OutputNullObject()
        {
            var doc = JsonParser<WolferhamptonRace>.Parse($"{Constants.TEST_FILE_PATH}/{Constants.EMPTY_JSON_FILE_NAME}");

            Assert.Null(doc);
        }
    }
}
