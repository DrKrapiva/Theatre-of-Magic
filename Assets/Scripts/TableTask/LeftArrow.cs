using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrow : MonoBehaviour
{
    public void Click()
    {
        PanelSafe.Instance.GetIndexInListLeft(gameObject.name);
    }
}
