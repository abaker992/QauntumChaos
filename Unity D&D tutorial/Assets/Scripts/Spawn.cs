using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    int handCount;

	GameObject player;
	

    public void Update()
    {
        if (GameObject.Find("Hand").transform.childCount == 7 || _PlayerController_.playerController.Getdecksize() == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

    public void Spawner (){

            _PlayerController_.playerController.Pluckcard();


	}
}
