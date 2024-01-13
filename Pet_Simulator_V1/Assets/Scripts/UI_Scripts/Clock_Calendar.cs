using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock_Calendar : MonoBehaviour
{
    public TMP_Text clock_Text;
    public TMP_Text calendar_Text;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock_Text.text = "" + (GameEnvironment.hour/10) + (GameEnvironment.hour%10) 
            + ":" + GameEnvironment.minute/10 
            + GameEnvironment.minute%10;
        calendar_Text.text = "" + GameEnvironment.year/1000 + GameEnvironment.year/100 + GameEnvironment.year/10 + GameEnvironment.year%10 + "/" 
            + GameEnvironment.month/10 + GameEnvironment.month%10 + "/" 
            + GameEnvironment.day/10 + GameEnvironment.day%10;
    }
}
