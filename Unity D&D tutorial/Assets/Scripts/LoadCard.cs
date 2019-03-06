using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadCard : MonoBehaviour
{
    public GameObject card;
    readonly _PlayerController_ playerDeck;
    Text displayText;
    int deckSize;
    public void Loadcard (){
        _PlayerController_.playerController.Addcard(card);
        deckSize = _PlayerController_.playerController.Getdecksize();
        displayText = GameObject.Find("Card added ").GetComponent<Text>();
        displayText.text = "card added "+ deckSize +"/60 added";
        

    }

}
