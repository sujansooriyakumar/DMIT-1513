using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    // high strength
    // high speed build
    // high durability build

    public int strength, speed, durability;
    public WeaponType weaponType;
}

public enum WeaponType
{
    SWORD,
    SHIELD,
    STAFF
}
