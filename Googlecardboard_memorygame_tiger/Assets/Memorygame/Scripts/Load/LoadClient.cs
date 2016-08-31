using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadClient : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndLoad());
	}

	private IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene ("start_menu");
	}

}
