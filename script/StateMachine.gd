class_name StateMachine
extends Node

var states = {}
var state_now = null
func _ready():
	state_machine_ready()

func state_machine_ready():
	#print("StateMachine " + name + " _ready")
	states = {}
	# add all child state nodes in states & get set first node as state now
	for child in get_children():
		if !("state_machine" in child):
			continue
		child.state_machine = self
		states[child.name] = child
		print(name + " add state:" + child.name)
		if state_now == null :
			print(name + " state_now: " + child.name)
			state_now = child
	if state_now == null:
		print(name + " state_now == null")
		return
	state_now.ready()
	print(name + " init state:" + state_now.name)
	
func _process(delta):
	if state_now == null:
		return
	state_now.process(delta)

func _input(event):
	if state_now == null:
		return
	state_now.input(event)
	pass

func _unhandled_input(event):
	if state_now == null:
		return
	state_now.unhandled_input(event)
	pass
	
func _unhandled_key_input(event):
	if state_now == null:
		return
	state_now.unhandled_key_input(event)
	pass
	
func transition(name):
	if state_now == null:
		return
	print("transtion to :" + name)
	state_now.end()
	state_now = states[name]
	state_now.ready()
	pass

