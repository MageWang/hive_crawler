// <copyright file="StateMachine.cs" company="MageWang">
// Copyright (c) MageWang. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <author>Mage Wang</author>
using System.Collections.Generic;
using Godot;

/// <summary>
/// StateMachine.
/// </summary>
public class StateMachine : Node
{
    /// <summary>
    /// StateNow.
    /// </summary>
    private State stateNow = null;

    /// <summary>
    /// States.
    /// </summary>
    private Dictionary<string, State> states;

    /// <summary>
    /// Called when the node enters the scene tree for the first time.
    /// Declare member variables here. Examples:
    /// private int a = 2;
    /// private string b = "text";.
    /// </summary>
    public override void _Ready()
    {
        this.StateMachineReady();
    }

    /// <summary>
    /// StateMachineReady.
    /// </summary>
    public virtual void StateMachineReady()
    {
        // GD.Print("StateMachine " + name + " _ready")
        this.states = new Dictionary<string, State>();

        // add all child state nodes in states and get set first node as state now
        foreach (State child in this.GetChildren())
        {
            if (child == null)
            {
                continue;
            }

            if (!(child is State))
            {
                continue;
            }

            child.SetStateMachine(this);
            this.states[child.Name] = child;
            GD.Print(this.Name + " add state:" + child.Name);
            if (this.stateNow == null)
            {
                GD.Print(this.Name + " StateNow: " + child.Name);
                this.stateNow = child;
            }
        }

        if (this.stateNow == null)
        {
            GD.Print(this.Name + " StateNow == null");
            return;
        }

        this.stateNow.Ready();
        GD.Print(this.Name + " init state:" + this.stateNow.Name);
    }

    /// <summary>
    /// _Process, overrid form Godot Node.
    /// </summary>
    /// <param name="delta">delta of time in seconds.</param>
    public override void _Process(float delta)
    {
        if (this.stateNow == null)
        {
            return;
        }

        this.stateNow.Process(delta);
    }

    /// <summary>
    /// _Input, overrid form Godot Node.
    /// </summary>
    /// <param name="event">event.</param>
    public override void _Input(InputEvent @event)
    {
        if (this.stateNow == null)
        {
            return;
        }

        this.stateNow.Input(@event);
    }

    /// <summary>
    /// _UnhandledInput, overrid form Godot Node.
    /// </summary>
    /// <param name="event">event.</param>
    public override void _UnhandledInput(InputEvent @event)
    {
        if (this.stateNow == null)
        {
            return;
        }

        this.stateNow.UnhandledInput(@event);
    }

    /// <summary>
    /// _UnhandledKeyInput, overrid form Godot Node.
    /// </summary>
    /// <param name="event">event.</param>
    public override void _UnhandledKeyInput(InputEventKey @event)
    {
        if (this.stateNow == null)
        {
            return;
        }

        this.stateNow.UnhandledKeyInput(@event);
    }

    /// <summary>
    /// Transition.
    /// </summary>
    /// <param name="name">name.</param>
    public void Transition(string name)
    {
        if (this.stateNow == null)
        {
            return;
        }

        GD.Print("Transition to :" + name);
        this.stateNow.End();
        this.stateNow = this.states[name];
        this.stateNow.Ready();
    }

    /// <summary>
    /// GetStateNow.
    /// </summary>
    /// <returns>stateNow.</returns>
    public State GetStateNow()
    {
        return this.stateNow;
    }

    /// <summary>
    /// SetStateNow.
    /// </summary>
    /// <param name="state">state.</param>
    public void SetStateNow(State state)
    {
        this.stateNow = state;
    }
}
