using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestionPanel : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text countText;
    [SerializeField] UI_OwnedResources resourceStorage;
    [SerializeField] Transform questionContainer;
    [SerializeField] Transform mainCanvas;

    int count = 0;
    Struct_Resource resource;
    Vector3 iconPos;

    private void Awake()
    {
        iconPos = icon.rectTransform.anchoredPosition;
        gameObject.SetActive(false);
    }

    public void SetupQuestion(Struct_Resource incomingResource, int _count)
    {
        resource = incomingResource;
        count = _count;

        icon.sprite = resource.icon;
        countText.text = count.ToString();

        icon.color = Color.white;
        icon.rectTransform.anchoredPosition = iconPos;

        resourceStorage.transform.SetParent(questionContainer);
        resourceStorage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        resourceStorage.EnableButtons(true);
        gameObject.SetActive(true);
    }

    public int CollectResource(Struct_Resource selectedResource)
    {
        resourceStorage.EnableButtons(false);
        if (selectedResource.resourceName != resource.resourceName)
        {
            icon.rectTransform.DOLocalMoveY(-100f, 1f);
            icon.DOBlendableColor(new Color(1, 1, 1, 0), 1);
            icon.DOBlendableColor(Color.red, 1f).SetInverted(true).OnComplete(CloseWindow);
            return 0;
        }
        icon.rectTransform.DOJump(icon.rectTransform.position, 40, 3, 1f).SetEase(Ease.Linear);
        icon.DOColor(Color.green, 1f).SetInverted(true).OnComplete(CloseWindow);
        return count;
    }

    void CloseWindow()
    {
        resourceStorage.transform.SetParent(mainCanvas);
        resourceStorage.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        gameObject.SetActive(false);
    }
}
