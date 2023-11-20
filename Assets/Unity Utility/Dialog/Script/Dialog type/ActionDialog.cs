using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDialog : DialogBase,IDialog
{

    public void PositiveButtonPressed()
    {
        if(GetDialogClass() != null)
            GetDialogClass().positiveButtonAction(this);
    }

    public void NegativeeButtonPressed()
    {
        if (GetDialogClass() != null)
            GetDialogClass().negativeButtonAction(this);
    }

    public void HideDialog()
    {
        HideDialogPanel();
    }
}
