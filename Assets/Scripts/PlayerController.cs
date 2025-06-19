using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour, GameControls.IPlayerActions, GameControls.ICameraActions
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    public Transform cameraTransform;

    private CharacterController characterController;
    private GameControls controls;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        controls = new GameControls();

        controls.Player.SetCallbacks(this);
        controls.Camera.SetCallbacks(this);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        // Move the player
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = transform.TransformDirection(move);
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Rotate camera
        if (cameraTransform != null)
        {
            transform.Rotate(0, lookInput.x * lookSensitivity, 0);
            cameraTransform.Rotate(-lookInput.y * lookSensitivity, 0, 0);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}