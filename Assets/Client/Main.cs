using Client.Data;
using Client.Network;
using Client.UI;
using UnityEngine;

namespace Client
{
    public class Main : MonoBehaviour
    {
        public NetworkHandler NetworkHandlerPrefab;
        public NewsListComponent NewsListComponent;

        void Start()
        {
            var networkHandler = Instantiate(NetworkHandlerPrefab, transform);
            networkHandler.Initialize();

            networkHandler.GetDefault(HandleLoaded);
        }

        private void HandleLoaded(RootObject rootObj)
        {
            NewsListComponent.DisplayEntries(rootObj.Data);
        }
    }
}
