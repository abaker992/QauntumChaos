using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BOTPBattle : MonoBehaviour, IEndDragHandler
{
    readonly int lftArrow = 5;
    readonly int rghtArrow = 1;
    public int sibIndex;

    GameObject ah;

    List<int> sides;
    Transform Grandpa;
    ArrowBehavior ab;


    public void Start()
    {

    }




    public void OnEndDrag(PointerEventData eventData)
    {

        sides = new List<int>();
        sides.Add(lftArrow);
        sides.Add(rghtArrow);
        ah = this.transform.Find("ArrowHolder").gameObject;
        ab = ah.GetComponent<ArrowBehavior>();
        ab.Nullify(sides);




    }

}
