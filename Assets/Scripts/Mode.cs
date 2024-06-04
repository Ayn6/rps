using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{
    private bool action = false;
    public static int mode = 0;
    [SerializeField] private GameObject gameObject;

    public void Open(GameObject gameObject)
    {
        if(action)
        {
            gameObject.SetActive(false);
            action = false;
        }
        else
        {
            gameObject.SetActive(true);
            action = true;
        }

    }

    public void Change(int index)
    {
        mode = index;
        if(index == 2)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
