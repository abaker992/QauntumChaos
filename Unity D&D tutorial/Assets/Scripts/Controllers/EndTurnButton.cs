using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnButton : MonoBehaviour
{
    private void Update()
    {
        switch (_PlayerController_.playerController.GetTurn())
        {
            case(false):
                this.gameObject.GetComponent<Button>().interactable = false;
                break;

            case (true):
                this.gameObject.GetComponent<Button>().interactable = true;
                break;

        }
    }
}
