using UnityEngine;

public class ReadInteraction
{
    [SerializeField] private GameObject _gmPrefab;

    public GameObject GetInteractionObject(string pathFromResources)
    {
        return GameObject.Instantiate(Resources.Load(pathFromResources)) as GameObject;
    }
}