using UnityEngine; // 41 Post - Created by DimasTheDriver on Apr/20/2012 . Part of the 'Unity: Animated texture from image sequence' post series. Available at: http://www.41post.com/?p=4742 
using System.Collections; //Script featured at Part 2 of the post series.

public class ImageSequenceSingleTexture : MonoBehaviour 
{
	//A texture object that will output the animation
	private Texture texture;
	//With this Material object, a reference to the game object Material can be stored
	private Material goMaterial;
	//An integer to advance frames
	private int frameCounter = 0;

	public float fps = 24f;
	
	//A string that holds the name of the folder which contains the image sequence
	public string folderName;
	//The name of the image sequence
	public string imageSequenceName;
	//The number of frames the animation has
	public int numberOfFrames;
	
	//The base name of the files of the sequence
	private string baseName;

	public bool isPaused  = false;

	private GameObject Player;
	public GameObject Scanning_Audio;

	void Awake()
	{
		//Get a reference to the Material of the game object this script is attached to
		this.goMaterial = this.GetComponent<Renderer>().material;
		//With the folder name and the sequence name, get the full path of the images (without the numbers)
		this.baseName = this.folderName + "/" + this.imageSequenceName;
	}
	
	void Start () 
	{
		Player = GameObject.Find ("GvrMain_with_Gaze");
		//set the initial frame as the first texture. Load it from the first image on the folder
		//texture = (Texture)Resources.Load(baseName + "00000", typeof(Texture));
				texture = (Texture)Resources.Load(baseName + "1", typeof(Texture));
	}
	
	void Update () 
	{

		float distance = Vector3.Distance (Player.transform.position,transform.position);

		//Debug.Log ("distance: " + distance);

		if( distance < 7 )
		{
			isPaused = false;
			if( !Scanning_Audio.GetComponent<GvrAudioSource> ().isPlaying )
				Scanning_Audio.GetComponent<GvrAudioSource> ().Play ();
		}
		else{
			isPaused = true;
			if( Scanning_Audio.GetComponent<GvrAudioSource> ().isPlaying )
				Scanning_Audio.GetComponent<GvrAudioSource> ().Pause();
		}

		if (isPaused == false) {
			//Start the 'PlayLoop' method as a coroutine with a 0.04 delay  
			//StartCoroutine("PlayLoop", 0.04f);
			StartCoroutine ("PlayLoop", 1 / fps);
			//Set the material's texture to the current value of the frameCounter variable
			goMaterial.mainTexture = this.texture;
		}
	}

	public void onClick()
	{
		if( isPaused )
		{
			isPaused = false;
		}
		else
		{
			isPaused = true;
		}
	}
	
	//The following methods return a IEnumerator so they can be yielded:
	//A method to play the animation in a loop
    IEnumerator PlayLoop(float delay)  
    {  
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);  
        
		//advance one frame
		frameCounter = (++frameCounter)%numberOfFrames;
		
		//load the current frame
		//this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D5"), typeof(Texture));
				this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString(), typeof(Texture));
		
				Debug.Log ("Frame: " + frameCounter + " - Delay: " + delay);
        //Stop this coroutine  
        StopCoroutine("PlayLoop");  
    }
	
	//A method to play the animation just once
    IEnumerator Play(float delay)  
    {  
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);  
        
		//if it isn't the last frame
		if(frameCounter < numberOfFrames-1)
		{
			//Advance one frame
			++frameCounter;
			
			//load the current frame
			//this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D5"), typeof(Texture));
						this.texture = (Texture)Resources.Load(baseName + frameCounter.ToString("D1"), typeof(Texture));
		}

        //Stop this coroutine  
        StopCoroutine("Play");  
    }
}
