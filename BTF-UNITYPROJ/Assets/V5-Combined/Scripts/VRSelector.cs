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
    public LayerMask buildingLayerMask;

    void Update()
    {
        //VR Specific - use hand tracking to check if hand is pinching
        bool isPinching = parentHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        pinchIndicator.SetActive(isPinching);

         // Check for hit building by sending out a raycast
        RaycastHit hit;
        Vector3 aimDir = this.transform.forward;
        aimDir = new Vector3(aimDir.x, 0f, aimDir.z);
        Ray selectorRay = new Ray(this.transform.position, aimDir);
        Debug.DrawRay(selectorRay.origin, selectorRay.direction * 30.0f, Color.red);

        //we don't want to select a building if we're pinching
        if (isPinching == false)
        {


            // If we've hit a building with our raycast and we are not pinching
            if (Physics.Raycast(selectorRay, out hit, 100f, buildingLayerMask))
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

                if (this.selectedBuilding != null)
                {
                    selectedBuilding.buildingIsHighlighted = false;
                    this.selectedBuilding = null;
                }

            }

        }
        else if (selectedBuilding != null)
        {
            // If I have a building selected and I'm pinching, do something with it
            selectedBuilding.TriggerAnimation();
        }
    }
}
