using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;

	/// <summary>
	/// generate the repulsive force of explosion; Hide the Explosive box and instantiate the explosion
	/// prefab; also destruct the explosive box after 0.1s
	/// </summary>
	private void Boom(){
		this.gameObject.GetComponent<PointEffector2D> ().enabled = true;
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
		Invoke ("Destruct", 0.1f);
	}

	/// <summary>
	/// if the relative velocity exceeds thresholdForce, call Boom()
	/// </summary>
	/// <param name="obj">Object the explosive box collides with</param>
	private void OnCollisionEnter2D(Collision2D obj) {
		if (obj.relativeVelocity.magnitude > ThresholdForce) {
			Boom ();
		}
	}
	/// <summary>
	/// Destroy the Explosive Box.
	/// </summary>
	private void Destruct() {
		Destroy (this.gameObject);
	}
}
