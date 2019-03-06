using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class _PlayerController_ : MonoBehaviour
{
    public static _PlayerController_ playerController { get; private set; }


    private List<GameObject> Deck ;
    private int energy;
    private bool yourTurn = true; 


    private void Awake()
    {
        if (playerController == null)
        {
            playerController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Deck = new List<GameObject>();
        GameObject.Find("StartGame").GetComponent<Button>().interactable = false;


    }
    public int Getdecksize()
    {
        return Deck.Count;
    }

    public void Addcard(GameObject card){
        if (Deck.Count != 60) {
            Deck.Add(card);
            Debug.Log(card);
            GameObject.Find("StartGame").GetComponent<Button>().interactable = true;


        }
        else
        {
            print("you've reached your deck limit");
        }
    }

    public void Pluckcard ()
    {
        int index = Random.Range(0, (Deck.Count) -1);
        Debug.Log("this is the Deck size " + Deck.Count);
        if (Deck.Count == 1) 
        {
            Debug.Log( "the if " + index);
            GameObject.Find("Deck").GetComponent<Button>().interactable = false;
            Instantiate(Deck[0], GameObject.Find("Hand").transform);
            Deck.RemoveAt(0);

        }
        else
        {
            Debug.Log(index);
            Instantiate(Deck[index],GameObject.Find("Hand").transform);
            Deck.RemoveAt(index);
        }
    
   
    }

    public int GetEnergyCount()
    {
        return energy;
    }

    public int SetEnergyCount(int newEenergy)
    {
       
        energy += newEenergy;
        return energy;



    }

    public bool GetTurn()
    {
        return yourTurn;
    }

    public void SetTurn()
    {
        yourTurn = !(yourTurn);
       
    }
}
