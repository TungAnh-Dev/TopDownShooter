using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    private Vector2 movementInput;
    private bool isJumping;
    private bool isSprinting;

    public Vector3 InputVector => new Vector3(movementInput.x, 0f, movementInput.y);

    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public bool IsSprinting { get => isSprinting; set => isSprinting = value; }

    private void OnEnable() { AddEventInputReader(); }

    private void OnDisable() { RemoveEventInputReader(); }

    private void AddEventInputReader()
    {
        inputReader.onMove += HandleMove;
    }

    private void RemoveEventInputReader()
    {
        inputReader.onMove -= HandleMove;
    }

    private void HandleMove(Vector2 move) { movementInput = move; }
}