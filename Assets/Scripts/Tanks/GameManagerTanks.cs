using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField]
    private GameObject _panelGameOver;
    private EnemyManager _enemyManager;

    private void Awake() {

        _enemyManager = gameObject.GetComponent<EnemyManager>();

    }

    public void GameOver() {

        _panelGameOver.SetActive(true);
        //Esta parte la he tenido que comentar porque sigue invocando los tanque enemigos
        //_enemyManager.enabled = false;
        //Con esto cancelaremos la creacion de enemigos.
        _enemyManager.CancelInvoke("CreateEnemies");

    }

    public void LoadSceneLevel() {

        SceneManager.LoadScene(1);

    }

}
