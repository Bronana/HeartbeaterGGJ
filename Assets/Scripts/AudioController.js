    var source1: AudioSource;
    var source2: AudioSource;
     
    function Start(){
    var aSources = GetComponents(AudioSource);
    source1 = aSources[0];
    source2 = aSources[1];
     
    source1.Play();
     
    yield WaitForSeconds (15.2);
     
    source2.Play();
    }