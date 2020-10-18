using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSelector : MonoBehaviour
{
    public GameObject parentHand;
    [SerializeField] private BuildingV5 selectedBuilding;
    public bool isPinching;

    void Update()
    {
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
        } else
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
