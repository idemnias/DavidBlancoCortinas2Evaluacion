using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //Variables globales
    [Header("Movimiento")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal, 
                  _vertical;
    private Rigidbody _rigibody;

    private void Awake() {
        
        _rigibody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate() {

        Move();

    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

    }

    private void InputPlayer() {

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }

    private void Move() {

        Vector3 direction = transform.forward * _vertical * speed * Time.deltaTime; // Time.fixedDeltaTime
        _rigibody.MovePosition(transform.position + direction); 

    }

}
