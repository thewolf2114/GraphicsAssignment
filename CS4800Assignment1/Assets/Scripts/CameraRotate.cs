using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]
    int rotationSpeed = 20;

    [SerializeField]
    int moveSpeed;

    [SerializeField]
    int tooClose;

    GameObject bowl;
    Vector3 rotationPoint;
    float timer = 2;
    bool zoom = true;

    // Start is called before the first frame update
    void Start()
    {
        bowl = GameObject.FindGameObjectWithTag("Bowl");

        rotationPoint = bowl.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rotationPoint = bowl.transform.position;
        transform.LookAt(rotationPoint);
        transform.Translate(Vector3.right * rotationSpeed * Time.deltaTime);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && zoom)
        {
            Vector3 location = transform.position;
            Vector3 dir = rotationPoint - location;
            dir = dir.normalized;

            transform.position += dir * moveSpeed * Time.deltaTime;

            if ((rotationPoint - transform.position).magnitude < tooClose)
            {
                rotationSpeed = 10;
                zoom = false;
            }
        }
    }
}
