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

    [Header("Sound")]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivingClip;

    private void Awake() {
        
        _rigibody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate() {

        Move();
        Turn();

    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();
        AudioPlayer();

    }

    private void InputPlayer() {

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    }

    private void Move() {

        Vector3 direction = transform.forward * _vertical * speed * Time.deltaTime; // Time.fixedDeltaTime
        _rigibody.MovePosition(transform.position + direction); 

    }

    private void Turn() {

        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        _rigibody.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer() {

        //El tanque se esta moviendo o esta en rotacion
        if (_horizontal != 0 || _vertical != 0) {

            if (_audioSource.clip != _drivingClip){

                _audioSource.clip = _drivingClip;
                _audioSource.Play();

            }

        } else {

            if (_audioSource.clip != _idleClip){

                _audioSource.clip = _idleClip;
                _audioSource.Play();

            }

        }

    }

}
