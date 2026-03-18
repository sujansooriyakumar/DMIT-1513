using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public GameObject uiObject;
    public TMP_Text speakerNameDisplay;
    public TMP_Text dialogDisplay;
    public Image portrait;
    public float typingSpeed = 0.2f;
    public InputAction continueDialog;
    private bool inputRecieved = false;
    public event Action onMessageComplete;

    private void Awake()
    {
        continueDialog.Enable();
        continueDialog.performed += ContinueDialog;
    }

    public void ContinueDialog(InputAction.CallbackContext c)
    {
        inputRecieved = true;
    }

    public void InitiateDialog(DialogLine dialogLine)
    {
        uiObject.SetActive(true);
        speakerNameDisplay.text = dialogLine.speakerName;
        portrait.sprite = dialogLine.portrait;
        StartCoroutine(DisplayDialog(dialogLine));
    }

    private IEnumerator DisplayDialog(DialogLine dialogLine)
    {
        dialogDisplay.text = "";
        string dialogText = dialogLine.dialogText;
        for(int i = 0; i < dialogText.Length; i++)
        {
            dialogDisplay.text += dialogText[i];
            dialogDisplay.ForceMeshUpdate();
            yield return new WaitForSeconds(typingSpeed);
        }
        inputRecieved = false;
        yield return new WaitUntil(() => inputRecieved);
        uiObject.SetActive(false);
        onMessageComplete?.Invoke();
        yield return null;
    }
}

[Serializable]
public class DialogLine
{
    public string speakerName;
    public string dialogText;
    public Sprite portrait;
}
