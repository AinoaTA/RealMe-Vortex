using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public delegate void DelegateMove(Vector2 vector);
    public static DelegateMove OnMoveDelegate;

    public delegate void DelegateInteraction();
    public static DelegateInteraction OnInteraction;

    public delegate void DelegateInventory();
    public static DelegateInventory OnOpenInventory;

    private PlayerInput _playerInput;

    public delegate void DelegateExitInventory();
    public static DelegateExitInventory OnInventoryExit;

    private void Awake()
    {
        TryGetComponent(out _playerInput);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx.phase);
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
                OnMoveDelegate?.Invoke(ctx.ReadValue<Vector2>().normalized);
                break;

            case InputActionPhase.Canceled:
            case InputActionPhase.Disabled:
                OnMoveDelegate?.Invoke(Vector2.zero);
                break;
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
                OnInteraction?.Invoke();
                break;
        }
    }

    public void OnInventory(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
                _playerInput.SwitchCurrentActionMap("Menu");
                OnOpenInventory?.Invoke();
                break;
        }
    }

    #region Menu

    public void OnExitInventory(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started:
                _playerInput.SwitchCurrentActionMap("Gameplay");

                OnInventoryExit?.Invoke();
                break;
        }
    }

    #endregion
}