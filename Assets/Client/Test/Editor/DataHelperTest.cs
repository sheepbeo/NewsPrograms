using Client.Data;
using NUnit.Framework;

namespace Client.Test
{
    public class DataHelperTest
    {
        [TestCase("", "", ExpectedResult = "")]
        [TestCase(null, "", ExpectedResult = "")]
        [TestCase("a", "", ExpectedResult = "a")]
        [TestCase("", "a", ExpectedResult = "a")]
        [TestCase("", "a", "b", ExpectedResult = "a")]
        public string LoadingFunctionNoNullTest(params string[] input)
        {
            return DataHelper.GetNotEmpty(input);
        }
    }
}