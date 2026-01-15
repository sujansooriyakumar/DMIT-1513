using UnityEngine;

public class CharacterSelectSingleton : MonoBehaviour
{
    public static CharacterSelectSingleton Instance;
    public CharacterSO selectedCharacter;
    public string weaponType;
    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void SetCharacter(CharacterSO character_) { selectedCharacter= character_; }
    public CharacterSO GetCharacter() { return selectedCharacter; }

    public void SetWeaponType(string s) { weaponType = s; }
    public string GetWeaponType() { return weaponType; }
}
