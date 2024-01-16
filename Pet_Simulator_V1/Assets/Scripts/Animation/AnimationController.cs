using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    public int animation_number;

    // Start is called before the first frame update
    void Start()
    {
        animation_number = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            animator.SetInteger("Animation_Part", animation_number);
            //animator.SetFloat("normalizedTime", 0.0f);
    }
}
