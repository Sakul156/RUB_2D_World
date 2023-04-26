using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private int playerSpeed;
    private int speedState = 0;
    public List<List<SpriteRenderer>> spriteRendererLists = new List<List<SpriteRenderer>>();
    private List<SpriteRenderer> sr_currCharObject = new List<SpriteRenderer>();
    public List<GameObject> characters = new List<GameObject>();
    private int currCharacter = 0;

    private void Awake()
    {
        getSpriteRenderer();
        sr_currCharObject = spriteRendererLists[0];
    }

    void Update()
    {
        playerMovement();
        changeSpeed();
        changeColors(sr_currCharObject);
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
        // Get all child transforms
        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i);
        }

        // Create a list of SpriteRenderers for each child
        foreach (Transform child in children)
        {
            List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
            spriteRenderers.AddRange(child.GetComponentsInChildren<SpriteRenderer>());
            spriteRendererLists.Add(spriteRenderers);
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

    public void changeColors(List<SpriteRenderer> sr)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            for(int i = 0; i < sr.Count; i++)
            {
                sr[i].color = Random.ColorHSV();              
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
            sr_currCharObject = spriteRendererLists[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currCharacter != 1)
        {
            characters[currCharacter].SetActive(false);
            characters[1].SetActive(true);
            currCharacter = 1;
            sr_currCharObject = spriteRendererLists[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && currCharacter != 2)
        {
            characters[currCharacter].SetActive(false);
            characters[2].SetActive(true);
            currCharacter = 2;
            sr_currCharObject = spriteRendererLists[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && currCharacter != 3)
        {
            characters[currCharacter].SetActive(false);
            characters[3].SetActive(true);
            currCharacter = 3;
            sr_currCharObject = spriteRendererLists[3];
        }
    }
}
