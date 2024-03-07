using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Dog : MonoBehaviour
{
    private int _collectedPoints;

    public int CollectedPoints => _collectedPoints;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _body;
    [SerializeField] private float _speedRotate;
    
    private bool _isGrounded;

    private PlayerInput _input;
    private Controls _controls;
    
    private void Awake()
    {
        _controls = new Controls();
        _controls.Dog.Enable();
    }
    
        private void Update()
    {
    
    
    }

        private void FixedUpdate()
        {
            var move = _controls.Dog.Movement.ReadValue<Vector2>();
            _body.AddRelativeForce(new Vector3(0.0f, 0.0f, move.y) * _movementSpeed, ForceMode.VelocityChange);
            _body.AddTorque(new Vector3(0.0f,move.x, 0.0f) * _speedRotate);
        }

        private void OnCollisionEnter(Collision other)
        { 
            var collisionSphere = other.gameObject.GetComponent<Sphere>();
        
            if (collisionSphere != null)
            {
                _collectedPoints += collisionSphere.Points;
            
            }
        
        }
    
        public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _body.AddForce(Vector3.up * _jumpForce);
        }
    }

}
