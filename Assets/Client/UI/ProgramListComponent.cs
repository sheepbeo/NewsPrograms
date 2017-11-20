using System;
using System.Collections;
using System.Collections.Generic;
using Client.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Client.UI
{
    public class ProgramListComponent : MonoBehaviour
    {
        public event Action OnReachEnd = () => { };
        public event Action<Datum> OnSelectDatum = (datum) => { };

        public Transform FullLoadingContainer;
        public Transform Container;
        public ScrollRect ScrollRect;
        public ProgramEntryComponent ProgramEntryComponentPrefab;

        public Transform EndReachedLoadingContainer;

        private int _nearBottomThreshold;
        private int _currentDisplaying;
        private bool _endReached;
        private bool _mayHaveMoreData;

        // TODO pooling

        public void Setup(int nearBottomThreshold)
        {
            _nearBottomThreshold = nearBottomThreshold;
            _mayHaveMoreData = true;

            ScrollRect.onValueChanged.AddListener(HandleScrollValueChanged);
        }

        private void HandleScrollValueChanged(Vector2 pos)
        {
            if ((float)_nearBottomThreshold / _currentDisplaying >= pos.y)
            {
                TryTriggerReachEnd();
            }
        }

        private void TryTriggerReachEnd()
        {
            if (!_endReached && _mayHaveMoreData)
            {
                _endReached = true;
                OnReachEnd();
            }
        }

        public void DisplayEntries(List<Datum> entryData)
        {
            EndReachedLoadingContainer.SetParent(null, true);

            _currentDisplaying += entryData.Count;
            foreach (var datum in entryData)
            {
                var entryComponent = Instantiate(ProgramEntryComponentPrefab, Container);
                entryComponent.Setup(() =>
                {
                    HandleSelectDatum(datum);
                });
                entryComponent.Display(datum.GetTitle());
            }

            EndReachedLoadingContainer.SetParent(Container);

            _endReached = false;
            _mayHaveMoreData = (entryData.Count > 0);
            EndReachedLoadingContainer.gameObject.SetActive(entryData.Count > 0);
            StartCoroutine(CheckIfAlreadyReachedEnd());
        }

        private void HandleSelectDatum(Datum datum)
        {
            OnSelectDatum(datum);
        }

        /// <summary>
        /// Work around rect height only update after one frame because of content size fitter
        ///     Using content size fitter because Entry size might change with design
        /// </summary>
        private IEnumerator CheckIfAlreadyReachedEnd()
        {
            yield return null;
            if (Container.GetHeightRectTransform() <= ScrollRect.GetHeightRectTransform())
            {
                TryTriggerReachEnd();
            }
        }

        public void ToggleFullLoading(bool state)
        {
            if (state)
            {
                EndReachedLoadingContainer.SetParent(null);
                EndReachedLoadingContainer.gameObject.SetActive(false);
                foreach (Transform t in Container)
                {
                    Destroy(t.gameObject);
                }
                _currentDisplaying = 0;
            }

            FullLoadingContainer.gameObject.SetActive(state);
        }
    }
}