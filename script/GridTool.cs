// <copyright file="GridTool.cs" company="MageWang">
// Copyright (c) MageWang. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
using System;
using Godot;

/// <summary>
/// GridTool.
/// </summary>
public class GridTool : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private bool generateGrids = false;

    [Export]
    private bool GenerateGrids
    {
        get
        {
            return this.generateGrids;
        }

        set
        {
            GD.Print("set_generate_grids");
            Node parent = this.GetParent();
            Node gridsNode = parent.GetNodeOrNull("Grids");
            if (gridsNode == null)
            {
                var ins = new Node2D();
                parent.AddChild(ins);
                ins.Name = "Grids";
                ins.Owner = this.GetTree().EditedSceneRoot;
                gridsNode = ins;
            }

            if (gridsNode.GetChildCount() > 0)
            {
                GD.Print("gridsNode.get_child_count() > 0");
                return;
            }

            // if (parent.grid_type == parent.GridType.SQUARE)
            // {
            //     parent.grid_map = []
            //     for _i in range(parent.grid_map_h):
            //         parent.grid_map.append([])
            //     for i in range(parent.grid_map_h):
            //         for j in range(parent.grid_map_w):
            //             var ins = parent.grid.instance() as Sprite
            //             gridsNode.add_child(ins)
            //             ins.set_owner(get_tree().get_edited_scene_root())
            //             ins.position.x = j*ins.texture.get_size().x
            //             ins.position.y = i*ins.texture.get_size().y
            //             parent.grid_map[i].append(parent.get_path_to(ins))
            // }
            // else if(parent.grid_type == parent.GridType.HEX)
            // {
            //     parent.grid_map = []
            //     for _i in range(parent.grid_map_h):
            //         parent.grid_map.append([])
            //     for i in range(parent.grid_map_h):
            //         for j in range(parent.grid_map_w):
            //             var ins = parent.grid.instance()
            //             gridsNode.add_child(ins)
            //             ins.set_owner(get_tree().get_edited_scene_root())
            //             ins.position.x = j*ins.texture.get_size().x
            //             if i % 2 == 0:
            //                 ins.position.x += ins.texture.get_size().x/2
            //             ins.position.y = i*ins.texture.get_size().y
            //             parent.grid_map[i].append(parent.get_path_to(ins))
            // }
        }
    }

    [Export]
    private bool AlignGrids { get; set; } = false;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// </summary>
    public override void _Ready()
    {
        GD.Print("custom/dev: " + ProjectSettings.GetSetting("custom/dev"));
        GD.Print("get: " + this.GetTree().Root.Name);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {
    // }
}
