using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour
{
    public void RefreshHearts(int currentLives)
    {
        //Get hearts in children and set them active or inactive
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i < currentLives);
        }
    }
    
}
