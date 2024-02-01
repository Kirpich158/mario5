using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject target;

    void Start() {
        
    }

    void Update() {
        Vector3 newPos = new Vector3(this.target.transform.position.x, this.target.transform.position.y, this.target.transform.position.z);
        this.transform.position = new Vector3(newPos.x, newPos.y, this.transform.position.z);
    }
}
