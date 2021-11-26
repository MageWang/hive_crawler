// <copyright file="UnitManager.cs" company="MageWang">
// Copyright (c) MageWang. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using Godot;

/// <summary>
/// UnitManager.
/// </summary>
public class UnitManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// </summary>
    public override void _Ready()
    {
        GD.Print("UnitManager");
    }

// // Called every frame. 'delta' is the elapsed time since the previous frame.
// public override void _Process(float delta)
// {
// }
}
