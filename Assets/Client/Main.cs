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
        public Config Config;

        private NetworkHandler _networkHandler;

        void Start()
        {
            _networkHandler = Instantiate(NetworkHandlerPrefab, transform);
            _networkHandler.Initialize(Config.ProgramQueryLimit);

            SearchComponent.Setup();
            SearchComponent.OnSearchStarted += HandleSearchStarted;
            SearchComponent.OnSearchCanceled += HandleSearchCanceled;

            ProgramListComponent.Setup(Config.NearBottomThreshold);
            ProgramListComponent.OnReachEnd += HandleOnReachEnd;
            
            LoadDefault();
        }

        private void LoadDefault()
        {
            ProgramListComponent.ToggleFullLoading(true);
            _networkHandler.GetDefault(HandleLoaded);
        }

        private void HandleSearchStarted(string searchText)
        {
            ProgramListComponent.ToggleFullLoading(true);
            _networkHandler.SearchWith(searchText, HandleLoaded);
        }

        private void HandleSearchCanceled()
        {
            LoadDefault();
        }

        private void HandleOnReachEnd()
        {
            _networkHandler.ContinueLoad(HandleLoaded);
        }

        private void HandleLoaded(RootObject rootObj)
        {
            ProgramListComponent.ToggleFullLoading(false);
            ProgramListComponent.DisplayEntries(rootObj.Data);
        }
    }
}
