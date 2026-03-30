using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecurityMonitorSwitcher : MonoBehaviour
{
    public List<Material> cameraMaterials;
    public MeshRenderer meshRenderer;
    private int currentIndex = 0;
    public UnityEvent onCameraSwitch;
    public void SwitchCamera()
    {
        currentIndex++;
        if (currentIndex >= cameraMaterials.Count)
        {

            currentIndex = 0;

        }

        meshRenderer.material = cameraMaterials[currentIndex];
        onCameraSwitch?.Invoke();

    }
}
