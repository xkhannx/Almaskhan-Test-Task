using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Scene references")]
    [SerializeField] Transform truck;
    [SerializeField] Transform logs;
    [SerializeField] Transform logsAnchor;
    [SerializeField] Transform pickupPoint;
    [SerializeField] Transform payload;
    [SerializeField] Transform warehouseBuilding;
    [SerializeField] UI_QuestionPanel questionPanel;
    [Header("Parameters")]
    [SerializeField] float truckSpeed = 3f;
    bool truckDeployed = false;
    Struct_Resource curResource;
    int curCount = 0;
    public bool PrepareResource(Struct_Resource resource, int count)
    {
        if (truckDeployed) return false;

        curResource = resource;
        curCount = count;
        logs.gameObject.SetActive(true);
        logs.SetParent(payload);
        logs.localPosition = Vector3.zero;
        DeployTruck();
        return true;
    }

    void DeployTruck()
    {
        truckDeployed = true;

        truck.position = warehouseBuilding.position;
        truck.LookAt(pickupPoint.position);
        truck.gameObject.SetActive(true);
        mySequence.Rewind();
        mySequence.Restart();
    }

    void DeploymentComplete()
    {
        truckDeployed = false;
        truck.gameObject.SetActive(false); 
        logs.gameObject.SetActive(false);

        questionPanel.SetupQuestion(curResource, curCount);
    }

    Sequence mySequence;
    private void Awake()
    {
        float distance = (pickupPoint.position - warehouseBuilding.position).magnitude;
        mySequence = DOTween.Sequence();
        mySequence.SetAutoKill(false);
        mySequence.Append(truck.DOMove(pickupPoint.position, distance / truckSpeed));
        mySequence.Append(
            logs.DOJump(logsAnchor.position, 3, 1, 0.2f)
                .OnComplete(() =>
                {
                    logs.SetParent(logsAnchor);
                    logs.localEulerAngles = Vector3.zero;
                    logs.localPosition = Vector3.zero;
                    truck.LookAt(warehouseBuilding.position);
                })
            );
        mySequence.Append(truck.DOMove(warehouseBuilding.position, distance / truckSpeed));
        mySequence.OnComplete(DeploymentComplete);
        mySequence.Pause();
    }
}
