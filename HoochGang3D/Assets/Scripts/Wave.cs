using UnityEngine;

[System.Serializable]
public class Wave
{
    [HideInInspector]public GameObject _enemyPrefab;
    public Node[] startingNodes;
}
