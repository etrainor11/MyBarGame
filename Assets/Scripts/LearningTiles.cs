using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LearningTiles : MonoBehaviour
{

    private Grid grid;
    public Tilemap tilemap;

    [SerializeField]
    public List<Vector3> availablePlaces;

    // Start is called before the first frame update
    void Awake()
    {

        Debug.Log(tilemap.origin);
        //Debug.Log(tilemap.size);

        

        availablePlaces = new List<Vector3>();

        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tilemap.transform.position.y ));
                Vector3 place = tilemap.GetCellCenterLocal(localPlace);
                

                //Debug.Log(place);

                availablePlaces.Add(place);

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
