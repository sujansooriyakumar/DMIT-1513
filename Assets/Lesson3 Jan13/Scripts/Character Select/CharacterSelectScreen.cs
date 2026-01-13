using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScreen : MonoBehaviour
{
    // provided list of characters
    // reference to the parent
    // reference to the button object

    public CharacterSO[] characterList;
    public Transform parent;
    public GameObject buttonPrefab;

    [ContextMenu("debug")]
    public void InstantiateCharacterSelect()
    {
        // loop through our list of characters
        // instantiate a button under the provided parent
        // set up the image with our character portrait

        foreach(CharacterSO character in characterList)
        {
            GameObject tmp = Instantiate(buttonPrefab, parent);
            Image portrait = tmp.GetComponentsInChildren<Image>()[1];
            portrait.sprite = character.characterSprite;
            Button b = tmp.GetComponent<Button>();

            b.onClick.AddListener(delegate { SelectCharacter(character); });
          
        }
    }

    public void SelectCharacter(CharacterSO c)
    {
        // character selection is stored
        CharacterSelectSingleton.Instance.SetCharacter(c);
        // character select menu is disabled
        // transition to our gameplay screen


    }
}

