using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSelector : MonoBehaviour
{
    [SerializeField] private BuildingV5 selectedBuilding;
    [SerializeField] private bool isPinching;

    //VR Specific 
    public OVRHand parentHand;
    public GameObject pinchIndicator; //just a lil' additional feedback

    void Update()
    {
        //VR Specific - use hand tracking to check if hand is pinching
        bool isPinching = parentHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        if (isPinching)
        {
            pinchIndicator.SetActive(true);
        }
        else
        {
            pinchIndicator.SetActive(false);
        }

        // Check for hit building by sending out a raycast
        RaycastHit hit;
        Ray selectorRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(selectorRay.origin, selectorRay.direction * 30.0f, Color.red);

        // If we've hit a building with our raycast and we are not pinching
        if (Physics.Raycast(selectorRay, out hit) && isPinching == false)
        {
            // check if the thing we've hit has a building script, if so, set it as the selected building
            BuildingV5 hitBuilding = hit.collider.GetComponent<BuildingV5>();

            if (hitBuilding != null)
            {
                this.selectedBuilding = hitBuilding;
                selectedBuilding.buildingIsHighlighted = true;
            }
        }
        else
        {
            //Set the selected building to null if we're not pointing at anything
            if (isPinching == false)
            {
                selectedBuilding.buildingIsHighlighted = false;
                this.selectedBuilding = null;
            }
        }

        // If I have a building selected and I'm pinching, do something with it
        if (selectedBuilding != null && isPinching)
        {
            selectedBuilding.TriggerAnimation();
        }
    }
}
