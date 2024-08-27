using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }


    public void Show()
    {
        transform.LeanScale(Vector2.one, 0.2f);
    }


    public void Hide()
    {
        transform.LeanScale(Vector2.zero, 0.25f).setEaseInBack();
    }
}
