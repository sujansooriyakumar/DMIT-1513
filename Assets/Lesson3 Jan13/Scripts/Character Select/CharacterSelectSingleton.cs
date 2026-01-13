using UnityEngine;

public class CharacterSelectSingleton : MonoBehaviour
{
    public static CharacterSelectSingleton Instance;
    public CharacterSO selectedCharacter;

    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void SetCharacter(CharacterSO character_) { selectedCharacter= character_; }
    public CharacterSO GetCharacter() { return selectedCharacter; }
}
