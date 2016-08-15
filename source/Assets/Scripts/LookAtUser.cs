using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookAtUser : MonoBehaviour 
{
    public GameObject cursor;
    public Vector3 cursorRotation;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        cursorRotation = cursor.transform.eulerAngles;
        rectTransform.rotation = Quaternion.Euler(0, cursorRotation.y, 0);

    }
	
}
