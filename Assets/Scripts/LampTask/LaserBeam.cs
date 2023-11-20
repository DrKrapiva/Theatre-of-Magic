using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private Transform target; // ������� ������
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
            lineRenderer.SetPosition(0, transform.position); // ��������� ����� ����� � ������� ��������
            lineRenderer.SetPosition(1, target.position); // �������� ����� ����� � ������� �������� �������
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
