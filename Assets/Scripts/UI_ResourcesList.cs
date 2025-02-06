using System.Collections.Generic;
using UnityEngine;

public class UI_ResourcesList : MonoBehaviour
{
    [SerializeField] UI_ResourceEntry resourceEntryPrefab;
    List<UI_ResourceEntry> resourceEntryList = new();
    public void SetupList(List<Struct_Resource> resourceList)
    {
        foreach (Struct_Resource resource in resourceList)
        {
            UI_ResourceEntry newEntry = Instantiate(resourceEntryPrefab, transform);
            newEntry.SetupEntry(resource);
            resourceEntryList.Add(newEntry);
        }

        Vector2 entrySize = resourceEntryList[0].GetComponent<RectTransform>().sizeDelta;
        GetComponent<RectTransform>().sizeDelta = new Vector2(entrySize.x, resourceEntryList.Count * entrySize.y);
    }
}
