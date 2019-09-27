using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Display : MonoBehaviour
{
    [SerializeField]
    private GameObject[] taps;
    private GameObject prefab;

    private void Awake()
    {
        taps = GameObject.FindGameObjectsWithTag("DrinkStorage");


        for (int i = 0; i <= taps.Length; i++)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
}
