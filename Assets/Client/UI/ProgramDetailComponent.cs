using System;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    // TODO more fields
    // TODO back to list

    public class ProgramDetailComponent : MonoBehaviour
    {
        public Text Title;
        public Text StartTime;
        public Text Duration;

        public void DisplayDatum(Datum datum)
        {
            Title.text = datum.GetFinalTitle();
            StartTime.text = datum.GetStartTime().ToString();
            var duration = TimeSpan.FromSeconds(datum.GetDurationSeconds());
            Duration.text = duration.ToString();
        }
    }
}