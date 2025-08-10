using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This is a simplified script to display the recognized text.
public class VoskResultText : MonoBehaviour
{
    // A reference to the main Vosk Speech To Text component.
    public VoskSpeechToText VoskSpeechToText;

    // A reference to the UI Text element where the result will be displayed.
    public TextMeshProUGUI ResultText;

    void Start()
    {
        // Subscribe to the transcription result event.
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    // This method is called when Vosk has a final recognition result.
    private void OnTranscriptionResult(string jsonResult)
    {
        // The result is a JSON string. We parse it using the helper class.
        var result = new RecognitionResult(jsonResult);

        // We only care about the first, most likely phrase.
        if (result.Phrases.Length > 0)
        {
            // Set the UI Text to display the recognized text.
            ResultText.text = result.Phrases[0].Text;

            // --- THIS IS WHERE YOU ADD YOUR GAME LOGIC ---
            // You can now check the recognized text for keywords.
            // For example:
            if (result.Phrases[0].Text.Contains("jump"))
            {
                Debug.Log("Player should jump!");
                // Add your player jump code here.
            }
            else if (result.Phrases[0].Text.Contains("open door"))
            {
                Debug.Log("Opening the door!");
                // Add your door opening code here.
            }
        }
    }
}