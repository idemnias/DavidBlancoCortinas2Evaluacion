using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{

    //Zona de variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed,
                  _turnSpeed;
    
    // Se guarda la dirección de movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rigibody;
    private Animator _animator;
    private float _horizontal,
                  _vertical;

    // Start is called before the first frame update
    private void Awake()
    {
        
        _rigibody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

    }

    private void FixedUpdate() 
    {
        
        _rigibody.MovePosition(transform.position + (_direction * _speed * Time.deltaTime));

    }


    void Update()
    {

        InputsPlayer();

    }

    private void InputsPlayer() {

        // Recogemos los datos de A o D, asi como las flechas < >
        _horizontal = Input.GetAxis("Horizontal");
        // Recogemos los datos de W o S, asi como las flechas ^\/
        _vertical = Input.GetAxis("Vertical");
        // new Vertor3(x,y,z);
        _direction = new Vector3(_horizontal, 0.0f , _vertical);

    }

}
