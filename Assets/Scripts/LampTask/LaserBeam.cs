using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private Transform target; // Целевой объект
    private LineRenderer lineRenderer;
    public Transform Target { get { return target; } }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.9f;

        
        GetTargetSpot();
        MakeLine();
    }

    private void MakeLine()
    {
        if (lineRenderer != null && target != null)
        {
            lineRenderer.SetPosition(0, transform.position); // Начальная точка линии у позиции лампочки
            lineRenderer.SetPosition(1, target.position); // Конечная точка линии у позиции целевого объекта
        }
    }
    private void GetTargetSpot()
    {
        target = LampTask.Instance.GiveTargetSpot();
    }
    public void ClickLampBulb()
    {
        target = LampTask.Instance.GiveNewTargetSpot(target);
        MakeLine();
    }
}
