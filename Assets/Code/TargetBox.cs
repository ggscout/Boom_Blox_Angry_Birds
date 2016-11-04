using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;
	/// <summary>
	/// check whether the score has been awarded to the player
	/// </summary>
	public bool ScoreAdded = false;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

	/// <summary>
	/// change the color of the target box; add score;
	/// </summary>
    private void Scored()
    {
		this.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		if (!ScoreAdded) {
			ScoreKeeper.AddToScore (this.gameObject.GetComponent<Rigidbody2D>().mass);
			ScoreAdded = true;
		}
    }

	/// <summary>
	/// call Scored() if the target box hits ground
	/// </summary>
	/// <param name="obj">Object TargetBox collides with</param>
	private void OnCollisionEnter2D(Collision2D obj) {
		if (obj.gameObject.tag.Equals("Ground")) {
			Scored ();
		}
	}
}
