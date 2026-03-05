using UnityEngine;
using UnityEngine.Events;

public class DialogInteraction : MonoBehaviour
{
    public DialogLine dialogLine;
    public DialogBox dialogBox;
    public UnityEvent onDialogComplete;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == false) return;
        dialogBox.onMessageComplete += DialogComplete;
        dialogBox.InitiateDialog(dialogLine);
    }

    public void DialogComplete()
    {
        onDialogComplete?.Invoke();
    }
}
