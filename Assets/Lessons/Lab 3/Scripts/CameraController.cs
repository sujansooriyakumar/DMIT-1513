using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public InputAction swapCameraAction;
    public CameraState currentState = CameraState.THIRD_PERSON;
    public UnityEvent OnThirdPersonCamActivate;
    public UnityEvent OnFirstPersonCamActivate;

    private void Start()
    {
        swapCameraAction.Enable();
        swapCameraAction.performed += SwapCamera;
    }
    public void SwapCamera(InputAction.CallbackContext c)
    {
        if (currentState == CameraState.THIRD_PERSON)
        {
            currentState = CameraState.FIRST_PERSON;
            OnFirstPersonCamActivate?.Invoke();
            return;

        }
        else currentState = CameraState.THIRD_PERSON;
        OnThirdPersonCamActivate?.Invoke();

    }

}

public enum CameraState
{
    THIRD_PERSON,
    FIRST_PERSON
}
