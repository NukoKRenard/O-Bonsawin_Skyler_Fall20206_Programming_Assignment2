using UnityEngine;

public class AddForceAtPosition : MonoBehaviour
{
    private float m_startTime;
    private float m_time = 0;

    [SerializeField] private Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
	    m_startTime = Random.Range(0,1);
    }

    // Update is called once per frame
    void Update()
    {
	 if (m_time > m_startTime)
	 {
		 body.AddForceAtPosition(new Vector3(0,10,0),transform.position + new Vector3(0.5f,0.5f,0),ForceMode2D.Force);
		 if (body.linearVelocity.magnitude > 10)
		 {
			 body.linearVelocity = body.linearVelocity.normalized*10;
		 } 
	 }
	 m_time += Time.deltaTime;   
    }
}
