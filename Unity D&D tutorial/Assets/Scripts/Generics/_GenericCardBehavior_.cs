using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//the comma is like impliments in Java, so what your saying is youre implimenting the IBeginDragHandler etc. interface
public class _GenericCardBehavior_ : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform returnedToParent = null;
    public Transform originParent = null;
    public Transform Player = null;
    public bool ofPlayer = true;
    public bool isPlayed = false;
    public bool go;
    Quaternion newQuaternion = new Quaternion();


    public GameObject sealCard;
    GameObject bc;



    private void Start()
    {
        originParent = this.transform.parent;

        if (this.gameObject.tag == "BattleCard" && this.Player != GameObject.Find("Player1").transform)

        {

            Debug.Log("words");
            this.transform.Find("Image").localScale = new Vector3(-1f, 1f, 1f);
            this.ofPlayer = false;
        }


    }


    private void Update()
    {
        switch (_PlayerController_.playerController.GetTurn())
        {
            case (true):
                if (this.isPlayed == true)
                {
                    this.isPlayed = true;

                }


                break;

            case (false):
                if (this.isPlayed == true)
                {
                    this.isPlayed = false;
                }
                break;
        }

    }

    //creatihng it so that you can have a card missing slot
    //GameObject placeholder = null;

    public enum Slot { ENERGY, DECK, };
    public Slot typeOfCard = Slot.ENERGY;

    //because its an interface our function needs to be public
    public void OnBeginDrag(PointerEventData eventData)
    {
        //      Debug.Log ("OnBeginDrag");


        if ((this.gameObject.CompareTag("HandCard") || this.Player == GameObject.Find("Player1").transform)
             && (this.isPlayed == false && _PlayerController_.playerController.GetTurn()))
        {
            returnedToParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);

            //this allows the card to know when its in the drop zone
            //your mouse is always raycasting to know where it is but we block it so that 
            //when getting a card the card isnt constantly consuming the raycasts so it doesnt see the mouse
            //also, you can do this in the UI but doing it this way will make it so you dont have to remeber to set things
            //just go into the code, but thts just preference
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }


    }



    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        if ((this.gameObject.CompareTag("HandCard") | this.Player == GameObject.Find("Player1").transform)
             && this.isPlayed == false && _PlayerController_.playerController.GetTurn())
        {
            //has the card follow the mouse since the render is screen space camera
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera, out pos);
            //changes the trasnformation of the card 
            this.transform.position = canvas.transform.TransformPoint(pos);
            this.transform.SetParent(GameObject.Find("Canvas").transform);




        }
        else
        {
            eventData.pointerDrag = null;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        GameObject battle = GameObject.Find("SMBattle");
        this.transform.SetParent(returnedToParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.GetComponent<RectTransform>().anchoredPosition3D = this.returnedToParent.GetComponent<RectTransform>().anchoredPosition3D;
        this.GetComponent<RectTransform>().rotation =newQuaternion;

        Debug.Log(this.GetComponent<RectTransform>().anchoredPosition3D);
        if (returnedToParent.parent.parent == GameObject.Find("The_Field").transform && this.gameObject.CompareTag("HandCard"))
        {

            bc = this.transform.GetChild(transform.childCount - 1).gameObject;
            bc.GetComponent<_GenericCardBehavior_>().Player = GameObject.Find("Player1").transform;
            bc.GetComponent<_GenericCardBehavior_>().ofPlayer = true;
            bc.GetComponent<_GenericCardBehavior_>().isPlayed = true;
            bc.SetActive(true);
            bc.transform.SetParent(this.returnedToParent);
            Destroy(gameObject);
            _PlayerController_.playerController.SetEnergyCount(-1);



        }



    }



}
