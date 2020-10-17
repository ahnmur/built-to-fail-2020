using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V5AnimCtrl : MonoBehaviour
{

    public Transform targetLoc;
    public Transform hand;
    private Animator buildingAnim;

    void Start()
    {
        buildingAnim = GetComponent<Animator>();
    }

    void isTriggered()
    {
        
        if (buildingAnim != null)
        {
        float targetDistance = (targetLoc.transform.position.y - hand.transform.position.y);
        float desiredFrame = ExtensionMethods.Multiply(targetDistance, 8);
        //float desiredFrame = ExtensionMethods.Remap(targetDistance, 0, 5, 0, 1);
        // Original values were 1, 5, 0, 1
        buildingAnim.Play("Crumble", 0, desiredFrame);
        }

    }

    


    //https://docs.unity3d.com/ScriptReference/Animator.Play.html
}
