using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        //Mirar hacia la cámara de la escena que tenga la etiqueta "MainCamer"
        transform.LookAt(Camera.main.transform.position);

    }

}
