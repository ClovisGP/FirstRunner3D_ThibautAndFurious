using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        Vector3 vTmp = new Vector3(transform.position.x, transform.position.y, target.position.z - 8);
        transform.position = vTmp;
    }
}