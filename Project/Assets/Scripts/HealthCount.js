static var life : int;

function Start () {
	if (Application.loadedLevelName == "BarrelBreaker") {
		life = AddInScore.life;
	}
	displayHealth();
}

function Update () {
	displayHealth();
}

function displayHealth () {
	if (life > 2) 
		GameObject.Find("HealthBit3").guiTexture.pixelInset = Rect (-(Screen.width/2)+45,(Screen.height/2)-25, 20, 20);
	else
		Destroy(GameObject.Find("HealthBit3"));
	if (life > 1) 
		GameObject.Find("HealthBit2").guiTexture.pixelInset = Rect (-(Screen.width/2)+25,(Screen.height/2)-25, 20, 20);
	else
		Destroy(GameObject.Find("HealthBit2"));
	if (life > 0)
		GameObject.Find("HealthBit1").guiTexture.pixelInset = Rect (-(Screen.width/2)+5,(Screen.height/2)-25, 20, 20);
	else
		Destroy(GameObject.Find("HealthBit1"));
}
