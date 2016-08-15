﻿using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour 
{
    public static GazeGestureManager Instance { get; private set; }

    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;
	
	void Start () 
	{
        Instance = this;

        // Set up a GestureRecognizer to detect select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect");
            }
        };
        recognizer.StartCapturingGestures();
	}
	
	
	void Update () 
	{
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Raycast into the world based on the user's head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }

        // If the focused object changed this frame, start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
	
	}
	
}
