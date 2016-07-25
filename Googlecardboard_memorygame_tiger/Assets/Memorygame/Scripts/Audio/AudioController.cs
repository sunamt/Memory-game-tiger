using UnityEngine;

public class AudioController : MonoBehaviour {

	public static AudioController Instance { get; private set; }

	private AudioSource _thisAudioSource;
	[SerializeField]
	private AudioClip _cardFlipSound;
	[SerializeField]
	private AudioClip _pairSuccesSound;
	[SerializeField]
	private AudioClip _winningSound;

	void Awake()
	{
		Instance = this;

		_thisAudioSource = GetComponent<AudioSource>();
	}

	public void PlayCardFlipSound()
	{
		_thisAudioSource.PlayOneShot (_cardFlipSound);
	}

	public void PlayPairSuccesSound()
	{
		_thisAudioSource.PlayOneShot (_pairSuccesSound);
	}

	public void PlayWinningSound()
	{
		_thisAudioSource.PlayOneShot (_winningSound);
	}
}
