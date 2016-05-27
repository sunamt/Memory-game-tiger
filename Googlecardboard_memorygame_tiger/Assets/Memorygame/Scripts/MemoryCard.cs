using System.Collections;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{

    public int CardIndex;
    private Logic logic;
    private bool selected = false;

    private MeshRenderer myRenderer;
    private Animation myAnimation;
    private MeshFilter myFilter;

    private void Awake()
    {
        myAnimation = GetComponent<Animation>();
        myRenderer = GetComponent<MeshRenderer>();
        myFilter = GetComponent<MeshFilter>();
    }

    // Use this for initialization
    void Start()
    {

        logic = GameObject.Find("GameController").GetComponent<Logic>();
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
            StartCoroutine(Wait());
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        logic.CheckCards(this);
    }
}