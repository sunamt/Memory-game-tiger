using System.Collections.Generic;
using UnityEngine;

public class RevealSky : MonoBehaviour
{

    public List<GameObject> itemsForRandomHide;
    private int amount = 0;
    public int clearSkyNbr = 0;


    void Start()
    {
        itemsForRandomHide = new List<GameObject>();                                //building list of objects

        foreach (Transform child in transform)
        {
            itemsForRandomHide.Add(child.gameObject);                           //adding child to list
        }
    }

    public void RunHide()
    {
        for (amount = 0; amount < clearSkyNbr; amount++)
            Hide();
    }

    public void Hide()
    {
        if (itemsForRandomHide != null && itemsForRandomHide.Count > 0)
        {
            int itemId = new System.Random().Next(itemsForRandomHide.Count);        //setting itemId as a random pick from list

            for (int i = 0; i < itemsForRandomHide.Count; i++)
            {
                if (i == itemId)
                {
                    itemsForRandomHide[i].gameObject.SetActive(false);                    // hide the hexagon
                    itemsForRandomHide.Remove(itemsForRandomHide[i].gameObject);    //removes from list
                }
            }
        }
    }
}