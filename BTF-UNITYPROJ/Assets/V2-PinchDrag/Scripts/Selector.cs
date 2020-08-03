using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    public OVRHand parentHand;
    [SerializeField] private Building selectedBuilding;
    [SerializeField] private bool isPinching;

    public GameObject pinchIndicator;
    
    void Update()
    {
        
        
        // So this was handy: https://developer.oculus.com/documentation/unity/unity-handtracking/
        // HAHA "HANDY" look at my pun 
        // Not working: isPinching = parentHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && parentHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb);

        bool isPinching = parentHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        
        if (isPinching)
        {
            pinchIndicator.SetActive(true);
        }
        else
        {
            pinchIndicator.SetActive(false);
        }

        // Check for hit building
        RaycastHit hit;

        Ray selectorRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(selectorRay.origin, selectorRay.direction * 30.0f, Color.red);

        if (Physics.Raycast(selectorRay, out hit) && isPinching == false)
        {
            Building hitBuilding = hit.collider.GetComponent<Building>();
            
            if (hitBuilding != null)
            {
                this.selectedBuilding = hitBuilding;
            }
        } else
        {
            if (isPinching == false)
            {
                this.selectedBuilding = null;
            }
        }

        // If I have a building selected and I'm pinching, do something with it
        if (selectedBuilding != null && isPinching)
        {
            selectedBuilding.SetBuildingYPos(this.transform.position.y);
            selectedBuilding.buildingIsHighlighted = true;
        }
    }
}

