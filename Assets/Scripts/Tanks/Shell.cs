using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    //Variables globales
    [SerializeField]
    private ParticleSystem _explosionShell;

    private AudioSource _audioSource;
    private Collider _collider;
    private Renderer _renderer;

    private void Awake() {
        
        _audioSource = GetComponent<AudioSource>();
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<Renderer>();

    }

    private void OnCollisionEnter(Collision infoCollision) {
        
        _collider.enabled = false;
        _renderer.enabled = false;
        _explosionShell.Play();
        _audioSource.Play();
        if (infoCollision.gameObject.tag == "EnemyTank" || infoCollision.gameObject.tag == "PlayerTank") {
            Destroy(gameObject);
        } else {
            Destroy(gameObject, 0.5f);
        }    

    }

}
