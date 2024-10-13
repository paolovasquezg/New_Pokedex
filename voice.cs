using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.Windows.Speech;  // For keyword recognition
using System.Collections.Generic;
using System.Linq;

public class ControladorPorVoz : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> wordToAction;

    void Start()
    {
        wordToAction = new Dictionary<string, System.Action>();

        // Add your keywords and associated actions
        wordToAction.Add("inicio", ChangeSceneToInicio);  // Keyword "inicio" will change the scene

        // Initialize the keyword recognizer with your dictionary keys
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;

        // Start listening for the keywords
        keywordRecognizer.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs args)
    {
        // Check if the recognized word has an associated action
        if (wordToAction.ContainsKey(args.text))
        {
            wordToAction[args.text].Invoke();
        }
    }

    // Action to change the scene to "Inicio"
    private void ChangeSceneToInicio()
    {
        SceneManager.LoadScene("lapras"); // Make sure the scene is added in the build settings
    }
}
