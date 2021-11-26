// <copyright file="State.cs" company="MageWang">
// Copyright (c) MageWang. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <author>Mage Wang</author>
using System.Collections.Generic;
using Godot;

/// <summary>
/// State.
/// </summary>
public class State : StateMachine
{
    /// <summary>
    /// Gets or sets a value indicating whether StateMachine.
    /// </summary>
    private StateMachine stateMachine = null;

    /// <summary>
    /// Gets or sets a value indicating whether IsReady.
    /// </summary>
    private bool IsReady { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating StateMachineReady.
    /// </summary>
    public override void StateMachineReady()
    {
        // GD.Print("State " + name + " state_machine_ready");
    }

    /// <summary>
    /// Ready.
    /// </summary>
    public virtual void Ready()
    {
        // GD.Print("State " + name + " ready")
        base.StateMachineReady();
    }

    /// <summary>
    /// Process.
    /// </summary>
    /// <param name="delta">delta of time in seconds.</param>
    public virtual void Process(float delta)
    {
    }

    /// <summary>
    /// End.
    /// </summary>
    public virtual void End()
    {
        if (this.GetStateNow() == null)
        {
            return;
        }

        this.GetStateNow().End();
        this.SetStateNow(null);
    }

    /// <summary>
    /// Input.
    /// </summary>
    /// <param name="event">@event.</param>
    public virtual void Input(InputEvent @event)
    {
    }

    /// <summary>
    /// UnhandledInput.
    /// </summary>
    /// <param name="event">@event.</param>
    public virtual void UnhandledInput(InputEvent @event)
    {
    }

    /// <summary>
    /// UnhandledKeyInput.
    /// </summary>
    /// <param name="event">@event.</param>
    public virtual void UnhandledKeyInput(InputEvent @event)
    {
    }

    /// <summary>
    /// SetStateMachine.
    /// </summary>
    /// <param name="stateMachine">stateMachine.</param>
    public void SetStateMachine(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
