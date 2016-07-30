using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartMenu : MonoBehaviour {

	private void ShowStartMenu()
	{
		//SceneManager.LoadScene ("start_menu");
        transform.parent.gameObject.SetActive(false);
	}
}
