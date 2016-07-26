// Copyright 2015 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class CardboardReticle : MonoBehaviour, ICardboardGazePointer
{
	public bool interactive;

	private GameObject targetObj;
   

	private Image m_reticle;


	void Start ()
	{
		m_reticle = GetComponent<Image> ();
	}

	void OnEnable ()
	{
		GazeInputModule.cardboardPointer = this;
	}

	void OnDisable ()
	{
		if (GazeInputModule.cardboardPointer == this) {
			GazeInputModule.cardboardPointer = null;
		}
	}

	void Update ()
	{
		
	}

    public void OnMemoryCardGaze(float ntime)
    {
        m_reticle.fillAmount = Mathf.Clamp01(ntime);
    }

	/// This is called when the 'BaseInputModule' system should be enabled.
	public void OnGazeEnabled ()
	{

	}

	/// This is called when the 'BaseInputModule' system should be disabled.
    public void OnGazeDisabled ()
	{
        
	}

	/// Called when the user is looking on a valid GameObject. This can be a 3D
	/// or UI element.
	///
	/// The camera is the event camera, the target is the object
	/// the user is looking at, and the intersectionPosition is the intersection
	/// point of the ray sent from the camera on the object.
	public void OnGazeStart (Camera camera, GameObject targetObject, Vector3 intersectionPosition,
	                         bool isInteractive)
	{
		m_reticle.enabled = interactive ? true : false;

		if (isInteractive) {
			m_reticle.enabled = interactive ? true : false;
		} else {
			m_reticle.enabled = false;
		}
         
	}

	/// Called every frame the user is still looking at a valid GameObject. This
	/// can be a 3D or UI element.
	///
	/// The camera is the event camera, the target is the object the user is
	/// looking at, and the intersectionPosition is the intersection point of the
	/// ray sent from the camera on the object.
	public void OnGazeStay (Camera camera, GameObject targetObject, Vector3 intersectionPosition,
	                        bool isInteractive)
	{

	}

	/// Called when the user's look no longer intersects an object previously
	/// intersected with a ray projected from the camera.
	/// This is also called just before **OnGazeDisabled** and may have have any of
	/// the values set as **null**.
	///
	/// The camera is the event camera and the target is the object the user
	/// previously looked at.
	public void OnGazeExit (Camera camera, GameObject targetObject)
	{
		m_reticle.enabled = interactive ? false : true;  
	}

	/// Called when the Cardboard trigger is initiated. This is practically when
	/// the user begins pressing the trigger.
	public void OnGazeTriggerStart (Camera camera)
	{
		// Put your reticle trigger start logic here :)
	}

	/// Called when the Cardboard trigger is finished. This is practically when
	/// the user releases the trigger.
	public void OnGazeTriggerEnd (Camera camera)
	{
		// Put your reticle trigger end logic here :)
	}

	public void GetPointerRadius(out float innerRadius, out float outerRadius) {

		innerRadius = 0.0f;
		outerRadius = 0.5f;
	}

	
}