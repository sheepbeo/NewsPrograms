using System.Collections.Generic;
using Client.Data;
using UnityEngine;

namespace Client.UI
{
    public class NewsListComponent : MonoBehaviour
    {
        public Transform Container;
        public NewsEntryComponent NewsEntryComponentPrefab;

        // TODO pooling
        // TODO continue load near end
        // TODO config for number of entries

        public void DisplayEntries(List<Datum> entryData)
        {
            foreach (Transform t in Container)
            {
                Destroy(t.gameObject);
            }

            foreach (var datum in entryData)
            {
                var entryComponent = Instantiate(NewsEntryComponentPrefab, Container);
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
    }
}