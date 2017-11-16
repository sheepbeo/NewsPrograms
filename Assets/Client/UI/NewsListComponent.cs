using System.Collections.Generic;
using Client.Data;
using UnityEngine;

namespace Client.UI
{
    public class NewsListComponent : MonoBehaviour
    {
        public Transform Container;
        public NewsEntryComponent NewsEntryComponentPrefab;

        public void DisplayEntries(List<Datum> entryData)
        {
            foreach (var datum in entryData)
            {
                var entryComponent = Instantiate(NewsEntryComponentPrefab, Container);
                entryComponent.Display(datum.Title.Und);
            }
        }
    }
}