static var scoreString : String;
static var scoreCount : int;

function Start () {
	scoreCount = 0;
	scoreString = "x" + scoreCount;
}

function Update () {
	scoreString = "x" + scoreCount;
	guiText.text = scoreString;
}