using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClothSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private bool isBeingDragged = false;
    private static ClothSlot currentlyDraggedItem;
    private ClothSlot collisionItem; // ��� �������� �������, � ������� ��������� ������������

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        isBeingDragged = true;
        currentlyDraggedItem = this;
        collisionItem = null; // �������� ������ ������������ ��� ������ ��������������
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;
        currentlyDraggedItem = null;

        if (collisionItem != null)
        {
            // ��������� ��������������, ������� ��������� �� ����� ��������������
            // ���� ������ ������ ������� ��� ���������� ������ listCloth �����
            WardrobeTask.Instance.ChangeSlots(collisionItem.gameObject.name, gameObject.name);

            string tempNameGameObject = gameObject.name;
            string tempNameCollision = collisionItem.gameObject.name;

            gameObject.name = tempNameCollision;
            collisionItem.gameObject.name = tempNameGameObject;
        }

        rectTransform.anchoredPosition = originalPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBeingDragged && collision.GetComponent<ClothSlot>() != null)
        {
            collisionItem = collision.GetComponent<ClothSlot>();
        }
    }
}
