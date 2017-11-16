using System;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class SearchComponent : MonoBehaviour
    {
        public Action<string> OnSearchStarted = s => { };

        public Button SearchButton;
        public InputField Input;

        public void Setup()
        {
            SearchButton.onClick.AddListener(HandleSearchPressed);
            Input.onEndEdit.AddListener(HandleSearchInputEnd);
        }

        private void HandleSearchPressed()
        {
            OnSearchStarted(Input.text);
        }

        private void HandleSearchInputEnd(string input)
        {
            OnSearchStarted(input);
        }
    }
}