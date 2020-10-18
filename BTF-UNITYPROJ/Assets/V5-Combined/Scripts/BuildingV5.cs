using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingV5 : MonoBehaviour
{

    public bool buildingIsHighlighted = false;
    private Animator buildingAnim;
    public Transform target;
    public Transform hand;
    // float startFrame = .5f;

    // private void Start() {
        
    //     if (buildingAnim != null) //if there is, in fact, an animation attached to this gameObject, freeze the animation at the first frame (which has been set to 1)
    //     {
    //         float desiredFrame = ExtensionMethods.Remap(startFrame, 1, 5, 0, 1);
    //         buildingAnim.Play("CrumbleV5", 0, desiredFrame);
    //     }
    // }

    private void Update()
    {
        buildingAnim = GetComponent<Animator>();

        if (buildingIsHighlighted)
        {
            var outline = gameObject.AddComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 3f;
        }

        if (this.GetComponent<Outline>() != null && !buildingIsHighlighted)
        {
            Destroy(GetComponent<Outline>());
        }

    }

    public void TriggerAnimation()
    {
        if (buildingAnim != null) //if there is, in fact, an animation attached to this gameObject
        {
            //I'd like to add something here about saving the position of the hand at that point and calculating the difference from that
            float targetDistance = (target.transform.position.y - hand.transform.position.y); //height difference between hand and target
            float desiredFrame = ExtensionMethods.Remap(targetDistance, 1, 5, 0, 1);
            buildingAnim.Play("CrumbleV5", 0, desiredFrame);
        }


    }

}
