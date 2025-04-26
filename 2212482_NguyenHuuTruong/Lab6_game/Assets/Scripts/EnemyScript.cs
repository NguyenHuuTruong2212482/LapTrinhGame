using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript moveScript;
    private FiringScript[] weapons;
    private Collider2D coliderComponent;
    private SpriteRenderer rendererComponent;

    void Awake()
    {
        weapons = GetComponentsInChildren<FiringScript>();

        moveScript = GetComponent<MoveScript>();

        coliderComponent = GetComponent<Collider2D>();

        rendererComponent = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        hasSpawn = false;
        coliderComponent.enabled = false;
        moveScript.enabled = false;
        foreach (FiringScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }

    void Update()
    {
        if (hasSpawn == false)
        {
            if (rendererComponent.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            foreach (FiringScript weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                    SoundEffectsHelper.Instance.MakeEnemyShotSound();
                }
            }

            if (rendererComponent.IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Spawn()
    {
        hasSpawn = true;
        coliderComponent.enabled = true;
        moveScript.enabled = true;
        foreach (FiringScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}