using UnityEngine; // 41 Post - Created by DimasTheDriver on Apr/20/2012 . Part of the 'Unity: Animated texture from image sequence' post series. Available at: http://www.41post.com/?p=4742 
using System.Collections; //Script featured at Part 2 of the post series.
using System.IO;

public class TexturePlayer : MonoBehaviour 
{

	/**
	 * Tools:
	 * 
	 * To extract frame from video: https://www.dvdvideosoft.com/products/dvd/Free-Video-to-JPG-Converter.htm
	 * For rename all frames: http://alessandrofrancesconi.it/projects/bimp/
	 * To extract sound: https://www.howtogeek.com/66165/from-the-tips-box-extracting-audio-from-any-video-using-vlc-sneaking-around-paywalls-and-delaying-windows-live-mesh-during-boot./
	 * 
	 * 
	*/

	//A texture object that will output the animation
	private Texture frame_texture;
	//With this Material object, a reference to the game object Material can be stored
	private Material Monitor_Material;
	//An integer to advance frames
	private int curr_frame = 0;

	public float fps = 24f;
	
	//Folder containing frame's images
	public string frames_folder;
	//The name of the image sequence
	public string files_prefix;
	//Total video's frames
	public int total_frames;
	
	//The base name of the files of the sequence
	private string baseName;

	public bool isPaused  = false;

	public AudioSource Video_Audio;

	void Awake()
	{
		//Get a reference to the Material of the game object this script is attached to
		this.Monitor_Material = this.GetComponent<Renderer>().material;
		//With the folder name and the sequence name, get the full path of the images (without the numbers)
		this.baseName = this.frames_folder + "/" + this.files_prefix;
	}
	
	void Start () 
	{
		//set the initial frame as the first texture. Load it from the first image on the folder
		//texture = (Texture)Resources.Load(baseName + "00000", typeof(Texture));
				frame_texture = (Texture)Resources.Load(baseName + "0", typeof(Texture));
	}
	
	void Update () 
	{

		if (isPaused == false) {
			//Start the 'PlayLoop' method as a coroutine with a 0.04 delay  
			//StartCoroutine("PlayLoop", 0.04f);
			StartCoroutine ("PlayLoop", 1 / fps);
			//Set the material's texture to the current value of the curr_frame variable
			Monitor_Material.mainTexture = this.frame_texture;

			if ( Video_Audio != null && !Video_Audio.isPlaying)
				Video_Audio.Play ();

		}
		else{
			if ( Video_Audio != null && Video_Audio.isPlaying)
				Video_Audio.Pause ();
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
		//curr_frame = (++curr_frame)%total_frames;
		curr_frame++;
		if( curr_frame >= total_frames)
		{
			curr_frame = 0;
		}
		
		//load the current frame
		//this.texture = (Texture)Resources.Load(baseName + curr_frame.ToString("D5"), typeof(Texture));
				this.frame_texture = (Texture)Resources.Load(baseName + curr_frame.ToString(), typeof(Texture));
		
				//Debug.Log ("Frame: " + curr_frame + " - Delay: " + delay);
        //Stop this coroutine  
        StopCoroutine("PlayLoop");  
    }
	
	//Play video/animation once
    IEnumerator Play_Once(float delay)  
    {  
        //wait for the time defined at the delay parameter  
        yield return new WaitForSeconds(delay);  
        
		//if it isn't the last frame
		if(curr_frame >= total_frames)
		{
			//Advance one frame
			++curr_frame;
			
			//load the current frame
			//this.texture = (Texture)Resources.Load(baseName + curr_frame.ToString("D5"), typeof(Texture));
						this.frame_texture = (Texture)Resources.Load(baseName + curr_frame.ToString("D1"), typeof(Texture));
		}

        //Stop this coroutine  
        StopCoroutine("Play");  
    }
}
