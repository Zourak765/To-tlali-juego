using UnityEngine;

public class SimpleSlider : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    public void SetValue(float _normalizedValue)
    {
        Vector3 targetScale = targetTransform.localScale;
        targetScale.x = _normalizedValue;
        
        targetTransform.localScale = targetScale;
    }
}
