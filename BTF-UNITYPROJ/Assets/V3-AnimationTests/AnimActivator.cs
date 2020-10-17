using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimActivator : MonoBehaviour
{

    public Transform target;
    public Transform hands;
    private Animator buildingAnim;

    void Start()
    {
        buildingAnim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (buildingAnim != null)
        {
        float targetDistance = (target.transform.position.y - hands.transform.position.y);
        float desiredFrame = ExtensionMethods.Remap(targetDistance, 1, 5, 0, 1);
        buildingAnim.Play("Crumble", 0, desiredFrame);
        }

    }


    //https://docs.unity3d.com/ScriptReference/Animator.Play.html
}
