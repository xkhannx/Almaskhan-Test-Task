using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_OwnedResourceEntry : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text countText;
    [SerializeField] Button button;

    Struct_Resource resource;
    int count = 0;
    public void SetupEntry(Struct_Resource entry)
    {
        resource = entry;
        icon.sprite = resource.icon;
        countText.text = "0";
    }

    public void EnableButton(bool enable)
    {
        button.interactable = enable;
    }

    public void UpdateCount()
    {
        int delta = FindObjectOfType<UI_QuestionPanel>().CollectResource(resource);

        count += delta;
        countText.text = count.ToString();
    }
}
