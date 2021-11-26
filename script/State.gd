class_name State
extends StateMachine

var state_machine
var is_ready = false

# Called when the node enters the scene tree for the first time.
func state_machine_ready():
	#print("State " + name + " state_machine_ready")
	pass # Replace with function body.

func ready():
	
	#print("State " + name + " ready")
	.state_machine_ready()

func process(_delta):
	pass

func end():
	if state_now == null:
		return
	state_now.end()
	state_now = null
	pass

func input(_event):
	pass

func unhandled_input(_event):
	pass

func unhandled_key_input(_event):
	pass
