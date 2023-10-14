using System.Collections;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject textDialogue;

    private ResponseHandler responseHandler;
    private TypeWritterEffect typeWritterEffect;
    private void Start()
    {
        typeWritterEffect = GetComponent<TypeWritterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        closeDialogueBox();
        showDialogue(textDialogue);
    }

    public void showDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWritterEffect.Run(dialogue, textLabel);

            if (i == dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            closeDialogueBox();
        }
    }

    private void closeDialogueBox ()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
