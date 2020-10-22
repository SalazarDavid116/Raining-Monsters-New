using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonControlller : MonoBehaviour
{
    public void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }
}
