using Client.Network;
using NUnit.Framework;

namespace Client.Test
{
    public class CredentialLoaderTest
    {
        [Test]
        public void LoadingFunctionNoNullTest()
        {
            var credentialLoader = new CredentialLoader();
            var result = credentialLoader.GetCredential();

            Assert.AreNotEqual(result, null);
        }
    }
}
