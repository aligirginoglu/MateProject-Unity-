using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
   
    public float fuel;
    public Text fuelText;
    public GameObject gameOverPanel;
    private GameObject joystickPanel;
    public Controller controlScript;
    public bool fuelBool = true;
    void Start()
    {
        joystickPanel = GameObject.Find("Joystick");
    }
    void Update()
    {
        if (fuelBool)
        {
            fuel -= Time.deltaTime;
            fuelText.text = fuel.ToString("F1");
        }
             

        if (fuel <= 0)
        {
            gameOverPanel.SetActive(true);
            fuel = 0;
            joystickPanel.SetActive(false);
            controlScript.enabled = false;
        }
          
            
        
    }
}
