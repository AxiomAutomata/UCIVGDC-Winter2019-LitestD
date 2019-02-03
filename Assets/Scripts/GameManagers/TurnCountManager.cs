﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCountManager : GameEventListener
{
    public IntReference turnCountRef;
    public GameEvent updateUIEvent;

    private void Start()
    {
        LoadTurnCount();
    }

    private void LoadTurnCount()
    {
        turnCountRef.value = 1;
        updateUIEvent.Raise();
    }

    public void IncrementTurnCount()
    {
        turnCountRef.value++;
        updateUIEvent.Raise();
    }
}
