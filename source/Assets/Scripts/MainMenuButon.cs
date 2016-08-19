using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenuButon : MonoBehaviour, IPointerDownHandler
{
    [Tooltip("The other Button that is not this button")]
    public Button otherButton;  // reference to other Button.

    Button myButton;        // button attached to this script
    
    private bool isGazing;   // bool to check if we are currently gazing on this object.
   


    void Awake()
    {
        myButton = this.GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // sets other button not currently being pressed as the "unselect" sprite for the UI elements.
        otherButton.interactable = false;
        myButton.Select();
    }


    void GazeEntered()
    {   
        // Sets the gaze upon bool true
        isGazing = true;
    }

    void GazeExited()
    {
        isGazing = false;

        // Toggle the disabled button back to neutral and the highlighted button back to neutral as well.
        otherButton.interactable = true;
        myButton.interactable = false;
        myButton.interactable = true;

    }

    public void TapSelected()
    {
        if(isGazing)
        {
            // If gazing on button and tapped, highlight it and disable the non-selected/gazed upon button.
            myButton.Select();
            otherButton.interactable = false;
        }
    }
  

    void VoiceSelect()
    {
        if(isGazing)
        {
            // Executes the OnPointerDown function manually since we are using a voice command to execute.  But only if we're currently gazing on the button to execute on.
            ExecuteEvents.Execute<IPointerDownHandler>(myButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        }
    }

}
