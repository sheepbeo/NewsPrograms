using System;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    // TODO publication event array
    // TODO subject array

    public class ProgramDetailComponent : MonoBehaviour
    {
        public event Action OnBackPressed = () => { };
        public Button BackButton;

        public Text Title;
        public Text Description;
        public Text Type;
        public Text Subject;

        public Transform PublicationEventContainer;
        public PublicationEventComponent PublicationEventComponentPrefab;

        public void Setup()
        {
            BackButton.onClick.AddListener(HandleBackButtonPressed);
        }

        public void DisplayDatum(Datum datum)
        {
            Title.text = datum.GetTitle();
            Description.text = datum.GetDescription();
            Type.text = datum.GetTypeText();
            Subject.text = datum.GetSubject();

            foreach (var publicationEvent in datum.GetPublicationEvents())
            {
                var publicationEventComponent = Instantiate(PublicationEventComponentPrefab, PublicationEventContainer);
                publicationEventComponent.Display(publicationEvent);
            }
        }

        private void HandleBackButtonPressed()
        {
            OnBackPressed();
        }
    }
}