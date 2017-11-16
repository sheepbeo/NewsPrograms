using Client.Data;
using Client.Network;
using Client.UI;
using UnityEngine;

namespace Client
{
    public class Main : MonoBehaviour
    {
        public NetworkHandler NetworkHandlerPrefab;
        public ProgramListComponent ProgramListComponent;
        public SearchComponent SearchComponent;

        private NetworkHandler _networkHandler;

        void Start()
        {
            _networkHandler = Instantiate(NetworkHandlerPrefab, transform);
            _networkHandler.Initialize();

            SearchComponent.Setup();
            SearchComponent.OnSearchStarted += HandleSearchStarted;

            ProgramListComponent.ToggleFullLoading(true);
            _networkHandler.GetDefault(HandleLoaded);
        }

        private void HandleSearchStarted(string searchText)
        {
            ProgramListComponent.ToggleFullLoading(true);
            _networkHandler.SearchWith(searchText, HandleLoaded);
        }

        private void HandleLoaded(RootObject rootObj)
        {
            ProgramListComponent.ToggleFullLoading(false);
            ProgramListComponent.DisplayEntries(rootObj.Data);
        }
    }
}
