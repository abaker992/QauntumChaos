using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GenericBattleCardBehavior_ : MonoBehaviour, IFightable
{
    public Image art;
    [SerializeField]
    public int health;
    public Card card;
    int lftarrowdmg;
    int rghttarrowdmg;
    int uparrowdmg;
    int dwnarrowdmg;
    int cuplftarrowdmg;
    int cuprghtarrowdmg;
    int cdwnrghtarrowdmg;
    int cdwnleftarrowdmg;

    GameObject ah;
    ArrowBehavior ab;


    private void Start()
    {
        BuildCrd(card);
    }

    public void BuildCrd(Card crd)
    {
        card = crd;
        art.sprite = crd.art;
        health = crd.health;
        lftarrowdmg = crd.lftarrowdmg;
        rghttarrowdmg = crd.rghttarrowdmg;
        uparrowdmg = crd.uparrowdmg;
        dwnarrowdmg = crd.dwnarrowdmg;
        cuplftarrowdmg = crd.cuplftarrowdmg;
        cuprghtarrowdmg = crd.uparrowdmg;
        cdwnrghtarrowdmg = crd.cdwnrghtarrowdmg;
        cdwnleftarrowdmg = crd.cdwnleftarrowdmg;

    }

    public void Attack(string name)
    {

        ah = this.transform.Find("ArrowHolder").gameObject;

        ab = ah.GetComponent<ArrowBehavior>();
        switch (name)
        {
            case "rghtArrow":

                ab.DoDamage(1, rghttarrowdmg);
                break;

            case "lftArrow":
                ab.DoDamage(5, lftarrowdmg);
                break;

            case "upArrow":
                ab.DoDamage(7, uparrowdmg);
                break;

            case "dwnArrow":
                ab.DoDamage(3, dwnarrowdmg);
                break;

            case "cuplftArrow":
                ab.DoDamage(4, cuplftarrowdmg);
                break;

            case "cuprghtArrow":
                ab.DoDamage(2, cuprghtarrowdmg);
                break;

            case "cdwnlftArrow":
                ab.DoDamage(6, cdwnleftarrowdmg);
                break;

            case "cdwnrghtArrow":
                ab.DoDamage(8, cdwnrghtarrowdmg);
                break;
        }


    }


    public void Attacked(int n, GameObject self)
    {
        health -= n;
        if (health <= 0)
        {
            Destroy(self);
        }

    }

  
}
