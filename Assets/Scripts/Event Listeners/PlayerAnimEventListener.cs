using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEventListener : MonoBehaviour
{
    public bool animCompleted;
    Transform skateBoard => RefManager.I.skateBoard;
    public Transform leftFoot;
    public Transform leftHand;

    private RootMotion.FinalIK.FullBodyBipedIK fullBodyBipedIK;
    private bool correctRotation;

    private void Start()
    {
        fullBodyBipedIK = GetComponent<RootMotion.FinalIK.FullBodyBipedIK>();
    }

    private void Update()
    {
        if (skateBoard.localRotation != Quaternion.Euler(0, 0, 0))
            skateBoard.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void ChangeSkateBoardParent(string parent = "")
    {
        switch (parent)
        {
            case "Foot":
                PrintLog("Foot");
                animCompleted = false;
                skateBoard.parent = leftFoot;
                fullBodyBipedIK.enabled = false;
                correctRotation = true;
                break;
            case "Hand":
                PrintLog("Hand");
                skateBoard.parent = leftHand;
                break;
            case "Completed":
                //Invoke("AnimationCompleted", 0.2f);
                AnimationCompleted();
                break;
            default:
                PrintLog("Normal");
                skateBoard.parent = transform;
                fullBodyBipedIK.enabled = true;
                skateBoard.localRotation = Quaternion.Euler(0, 0, 0);
                correctRotation = false;
                break;
        }
    }

    public void AnimationCompleted()
    {
        animCompleted = true;
    }

    void PrintLog(string log)
    {
        Debug.Log("PlayerAnimEventListener: " + log);
    }
}
