using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LookController : MonoBehaviour
{
    public UnityEvent OnLook;
    public string tagToCheck;
    private Coroutine lookTimerCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tagToCheck)){

            return;

        }

        if(lookTimerCoroutine == null)
        {
            lookTimerCoroutine = StartCoroutine(LookTimer(3.0f));
        }

    }

    private IEnumerator LookTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        OnLook?.Invoke();

       
    }
}
