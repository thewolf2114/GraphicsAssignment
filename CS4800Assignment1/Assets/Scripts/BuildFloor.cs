using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFloor : MonoBehaviour
{
    [SerializeField]
    GameObject prefabWhiteTile, prefabBlackTile;

    Vector3 currPosition;
    List<GameObject> corners;
    GameObject currTile;
    float tileWidth;
    float tileHeight;
    int currCorner = 0;
    const int numCorners = 4;
    const int floorWidth = 5;
    const int floorHeight = 5;

    // Start is called before the first frame update
    void Awake()
    {
        corners = new List<GameObject>();

        tileWidth = prefabWhiteTile.transform.localScale.x;
        tileHeight = prefabWhiteTile.transform.localScale.z;

        for (int i = 0; i < numCorners; i++)
        {
            corners.Add(new GameObject("Corner"));
            corners[i].tag = "Corner";
        }

        currPosition = transform.position;
        // build the rows
        for (int i = 0; i < floorWidth; i++)
        {
            // build the columns
            for (int j = 0; j < floorHeight; j++)
            {
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                        currTile = Instantiate(prefabWhiteTile, currPosition, Quaternion.identity);
                    else
                        currTile = Instantiate(prefabBlackTile, currPosition, Quaternion.identity);
                }
                else
                {
                    if (j % 2 == 0)
                        currTile = Instantiate(prefabBlackTile, currPosition, Quaternion.identity);
                    else
                        currTile = Instantiate(prefabWhiteTile, currPosition, Quaternion.identity);
                }

                // if we are in one of the corners of the floor
                if ((i == 0 || i == 4) && (j == 0 || j == 4))
                {
                    corners[currCorner].transform.position = currTile.transform.position;
                    currCorner++;
                }

                currPosition.x -= tileWidth;
            }

            currPosition.z += tileHeight;
            currPosition.x = transform.position.x;
        }
    }
}
