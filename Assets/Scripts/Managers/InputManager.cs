using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void DelegateMovement(Vector2 axis);
    public static DelegateMovement Movement;

    public delegate void DelegatePause();
    public static DelegatePause Pause;

    public void OnMovement(InputAction.CallbackContext obj)
    {
        switch (obj.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                Movement?.Invoke(obj.ReadValue<Vector2>());

                break;
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }

    public void OnPause(InputAction.CallbackContext obj)
    {
        switch (obj.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                Pause?.Invoke();

                break;
            case InputActionPhase.Performed:
                break;
            case InputActionPhase.Canceled:
                break;
        }
    }
}
