using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Display : MonoBehaviour
{
    [SerializeField]
    private GameObject[] taps;
    [SerializeField]
    private GameObject prefab;

    public List<GameObject> UIs;

    //public GameObject bar;

    private Camera camera;

    private void Awake()
    {
        //get the camera first thing
        camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        
        GameObject canvas = GameObject.Find("Canvas");
        Vector3 UI_Vector;


        for (int i = 0; i < taps.Length; i++)
        {
            //obtain screen coordinates of the transform position of each tap
            UI_Vector = camera.WorldToScreenPoint(taps[i].transform.position);

            //Debug.Log("screen coordinates are: " + UI_Vector);

            //obatin a reference to each ItemCollection script in all taps
            ItemCollection collection = taps[i].GetComponent<ItemCollection>();
            GameObject new_UI = Instantiate(prefab, canvas.transform);

            //add this new ui to the list
            UIs.Add(new_UI);

            //assign what direction and distance we want to put the UI based on the taps position
            switch (collection.side)
            {
                case ItemCollection.Side.Top_Or_Down:
                    new_UI.transform.position = new Vector3(UI_Vector.x, UI_Vector.y + collection.distance, 0);
                    //collection.linkedUI = new_UI;
                    break;
                case ItemCollection.Side.Left_Or_Right:
                   new_UI.transform.position = new Vector3(UI_Vector.x + collection.distance, UI_Vector.y, 0);
                    break;
            }
        }

        for (int i = 0; i < UIs.Count; i++)
        {
            Debug.Log("i is " + i);

            //assign the UI to each respective gameobject
            ItemCollection collection = taps[i].GetComponent<ItemCollection>();
            collection.LinkedUI = UIs[i];

            //turn of the image components in all the UIs - will be activated when interacted with
            Image[] images = UIs[i].GetComponentsInChildren<Image>();
            foreach (Image im in images)
            {
                im.enabled = false;
            }
        }
            
    }


}
