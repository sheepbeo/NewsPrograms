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
            _networkHandler.Initialize(Config.ProgramQueryLimit, Config.InitialProgramCount);

            SearchComponent.Setup();
            SearchComponent.OnSearchStarted += HandleSearchStarted;

            ProgramListComponent.Setup(Config.NearBottomThreshold);
            
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
