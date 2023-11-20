using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDialog : MonoBehaviour
{
    public void ShowActionDialog()
    {
        DialogClass actionDialogClass = new DialogBuilder().
                           Title("Action Dialog !").
                           Message(" This Is an Action Message With Two Button.").
                           PositiveButtonText("OK").
                           NegativeButtonText("Cancel").

                           PositiveButtonAction((IDialog dialog) =>
                           {
                               Debug.Log("Action Dialog posituve Button clicked ");
                               dialog.HideDialog();
                           }).

                           NegativeButtonAction((IDialog dialog) =>
                           {
                               Debug.Log("Action Dialog Negative Button clicked  ");
                               dialog.HideDialog();
                           }).

                           build();

        DialogManager.instance.SpawnDialogBasedOnDialogType(DialogTypeEnum.DialogType.ActionDialog, actionDialogClass);
    }

    public void ShowAlertDialog()
    {
        DialogClass alertDialogClass = new DialogBuilder().
                           Title("Alert Dialog !").
                           Message(" This Is an Alert Message With One Button.").
                           PositiveButtonText("Got It").
                      
                           PositiveButtonAction(AlertDialogButtonClicked).
                           build();

        DialogManager.instance.SpawnDialogBasedOnDialogType(DialogTypeEnum.DialogType.AlertDialog, alertDialogClass);
    }

    private void AlertDialogButtonClicked(IDialog iDialog)
    {
        Debug.Log("Alert Dialog Button clicked  ");
        iDialog.HideDialog();
    }
}

