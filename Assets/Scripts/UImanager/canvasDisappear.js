  var speedsmooth:float = 0.5f; // your speed smooth, but not time
  private var myAlpha:float = 1.0f;
 
  function Start() {
    yield WaitForSeconds(3);
    Destroy(this.gameObject);
    Application.LoadLevel("mountainHelp2");
   
  }
 
  function Update() {
   
  }