extends VehicleBody3D

enum model_enum  {CheeseWheel, toilet, RiggedDude, cardboard_box}
var speed = 5000
var turn_speed = 20
var drive = 0
var turn = 0
@export var model: model_enum
@export var activate_input: bool = false

func _ready():
	if activate_input == false:
		set_process_input(false)
	var model_string = "res://Game Objects/"+ model_enum.keys()[model] +".tscn"
	add_child(load(model_string).instantiate())
	(get_child(-1).get_child(-1)).reparent(self) #Inelegant, but interal doesn't work.
	#print(get_tree_string_pretty())

func _physics_process(delta):
		engine_force = drive * delta
		steering = turn * delta      

func _input(input):
	if input.is_action_pressed("FORWARD"):
		drive -= speed
	elif input.is_action_released("FORWARD"):
		drive += speed
	elif input.is_action_pressed("BACKWARD"):
		drive += speed
	elif input.is_action_released("BACKWARD"):
		drive -= speed
	elif input.is_action_pressed("LEFT"):
		turn += turn_speed
	elif input.is_action_released("LEFT"):
		turn -= turn_speed
	elif input.is_action_pressed("RIGHT"):
		turn -= turn_speed
	elif input.is_action_released("RIGHT"):
		turn += turn_speed
