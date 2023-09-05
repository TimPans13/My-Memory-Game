using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Image> objects;

    private List<Sprite> distribution = new List<Sprite>();

    private CardScript firstCard;
    private CardScript secondCard;


    void Start()
    {
        if ((sprites.Count * 2) == objects.Count)
        {
            foreach (Sprite sprite in sprites)
            {
                distribution.Add(sprite);
                distribution.Add(sprite);
            }
        }
        else Debug.Log("Error, Sprites and objects are not equal");


        ShuffleList(distribution);

        for(int i=0;i<distribution.Count; i++)
        {
            objects[i].sprite = distribution[i];
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void IsEquals(CardScript newCard)
    {
        if (firstCard == null)
        {
            firstCard = newCard;
        }
        else
        {
            secondCard = newCard;
        }
    }
}
