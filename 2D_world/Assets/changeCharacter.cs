using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCharacter : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    private int currCharacter = 0;
    
    void Update()
    {
        switchCharacter();
    }

    private void switchCharacter()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && currCharacter != 0)
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
