using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script exists purly for playtesting purposes
public class DoubleJumpDebug : MonoBehaviour
{
    public Text display;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            DoubleJumpManager.canDoubleJump = !DoubleJumpManager.canDoubleJump;
        }
        if (display != null) 
        {
            display.text = DoubleJumpManager.canDoubleJump.ToString();
        }
    }
}
