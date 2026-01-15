using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponSelectScreen : MonoBehaviour
{
    public string[] customizationOptions;
    public GameObject buttonPrefab;
    public Transform parent;

    private void Awake()
    {
        customizationOptions = System.Enum.GetNames(typeof(WeaponType));

    }

    public void InitializeWeaponSelectScreen()
    {
        foreach(string option in customizationOptions)
        {
            GameObject tmp = Instantiate(buttonPrefab, parent);
            TMP_Text t = tmp.GetComponentInChildren<TMP_Text>();
            t.text = option;

            Button b = tmp.GetComponent<Button>();
            b.onClick.AddListener(delegate {CharacterSelectSingleton.Instance.SetWeaponType(option); });
        }
    }
}
