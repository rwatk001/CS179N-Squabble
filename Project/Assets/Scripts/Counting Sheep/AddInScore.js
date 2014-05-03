static var globalScore : int = 0;
var boardScore : int = 0;
var readyButton : boolean = false;
static var goLevel : boolean = false;

var buttonWidth : int = 200;
var buttonHeight : int = 100;

//From WAM ScoreContol @@@@@@@@@@@@
var playSkin : GUISkin;
var replaySkin : GUISkin;
var scoreSkin : GUISkin;
var showScore : boolean;
var height : float;
var width : float;
var cushionHeight : float;
var cushionWidth : float;
var helpCount : int;
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


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
//	setReadyBut();
	if (CountSheepGO.tallyScore) {
		//From WAM ScoreContol @@@@@@@@@@@@
		GUI.BeginGroup (new Rect(0, 0, width, height));
		GUI.Box (new Rect(cushionWidth*3, cushionHeight, width*0.40f, height*0.80f), "");
		GUI.BeginGroup (new Rect (cushionWidth*3, cushionHeight, width, height));
		GUI.skin = scoreSkin;
		GUI.Label (new Rect (cushionWidth*1.3f, cushionHeight/2, width, height), "SCORE");
		helpCount = globalScore;
		GUI.Label (new Rect (cushionWidth*1.4f, cushionHeight*3, width, height), helpCount.ToString());
		GUI.skin = playSkin;
		if (GUI.Button (new Rect (cushionWidth*2.5f, cushionHeight*6.50f, 100, 50), "CONTINUE")) {
			Application.LoadLevel ("Whack-A-Mole_v1");
		}
		GUI.skin = replaySkin;
		if (GUI.Button (new Rect (cushionWidth*0.75f, cushionHeight*6.50f, 100, 50), "REPLAY")) {
			Application.LoadLevel ("BarrelBreaker");
		}
		GUI.EndGroup ();
		GUI.EndGroup ();
		// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
	}
}

//From WAM ScoreContol @@@@@@@@@@@@
function Start () {
	showScore = false;
	height = Screen.height;
	width = Screen.width;
	cushionHeight = height * 0.10f;
	cushionWidth = width * 0.10f;
	helpCount = 0;
}
// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

function Update () {
//	updateScore();
}