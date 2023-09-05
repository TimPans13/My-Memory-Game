using UnityEngine;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject MainImage;
    [SerializeField] GameObject UnknowImage;

    public void OnPointerDown(PointerEventData pointerEventData)
    {

        if (UnknowImage.activeSelf) 
        {
            UnknowImage.SetActive(false);

            
        }
    }
    public void close()
    {
        UnknowImage.SetActive(true);
    }
}
