using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RevealSky : MonoBehaviour
{
    public int clearSkyNbr = 0;

    private List<Transform> itemsForRandomHide;
    private int amount = 0;

    private void Awake()
    {
        itemsForRandomHide = GetComponentsInChildren<Transform>().ToList();                                //building list of objects
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

            itemsForRandomHide[itemId].gameObject.SetActive(false);                    // hide the hexagon
            itemsForRandomHide.RemoveAt(itemId);    //removes from list
        }
    }
}