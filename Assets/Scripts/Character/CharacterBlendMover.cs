using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBlendMover : MonoBehaviour
{

    float MoveHorizontal;
    float MoveVertical;
    Animator ethan;
    bool isCrouched = false;
    bool isRunning = false;
    bool isWalking = false;
    public ANIMSTATE animState;
    public enum ANIMSTATE
    {
        Idle = 0,
        Running = 1,
        Crouching = 2,
        Walking = 3,
    };

    private void Start()
    {
        ethan = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            isCrouched = !isCrouched;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            isRunning = true;
        else
        {
            isRunning = false;
        }

        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");

        ethan.SetBool("isRunning", isRunning);
        ethan.SetBool("isCrouching", isCrouched);
        ethan.SetFloat("EVertical", MoveVertical);
        ethan.SetFloat("EHorizontal", MoveHorizontal);
    }
}