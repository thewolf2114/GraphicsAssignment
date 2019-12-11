using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    int rotationSpeed = 20;

    GameObject table;
    Vector3 rotationPoint;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.FindGameObjectWithTag("Table");

        rotationPoint = table.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(rotationPoint);
        transform.Translate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
