using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class LightingExample : MonoBehaviour
{
    public float flickerDelay;
    Light light;
    public UnityEvent OnFlicker;

    private void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(Flicker());
    }
    private IEnumerator Flicker()
    {
        while (true)
        {
            light.enabled = !light.enabled;
            OnFlicker?.Invoke();
            yield return new WaitForSeconds(flickerDelay);
        }
        yield return null;
    }
}
