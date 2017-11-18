using System;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class ProgramEntryComponent : MonoBehaviour
    {
        public Text Title;
        public Button SelectButton;

        private Action _onSelectCallBack;

        public void Setup(Action onSelectCallBack)
        {
            _onSelectCallBack = onSelectCallBack;
            SelectButton.onClick.AddListener(HandleSelected);
        }

        private void HandleSelected()
        {
            _onSelectCallBack();
        }

        public void Display(string title)
        {
            Title.text = title;
        }
    }
}