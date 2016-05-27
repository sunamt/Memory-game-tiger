using System;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int CardIndex;
    public int cardnumber;

    private bool selected = false;

    private MeshRenderer myRenderer;
    private Animation myAnimation;
    private MeshFilter myFilter;

    public Action<MemoryCard> onSelect = (MemoryCard card) => { };

    private void Awake()
    {
        myAnimation = GetComponent<Animation>();
        myRenderer = GetComponent<MeshRenderer>();
        myFilter = GetComponent<MeshFilter>();
    }

    public void SetCardFaceMaterial(Material material)
    {
        Material[] materialsList = myRenderer.sharedMaterials;
        materialsList[1] = material;

        myRenderer.sharedMaterials = materialsList;
    }

    public void SetCardBackfaceMaterial(Material material)
    {
        Material[] materialsList = myRenderer.sharedMaterials;
        materialsList[0] = material;

        myRenderer.sharedMaterials = materialsList;
    }

    public void SetCardMesh(Mesh mesh)
    {
        myFilter.sharedMesh = mesh;
    }

    public void Show()
    {
        if (!selected)
        {
            selected = true;
            myAnimation.Play("Flip_show");
            Invoke("SelectCard", 2f);
        }
    }

    public void Hide()
    {

        myAnimation.Play("Flip_hide");
        selected = false;
    }

    public void RemoveCard()
    {
        myAnimation.Play("Flip_hide");
        Destroy(gameObject, 0.5f);
    }

    private void SelectCard()
    {
        onSelect(this);
    }
}