using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogClass
{
    public string title { get; set; }
    public string message { get; set; }
    public string positiveButtonText { get; set; }
    public string negativeButtonText { get; set; }
    public Action<IDialog> positiveButtonAction { get; set; }
    public Action<IDialog> negativeButtonAction { get; set; }


    public DialogClass(DialogBuilder dialogBuilder)
    {
        this.title = dialogBuilder.title;
        this.message = dialogBuilder.message;
        this.positiveButtonText = dialogBuilder.positiveButtonText;
        this.negativeButtonText = dialogBuilder.negativeButtonText;
        this.positiveButtonAction = dialogBuilder.positiveButtonAction;
        this.negativeButtonAction = dialogBuilder.negativeButtonAction;
    }
}
