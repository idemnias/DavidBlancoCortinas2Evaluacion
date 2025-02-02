using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // Variables globales
    [Header("Images")]
    [SerializeField]
    private Image _caughtImage;
    [SerializeField]
    private Image _wonImage;
    [Header("Fade")]
    //La duración del "fade" de la imagen (aparece poco a poco)
    [SerializeField]
    private float _fadeDuration = 1f;
    //El total de tiempo que voy a dejar a la imagen en pantalla
    [SerializeField]
    private float _displayImageDuration = 2f;
    //Contador de tiempo
    private float _timer;

    [Header("Acabar Juego")]
    //Para saber si el "player" ha llegado a la salida
    public bool IsPlayerAtExit =  false;
    // Para saber si han pillado al player
    public bool IsPlayerCaught = false;
    // Saber cuando el nivel esta para reiniciarse
    private bool _isRestartLevel = false;
    // Boton de reinicio
    [SerializeField]
    private GameObject retryButton;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;


    private void Awake() {
        
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlayerAtExit) {

            Won();

        } else if (IsPlayerCaught) {

            Caught();

        }

    }

    private void Caught() {

        _audioSource.clip = _caughtClip;

        if (!_audioSource.isPlaying) {

            _audioSource.Play();

        }

        _timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco apoco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        if (_timer > _fadeDuration + _displayImageDuration) {

            Debug.Log("Has perdido");
            SceneManager.LoadScene("JuanitoLimones");
        
        }

    }

    private void Won() {

        _audioSource.clip = _wonClip;

        if (!_audioSource.isPlaying && !_isRestartLevel) {

            Debug.Log("Has ganado");

            _audioSource.Play();
            retryButton.SetActive(true);
            _isRestartLevel = true;

        }

        _timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco apoco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        /* La imagen de queda durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration) {
            //SceneManager.LoadScene("JuanitoLimones");
        }
        */

    }

    public void IsRestartLevel() {

        SceneManager.LoadScene("JuanitoLimones");

    }

}
