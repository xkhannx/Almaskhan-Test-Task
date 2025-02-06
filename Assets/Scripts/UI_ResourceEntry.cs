using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.DefaultControls;

public class UI_ResourceEntry : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Slider progressBar;
    [SerializeField] Text countText;
    public int count;
    float timer = 0;
    Struct_Resource resource;
    Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public void SetupEntry(Struct_Resource entry)
    {
        resource = entry;
        icon.sprite = resource.icon;
        countText.text = "0";
        progressBar.value = 0;

        count = 0;
        DOTween.To(() => timer, x => timer = x, 1, resource.buildTime)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear)
            .OnUpdate(UpdateProgressBar)
            .OnStepComplete(() => UpdateCount(1));
    }

    void UpdateProgressBar()
    {
        progressBar.value = timer;
    }

    void UpdateCount(int delta)
    {
        count += delta;
        countText.text = count.ToString();
    }

    public void Collect()
    {
        if (count == 0) return;

        if (player.PrepareResource(resource, count))
        {
            UpdateCount(-count);
        }
    }
}
