using UnityEngine;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{

    private MemoryCard[] cards = new MemoryCard[2];
    private int setsofcards;
    private int nroftries = 0;
    public Text wintext;
    private RandomCards randomC;
    private RevealSky revSky;
    private GameObject nextL;

    void Start()
    {
        wintext.text = "";
        randomC = GameObject.Find("CardHolder").GetComponent<RandomCards>();
        revSky = GameObject.Find("ChickenLitleSphere").GetComponent<RevealSky>();
        nextL = GameObject.Find("NextLevelButton");
        nextL.SetActive(false);

        setsofcards = transform.childCount;


        foreach (MemoryCard card in randomC.cardsInstances)
            card.onSelect += CheckCards;
    }

    public void CheckCards(MemoryCard mc)
    {
        if (cards[0] == null)
            cards[0] = mc;
        else
        {
            cards[1] = mc;
            nroftries++;

            if (cards[0].cardnumber == cards[1].cardnumber)
                CardsMatching();
            else
                CardsNotMatching();

            cards[0] = null;
            cards[1] = null;
        }
    }

    void CardsMatching()
    {
        cards[0].RemoveCard();
        cards[1].RemoveCard();
        revSky.RunHide();

        setsofcards--;
        if (setsofcards == 0)
            GameEnd();
    }
    void CardsNotMatching()
    {
        cards[0].Hide();
        cards[1].Hide();
    }
    void GameEnd()
    {
        wintext.text = "Du vandt i " + nroftries + " Træk";
        nextL.SetActive(true);
    }
}
