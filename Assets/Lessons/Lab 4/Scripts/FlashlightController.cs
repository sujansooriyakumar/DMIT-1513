using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    public InputAction toggleFlashlight;
    public Light flashlight;
    private float batteryLevel = 1.0f;
    public float usageRate = 0.1f;
    public float chargeRate = 0.2f;
    public Slider batteryGauge;

    private void Start()
    {
        toggleFlashlight.Enable();
        toggleFlashlight.performed += ToggleFlashlight;
        StartCoroutine(BatteryPercentageCoroutine());

    }

    private void ToggleFlashlight(InputAction.CallbackContext c)
    {
        flashlight.enabled = !flashlight.enabled;
    }

    private IEnumerator BatteryPercentageCoroutine()
    {
        while (true)
        {
            if (flashlight.enabled)
            {
                batteryLevel -= usageRate;
                // drain the battery
            }

            if(flashlight.enabled == false)
            {
                batteryLevel += chargeRate;
                // charge the battery
            }

            batteryLevel = Mathf.Clamp(batteryLevel, 0f, 1f);
            batteryGauge.value = batteryLevel;
            yield return null; 
        }
    }
}
