using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNextButton : MonoBehaviour
{
    public void GetNextDialog()
    {
        DBDialogManager.Instance.NextDialog();
    }
}
