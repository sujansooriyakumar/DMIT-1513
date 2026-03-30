using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHandler : MonoBehaviour
{
    public List<UnityEvent> onAnimationEvents;

    public void TriggerEvent(int index)
    {
        // onAnimationEvent?.Invoke();
        onAnimationEvents[index]?.Invoke();
    }

    public void Test(int i)
    {

    }
}


