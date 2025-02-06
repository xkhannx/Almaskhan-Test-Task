using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_OwnedResources : MonoBehaviour
{
    [SerializeField] UI_OwnedResourceEntry ownedResourceEntryPrefab;
    List<UI_OwnedResourceEntry> resourceEntryList = new();
    public void SetupList(List<Struct_Resource> resourceList)
    {
        foreach (Struct_Resource resource in resourceList)
        {
            UI_OwnedResourceEntry newEntry = Instantiate(ownedResourceEntryPrefab, transform);
            newEntry.SetupEntry(resource);
            resourceEntryList.Add(newEntry);
        }

        Vector2 entrySize = resourceEntryList[0].GetComponent<RectTransform>().sizeDelta;
        float x = resourceEntryList.Count > 3 ? 3 : resourceEntryList.Count;
        float y = (resourceEntryList.Count - 1) / 3 + 1;
        GetComponent<RectTransform>().sizeDelta = new Vector2(x * entrySize.x, y * entrySize.y);
    }

    public void EnableButtons(bool enable)
    {
        foreach (UI_OwnedResourceEntry resource in resourceEntryList)
        {
            resource.EnableButton(enable);
        }
    }
}
