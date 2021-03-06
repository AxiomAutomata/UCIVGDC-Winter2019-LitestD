﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCountListener : GameEventListener
{
    public IntReference turnCountRef;

    private void Start()
    {
        LoadTurnCount();
    }

    private void LoadTurnCount()
    {
        turnCountRef.value = 1;
        // Could later add logic to load in the turn count from a save file
    }

    public void IncrementTurnCount()
    {
        turnCountRef.value++;
    }
}
