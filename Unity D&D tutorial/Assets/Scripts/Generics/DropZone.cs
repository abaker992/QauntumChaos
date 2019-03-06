using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler,IPointerExitHandler {

	public draganddrop.Slot typeOfCard = draganddrop.Slot.ENERGY;
    int spacesMoved;


    public void OnPointerExit (PointerEventData eventData)
    {

    }


	public void OnPointerEnter (PointerEventData evenData){


	}


	public void OnDrop (PointerEventData eventData){

		draganddrop d = eventData.pointerDrag.GetComponent<draganddrop>();
		_GenericCardBehavior_ gcb = eventData.pointerDrag.GetComponent<_GenericCardBehavior_>();
        Transform originGrandpa;



	
		if (this.transform.parent.parent == GameObject.Find ("The_Field").transform) {
			
            gcb.returnedToParent = this.transform;
            originGrandpa = this.transform.parent;

            if (gcb.returnedToParent.childCount == 0)
            {


                if (gcb.gameObject.CompareTag("HandCard") && this.CompareTag("SpawnPoint"))
                {
                    gcb.originParent = gcb.returnedToParent;



                }

                if (gcb.gameObject.CompareTag("BattleCard"))
                {



                    if (gcb.originParent.parent.GetSiblingIndex() >= originGrandpa.GetSiblingIndex() - 1
                                && gcb.originParent.parent.GetSiblingIndex() <= originGrandpa.GetSiblingIndex() + 1)
                    {

                        Debug.Log("passed in range check");

                        if (gcb.originParent.parent == originGrandpa) 
                        {
                            Debug.Log("passed in row check");

                            spacesMoved = Mathf.Abs(gcb.originParent.GetSiblingIndex() - gcb.returnedToParent.GetSiblingIndex());

                            if (_PlayerController_.playerController.GetEnergyCount() > spacesMoved)
                            {
                                Debug.Log("passed greater than 0 check");

                                _PlayerController_.playerController.SetEnergyCount(-spacesMoved);
                            }
                            else
                            {
                                gcb.returnedToParent = gcb.originParent;

                            }


                        }

                        else if (gcb.originParent.parent.GetSiblingIndex() == originGrandpa.GetSiblingIndex() + 1)
                        {
                            Debug.Log("passed going up check");
                            spacesMoved = Mathf.Abs(gcb.originParent.GetSiblingIndex() - gcb.returnedToParent.GetSiblingIndex());
                            if (_PlayerController_.playerController.GetEnergyCount() > spacesMoved)
                            {
                                Debug.Log("passed greater than 0 check");

                                _PlayerController_.playerController.SetEnergyCount((-spacesMoved) - 1);
                            }
                            else
                            {
                                Debug.Log(spacesMoved);

                                gcb.returnedToParent = gcb.originParent;

                            }


                        }


                        if (_PlayerController_.playerController.GetEnergyCount() >= 0 && gcb.returnedToParent != gcb.originParent)
                        {
                            gcb.originParent = gcb.returnedToParent;
                            gcb.isPlayed = true;
                            SealDimension(gcb);
                        }

                        else
                        {
                            gcb.returnedToParent = gcb.originParent;
                        }

                 
                    }

                    else
                    {
                        gcb.returnedToParent = gcb.originParent;
                    }
                }
                else
                {

                    gcb.returnedToParent = gcb.originParent;
                }
            

            }
            else
            {
                Debug.Log("there again");
                gcb.returnedToParent = gcb.originParent;
            }
				
		} 
    
}




    public void SealDimension(_GenericCardBehavior_ card)
    {



        Transform row = card.transform.parent;
        if(16 <= row.GetSiblingIndex() && row.GetSiblingIndex() <= 19 )
        {
            Debug.Log(row.childCount);
            if (card.GetComponent<_GenericCardBehavior_>().ofPlayer == false)
            {
                _Gamecontroller_.KeepScore(card.gameObject,1);


            }

        }

    }


}



		

