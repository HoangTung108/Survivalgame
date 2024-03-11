using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("RotateAxe", true);
        }
        else
        {
            anim.SetBool("RotateAxe", false);
        }
    }
}
