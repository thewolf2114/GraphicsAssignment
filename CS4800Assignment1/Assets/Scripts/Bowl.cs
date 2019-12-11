using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    const int tileWidth = 4;
    const int tileHeight = 4;
    int numTiles = 2;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;

        position.x -= (tileWidth * numTiles);
        position.z += (tileHeight * numTiles);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
