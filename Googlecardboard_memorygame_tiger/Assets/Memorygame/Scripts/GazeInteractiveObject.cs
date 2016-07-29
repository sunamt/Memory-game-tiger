using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class GazeInteractiveObject : MonoBehaviour, ICardboardGazeResponder, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
{
	public Action<float> onGazeUpdate = (float time) => { };

	private float m_gazeTimer = 0f;
	private bool m_isGazed = false;
	private float gazeDelay = 1.5f;

	protected void Update()
	{
		if(m_isGazed)
		{
			m_gazeTimer += Time.deltaTime;
			onGazeUpdate(m_gazeTimer / gazeDelay);
		}

		if(m_gazeTimer >= gazeDelay)
		{
			Activate ();
		}
	}

	#region virtual functions
	public virtual void OnGazeEntered()
	{
		m_gazeTimer = 0f;
		m_isGazed = true;
	}

	public virtual void OnGazeExited()
	{
		m_gazeTimer = 0f;
		m_isGazed = false;
	}

	public virtual void Activate()
	{

	}
	#endregion

	#region ICardboardGazeResponder implementation

	void ICardboardGazeResponder.OnGazeEnter()
	{
		OnGazeEntered ();
	}

	void ICardboardGazeResponder.OnGazeExit()
	{
		OnGazeExited ();
	}

	void ICardboardGazeResponder.OnGazeTrigger()
	{
		Activate ();
	}

	#endregion

	#region Pointer interfaces implementation

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		OnGazeEntered ();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		OnGazeExited ();
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		Activate ();
	}

	#endregion
}
