using System.Collections.Generic;
using UnityEngine;

public class RandomCards : MonoBehaviour
{

    public int nrOfCards;
    public int numberOfPairs;
    private List<int> uniqueNumbers;
    public List<int> cardList;
    public Texture[] cardTex;

    public Material skinAtlasMaterial;
    public Material backfaceMaterial;

    public Mesh[] cardMeshes;

    public Material cardMaterialSource;
    private Material[] cardMaterialsPool;

    private MemoryCard[] cardsInstances;

    void Awake()
    {
        cardMaterialsPool = new Material[cardTex.Length];
        for (int i = 0; i < cardTex.Length; i++)
            cardMaterialsPool[i] = new Material(cardMaterialSource);

        cardsInstances = GetComponentsInChildren<MemoryCard>();


        nrOfCards = this.transform.childCount;
        numberOfPairs = nrOfCards / 2;

        uniqueNumbers = new List<int>();
        cardList = new List<int>();

        GenerateRandomList();
    }
    void Start()
    {

    }

    public void GenerateRandomList()
    {
        //first card
        for (int i = 0; i < numberOfPairs; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < numberOfPairs; i++)
        {
            int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            cardList.Add(ranNum);
            uniqueNumbers.Remove(ranNum);
        }

        //second maching card
        for (int i = 0; i < numberOfPairs; i++)
        {
            uniqueNumbers.Add(i);
        }
        for (int i = 0; i < numberOfPairs; i++)
        {
            int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
            cardList.Add(ranNum);
            uniqueNumbers.Remove(ranNum);
        }
    }
}