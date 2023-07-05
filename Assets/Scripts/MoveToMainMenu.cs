using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMainMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> Activate;
    [SerializeField] List<GameObject> Deactivate;
    [SerializeField] private bool locked = false;
    
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) && locked == false)
        {
            for (int i = 0;i < Activate.Count; i++)
                Activate[i].SetActive(true);
            for (int i = 0; i < Deactivate.Count; i++)
                Deactivate[i].SetActive(false);
            locked = true;
        }
    }
}
