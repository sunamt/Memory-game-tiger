using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadClient : MonoBehaviour {

	[SerializeField]
	private float _animationTime;

	// Use this for initialization
	void Start () {
		StartCoroutine (WaitAndLoad());
	}

	private IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(_animationTime);
		SceneManager.LoadScene ("client_Scene");
	}

}
