using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private int playerSpeed;
    private int speedState = 0;
    public List<SpriteRenderer> spriteRenderer = new List<SpriteRenderer>();
    public List<GameObject> characters = new List<GameObject>();
    private int currCharacter = 0;

    private void Awake()
    {
        getSpriteRenderer();
    }

    void Update()
    {
        playerMovement();
        changeSpeed();
        changeColors();
        getSpriteRenderer();
        switchCharacter();
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

    public void getSpriteRenderer()
    {
        foreach (SpriteRenderer chars in GetComponentsInChildren<SpriteRenderer>())
        {
            foreach (SpriteRenderer childspriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.Add(childspriteRenderer);
            }
                
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

    public void changeColors()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            for(int i = 0; i < spriteRenderer.Count; i++)
            {
                spriteRenderer[i].color = Random.ColorHSV();              
            }
        }
    }

    private void switchCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && currCharacter != 0)
        {
            characters[currCharacter].SetActive(false);
            characters[0].SetActive(true);
            currCharacter = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currCharacter != 1)
        {
            characters[currCharacter].SetActive(false);
            characters[1].SetActive(true);
            currCharacter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currCharacter != 2)
        {
            characters[currCharacter].SetActive(false);
            characters[2].SetActive(true);
            currCharacter = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && currCharacter != 3)
        {
            characters[currCharacter].SetActive(false);
            characters[3].SetActive(true);
            currCharacter = 3;
        }
    }
}
