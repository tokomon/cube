using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

    void OnMouseDown()
    {
        if (gameObject.name[gameObject.name.Length-1] != '1'){
          //  Destroy(gameObject);
            this.GetComponent<Renderer>().material = tablero.matPiso;
            //  gameObject.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.GetComponent<Renderer>().material = tablero.matPared;
        }

    }
}
