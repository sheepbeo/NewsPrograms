using System.Collections.Generic;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class ProgramListComponent : MonoBehaviour
    {
        public Transform FullLoadingContainer;
        public Transform Container;
        public ScrollRect ScrollRect;
        public ProgramEntryComponent ProgramEntryComponentPrefab;

        private int _nearBottomThreshold;
        private int _currentDisplaying;

        // TODO pooling
        // TODO continue load near end - need flag while loading (avoid duplicates)

        public void Setup(int nearBottomThreshold)
        {
            _nearBottomThreshold = nearBottomThreshold;

            ScrollRect.onValueChanged.AddListener(HandleScrollValueChanged);
        }

        public void DisplayEntries(List<Datum> entryData)
        {
            foreach (var datum in entryData)
            {
                var entryComponent = Instantiate(ProgramEntryComponentPrefab, Container);
                entryComponent.Display(datum.Title.GetFinalTitle());
            }
        }

        public void ToggleFullLoading(bool state)
        {
            if (state)
            {
                foreach (Transform t in Container)
                {
                    Destroy(t.gameObject);
                }
            }

            FullLoadingContainer.gameObject.SetActive(state);
        }

        private void HandleScrollValueChanged(Vector2 arg0)
        {
            Debug.Log("value: " + arg0 + " normalized: " + ScrollRect.normalizedPosition);
        }
    }
}