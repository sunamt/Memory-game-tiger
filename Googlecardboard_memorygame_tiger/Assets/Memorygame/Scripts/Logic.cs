﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
	public static Logic Instance { get; private set; }

	public CardboardReticle timer_rectile;

	public GameObject WinningConditionGO;
	public NewLevel nextL;

    private MemoryCard[] cards = new MemoryCard[2];
	public static int setsofcards;
    private int nroftries = 0;
    public Text wintext;

    private RandomCards randomC;
    private RevealSky revSky;


    private void Awake()
    {
        randomC = FindObjectOfType<RandomCards>();
        revSky = FindObjectOfType<RevealSky>();

		Instance = this;
    }

    private void Start()
    {
        wintext.text = "";

        setsofcards = transform.childCount;

        foreach (MemoryCard card in randomC.cardsInstances)
        {
            card.onSelect += CheckCards;
            card.onGazeUpdate += timer_rectile.OnMemoryCardGaze;
        }

		if(nextL !=null )
			nextL.onGazeUpdate += timer_rectile.OnMemoryCardGaze;
    }

    public void CheckCards(MemoryCard mc)
    {
        if (cards[0] == null)
            cards[0] = mc;
        else
        {
            cards[1] = mc;
            nroftries++;

            if (cards[0].cardnumber == cards[1].cardnumber)
                CardsMatching();
            else
                CardsNotMatching();

            cards[0] = null;
            cards[1] = null;
        }
    }

    void CardsMatching()
    {
        cards[0].RemoveCard();
        cards[1].RemoveCard();
        revSky.RunHide();

        setsofcards--;
		if (setsofcards == 0) {
			GameEnd ();
		} else {
			AudioController.Instance.PlayPairSuccesSound ();
		}

    }
    void CardsNotMatching()
    {
        cards[0].Hide();
        cards[1].Hide();
    }
    void GameEnd()
    {
		AudioController.Instance.PlayWinningSound ();

		WinningConditionGO.SetActive (true);
		wintext.text = "You won in " + nroftries + " moves";
    }


    #region utils

    public void ToggleVRMode()
    {
        Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
    }


    public void ToggleDirectRender()
    {
        Cardboard.Controller.directRender = !Cardboard.Controller.directRender;
    }

    public void ToggleDistortionCorrection()
    {
        switch (Cardboard.SDK.DistortionCorrection)
        {
            case Cardboard.DistortionCorrectionMethod.Unity:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.Native;
                break;
            case Cardboard.DistortionCorrectionMethod.Native:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.None;
                break;
            case Cardboard.DistortionCorrectionMethod.None:
            default:
                Cardboard.SDK.DistortionCorrection = Cardboard.DistortionCorrectionMethod.Unity;
                break;
        }
    }

    void LateUpdate()
    {
        Cardboard.SDK.UpdateState();
        if (Cardboard.SDK.BackButtonPressed)
        {
            Application.Quit();
        }

		#if UNITY_EDITOR
		if (Input.GetKeyUp (KeyCode.Space)) {
			GameEnd ();
		}
		#endif
    }

    #endregion
}
