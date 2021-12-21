using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private CharacterController _charController;
    private managerJoystick _managerJoystick;

    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float moveSpeed;

    void Start()
    {
         moveSpeed = 0.01f; // Tekne hızı       
         GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = tempPlayer.GetComponent<CharacterController>();
        _managerJoystick = GameObject.Find("Joystick").GetComponent<managerJoystick>();
    }

   
    void Update()
    {
          inputX = _managerJoystick.inputHorizontal(); //Joystick e bağlı horizontal
          inputZ = _managerJoystick.inputVertical();   //Joystick e bağlı vertical

          v_movement = new Vector3(inputX * moveSpeed, 0 , inputZ * moveSpeed);
         _charController.Move(v_movement);       
    }
}
