using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTable : MonoBehaviour
{
    List<GameObject> cornerAnchors;
    Vector3 moveToVector;
    Vector3 myCorner;
    float startTimer = 2;
    float speed = 5;
    bool atCorner = false;

    private void Start()
    {
        cornerAnchors = new List<GameObject>(GameObject.FindGameObjectsWithTag("Corner"));
        myCorner = FindMyCorner(cornerAnchors);

        myCorner.y = transform.position.y;
        moveToVector = myCorner - transform.position;
        moveToVector = moveToVector.normalized;
    }

    private void Update()
    {
        if (startTimer <= 0 && !atCorner)
        {
            transform.position += moveToVector * speed * Time.deltaTime;

            Vector3 dist = myCorner - transform.position;
            if (dist.magnitude < 0.1)
            {
                atCorner = true;
            }
        }

        if (startTimer > 0)
        {
            startTimer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Finds the closest corner to this joint anchor
    /// </summary>
    /// <param name="cornerList">List of all the corners</param>
    /// <returns>The position of the closest corner</returns>
    private Vector3 FindMyCorner(List<GameObject> cornerList)
    {
        List<Vector3> distances = new List<Vector3>();
        Vector3 closestDistance;
        Vector3 closestLocation;

        // load the vectors to each corner in a list
        for (int i = 0; i < cornerList.Count; i++)
        {
            distances.Add(cornerList[i].transform.position - transform.position);
        }

        // check which is the closest corner
        closestDistance = distances[0];
        closestLocation = cornerList[0].transform.position;
        for (int i = 0; i < distances.Count; i++)
        {
            if (distances[i].magnitude < closestDistance.magnitude)
            {
                closestDistance = distances[i];
                closestLocation = cornerList[i].transform.position;
            }
        }

        return closestLocation;
    }
}
