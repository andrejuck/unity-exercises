using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    public ShootPoollerManager shootPooller;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Shoot(shootPooller);
        }
    }
}
