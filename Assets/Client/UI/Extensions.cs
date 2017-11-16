using UnityEngine;

namespace Client.UI
{
    public static class Extensions
    {
        public static float GetHeightRectTransform(this Component monoBehaviour)
        {
            var rectTransform = monoBehaviour.GetComponent<RectTransform>();
            return rectTransform.rect.height;
        }
    }
}