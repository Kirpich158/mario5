using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject target;

    void Update() {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
