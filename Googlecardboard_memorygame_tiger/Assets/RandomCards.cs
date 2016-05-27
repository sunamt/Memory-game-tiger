using System.Collections.Generic;
using UnityEngine;

public class MeshContainer
{
    public int index = 0;

    public Mesh defaultMesh;
    public Mesh selectedMesh;
}

public class RandomCards : MonoBehaviour
{
    public Texture2D[] faceTexturesPack;

    public Mesh[] cardMeshes;
    private Dictionary<int, MeshContainer> meshPool = new Dictionary<int, MeshContainer>();


    [HideInInspector]
    public MemoryCard[] cardsInstances;

    private Rect[] atlasRects;
    private Material skinAtlasMaterial;
    private Material backfaceMaterial;

    private int ATLAS_TEX_COUNT = 8;
    private int ATLAS_TEX_SIZE = 256;

    private void Awake()
    {
        cardsInstances = GetComponentsInChildren<MemoryCard>();

        Texture2D atlasTexture = new Texture2D(2048, 2048, TextureFormat.RGB24, true, true);
        atlasTexture.wrapMode = TextureWrapMode.Clamp;

        for (int i = 0; i < transform.childCount / 2; i++)
        {
            int row = i / ATLAS_TEX_COUNT;
            int column = i % ATLAS_TEX_COUNT;

            Color32[] colors = faceTexturesPack[i].GetPixels32();
            atlasTexture.SetPixels32(column * ATLAS_TEX_SIZE, (ATLAS_TEX_COUNT - row - 1) * ATLAS_TEX_SIZE, ATLAS_TEX_SIZE, ATLAS_TEX_SIZE, colors);
        }

        atlasTexture.Apply(true, true);

        skinAtlasMaterial = new Material(Shader.Find("Unlit/Texture"));
        skinAtlasMaterial.mainTexture = atlasTexture;
    }

    private void Start()
    {
        GenerateRandomList();
    }

    private void GenerateRandomList()
    {
        int numberOfPairs = transform.childCount / 2;

        List<int> cardList = new List<int>();
        List<int> uniqueNumbers = new List<int>();

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


        // generate colors
        int lenght = cardMeshes[0].vertexCount;

        Color32[] defaultColorsBuffer = new Color32[lenght];
        Color32[] selectedColorsBuffer = new Color32[lenght];

        for (int i = 0; i < lenght; i++)
        {
            defaultColorsBuffer[i] = Color.white;
            selectedColorsBuffer[i] = Color.grey;
        }


        for (int i = 0; i < cardsInstances.Length; i++)
        {
            if (!meshPool.ContainsKey(cardList[i]))
            {
                MeshContainer mContainer = new MeshContainer();
                mContainer.defaultMesh = Instantiate(cardMeshes[cardList[i]]);
                mContainer.selectedMesh = Instantiate(cardMeshes[cardList[i]]);

                mContainer.defaultMesh.colors32 = defaultColorsBuffer;
                mContainer.selectedMesh.colors32 = selectedColorsBuffer;

                meshPool.Add(cardList[i], mContainer);
            }

            cardsInstances[i].cardnumber = cardList[i];
            cardsInstances[i].SetCardMesh(meshPool[cardList[i]]);
            cardsInstances[i].SetCardFaceMaterial(skinAtlasMaterial);
        }
    }
}