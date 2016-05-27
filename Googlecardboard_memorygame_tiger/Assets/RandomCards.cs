using System.Collections.Generic;
using UnityEngine;

public class RandomCards : MonoBehaviour
{
    private List<int> uniqueNumbers;

    public Material skinAtlasMaterial;
    public Material backfaceMaterial;

    public Mesh[] cardMeshes;

    [HideInInspector]
    public MemoryCard[] cardsInstances;

    void Awake()
    {
        cardsInstances = GetComponentsInChildren<MemoryCard>();

        uniqueNumbers = new List<int>();


        GenerateRandomList();
    }

    public void GenerateRandomList()
    {
        int numberOfPairs = transform.childCount / 2;
        List<int> cardList = new List<int>();

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

        for (int i = 0; i < cardsInstances.Length; i++)
        {
            cardsInstances[i].cardnumber = cardList[i];
            cardsInstances[i].SetCardMesh(cardMeshes[i]);
            cardsInstances[i].SetCardFaceMaterial(skinAtlasMaterial);
        }
    }
}