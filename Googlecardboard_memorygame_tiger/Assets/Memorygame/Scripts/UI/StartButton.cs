using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	private Button _thisStartButton;

	void Awake()
	{
		_thisStartButton = GetComponent<Button> ();
	}

	void Start()
	{
		_thisStartButton.onClick.AddListener(ClickedOnButton);
	}

	private void ClickedOnButton()
	{
		SceneManager.LoadScene ("Level_1");
	}

}
