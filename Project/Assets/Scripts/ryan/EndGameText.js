var s : String;
var score : int;
static var display : boolean;

function Start () {
	display = false;
	score = DataContainer.finalScore;
	s = "";
}

function Update () {
	if (display) {
		s = score + " NIGHTMARES CONQUERED!";
		guiText.text = s;
	}
}