using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    //Zona de variables globales
    //Array de posiciones para la patrulla del fantasma
    [SerializeField]
    private Transform[] _positionArray = new Transform[2];
    [SerializeField]
    private float _speed = 1.3f;
    //Almacenar la posición a la que se dirige el fantasma
    private Vector3 _posToGo;
    //Inidice para cotnrolar en que posición (casilla) del "array" estoy
    private int _currentIndex = 0;
    // Dirección del movimiento (1 = subiendo, -1 = bajando)
    private int _direction = 1;


    // Start is called before the first frame update
    void Start()
    {

        _currentIndex = 0;
        _posToGo = _positionArray[_currentIndex].position;

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
        if (Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon) {

            // Cambiar de dirección si llegamos al tope o a la base
            if (_currentIndex == _positionArray.Length - 1)
                _direction = -1; // Cambia a bajando
            else if (_currentIndex == 0)
                _direction = 1;  // Cambia a subiendo

            // Actualizamos el índice
            _currentIndex += _direction;

            _posToGo = _positionArray[_currentIndex].position;

        }

    }

    private void Rotate() {

        transform.LookAt(_posToGo);

    }

}
