using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDialog : DialogBase,IDialog
{
    public void PositiveButtonPressed()
    {
        if (GetDialogClass() != null)
            GetDialogClass().positiveButtonAction(this);
    }

    public void HideDialog()
    {
        HideDialogPanel();
    }
}
