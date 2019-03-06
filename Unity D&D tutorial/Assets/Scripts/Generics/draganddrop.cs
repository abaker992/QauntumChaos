using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//the comma is like impliments in Java, so what your saying is youre implimenting the IBeginDragHandler etc. interface
public class draganddrop : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler {

	public Transform returnedToParent = null;

	//creatihng it so that you can have a card missing slot
	GameObject placeholder = null;

	public enum Slot { ENERGY, DECK,};
	public Slot typeOfCard = Slot.ENERGY;

	//because its an interface our function needs to be public
	public void OnBeginDrag(PointerEventData eventData){
		

		// creating a new game object
		placeholder = new GameObject();
		//sets the place holder to the old parent
		placeholder.transform.SetParent (this.transform.parent);
		//place holder has a layout elemnt and grabs a copy of it
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		//so now whatwe did for the cards in the UI we explicitly set it in code
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		returnedToParent = this.transform.parent;
		this.transform.SetParent (this.transform.parent.parent);

		//this alows the card to know when its in the drop zone
		//your mouse is always raycasting to know where it is but we block it so that 
		//when getting a card the card isnt constantly consuming the raycasts so it doesnt see the mouse
		//also, you can do this in the UI but doing it this way will make it so you dont have to remeber to set things
		//just go into the code, but thts just preference
		GetComponent<CanvasGroup>().blocksRaycasts = false; 



	}
	public void OnDrag(PointerEventData eventData){
		//Debug.Log ("OnDrag");
		this.transform.position = eventData.position;

		int newSiblingIndex = returnedToParent.childCount ;

		if (returnedToParent.parent == GameObject.Find ("Hand").transform) {
			for (int i = 0; i < returnedToParent.childCount; i++) {
				if (this.transform.position.x < returnedToParent.GetChild (i).position.x) {
					newSiblingIndex = i;

					if (placeholder.transform.GetSiblingIndex () < newSiblingIndex) {
						newSiblingIndex--;

					}
					break;
				}

			}
		}
		placeholder.transform.SetSiblingIndex (newSiblingIndex);


	}
	public void OnEndDrag(PointerEventData eventData){
		this.transform.SetParent (returnedToParent);
		if (returnedToParent.parent == GameObject.Find ("Hand").transform) {
			this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
		}
		GetComponent<CanvasGroup>().blocksRaycasts = true; 
		Destroy (placeholder);

	}		
		
}
