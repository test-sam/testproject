using UnityEngine;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public class Interactible : MonoBehaviour
{


    //private Material[] defaultMaterials;


    void Start()
    {
        //defaultMaterials = GetComponent<Renderer>().materials;

        // Add a BoxCollider if the interactible does not contain one.
        //Collider collider = GetComponentInChildren<Collider>();
        //if (collider == null)
        //{
        //    gameObject.AddComponent<BoxCollider>();
        //}

       
    }

    

    

    void GazeEntered()
    {
        //for (int i = 0; i < defaultMaterials.Length; i++)
        //{
        //    // highlight the material when gaze enters.
        //    defaultMaterials[i].SetFloat("_Highlight", .25f);
        //}
    }

    void GazeExited()
    {
        //for (int i = 0; i < defaultMaterials.Length; i++)
        //{
        //    // remove highlight on material when gaze exits.
        //    defaultMaterials[i].SetFloat("_Highlight", 0f);
        //}
    }

    void OnSelect()
    {
        //for (int i = 0; i < defaultMaterials.Length; i++)
        //{
        //    defaultMaterials[i].SetFloat("_Highlight", .5f);
        //}

        
        // Handle the OnSelect by sending a PerformTagAlong message.

    }
}