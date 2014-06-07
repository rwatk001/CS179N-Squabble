static var scoreString : String;
static var scoreCount : int;
//static var lifePoints : int;
//static var lostLifeGO : boolean;

function Start () {
	scoreCount = 0;
	scoreString = "x" + scoreCount;
//	lifePoints = 3;
//	lostLifeGO = false;
}

function Update () {
	scoreString = "x" + scoreCount;
	guiText.text = scoreString;
}