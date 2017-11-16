using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class ProgramEntryComponent : MonoBehaviour
    {
        public Text Title;

        public void Display(string title)
        {
            Title.text = title;
        }
    }
}