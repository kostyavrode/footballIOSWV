using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBuilder
{
    public string title { get; set; }
    public string message { get; set; }
    public string positiveButtonText { get; set; }
    public string negativeButtonText { get; set; }
    public Action<IDialog> positiveButtonAction { get; set; }
    public Action<IDialog> negativeButtonAction { get; set; }


    public DialogBuilder()
    {
    }
    public DialogBuilder Title(string title)
    {
        this.title = title;
        return this;
    }
    public DialogBuilder Message(string message)
    {
        this.message = message;
        return this;
    }
    public DialogBuilder PositiveButtonText(string positiveButtonText)
    {
        this.positiveButtonText = positiveButtonText;
        return this;
    }
    public DialogBuilder NegativeButtonText(string negativeButtonText)
    {
        this.negativeButtonText = negativeButtonText;
        return this;
    }
    public DialogBuilder PositiveButtonAction(Action<IDialog> action)
    {
        this.positiveButtonAction = action;
        return this;
    }
    public DialogBuilder NegativeButtonAction(Action<IDialog> action)
    {
        this.negativeButtonAction = action;
        return this;
    }

    public DialogClass build()
    {
        return new DialogClass(this);
    }
}