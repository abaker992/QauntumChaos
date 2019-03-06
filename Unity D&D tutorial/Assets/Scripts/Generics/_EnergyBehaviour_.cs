using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _EnergyBehaviour_ : MonoBehaviour
{

    Text displayText;

    private void Start()
    {
        _PlayerController_.playerController.SetEnergyCount(10);
    }
    private void Update()
    {
        UpdateEnergy(); 
    }
    public void UpdateEnergy()
    {
        displayText = this.gameObject.GetComponent<Text>();
        //Debug.Log(displayText);
        displayText.text= _PlayerController_.playerController.GetEnergyCount().ToString();

    }



}
