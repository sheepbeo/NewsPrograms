using System;
// ReSharper disable UnassignedField.Global

namespace Client.Network
{
    [Serializable]
    public class Credential
    {
        public string AppId;
        public string AppKey;
        public string SecretKey;
    }
}