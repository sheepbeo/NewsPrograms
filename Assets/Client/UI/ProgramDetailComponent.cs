using System;
using System.Collections;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
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

            foreach (Transform child in PublicationEventContainer)
            {
                Destroy(child.gameObject);
            }

            foreach (var publicationEvent in datum.GetPublicationEvents())
            {
                var publicationEventComponent = Instantiate(PublicationEventComponentPrefab, PublicationEventContainer);
                publicationEventComponent.Display(publicationEvent);
            }

            StartCoroutine(RecheckLayout());
        }

        private void HandleBackButtonPressed()
        {
            OnBackPressed();
        }

        /// <summary>
        /// Current work around for layout system not working well with Content size fitter
        /// </summary>
        private IEnumerator RecheckLayout()
        {
            yield return null;
            PublicationEventContainer.gameObject.SetActive(false);
            PublicationEventContainer.gameObject.SetActive(true);
        }
    }
}