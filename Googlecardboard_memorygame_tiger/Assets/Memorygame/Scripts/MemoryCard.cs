using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryCard : GazeInteractiveObject
{
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
		if (selected)
			return;

       	selected = true;
       	myAnimation.Play("Flip_show");
		AudioController.Instance.PlayCardFlipSound ();
       	Invoke("SelectCard", 2f);
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

	public override void OnGazeEntered()
    {
		base.OnGazeEntered ();

        myFilter.sharedMesh = meshContainer.selectedMesh;
    }

	public override void OnGazeExited()
	{
		base.OnGazeExited ();

		myFilter.sharedMesh = meshContainer.defaultMesh;
	}

	public override void Activate()
	{
		Show();
	}
}