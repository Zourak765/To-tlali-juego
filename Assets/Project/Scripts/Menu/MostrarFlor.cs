using UnityEngine;
using UnityEngine.EventSystems;

public class MostrarFlor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject flor; 

    void Start()
    {
        flor.SetActive(false); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        flor.SetActive(true); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        flor.SetActive(false); 
    }
}