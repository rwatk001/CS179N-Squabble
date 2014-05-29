#pragma strict

@script RequireComponent(LineRenderer)

var lineRenderer : LineRenderer;
private var maxPoints : int = 20;
static var myPoints : Vector3[];

function Start () {
	myPoints = new Vector3[0];
    lineRenderer = GetComponent(LineRenderer);
    lineRenderer.SetWidth(0.2,0.2);
}

function Update () {

    if(myPoints){

        lineRenderer.SetVertexCount(myPoints.Length);
        for(var i = 0;i<myPoints.Length;i++){
            lineRenderer.SetPosition(i,myPoints[i]);    
        }
    }
    else
    lineRenderer.SetVertexCount(0);
    
    if(Input.GetMouseButtonDown(0)){
        InvokeRepeating("AddPoint",.05,.05);
    } 
     if(Input.GetMouseButtonUp(0)){
        CancelInvoke();
        myPoints = new Vector3[0];
    }

}

function AddPoint(){

	if (myPoints.Length < maxPoints) {
	    var tempPoints : Vector3[];

	    if(!myPoints)
	        tempPoints = new Vector3[1];
	    else{
	        tempPoints = new Vector3[myPoints.Length+1];
	       
	    	for(var j = 0; j < myPoints.Length; j++)
	        	tempPoints[j] = myPoints[j];
	    }   
	    var tempPos : Vector3 = Input.mousePosition;
	    tempPos.z = 9;
	    
	    tempPoints[j] = camera.ScreenToWorldPoint(tempPos);
	   	myPoints = new Vector3[tempPoints.Length];
	   	for(j=0; j< myPoints.Length; j++) 
	   		myPoints[j] = tempPoints[j];
	}
}