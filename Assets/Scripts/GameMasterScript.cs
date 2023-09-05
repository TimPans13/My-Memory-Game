using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Image> objects;
    [SerializeField] Text scoreText;
    [SerializeField] Text attemptsText;
    //[SerializeField] ButtonScript button;
    ButtonScript button=new ButtonScript();


    private List<Sprite> distribution = new List<Sprite>();

    private CardScript firstCard;
    private CardScript secondCard;

    private int score = 0;
    private int attempts = 0;



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

    public bool canOpen
    {
        get { return secondCard == null; }
    }
    public void GetCard(CardScript newCard)
    {
        if (firstCard == null)
        {
            firstCard = newCard;
        }
        else
        {
            secondCard = newCard;
            Sprite firstSprite = firstCard.GetSprite();
            Sprite secondSprite = secondCard.GetSprite();
            StartCoroutine(IsEquals(firstSprite, secondSprite));
        }
    }
    private IEnumerator IsEquals(Sprite firstSprite, Sprite secondSprite)
    {

        if (firstSprite.Equals(secondSprite)) {
            Debug.Log("win");
            score++; 
            scoreText.text = "Score : " + score;
            if (score > 3) 
            {
                yield return new WaitForSeconds(0.5f); 
                button.Restart(); 
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f); 

            firstCard.Close();
            secondCard.Close();
        }

        attempts++;
        attemptsText.text = "Attempts : " + attempts;

        firstCard = null;
        secondCard = null;
    }

}
