using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponSelectScreen : MonoBehaviour
{
    public string[] customizationOptions;
    public GameObject buttonPrefab;
    public Transform parent;
    public UnityEvent OnWeaponSelected;

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
            b.onClick.AddListener(delegate { OnWeaponSelected?.Invoke(); }
                );
        }
    }
}
