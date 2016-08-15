using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MainMenuButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button otherButton;  // reference to other Button.
    Button myButton;

    void Awake()
    {
        myButton = this.GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // sets other button not currently being pressed as the "unselect" sprite for the UI elements.
        otherButton.interactable = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // resets the other button to the "neutral" sprite when the button being pressed is released.
        otherButton.interactable = true;
    }

  

    void VoiceSelect()
    {
        ExecuteEvents.Execute<IPointerDownHandler>(myButton.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
       
    }

}
