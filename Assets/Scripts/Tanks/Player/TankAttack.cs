using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Variables globales
    [SerializeField]
    private Rigidbody _shellPrefab;
    //Referencia al "gameObject" vacío que representa la posición de salida
    [SerializeField]
    private Transform _posShell;
    //Fuerza a la bala
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private AudioSource _audioSource;

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

    }

    private void InputPlayer() {

        if (Input.GetMouseButtonDown(0)) {

            Launch();

        }
    
    }

    private void Launch() {
        
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        if (_audioSource.isPlaying) {
            _audioSource.Stop();
        }
        _audioSource.Play();

        cloneShellPrefab.velocity = _posShell.forward * _launchForce;

        //Utilizaremos mejor con rigibody para no necesitar obtenerlo
        //GameObject cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);
        //cloneShellPrefab.GetComponent<Rigidbody>().velocity = _posShell.forward * _launchForce;


    }

}
