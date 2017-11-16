using System;
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
        }

        public void GetDefault(Action<RootObject> callBack)
        {
            StartCoroutine(LoadData(UriParams.Default, callBack));
        }

        public void SearchWith(string searchText, Action<RootObject> callBack)
        {
            var uriParams = new UriParams();
            uriParams.SetSearchParam(searchText);
            StartCoroutine(LoadData(uriParams, callBack));
        }

        private IEnumerator LoadData(UriParams uriParams, Action<RootObject> callBack)
        {
            var uri = _baseUriAuthenticated + uriParams;
            Debug.Log(uri);
            UnityWebRequest www = UnityWebRequest.Get(uri);
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                var text = Regex.Replace(www.downloadHandler.text, @"("")(\w)(\w*"":)", m =>
                    m.Groups[1] + m.Groups[2].ToString().ToUpper() + m.Groups[3]);
                var rootObject = JsonUtility.FromJson<RootObject>(text);
                callBack(rootObject);
            }
        }
    }
}