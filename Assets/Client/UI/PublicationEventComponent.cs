using System.Globalization;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class PublicationEventComponent : MonoBehaviour
    {
        public Text Service;
        public Text StartTime;
        public Text Duration;

        public void Display(PublicationEvent publicationEvent)
        {
            Service.text = publicationEvent.GetService();
            StartTime.text = publicationEvent.GetStartTime().ToString(CultureInfo.InvariantCulture);
            Duration.text = publicationEvent.GetDuration();
        }
    }
}