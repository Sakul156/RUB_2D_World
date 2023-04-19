using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    private int playerSpeed;
    private int speedState = 0;
    public List<SpriteRenderer> spriteRenderer = new List<SpriteRenderer>();

    void Awake()
    {
        foreach (SpriteRenderer childspriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.Add(childspriteRenderer);
        }
    }

    void Update()
    {
        playerMovement();
        changeSpeed();
        changeColors();
    }

    private void playerMovement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1) * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0) * playerSpeed * Time.deltaTime;
        }
    }

    private void changeSpeed()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedState += 1;

            if(speedState >= 3)
            {
                speedState = 0;
            }
        }

        if (speedState == 0)
        {
            playerSpeed = 3;
        }

        if (speedState == 1)
        {
            playerSpeed = 6;
        }

        if (speedState == 2)
        {
            playerSpeed = 12;
        }
    }

    private void changeColors()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            for(int i = 0; i < spriteRenderer.Count; i++)
            {
                spriteRenderer[i].color = Random.ColorHSV();              
            }
        }
    }

}
