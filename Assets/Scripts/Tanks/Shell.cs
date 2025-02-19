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

        // Asegurar que el AudioSource está activo antes de reproducirlo
        if (_audioSource != null) {
            _audioSource.enabled = true;  // Asegura que está habilitado
            if (!_audioSource.isPlaying) {
                _audioSource.Play();
            }
        } else {
            Debug.LogWarning("AudioSource no encontrado en Shell.");
        }

        Destroy(gameObject);  

    }

}
