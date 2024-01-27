extends VehicleBody3D

enum model_enum  {CheeseWheel, toilet, RiggedDude, cardboard_box}
enum weapon_enum {Knife, Rake}
var speed = 5000
var turn_speed = 20
var drive = 0
var turn = 0
@export var model: model_enum
@export var activate_input: bool = false
@export var weapon1: weapon_enum
@export var weapon2: weapon_enum
@export var weapon3: weapon_enum
@export var weapon4: weapon_enum
var weapons = []

func _ready():
	weapons = [weapon_enum.keys()[weapon1], weapon_enum.keys()[weapon2], weapon_enum.keys()[weapon3], weapon_enum.keys()[weapon4]]
	
	if activate_input == false:
		set_process_unhandled_input(false)
	#model generation
	var model_string = "res://Game Objects/"+ model_enum.keys()[model] +".tscn"
	add_child(load(model_string).instantiate())
	(get_child(-1).get_child(-1)).reparent(self) #Inelegant, but internal doesn't work.
	#weapon generation
	for placement in get_child(-2).get_node("WeaponPlacements").get_child_count():
		get_child(-2).get_node("WeaponPlacements").get_child(placement).add_child(load("res://Game Objects/Weapons/"+ weapons[placement] +".tscn").instantiate())
	
func _physics_process(delta):
		engine_force = drive * delta
		steering = turn * delta      

func _unhandled_input(input):
	if input.is_action_pressed("p1_Forward"):
		drive -= speed
	elif input.is_action_released("p1_Forward"):
		drive += speed
	elif input.is_action_pressed("p1_Backward"):
		drive += speed
	elif input.is_action_released("p1_Backward"):
		drive -= speed
	elif input.is_action_pressed("p1_Left"):
		turn += turn_speed
	elif input.is_action_released("p1_Left"):
		turn -= turn_speed
	elif input.is_action_pressed("p1_Right"):
		turn -= turn_speed
	elif input.is_action_released("p1_Right"):
		turn += turn_speed
