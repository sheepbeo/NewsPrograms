using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Utils.Editor
{
    public class UiRaycastHelper
    {
        [MenuItem("Tools/UI/Turn Off Ray Cast #C")]
        public static void TurnOffRayCastSelected()
        {
            var objs = Selection.gameObjects;
            foreach (var obj in objs)
            {
                TurnOffRayCast(obj);
            }
        }

        [MenuItem("Tools/UI/Toggle Ray Cast Recursively #&C")]
        public static void TurnOffRaycastRecursively()
        {
            var objs = Selection.gameObjects;
            foreach (var obj in objs)
            {
                TurnOffRayCastRecursively(obj);
            }
        }

        private static void TurnOffRayCastRecursively(GameObject obj)
        {
            TurnOffRayCast(obj);

            foreach (Transform child in obj.transform)
            {
                TurnOffRayCastRecursively(child.gameObject);
            }
        }

        private static void TurnOffRayCast(GameObject obj)
        {
            var graphic = obj.GetComponent<Graphic>();
            if (graphic != null)
            {
                // Ignore some components that actually need raycasting
                if (obj.GetComponent<Button>() != null
                    || obj.GetComponent<Mask>() != null
                    || obj.GetComponent<InputField>() != null)
                {
                    return;
                }

                graphic.raycastTarget = false;
            }
        }
    }
}
