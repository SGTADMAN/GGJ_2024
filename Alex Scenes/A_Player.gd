extends VehicleBody3D

var speed = 5000
var turn_speed = 20
var drive = 0
var turn = 0

func _ready():
	pass

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
