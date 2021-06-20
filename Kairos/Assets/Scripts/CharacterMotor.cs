using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    Animation animations; // on recupere les animations 

    public bool is_pressing = false;


    public float walkSpeed;

    public int Damage;
    public float AttackRange;
    
    CapsuleCollider PlayerCollider; // on recupere la boite de collision du player
    public GameObject RayHit;           // raycast pour savoir si le joeur touche un ennemie avec une attack
    public GameObject characterMortor;
    public bool isdead;
    public Camera followCamera;

    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;

    void Awake()
    {
        animations = characterMortor.GetComponent<Animation>();

        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
    }

    void Start() // on récupere les différents valeurs qu'il nous faut 
    {

        animations = characterMortor.GetComponent<Animation>();

        PlayerCollider = characterMortor.GetComponent<CapsuleCollider>();

        RayHit = GameObject.Find("RayHit");

        animations["Roll"].speed = 1f;

    }
    void FixedUpdate()
    {
        isdead = gameObject.GetComponent<CharacterStat>().isDead;

        if (!isdead)
        {
            if (animations.IsPlaying("Roll"))
            {

                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

                m_Rb.MovePosition(m_Rb.position + movement * 20 * Time.fixedDeltaTime);
                m_Rb.MoveRotation(targetRotation);
            }
            if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && !animations.IsPlaying("attack")&& !animations.IsPlaying("Roll"))
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

                if (Input.GetKeyDown("e") && !animations.IsPlaying("attack") && !animations.IsPlaying("Roll"))
                {
                    animations.Play("Roll");

                }
                else
                {


                    animations.Play("run");

                    if (movement == Vector3.zero)
                    {
                        return;
                    }

                    Quaternion targetRotation = Quaternion.LookRotation(movement);

                    Debug.Log(targetRotation.eulerAngles);

                    targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

                    m_Rb.MovePosition(m_Rb.position + movement * walkSpeed * Time.fixedDeltaTime);
                    m_Rb.MoveRotation(targetRotation);

                }
            }
            else
            {
                if (!animations.IsPlaying("attack")&& !animations.IsPlaying("Roll"))
                {
                    animations.Play("idle");

                }
            }


            // attacker 
            if (Input.GetMouseButtonDown(0) && !animations.IsPlaying("attack")&& !animations.IsPlaying("Roll"))
            {
                animations.Play("attack");
                RaycastHit hit;
                if (Physics.Raycast(RayHit.transform.position, transform.TransformDirection(Vector3.forward), out hit, AttackRange))
                    // ici le raycast gère l'attack du player en envoyany une ligne imaginaire devant lui avec une distance defini par distanceattack
                {
                    Debug.DrawLine(RayHit.transform.position, hit.point, Color.red); // juste pour savoir si ça touche qqchose (peut être supprimer) 
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<IaCapsule>().ApplyDamage(Damage); // on récupere l'ennemie et on lui applique des dégats grace a applydamage
                    }
                    
                }
            }
        }
    }
    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }
}
