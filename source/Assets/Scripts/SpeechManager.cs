using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System.Linq;
using HoloToolkit.Unity;

public class SpeechManager : MonoBehaviour 
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {   
        // Adds Select voice command to recognizer
        keywords.Add("Select", () =>
        {
            var focusObject = GestureManager.Instance.FocusedObject;
            if (focusObject != null)
            {   
                // calls the method on the focused object
                focusObject.SendMessage("VoiceSelect");
            }
            
        });
        

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

}
