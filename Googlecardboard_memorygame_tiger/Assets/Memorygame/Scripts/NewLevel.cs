using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour, ICardboardGazeResponder {

	public string levelToLoad;

		void Start() {
			SetGazedAt(false);
		}

		void LateUpdate() {
			Cardboard.SDK.UpdateState();
			if (Cardboard.SDK.BackButtonPressed) {
				Application.Quit();
			}
		}

		public void SetGazedAt(bool gazedAt) {
		GetComponent<Text>().color = gazedAt ? Color.white : Color.green;
		}


		public void ToggleVRMode() {
			Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
		}

		public void ToggleDistortionCorrection() {
			switch(Cardboard.SDK.DistortionCorrection) {
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

		public void ToggleDirectRender() {
			Cardboard.Controller.directRender = !Cardboard.Controller.directRender;
		}

		public void NextLevel (){
		SceneManager.LoadScene (levelToLoad);
		}

		/*public void Turn() {
			if(GetComponent<MemoryCard>() != null){
				GetComponent<MemoryCard>().Show();
			}

		}*/

		#region ICardboardGazeResponder implementation

		/// Called when the user is looking on a GameObject with this script,
		/// as long as it is set to an appropriate layer (see CardboardGaze).
		public void OnGazeEnter() {
			SetGazedAt(true);
		}

		/// Called when the user stops looking on the GameObject, after OnGazeEnter
		/// was already called.
		public void OnGazeExit() {
			SetGazedAt(false);
		}

		// Called when the Cardboard trigger is used, between OnGazeEnter
		/// and OnGazeExit.
		public void OnGazeTrigger() {
			NextLevel ();
		}

		#endregion
	}
	
