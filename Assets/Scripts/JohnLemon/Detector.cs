using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    private void OnTriggerEnter(Collider infoAccess) {

        if (infoAccess.CompareTag("JohnLemon")) {
            Debug.Log("Te hemos pillado Limones");
        }

    }

}
