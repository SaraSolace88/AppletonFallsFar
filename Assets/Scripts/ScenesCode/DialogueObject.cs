using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialoge;
    [SerializeField] private Response[] responses;
    public string[] Dialogue => dialoge;

    public bool HasResponses => Responses != null && Responses.Length > 0;
    public Response[] Responses => responses;
}
