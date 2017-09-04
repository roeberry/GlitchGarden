using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarsCounter : MonoBehaviour {

    public Text text;

    public static int count = 50;

    public const int starValue = 40;

    private void Start()
    {
        count = 50;
    }

    public static void AddStar(){
        count += starValue;
    }

    public static bool UseStar(int amount)
    {
        if (amount > count)
        {
            return false;
        }
        count -= amount;
        return true;
    }

    private void Update()
    {
        text.text = "" + count;
    }
}
