using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDrink", menuName = "Drinks")]
public class Drink_SO : ScriptableObject
{
    public string DrinkName;
    public float Price;
    public Sprite spriteImage;
    public Color color;
    
}
