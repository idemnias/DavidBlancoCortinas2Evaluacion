using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Zona de variables globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damageEnemyBuller;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    private void Awake() {

        _bigExplosion.Stop();
        _smallExplosion.Stop();
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void Update() {

        if (!_smallExplosion.isPlaying && !_smallExplosion.isStopped) {
            _smallExplosion.Stop();
        }
        if (!_bigExplosion.isPlaying && !_bigExplosion.isStopped) {
            _bigExplosion.Stop();
        }

    }

    private void OnCollisionEnter(Collision infoAcess) {

        Debug.Log("EnemyHealth --> " + infoAcess.gameObject.tag);

        if (infoAcess.gameObject.tag == "BulletTank") {

            _smallExplosion.Play();
            _currentHealth -= _damageEnemyBuller;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAcess.gameObject);

            if (_currentHealth <= 0.0f) {

                _bigExplosion.Play();
                Death();

            }

        }

    }

    private void Death() {

        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1.0f);

    }

}
