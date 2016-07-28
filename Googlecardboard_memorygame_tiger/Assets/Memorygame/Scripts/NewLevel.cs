using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewLevel : MonoBehaviour, ICardboardGazeResponder, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string levelToLoad;

    void Start()
    {
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
		GetComponent<Text>().color = gazedAt ? Color.green : Color.white;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
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
        NextLevel();
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
        NextLevel();
    }

    #endregion
}

