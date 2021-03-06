﻿using System;
using System.Collections;
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
        private Query _currentQuery;
        private readonly JsonSerializationWrapper _jsonSerializer = new JsonSerializationWrapper();

        public void Initialize(int queryLimit)
        {
            _queryLimit = queryLimit;
            var credentialLoader = new CredentialLoader();
            var credential = credentialLoader.GetCredential();

            _defaultQuery = new Query(queryLimit, "");
            _baseUriAuthenticated = BaseUri + "?app_id=" + credential.AppId + "&app_key=" + credential.AppKey;
        }

        public void GetDefault(Action<RootObject> callBack)
        {
            _defaultQuery.Reset();
            _currentQuery = _defaultQuery;
            StartCoroutine(LoadData(_defaultQuery, callBack));
        }

        public void SearchWith(string searchText, Action<RootObject> callBack)
        {
            var query = new Query(_queryLimit, searchText);
            _currentQuery = query;
            StartCoroutine(LoadData(query, callBack));
        }

        public void ContinueLoad(Action<RootObject> callBack)
        {
            _currentQuery.Increment();
            StartCoroutine(LoadData(_currentQuery, callBack));
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
                var rootObject = _jsonSerializer.Parse<RootObject>(www.downloadHandler.text, true);
                callBack(rootObject);
            }
        }
    }
}