﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryCard : MonoBehaviour, ICardboardGazeResponder, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int CardIndex;
    public int cardnumber;

    public Action<MemoryCard> onSelect = (MemoryCard card) => { };

    private bool selected = false;

    private MeshRenderer myRenderer;
    private Animation myAnimation;
    private MeshFilter myFilter;

    private MeshContainer meshContainer;


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

    public void SetCardMesh(MeshContainer mContainer)
    {
        meshContainer = mContainer;
        myFilter.sharedMesh = mContainer.defaultMesh;
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

    public void SetGazedAt(bool gazedAt)
    {
        myFilter.sharedMesh = gazedAt ? meshContainer.selectedMesh : meshContainer.defaultMesh;
    }

    #region ICardboardGazeResponder implementation

    void ICardboardGazeResponder.OnGazeEnter()
    {
        SetGazedAt(true);
    }

    void ICardboardGazeResponder.OnGazeExit()
    {
        SetGazedAt(false);
    }

    void ICardboardGazeResponder.OnGazeTrigger()
    {
        Show();
    }

    #endregion

    #region Pointer interfaces implementation

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SetGazedAt(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        SetGazedAt(false);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Show();
    }

    #endregion
}