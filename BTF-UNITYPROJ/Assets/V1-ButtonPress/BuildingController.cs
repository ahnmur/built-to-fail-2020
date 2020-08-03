using System.Collections;
using System.Collections.Generic;
using OculusSampleFramework;
using UnityEngine;
using UnityEngine.Assertions;

public class BuildingController : MonoBehaviour
{

		[SerializeField] private GameObject _startStopButton = null;
		[SerializeField] float bSpeed = 300f;
		[SerializeField] private SelectionCylinder _selectionCylinder = null;
		private InteractableTool _toolInteractingWithMe = null;

	private void Awake()
	{
		Assert.IsNotNull(_startStopButton);
		Assert.IsNotNull(_selectionCylinder);

	}

    void Start()
    {
        
    }

	private void OnEnable()
		{
			_startStopButton.GetComponent<Interactable>().InteractableStateChanged.AddListener(StartStopStateChanged);
		}

		private void OnDisable()
		{
			if (_startStopButton != null)
			{
				_startStopButton.GetComponent<Interactable>().InteractableStateChanged.RemoveListener(StartStopStateChanged);
			}
		}

	private void StartStopStateChanged(InteractableStateArgs obj)
		{
			bool inActionState = obj.NewInteractableState == InteractableState.ActionState;
			if (inActionState)
			{
				transform.Translate(Vector3.down * Time.deltaTime * bSpeed);
			}

			_toolInteractingWithMe = obj.NewInteractableState > InteractableState.Default ?
			  obj.Tool : null;
		}

    void Update()

	{
			if (_toolInteractingWithMe == null)
			{
				_selectionCylinder.CurrSelectionState = SelectionCylinder.SelectionState.Off;
			}
			else
			{
				_selectionCylinder.CurrSelectionState = (
				  _toolInteractingWithMe.ToolInputState == ToolInputState.PrimaryInputDown ||
				  _toolInteractingWithMe.ToolInputState == ToolInputState.PrimaryInputDownStay)
				  ? SelectionCylinder.SelectionState.Highlighted
				  : SelectionCylinder.SelectionState.Selected;
			}
		}
}