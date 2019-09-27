using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCustomer", menuName = "Customers")]
public class Customers : ScriptableObject
{
    public List<Drink_SO> drinks_SO;
}
