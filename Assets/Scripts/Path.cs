using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Path : MonoBehaviour {

    private void Awake() {
        foreach(Transform path in transform) {
            path.GetComponent<Tile>().SetPlacable(false);
        }
    }

}
