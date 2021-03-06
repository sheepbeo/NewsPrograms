﻿using UnityEngine;

namespace Client.Network
{
    public class CredentialLoader
    {
        private const string CredentialPath = "Authentication/credentials";

        public Credential GetCredential()
        {
            var credentialText = Resources.Load<TextAsset>(CredentialPath).text;
            var credential = JsonUtility.FromJson<Credential>(credentialText);

            return credential;
        }
    }
}