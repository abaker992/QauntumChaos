using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFightable 
{
    void Attack(string name);
    void Attacked(int n, GameObject self);
}
