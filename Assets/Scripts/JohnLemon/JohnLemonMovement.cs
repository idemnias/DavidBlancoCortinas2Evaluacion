using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{

    //Zona de variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed = 2.25f,
                  _turnSpeed = 45f;
    
    // Se guarda la dirección de movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rigibody;
    private Animator _animator;
    private float _horizontal,
                  _vertical;

    private AudioSource _audioSource;


    // Start is called before the first frame update
    private void Awake()
    {
        
        _rigibody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate() {

        Rotation();

    }

    private void OnAnimatorMove() 
    {
        
        _rigibody.MovePosition(transform.position + (_direction * _animator.deltaPosition.magnitude));

    }


    void Update()
    {

        InputsPlayer();
        IsAnimate();
        audioSteps();

    }

    private void InputsPlayer() {

        // Recogemos los datos de A o D, asi como las flechas < >
        _horizontal = Input.GetAxis("Horizontal");
        // Recogemos los datos de W o S, asi como las flechas ^\/
        _vertical = Input.GetAxis("Vertical");
        // new Vertor3(x,y,z);
        _direction = new Vector3(_horizontal, 0.0f , _vertical);
        //Normalizar
        _direction.Normalize();
    }

    private void IsAnimate() {

        if(_horizontal != 0.0f || _vertical != 0.0f) {

            _animator.SetBool("IsWalking", true);

        } else {

            _animator.SetBool("IsWalking", false);

        }

    }
    
    private void Rotation() {

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        _rigibody.MoveRotation(rotation);

    }

    private void audioSteps() {

        if (_horizontal != 0 || _vertical != 0) {
            if (!_audioSource.isPlaying) {
                _audioSource.Play();
            }
        } else {
            _audioSource.Stop();
        }

    }

}
