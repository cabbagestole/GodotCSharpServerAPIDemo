extends Node2D

func _ready():
	$SpawnButton.toggled.connect(func(t): $SpriteMgr.spawn = t)
	$ClearButton.pressed.connect(func(): $SpriteMgr.clear())
	Engine.max_fps = 500

func _process(_delta: float) -> void:
	$FPS.text = "FPS: %.3f" % Performance.get_monitor(Performance.TIME_FPS)
	$Count.text = "Object: %d" % $SpriteMgr.get_count()
