using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy;
    public int count;
    public Transform[] startLocations;

    private void Start()
    {
        count = startLocations.Length;
    }
}
