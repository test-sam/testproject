using UnityEngine;
using HoloToolkit.Unity;


// This gazingmanager determines the location of the user's gaze, hit position and normals.

public class GazingManager : Singleton<GazingManager>
{
    [Tooltip("Maximum gaze distance for calculating a hit.")]
    public float MaxGazeDistance = 5.0f;

    [Tooltip("Select the layers raycast should target.")]
    public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;

    // Physics.Raycast result is true if it hits a hologram.
    public bool Hit { get; private set; }

    // HitInfo property gives access to RaycastHit public members.
    public RaycastHit HitInfo { get; private set; }

    // Position of the user's gaze.
    public Vector3 Position { get; private set; }

    // RaycastHit Normal direction.
    public Vector3 Normal { get; private set; }

    private GazeStabilizer gazeStabilizer;
    private Vector3 gazeOrigin;
    private Vector3 gazeDirection;

    void Awake()
    {
        gazeStabilizer = GetComponent<GazeStabilizer>();
    }
	
	// Update is called once per frame
	private void Update () 
	{
        // Assign Camera's main transform position to gazeOrigin.
        gazeOrigin = Camera.main.transform.position;

        // Assign Camera's main transform forward to gazeDirection.
        gazeDirection = Camera.main.transform.forward;

        // Using gazeStabilizer, call function UpdateHeadStability.  Pass in gazeOrigin and Cameras main transform rotation.
        gazeStabilizer.UpdateHeadStability(gazeOrigin, Camera.main.transform.rotation);

        // Using gazeStabilitzer, get the StableHeadPosition and assign it to gazeOrigin.
        gazeOrigin = gazeStabilizer.StableHeadPosition;

        UpdateRaycast();
	}


    private void UpdateRaycast()
    {
        RaycastHit hitInfo;

        // Shed Raycast and store return value in public property Hit.  Pass in origin as gazeOrigin and direction as gazeDirection. Collect the ray information in hitInfo. Pass in MaxGazeDistance and RaycastLayerMask.
        Hit = Physics.Raycast(gazeOrigin, gazeDirection, out hitInfo, MaxGazeDistance, RaycastLayerMask);

        // Assign hitInfo variable to the HitInfo public property so other classes can access it.
        HitInfo = hitInfo;

        if (Hit)
        {
            // If raycast hit a hologram

            // Assign property Position to be the hitInfo point.
            Position = hitInfo.point;
            // Assign property Normal to be the hitInfo normal.
            Normal = hitInfo.normal;
        }
        else
        {
            // If raycast did not hit a hologram
            // Save defaults....

            // Assign Position to be gazeOrigin plus MaxGazeDistance times gazeDirection.
            Position = gazeOrigin + (gazeDirection * MaxGazeDistance);
            // Assign Normal to be the user's gazeDirection.
            Normal = gazeDirection;
        }

    }

	
}
