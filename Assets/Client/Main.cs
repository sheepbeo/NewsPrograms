using Client.Network;
using UnityEngine;

namespace Client
{
    public class Main : MonoBehaviour
    {
        public NetworkHandler NetworkHandlerPrefab;

        void Start()
        {
            var networkHandler = Instantiate(NetworkHandlerPrefab, transform);
            networkHandler.Initialize();
        }
    }
}
