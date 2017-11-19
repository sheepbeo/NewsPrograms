using System;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    // TODO more fields
    // TODO publication event array
    // TODO subject array

    public class ProgramDetailComponent : MonoBehaviour
    {
        public event Action OnBackPressed = () => { };
        public Button BackButton;

        public Text Title;
        public Text StartTime;
        public Text Duration;

        public void Setup()
        {
            BackButton.onClick.AddListener(HandleBackButtonPressed);
        }

        public void DisplayDatum(Datum datum)
        {
            Title.text = datum.GetFinalTitle();
            StartTime.text = datum.GetStartTime().ToString();
            var duration = TimeSpan.FromSeconds(datum.GetDurationSeconds());
            Duration.text = duration.ToString();
        }

        private void HandleBackButtonPressed()
        {
            OnBackPressed();
        }
    }
}