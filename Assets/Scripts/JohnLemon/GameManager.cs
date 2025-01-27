using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //Para saber si el "player" ha llegado a la salida
    public bool IsPlayerAtExit;
    // Para saber si han pillado al player
    public bool IsPlayerCaught;
    // Me va a decir si "reseteo" el nivel o no
    private bool _isRestartLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;
    private AudioSource _audioSource;


    private void Awake() {
        
        _audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    private void Won(){

        _audioSource.clip = _wonClip;
        if (_audioSource.isPlaying == false) {

            _audioSource.Play();

        }

        _timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco apoco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        //La imagen de queda durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration) {

            Debug.Log("Has ganado");
            SceneManager.LoadScene("JuanitoLimones");

        }

    }

    private void Caught() {

        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false) {

            _audioSource.Play();

        }

        _timer += Time.deltaTime;
        //Aumentar el canal alfa de la imagen poco apoco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        //La imagen de queda durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration) {

            Debug.Log("Has perdido");
            SceneManager.LoadScene("JuanitoLimones");

        }

    }


}
