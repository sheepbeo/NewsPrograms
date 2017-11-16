using UnityEngine;

namespace Client.UI
{
    public class Config : MonoBehaviour
    {
        [Header("Should put more than enough to fill the screen")]
        public int InitialProgramCount = 25;

        public int ProgramQueryLimit = 10;
        public int NearBottomThreshold = 5;
    }
}