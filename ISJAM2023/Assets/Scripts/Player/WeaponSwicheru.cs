using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwicheru : MonoBehaviour
{
    public int holding;
    // Start is called before the first frame update
    void Start()
    {
        Swicheru();
    }

    // Update is called once per frame
    void Update()
    {
        int prevItem = holding;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            holding = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            holding = 1;
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (holding >= transform.childCount - 1)
            {
                holding = 0;
            }
            else
            {
                holding++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (holding <= 0)
            {
                holding = transform.childCount - 1;
            }
            else
            {
                holding--;
            }
        }
        if(prevItem != holding)
        {
            Swicheru();
        }
        
        
    }

    void Swicheru()
    {
        int i = 0;
        foreach (Transform item in transform)
        {
            if(i == holding)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
