using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class OutlineAnimator : MonoBehaviour 
{
	public Color animateFrom;
	public Color animateTo;

	public float frequency = 1f;

	private Outline m_outline;
	private Graphic m_graphic;

	private void Start()
	{
		m_outline = GetComponent<Outline> ();
		m_graphic = GetComponent<Graphic> ();
	}

	private void Update()
	{
		Color currentColor = Color.Lerp (animateFrom, animateTo, Mathf.Sin (Time.time * frequency) * 0.5f + 0.5f);
		m_outline.effectColor = currentColor;

		m_graphic.SetVerticesDirty ();
	}
}
