using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewLevel : GazeInteractiveObject
{
    public string levelToLoad;
	private Text text;

	private void Awake()
	{
		text = GetComponent<Text> ();
	}

    void Start()
    {
		text.color = Color.white;
    }

	public override void OnGazeEntered()
	{
		base.OnGazeEntered ();

		text.color = Color.green ;
	}

	public override void OnGazeExited()
	{
		base.OnGazeExited ();

		text.color = Color.white;
	}		

    public override void Activate()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

