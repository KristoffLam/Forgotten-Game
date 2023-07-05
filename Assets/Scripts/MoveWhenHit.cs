using UnityEngine;
using System.Collections;
using UnityEngine;

public class MoveWhenHit : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        anim.SetTrigger("Shake");
    }
}
