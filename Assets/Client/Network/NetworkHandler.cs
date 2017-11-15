using System.Collections;
using System.Text.RegularExpressions;
using Client.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Network
{
    public class NetworkHandler : MonoBehaviour
    {
        private const string BaseUri = "https://external.api.yle.fi/v1/programs/items.json";

        private string _baseUriAuthenticated = "";

        public void Initialize()
        {
            var credentialLoader = new CredentialLoader();
            var credential = credentialLoader.GetCredential();
            
            _baseUriAuthenticated = BaseUri + "?app_id=" + credential.AppId + "&app_key=" + credential.AppKey;

            StartCoroutine(GetDefaultData());
        }

        private IEnumerator GetDefaultData()
        {
            var uri = _baseUriAuthenticated;
            UnityWebRequest www = UnityWebRequest.Get(uri);
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                var text = Regex.Replace(www.downloadHandler.text, @"("")(\w)(\w*"":)", m => 
                    m.Groups[1] + m.Groups[2].ToString().ToUpper() + m.Groups[3]);
                Debug.Log(text);
                var rootObject = JsonUtility.FromJson<RootObject>(text);
                Debug.Log(rootObject.ApiVersion);
            }
        }

    }
}