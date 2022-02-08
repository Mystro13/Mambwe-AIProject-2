using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//player must be able to interact with NPC
//	-interaction requires a collider , different objects could use different kind of collider
//	-if we can use the same kind of collider that will simplify 
public class InteractionObject : MonoBehaviour
{
	public InteractionType interactionType;
	//interaction has a range requirement, it only happen within a range
	//	-this interaction object will look at proximity interaction based on collider proximity trigger (enter or exit)
	[SerializeField] private float maxRange;
	public float MaxRange => maxRange; //max range (door, camera, dialog with npc)

	//player must able to pickup various size cubes.
	//	-when seomthing is picked up it disappear from the screen.
	//	-something could be pick up to be consumed like food or use later like a key to unlock a door.
	public bool pickingIsForKeep;

	//player must be able to dialog or talk with other NPC or AI.
	// -the NPC could initiate the dialog or the player could initiate the dialog.
	// -the dialog could be playing an audio.
	// -the dialog could be 
	public bool interactionIsDialog;
	public bool dialogIsInitiated;
	public bool dialogIsFeedback;
	public bool dialogFeedbackIsPlayingAudio;
	public string dialogText;
	[SerializeField] private Dialogue[] dialogueList;
	private Queue<Dialogue> dialogueQueue;

	//player can request a quest, pick it up or return it.
	//	- quest are stored as name
	//	- can the player only take one quest or should we provide storage for multiple quests
	public string questName;
	public bool pickingAQuest; //A quest could be requested or returned in a dialog
	public bool releasingAQuest;
	public bool activateQuest;

	//public AudioSource audioSource;

	//player should be able to open or close doors.
	//	- door can be locked / unlocked.
	//	- door can be opened / closed.
	//  - if door need to be unlocked then we may need to have a key or a power to allow player to do that.
	//	- to have a key may require picking the key and keeping it for later use e.g. unlocking the door.
	//	- opening a door may need another object (key) to interact with the door.
	//	- the required intereaction object can be used only once or allowed to be reused over and over once it is picked up.
	//	- interaction with the door includes opening and closing the door. Animation could be provided for that.

	public GameObject neededInteractionObject;
	public bool multiUseInteractionObject;
	public bool interactionIsOpenOrCloseEntry;
	public bool entryIsLocked;
	public bool entryIsOpened;

	//interaction may require playing an animation. For door we can imagine opening and closing the entry as two distincts 
	public Animator animator;

	public string entryOpeningAnimation;
	public string entryClosingAnimation;
	public bool interactionRequiresAnimation;
	public string interactionAnimation;

	//interaction could be automatic like pciking as soon as the player collides with the object
	public bool interactionIsAutomatic;
	public GameObject interactionIcon; //this could be on player interaction

    private void Start()
    {
		dialogueQueue = new Queue<Dialogue>();
		if(dialogueList.Any() )
        {
			foreach(Dialogue dialogue in dialogueList)
            {
				dialogueQueue.Enqueue(dialogue);
            }
        }
    }

    //what happen when you interact with 
    public void OnInteract()
	{
		//picked up and put in inventory
		gameObject.SetActive(false);
	}

	//playing opening entry animation
	public void OpenEntry()
	{
		if (!string.IsNullOrEmpty(entryOpeningAnimation))
		{
			animator.SetBool(entryOpeningAnimation, true);
		}
	}

	//playing closing entry animation
	public void CloseEntry()
	{
		if (!string.IsNullOrEmpty(entryClosingAnimation))
		{
			animator.SetBool(entryClosingAnimation, true);
		}
	}

	//playing interaction animation
	public void PlayInteractionAnimation()
	{
		if (!string.IsNullOrEmpty(interactionAnimation))
		{
			animator.SetBool(interactionAnimation, true);
		}
	}

	//interaction are not always active. Interactions can start and end.
	//	- proximity to the interaction collider or raycasting hit to the interaction collider will activate the interaction
	//	- the activation can present something on the UI
	//	- the interaction can be deactivated if the object is no longer in the proximity of the player.
	public void OnInteractionActivation()
	{
		//TBD
		//shows interactionIcon
	}
	public void OnInteractionDeActivation()
	{
		//TBD
		//hides interactionIcon
	}

	public Dialogue GetNextDialogue()
    {
		if(dialogueQueue.Any())
        {
			return dialogueQueue.Dequeue();
        }
		return null;
    }

	public void ShowNextDialogue(Text promptText, Text responseText )
	{
		promptText.text = "";
		responseText.text = "";
		if (dialogueQueue.Any())
		{
			Dialogue dialogue = dialogueQueue.Dequeue();
			promptText.text = dialogue.prompt;
			responseText.text = dialogue.response;
		}
	}

}



