using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandBehaviour : MonoBehaviour
{
	
	public void NoPluck(){
        GameObject.Find("Deck").GetComponent<Button>().interactable &= transform.childCount != 7;

    }

	

}