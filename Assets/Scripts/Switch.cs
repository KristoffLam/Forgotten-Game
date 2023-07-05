using UnityEditor;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject item;
    private bool switchInv;

    public void Switcheroo()
    {
        switchInv = !switchInv; 
    }

    private void Update()
    {
        item.SetActive(switchInv);
        if (switchInv == true && this.gameObject.CompareTag("Paused"))
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }
}
