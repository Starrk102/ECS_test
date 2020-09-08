using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUniversalScriptableObject", menuName = "UniversalScriptableObject", order = 51)]
public class UniversalScriptableObject : ScriptableObject
{
    [SerializeField]
    private string objName;
    [SerializeField]
    private string objDescription;
    [SerializeField]
    private Sprite objIcon;
    [SerializeField]
    public GameObject obj;
    [SerializeField]
    public float objSpeed = 2f;
    //по такому же принципу добавить доп. свойства объекту
    public static UniversalScriptableObject CreatePlayerObj() => Resources.Load("ScriptableObject/PlayerScriptableObject") as UniversalScriptableObject;
    
    public static UniversalScriptableObject CreateEnemyObj() => Resources.Load("ScriptableObject/EnemyScriptableObject") as UniversalScriptableObject;
    
    public string ObjName
    {
        get
        {
            return objName;
        }
    }

    public string ObjDescription
    {
        get
        {
            return objDescription;
        }
    }

    public Sprite ObjIcon
    {
        get
        {
            return objIcon;
        }
    }

    public GameObject Obj
    {
        get
        {
            return obj;
        }
    }

    public float ObjSpeed
    {
        get
        {
            return objSpeed;
        }
    }
}
