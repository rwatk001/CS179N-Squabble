static var globalScore : int = 0;
var boardScore : int = 0;
var readyButton : boolean = false;
static var goLevel : boolean = false;

var buttonWidth : int = 200;
var buttonHeight : int = 100;


function updateScore () {
	if (CountSheepGO.tallyScore) {
		while (boardScore < globalScore) {
			boardScore++;
			guiText.text = boardScore.ToString();
			yield WaitForSeconds(10);
		}
		guiText.text = boardScore.ToString();
		if (GameObject.Find("ScoreBoardText").transform.position.y < 0.75) {
			GameObject.Find("ScoreBoardText").transform.Translate(Vector3.up * Time.deltaTime/2);
		} else 
			readyButton = true;
	}
}

function setReadyBut () {
	if (readyButton) {
		if (GUI.Button(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2,
			buttonWidth, buttonHeight),"Ready?")) {
			goLevel = true;
			yield WaitForSeconds(1);
			Application.LoadLevel("BarrelBreaker");
		}
	}
}

function OnGUI() {
	setReadyBut();
}

function Update () {
	updateScore();
}