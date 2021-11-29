// <copyright file="GridManager.cs" company="MageWang">
// Copyright (c) MageWang. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using Godot;

/// <summary>
/// GridType.
/// </summary>
public enum GridType
{
    /// <summary>
    /// SQUARE.
    /// </summary>
    SQUARE,

    /// <summary>
    /// HEX.
    /// </summary>
    HEX,
}

/// <summary>
/// GridManager.
/// </summary>
public class GridManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private Grid[][] gridMap;
    private bool processFirst = true;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// </summary>
    public override void _Ready()
    {
        GD.Print("Owner " + Owner);
    }

    /// <summary>
    /// _Process.
    /// </summary>
    /// <param name="delta">delta.</param>
    public override void _Process(float delta)
    {
        if (!this.processFirst)
        {
            return;
        }

        var mainScenes = ProjectSettings.GetSetting("custom/main_scene") as string[];
        var root = this.GetNode("/root");
        GD.Print("root " + this.GetNode("/root"));
        for (var i = 0; i < root.GetChildCount(); i++)
        {
            Node child = root.GetChild<Node>(i);
            if (Array.IndexOf(mainScenes, (child as Node).Name) != -1)
            {
                return;
            }
        }

        this.Init(10, 10, GridType.SQUARE, "res://image/grid.png");
        this.processFirst = false;
    }

    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="gridColumnNum">gridColumnNum.</param>
    /// <param name="gridRowNum">gridRowNum.</param>
    /// <param name="gridType">gridType.</param>
    /// <param name="gridPath">gridPath.</param>
    public void Init(int gridColumnNum, int gridRowNum, GridType gridType, string gridPath)
    {
        GD.Print("GridManager::Init");
        Node parent = this.GetParent();
        Node gridsNode = parent.GetNodeOrNull("Grids");
        if (gridsNode != null && gridsNode.GetChildCount() > 0)
        {
            parent.RemoveChild(gridsNode);
            gridsNode = null;
        }

        if (gridsNode == null)
        {
            var ins = new Node2D();
            parent.AddChild(ins);
            ins.Name = "Grids";
            ins.Owner = this.GetTree().EditedSceneRoot;
            gridsNode = ins;
        }

        var packedScene = ResourceLoader.Load(gridPath);

        if (gridType == GridType.SQUARE)
        {
            this.gridMap = new Grid[gridColumnNum][];
            for (var i = 0; i < gridColumnNum; i++)
            {
                this.gridMap[i] = new Grid[gridRowNum];
            }

            for (var i = 0; i < gridColumnNum; i++)
            {
                for (var j = 0; j < gridRowNum; j++)
                {
                    var ins = packedScene. .Instance<Grid>();
                    gridsNode.AddChild(ins);
                    ins.Owner = this.GetTree().EditedSceneRoot;
                    ins.Position = new Vector2(j * ins.Texture.GetSize().x, i * ins.Texture.GetSize().y);
                    this.gridMap[i][j] = ins;
                }
            }
        }
    }

// // Called every frame. 'delta' is the elapsed time since the previous frame.
// public override void _Process(float delta)
// {
// }
}
