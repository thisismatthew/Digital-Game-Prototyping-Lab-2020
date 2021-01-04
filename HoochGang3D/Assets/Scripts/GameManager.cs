using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject currentCharacter;
    private int i;

    private void Start()
    {
        currentCharacter = characters[0];
        i = 0;
    }

    private void Update()
    {
        if (Vector3.Distance(currentCharacter.transform.position, currentCharacter.GetComponent<Movement>().goal.position) < 3.0f)
        {
            if (Vector3.Distance(currentCharacter.transform.position, currentCharacter.GetComponent<Movement>().startPoint.position) > 3.0f)
            {
                i++;
                currentCharacter.GetComponent<Movement>().startPoint = currentCharacter.GetComponent<Movement>().goal;
                currentCharacter = characters[i];

                if (i == characters.Length - 1)
                {
                    i = -1;
                }
            }
            
        }  
    }
}
