using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : MonoBehaviour
{
    public void Click()
    {
        PanelSafe.Instance.GetIndexInListRight(gameObject.name);
    }
}

