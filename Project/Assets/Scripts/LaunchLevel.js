var goString : String = "GO, Dude!";

function launch () {
	if (AddInScore.goLevel) {
		guiText.text = goString;
	}
}

function Update () {
	launch();
}