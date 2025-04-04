using UnityEngine;
public enum EnemyStates { alive, dead };
public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 1.7f;
    private float obstacleRange = 5.0f;
    private float sphereRadius = 0.75f;
    private EnemyStates state;
    [SerializeField] private GameObject laserbeamPrefab;
    private GameObject laserbeam;
    public float fireRate = 2.0f;
    private float nextFire = 0.0f;
    private float baseSpeed = 0.25f;
    float difficultySpeedDelta = 0.3f; // the change in speed per level of difficulty
    public void SetDifficulty(int difficulty)
    {
        Debug.Log("WanderingAI.SetDifficulty(" + difficulty + ")");
        enemySpeed = baseSpeed + (difficulty * difficultySpeedDelta);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = EnemyStates.alive;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == EnemyStates.alive)
        {
            // Move Enemy
            Vector3 movement = Vector3.forward * enemySpeed * Time.deltaTime;
            transform.Translate(movement);
            // generate Ray
            Ray ray = new Ray(transform.position, transform.forward);
            // Spherecast and determine if Enemy needs to turn
            RaycastHit hit;
            if (Physics.SphereCast(ray, sphereRadius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    // Spherecast hit Player, fire laser!
                    if (laserbeam == null && Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        laserbeam = Instantiate(laserbeamPrefab) as GameObject;
                        laserbeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                        laserbeam.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    // Must've hit wall or other object, turn
                    float turnAngle = Random.Range(-110, 110);
                    transform.Rotate(0, turnAngle, 0);
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;

        Debug.DrawLine(transform.position, rangeTest);

        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }

    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }
}
