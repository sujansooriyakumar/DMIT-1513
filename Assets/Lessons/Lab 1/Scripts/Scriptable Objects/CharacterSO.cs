using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public GameObject prefab;

    public WeaponType weaponType;
}

public enum WeaponType
{
    SWORD,
    SHIELD,
    STAFF,
    GUN,
    FLAMETHROWER
}

public enum Skin
{
    RED,
    BLUE,
    GREE,
    PINK
}
