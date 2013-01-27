   function Start () {
   		guiTexture.color.a = 0F;
   		yield WaitForSeconds (14.5);
        yield Fade(0.0, 1.0, .1);     // fade up;
    }
     
    function Fade (startLevel :float, endLevel :float, duration :float) {
        var speed : float = 1.0/duration;   
        for (var t :float = 0.0; t < 1.0; t += Time.deltaTime*speed) {
            guiTexture.color.a = Mathf.Lerp(startLevel, endLevel, t);
            yield;
        }
    }