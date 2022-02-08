using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
	[SerializeField]
	private float range;
	public InteractionObject currentInteractionScript = null; //store the object we are interacting with
    //public InteractionStorage interactionInventory;  //assign thru the inspector
	private Camera mainCamera;

	private void Awake()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		RaycastForInteractacle();

		if (Input.GetKeyDown(KeyCode.E) && currentInteractionScript)
		{
			currentInteractionScript.OnInteract();
		}
	}

	private void RaycastForInteractacle()
	{
		//RaycastHit whatWasHit;
		//Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		////Debug.DrawRay(
		//if (Physics.Raycast(ray, out whatWasHit, range))
		//{
		//	IInteractable interactable = whatWasHit.collider.GetComponent<IInteractable>();
		//	if (interactable != null)
		//	{
		//		if (whatWasHit.distance <= interactable.MaxRange)
		//		{
		//			if (interactable == currentInteractionScript) //already looking at the target
		//			{
		//				return;
		//			}
		//			else if (currentInteractionScript != null) // stop looking at he current target , switch looking at the new target
		//			{
		//				currentInteractionScript.OnEndHover();
		//				currentInteractionScript = intereactable;
		//				currentInteractionScript.OnStartHover();
		//				return;
		//			}
		//			else
		//			{
		//				currentInteractionScript = interactable;
		//				currentInteractionScript.OnStartHover();
		//				return;
		//			}
		//		}
		//		else
		//		{
		//			if (currentInteractionScript != null) // stop looking at he current target , switch looking at the new target like an ennemy getting out of range
		//			{
		//				currentInteractionScript.OnEndHover();
		//				currentInteractionScript = null;
		//				return;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		if (currentInteractionScript != null) // stop looking at he current target , switch looking at the new target like an ennemy getting out of range
		//		{
		//			currentInteractionScript.OnEndHover();
		//			currentInteractionScript = null;
		//			return;
		//		}
		//	}
		//}
		//else
		//{
		//	if (currentInteractionScript != null) // stop looking at he current target , switch looking at the new target like an ennemy getting out of range
		//	{
		//		currentInteractionScript.OnEndHover();
		//		currentInteractionScript = null;
		//		return;
		//	}
		//}
	}
}