using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isWalkingBackHash;
    int isWalkingLeftHash;
    int isWalkingRightHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
    }

    
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isWalkingBack = animator.GetBool(isWalkingBackHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool forwardPress = Input.GetKey("w");
        bool backwardPress = Input.GetKey("s");
        bool rightPress = Input.GetKey("d");
        bool leftPress = Input.GetKey("a");

        if (!isWalking && forwardPress)
        {
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isWalkingBackHash, false);
            animator.SetBool(isWalkingLeftHash, false);
            animator.SetBool(isWalkingRightHash, false);
        }
        if (isWalking && !forwardPress)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isWalkingBack && backwardPress)
        {
            animator.SetBool(isWalkingBackHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isWalkingLeftHash, false);
            animator.SetBool(isWalkingRightHash, false);
        }
        if ((isWalking || isWalkingBack) && (!forwardPress && !backwardPress))
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isWalkingBackHash, false);
        }
        if (!isWalkingLeft && leftPress)
        {
            animator.SetBool(isWalkingLeftHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isWalkingBackHash, false);
            animator.SetBool(isWalkingRightHash, false);
        }
        if (!isWalkingRight && rightPress)
        {
            animator.SetBool(isWalkingRightHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isWalkingBackHash, false);
            animator.SetBool(isWalkingLeftHash, false);
        }
        if ((isWalking || isWalkingBack || isWalkingLeft || isWalkingRight) && (!forwardPress && !backwardPress && !leftPress && !rightPress))
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isWalkingBackHash, false);
            animator.SetBool(isWalkingLeftHash, false);
            animator.SetBool(isWalkingRightHash, false);
        }
    }
}
