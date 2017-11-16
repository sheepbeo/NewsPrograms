using System.Collections.Generic;
using Client.Data;
using UnityEngine;

namespace Client.UI
{
    public class ProgramListComponent : MonoBehaviour
    {
        public Transform FullLoadingContainer;
        public Transform Container;
        public ProgramEntryComponent ProgramEntryComponentPrefab;


        // TODO pooling
        // TODO continue load near end
        // TODO config for number of entries

        public void DisplayEntries(List<Datum> entryData)
        {
            foreach (var datum in entryData)
            {
                var entryComponent = Instantiate(ProgramEntryComponentPrefab, Container);
                // TODO refactor this logic to model
                if (!string.IsNullOrEmpty(datum.Title.Fi))
                {
                    entryComponent.Display(datum.Title.Fi);
                }
                else
                {
                    entryComponent.Display(datum.Title.Und);
                }
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
    }
}