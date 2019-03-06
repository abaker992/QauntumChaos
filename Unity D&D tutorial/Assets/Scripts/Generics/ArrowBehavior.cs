using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ArrowBehavior : MonoBehaviour
{



    GameObject lab;
    GameObject rab;
    Transform parent;
    Transform Grandpa;
    [SerializeField]
    private int sibIndex;
    List<int> sides;



    private void Start()
    {
        int children = this.transform.childCount;
        sides = new List<int>();
        int side;


        if (this.transform.parent.GetComponent<_GenericCardBehavior_>().ofPlayer != true)
        {
            for (int i = 0; i <= (children - 1); i++)
            {
                Button button = this.transform.GetChild(i).GetComponent<Button>();
                Color newColor = new Color(1f, 1f, 1f, 1f);
                ColorBlock cb = button.colors;
                cb.disabledColor = newColor;
                button.colors = cb;
                button.interactable = false;

            }

        }
        else
        {
            for (int i = 0; i <= (children - 1); i++)
            {
                string child = this.transform.GetChild(i).gameObject.name;
                int.TryParse(child, out side);
                sides.Add(side);
            }
            Nullify(sides);
        }
    }

    public void DoDamage(int side, int dmg)
    {




        Grandpa = this.transform.parent.parent;
        sibIndex = Grandpa.GetSiblingIndex();
        GameObject enemy;
        string message = "hit for " + dmg + " dmg!";
        string slot;
        switch (side)
        {
            case 1:
                if (GameObject.Find("Slot (" + ((sibIndex) +1) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) + 1) + ")";
                    Debug.Log(slot);
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;
                    Debug.Log(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer);

                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;


            case 2:
                if (GameObject.Find("Slot (" + ((sibIndex) + 5) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) + 5) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;
                    if (!(enemy.gameObject.GetComponent<_GenericCardBehavior_>().ofPlayer)) {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;


            case 3: 
                if (GameObject.Find("Slot (" + ((sibIndex) + 4) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) + 4) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;

                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;

            case 4:
                if (GameObject.Find("Slot (" + ((sibIndex) + 3) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) + 3) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;

                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;

            case 5:
                if (GameObject.Find("Slot (" + ((sibIndex) - 1) + ")").transform.childCount != 0) 
                {
                    slot = "Slot (" + ((sibIndex) - 1) + ")";
                    Debug.Log(side);
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;

                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }
                   

                }
                break;

            case 6:
                if (GameObject.Find("Slot (" + ((sibIndex) - 5) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) - 5) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;
                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;

            case 7:
                if (GameObject.Find("Slot (" + ((sibIndex) - 4) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) - 4) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;
                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;

            case 8:
                if (GameObject.Find("Slot (" + ((sibIndex) -3) + ")").transform.childCount != 0)
                {
                    slot = "Slot (" + ((sibIndex) - 3) + ")";
                    enemy = GameObject.Find(slot).transform.GetChild(0).gameObject;
                    if (!(enemy.GetComponent<_GenericCardBehavior_>().ofPlayer))
                    {
                        enemy.GetComponent<_GenericBattleCardBehavior_>().Attacked(dmg, enemy);
                        Debug.Log(message);
                    }

                }
                break;

        }
    }




    public void Nullify(List<int> sides)
    {


        Grandpa = this.transform.parent.parent;
        sibIndex = Grandpa.GetSiblingIndex();
        ArrowBehavior arrowBehavior = this;

        if ( sibIndex % 4 == 0)
        {

            foreach (int side in sides)
            {

                switch (side)
                {
                    case 3:
                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;
                    case 4:
                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;
                    case 5:

                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;

                    default:

                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = true;
                        break;

                }

            }

        }

        else if ((sibIndex + 1) % 4 == 0 || sibIndex == 19)
        {

            foreach (int side in sides)
            {

                switch (side)
                {
                    case 1:

                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;
                    case 2:
                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;
                    case 8:
                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = false;
                        break;

                    default:
                        arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = true;
                        break;

                }

            }


        }
        else
            {
            foreach (int side in sides)
            {
                arrowBehavior.transform.Find("" + side).GetComponent<Button>().interactable = true;

            }

        }

    }
}