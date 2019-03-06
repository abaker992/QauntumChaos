using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="create card/Battle")]
public class Card : ScriptableObject
{

    public Sprite art;
    public int health;
    public int lftarrowdmg;
    public int rghttarrowdmg;
    public int uparrowdmg;
    public int dwnarrowdmg;
    public int cuplftarrowdmg;
    public int cuprghtarrowdmg;
    public int cdwnrghtarrowdmg;
    public int cdwnleftarrowdmg;


}

[CreateAssetMenu(menuName = "create card/Detail")]
public class Detail : ScriptableObject
{

    public Sprite art;
    public Text cardName;
    public Text detail;




}

[CreateAssetMenu(menuName = "create card/Icon")]
public class Icon : ScriptableObject
{

    public Sprite art;
    public Text cardName;
    public Text detail;




}