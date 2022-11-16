using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    [SerializeField]
    private int totalCustomersSpawned;

    public int TotalCustomersSpawned
    {
        get { return totalCustomersSpawned; }
        set { totalCustomersSpawned = value; }
    }

    private void Awake()
    {
        totalCustomersSpawned = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalCustomersSpawned = 0;
    }
}
