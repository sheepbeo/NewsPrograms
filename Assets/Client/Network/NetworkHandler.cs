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
        private int _queryLimit;

        private Query _defaultQuery;

        public void Initialize(int queryLimit, int initialLoadCount)
        {
            _queryLimit = queryLimit;
            var credentialLoader = new CredentialLoader();
            var credential = credentialLoader.GetCredential();

            _defaultQuery = new Query(Mathf.Max(queryLimit, initialLoadCount), "");
            _baseUriAuthenticated = BaseUri + "?app_id=" + credential.AppId + "&app_key=" + credential.AppKey;
        }

        public void GetDefault(Action<RootObject> callBack)
        {
            StartCoroutine(LoadData(_defaultQuery, callBack));
        }

        public void SearchWith(string searchText, Action<RootObject> callBack)
        {
            var query = new Query(_queryLimit, searchText);
            StartCoroutine(LoadData(query, callBack));
        }

        private IEnumerator LoadData(Query query, Action<RootObject> callBack)
        {
            var uri = _baseUriAuthenticated + query.GetParams();
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