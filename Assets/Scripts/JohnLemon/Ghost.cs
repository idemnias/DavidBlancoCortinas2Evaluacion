using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UIElements;

public class Ghost : MonoBehaviour
{

    //Zona de variables globales
    [Header("WayPoints")]
    //Array de posiciones para la patrulla del fantasma
    [SerializeField]
    private Transform[] _positionArray = new Transform[2] ;
    [SerializeField]
    private float _speed = 1.3f;
    //Almacenar la posición a la que se dirige el fantasma
    private Vector3 _posToGo;
    //Inidice para cotnrolar en que posición (casilla) del "array" estoy
    private int _currentIndex = 0;
    // Dirección del movimiento (1 = subiendo, -1 = bajando)
    private int _direction = 1;

    [Header("RayCast")]
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;


    // Start is called before the first frame update
    void Start()
    {

        _currentIndex = 0;
        _posToGo = _positionArray[_currentIndex].position;

    }

    private void FixedUpdate() {

        DetectionJohnLemon();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePosition();
        Rotate();
        
    }

    private void Move() {

        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);

    }

    private void ChangePosition() {

        // Si el fantasma ha llegado a su destino, cambia la posicion
        // No he podido poner Mathf.Epsilon
        if (Vector3.Distance(transform.position, _posToGo) <= 0.1f) { 

            // Cambiar de dirección si llegamos al tope o a la base
            if (_currentIndex == _positionArray.Length - 1) {
                _direction = -1; // Cambia a bajando
            }else if (_currentIndex == 0) {
                _direction = 1;  // Cambia a subiendo
            }

            // Actualizamos el índice
            _currentIndex += _direction;

            _posToGo = _positionArray[_currentIndex].position;

        }

    }

    private void Rotate() {

        transform.LookAt(_posToGo);

    }

    private void DetectionJohnLemon() {
        
        //Subimos el origen del ray 1 metro en el eje y con restpeto al punto de pivote del objeto
        _ray.origin = new Vector3(transform.position.x,transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;
        if (Physics.Raycast(_ray, out _hit)) {

            if (_hit.collider.CompareTag("JohnLemon")){

                Debug.Log("Soy el fantasma y te he pillado");
                GameManagerScript.IsPlayerCaught = true;

            }

        }

    }

}
