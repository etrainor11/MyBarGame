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

    public Image[] images;

    public GameObject bar;

    private Camera camera;

    private void Awake()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Start()
    {
        //Vector3 vec3 = camera.WorldToScreenPoint(taps[0].transform.position);
        GameObject canvas = GameObject.Find("Canvas");
        Vector3 UI_Vector;

        /*GameObject newUI = Instantiate(prefab, canvas.transform);
        newUI.transform.position = new Vector3(vec3.x, vec3.y - 20, 0);*/


        for (int i = 0; i < taps.Length; i++)
        {
            UI_Vector = camera.WorldToScreenPoint(taps[i].transform.position);

            //Debug.Log("screen coordinates are: " + UI_Vector);

            ItemCollection collection = taps[i].GetComponent<ItemCollection>();
            GameObject new_UI = Instantiate(prefab, canvas.transform);


            /*switch(collection.side)
            {
                case ItemCollection.Side.Top_Or_Down:
                    new_UI.transform.position = new Vector3(UI_Vector.x, UI_Vector.y + collection.distance, 0);
                    collection.linkedUI = new_UI;
                    break;
                case ItemCollection.Side.Left_Or_Right:
                   new_UI.transform.position = new Vector3(UI_Vector.x + collection.distance, UI_Vector.y, 0);
                    break;

            }*/
        }

    }


}
