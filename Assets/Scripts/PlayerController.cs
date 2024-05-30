using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 move;
    [SerializeField] private float moveSpeed = 8f;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.05f);
            transform.Translate(movement * Time.deltaTime * moveSpeed, Space.World);
        }
            
    }
}
