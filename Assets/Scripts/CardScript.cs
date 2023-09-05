using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] GameObject MainImage;
    [SerializeField] GameObject UnknowImage;
    [SerializeField] GameMasterScript script;

    public void OnPointerDown(PointerEventData pointerEventData)
    {

        if (UnknowImage.activeSelf && script.canOpen)  
        {
            UnknowImage.SetActive(false);
            script.GetCard(this);
        }
    }
    public Sprite GetSprite()
    {
        return MainImage.GetComponent<Image>().sprite;
    }
    public void Close()
    {
        UnknowImage.SetActive(true);
    }
}
