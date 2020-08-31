using UnityEngine;

namespace ECSGuide.ECS
{
    [CreateAssetMenu]
    public class PlayerInitDate : ScriptableObject
    {

        //public GameObject playerPrefab;
        //public float defaultSpeed = 2f;
        //метод должен быть в другом дата файле(!!!)
        public static PlayerInitDate CreateObj() => Resources.Load("Resource/ScriptableObject/PlayerScriptableOnject") as PlayerInitDate;
    }
}
