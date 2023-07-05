using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMSwitch : MonoBehaviour
{
    public GameObject item1, item2;
    private bool switchInv;

    public void Switch()
    {
        switchInv = !switchInv;
    }
    void Update()
    {
        if (item1 != null)
        item1.SetActive(switchInv);
        if (item2 != null)
        item2.SetActive(!switchInv);
    }
}
