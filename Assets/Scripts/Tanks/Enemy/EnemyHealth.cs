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

    [Header("Destruction")]
    private EnemyTankAttack _enemyTankAttack;
    private EnemyTankMovement _enemyTankMovement;

    private void Awake() {

        _enemyTankAttack = GetComponent<EnemyTankAttack>();
        _enemyTankMovement = GetComponent<EnemyTankMovement>();
        _bigExplosion.Stop();
        _smallExplosion.Stop();
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnCollisionEnter(Collision infoAcess) {

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

        _enemyTankAttack.enabled = false;
        _enemyTankMovement.enabled = false;
        Destroy(gameObject, 1.0f);

    }

}
