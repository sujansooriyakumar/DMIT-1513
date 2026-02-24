using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CombatInput : MonoBehaviour
{
    public InputAction shootInput;

    private void Start()
    {
        shootInput.Enable();
        shootInput.performed += ShootInputPerformed;
        shootInput.canceled += ShootInputReleased;

    }

    private void ShootInputPerformed(InputAction.CallbackContext c)
    {
        GetComponent<Gun>().Shoot();
    }

    private void ShootInputReleased(InputAction.CallbackContext c)
    {
        GetComponent<Gun>().StopShooting();
    }
}
