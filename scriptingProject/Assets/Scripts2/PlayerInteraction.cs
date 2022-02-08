using UnityEngine;
using UnityEngine.UI;
public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInteractionObject = null;
    public InteractionObject currentInteractionScript = null;
    public InteractionStorage interactionStorage;  //assign thru the inspector
    public DoorActions doorAction;
    [SerializeField] private GameObject interactionIcon;
    public Text dialogPromptText;
    public Text dialogResponseText;

    void Start()
    {
        //interactionStorage = new InteractionStorage();
        //interactionStorage.store = new System.Collections.Generic.List<GameObject>();
    ////whenever we cick on our interaction key we check our interactions
    //if (Input.GetKeyDown(KeyCode.E))
    //{
    //    CheckInteraction();
    //}
}
    //public Inventory inventory;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            doorAction.OpenDoor();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            doorAction.CloseDoor();
        }
        if (Input.GetKeyDown(KeyCode.E) && currentInteractionObject)
        {

            switch (currentInteractionScript.interactionType)
            {
                case InteractionType.Picking:
                    {
                        //check to see if this object is to be stored after picking
                        if (currentInteractionScript.pickingIsForKeep)
                        {
                            interactionStorage.AddInteractionObject(currentInteractionObject);
                        }
                        break;
                    }

                case InteractionType.Quest:
                    {
                        break;
                    }
                case InteractionType.Entry:
                    {
                        //check to see if the obejct is locked
                        if (currentInteractionScript.entryIsLocked)
                        {
                            //check to see if we have the object needed to unlock the interactable that is locked
                            if (currentInteractionScript.neededInteractionObject != null)
                            {
                                //Search the interaction inventory for the item needed - of found unlock object
                                if (interactionStorage.FindInteractionObject(currentInteractionScript.neededInteractionObject))
                                {
                                    //item needed is found
                                    currentInteractionScript.entryIsLocked = false;
                                    Debug.Log($"{currentInteractionObject.name} was unlocked!");
                                }
                                else
                                {
                                    Debug.Log($"{currentInteractionObject.name} cannot be unlocked!");
                                }
                            }
                            else
                            {
                                //no item is needed to interact with this object.
                                currentInteractionScript.entryIsLocked = false;
                                Debug.Log($"{currentInteractionObject.name} was unlocked!");
                            }
                        }
                        else
                        {
                            //object is not locked - open the object
                            Debug.Log($"{currentInteractionObject.name} is unlocked!");
                            currentInteractionScript.entryIsOpened = true;
                            currentInteractionScript.OpenEntry();
                        }

                        break;
                    }
                case InteractionType.Dialog:
                    {
                        currentInteractionScript.ShowNextDialogue(dialogPromptText, dialogResponseText);
                        //if (dialogue != null)
                        //    Dialogue dialogue = currentInteractionScript.GetNextDialogue();
                        //if (dialogue != null)
                        //{
                        //    Debug.Log($"{dialogue.prompt}{dialogue.response}");
                        //    dialogPromptText.text = dialogue.prompt;
                        //    dialogResponseText.text = dialogue.response;
                        //}
                        break;
                    }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("interactionObject"))
        {
            Debug.Log($"Player detect interaction object {other.name}");
            currentInteractionObject = other.gameObject;
            currentInteractionScript = other.gameObject.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("interactionObject"))
        {
            if (other.gameObject == currentInteractionObject)
            {
                Debug.Log($"Player is out of range from object {other.name}");
                currentInteractionObject = null;
            }
        }
    }

    public void OpenInteractableIcon()
    {
        interactionIcon.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactionIcon.SetActive(false);
    }

    private void CheckInteraction()
    {

    }
}