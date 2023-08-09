using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public bool isDoublespeed = false;

    public void DoubleSpeed()
    {
        if(isDoublespeed == false)
        {
            Time.timeScale = 2.0f;
            isDoublespeed = true;
        }

        else if(isDoublespeed == true)
        {
            Time.timeScale = 1.0f;
            isDoublespeed = false;
        }
        
    }
    
}
