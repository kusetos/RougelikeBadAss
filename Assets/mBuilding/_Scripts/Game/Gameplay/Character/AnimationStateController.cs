using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isWalkingHash = Animator.StringToHash("IsRunning");
        Debug.Log(animator);
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("IsRunning");
        bool isRunning = animator.GetBool("IsWalking");
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("IsWalking", true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("IsWalking", false);
        }
        if(!isRunning && (runPressed && forwardPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
        
    }
}
