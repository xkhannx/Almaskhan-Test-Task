using System;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] SO_Resources resourceTypes;
    [SerializeField] UI_ResourcesList UI_resourceList;
    [SerializeField] UI_OwnedResources UI_ownedResourceList;
    List<Struct_Resource> resourceList = new();
    void GetResourceTypes()
    {
        foreach (Struct_Resource newResource in resourceTypes.resources)
        {
            resourceList.Add(newResource);
        }
        UI_resourceList.SetupList(resourceList);
        UI_ownedResourceList.SetupList(resourceList);
    }

    private void Awake()
    {
        GetResourceTypes();
    }
}

[Serializable]
public struct Struct_Resource
{
    public string resourceName;
    public float buildTime;
    public Sprite icon;
}