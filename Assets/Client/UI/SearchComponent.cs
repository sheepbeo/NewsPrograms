using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Client.UI
{
    public class SearchComponent : MonoBehaviour
    {
        public Action<string> OnSearchStarted = s => { };
        public Action OnSearchCanceled = () => { };

        public Button SearchButton;
        public Button CancelSearchButton;
        public InputField Input;

        public void Setup()
        {
            SearchButton.onClick.AddListener(HandleSearchPressed);
            CancelSearchButton.onClick.AddListener(HandleSearchCancelPressed);

            Input.onEndEdit.AddListener(HandleSearchInputEnd);
            Input.onValueChanged.AddListener(HandleSearchValueChanged);
        }

        private void HandleSearchPressed()
        {
            OnSearchStarted(Input.text);
        }

        private void HandleSearchCancelPressed()
        {
            Input.text = "";
            CancelSearchButton.gameObject.SetActive(false);
            OnSearchCanceled();
        }

        private void HandleSearchInputEnd(string input)
        {
            // Current workaround for losing focus makes InputField submit
            // From https://forum.unity.com/threads/how-do-i-stop-inputfield-submitting-twice-when-enter-and-again-when-it-loses-focus.278739/
            // TODO test this on device
            // https://forum.unity.com/threads/inputfield-focus-triggers-onendedit-and-touchscreenkeyboard-done-triggers-on-loss-of-focus-what-now.442417/
            if (EventSystem.current.alreadySelecting) return; 

            OnSearchStarted(input);
        }

        private void HandleSearchValueChanged(string newValue)
        {
            CancelSearchButton.gameObject.SetActive(!string.IsNullOrEmpty(newValue));
        }
    }
}