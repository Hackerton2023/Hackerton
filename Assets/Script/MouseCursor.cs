using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public static void SetActive(bool value)
    {
        Cursor.visible = value;
    }
}
