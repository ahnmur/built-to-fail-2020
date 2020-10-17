using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{

    public OVRHand parentHand;
    [SerializeField] private Building selectedBuilding;
    [SerializeField] private bool isPinching;
    public GameObject pinchIndicator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Check if hand is pinching
        bool isPinching = parentHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        if (isPinching)
        {
            pinchIndicator.SetActive(true);
        }
        else
        {
            pinchIndicator.SetActive(false);
        }

        // Check if raycast is hitting a building, if so, set that building as hitBuilding
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
