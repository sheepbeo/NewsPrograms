using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class NewsEntryComponent : MonoBehaviour
    {
        public Text Title;

        public void Display(string title)
        {
            Title.text = title;
        }
    }
}