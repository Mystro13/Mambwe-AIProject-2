using System.Linq;
using UnityEngine;

public class InteractionStorage : MonoBehaviour
{
	public System.Collections.Generic.List<GameObject> store;  //made public to help debug thru the inspector
	[SerializeField] private int inventoryCapacity = 10;

	public void AddInteractionObject(GameObject item)
	{
		if (item == null)
		{
			Debug.Log($"item is null, won't be added to inventory");
			return;
		}
		if ( store.Count < inventoryCapacity)
		{
			store.Add(item);
			Debug.Log($"{item.name} was added");
			//do something with the object
			item.SendMessage("OnInteract");
		}
		else
		{
			Debug.Log($"{item.name} was not added, inventory is full");
		}
	}

	public bool FindInteractionObject(GameObject searchInteractionObject)
	{
		return store.Any(gameObject => gameObject == searchInteractionObject);
	}

	public bool RemoveInteractionObject(GameObject interactionObjectToRemove)
	{
		return store.Remove(interactionObjectToRemove);
	}
}