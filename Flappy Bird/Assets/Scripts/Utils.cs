using UnityEngine;
using UnityEngine.UI;

public static class Utils
{
    public static void SetText(GameObject gameObject, string text)
    {
        Text textComponent = gameObject.GetComponent<Text>();
        if (textComponent == null) return;
        textComponent.text = text;
    }
    public static float getAnglesFromVector(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0)
            angle += 360;
        return angle;
    }
}
