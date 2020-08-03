
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolitionScript : MonoBehaviour
{
	public float TimeBetweenBuildingDestructions = 10;

	public GameObject ExplosionContainer;

	int childNumber;
	int childrenCount;
	Transform parentTransform; 

	private bool m_canDestroy = true;
	private RaycastHit hit;
	//public float particleDelay = 10;
	//float particleTimer;

	private void Update()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
		}

		if ( m_canDestroy && Physics.Raycast(transform.position, this.transform.forward, out hit) )
		{
			ExplosionContainer.SetActive (true);
			hit.rigidbody.isKinematic = false;
			hit.collider.isTrigger = true;
			hit.transform.gameObject.transform.GetChild (0).gameObject.SetActive (true);
			childrenCount = hit.transform.gameObject.transform.childCount;
			for (childNumber = 0; childNumber < childrenCount; ++childNumber) 
			{
				hit.transform.gameObject.transform.GetChild (childNumber).gameObject.SetActive (true);
			}
			parentTransform = hit.transform.gameObject.transform;
			m_canDestroy = false;
			StartCoroutine (WaitForDestructionCooldown ());

		}
	}		

	private IEnumerator WaitForDestructionCooldown()
	{
		yield return new WaitForSeconds (TimeBetweenBuildingDestructions);
		m_canDestroy = true;
	}

	private IEnumerator DestroyAfterSeconds( float time, GameObject destroyObj )
	{
		yield return new WaitForSeconds (20f);
		Destroy (destroyObj);
	}

}

