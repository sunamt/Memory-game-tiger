using UnityEngine;
using System.Collections;

public class MemoryCard : MonoBehaviour {

	public int CardIndex;
	public int cardnumber;
	private Logic logic;
	private RandomCards randomC;
	private bool selected = false;
	Texture mainT;
	
	// Use this for initialization
	void Start () {
		
		logic = GameObject.Find("GameController").GetComponent<Logic>();
		randomC = GameObject.Find("CardHolder").GetComponent<RandomCards>();
		cardnumber = randomC.cardList [CardIndex];
		SetPicture ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPicture(){
		mainT = randomC.cardTex[cardnumber];
		GetComponent<Renderer>().materials[1].mainTexture = mainT;
	}
	
	public void Show(){
		if(!selected){
			selected = true;
			GetComponent<Animation>().Play("Flip_show");
			StartCoroutine(Wait());

		}
	}

	public void Hide(){
		
		GetComponent<Animation>().Play("Flip_hide");
		selected = false;
	}
	
	public void RemoveCard(){
		GetComponent<Animation>().Play("Flip_hide");
		StartCoroutine(Remove());
	}
	IEnumerator Remove(){
		yield return new WaitForSeconds (0.5f);
		Destroy(gameObject);
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (2);
		logic.CheckCards(this);
	}
}