using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstRate;
    [SerializeField] private float timer = 10f;

    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched;

    [SerializeField] private GameObject playerObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerObject = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        /*Subtracting the current value of thirstLevel with thirstRate. thirstRate is normalized
         by using Time.deltaTime, so that it's frame rate independent. 
         Math.Clamp restricts the thirstLevel between its current max value and 0.
         */
        thirstLevel -= Mathf.Clamp(thirstRate*Time.deltaTime,0,thirstLevel);

        if (thirstLevel <= 50f && !thirsty)
        {
            Debug.Log("getting thirsty...");
            thirsty = true;
        }
        if (thirstLevel <= 20f && !parched)
            {
            Debug.Log("im dying of thirst...");
            parched = true;
            }

        if (thirstLevel <= 0f && parched)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
             Damageable.DamageMessage msg = new Damageable.DamageMessage()
                         {
                             amount = 1,
                             damager = this,
                             damageSource = new Vector3(x: 0, y: 0, z: 0),
                             direction = new Vector3(x: 0, y: 0, z: 0),
                             throwing = false,
                             stopCamera = false
                         };
                         playerObject.GetComponent<Damageable>().ApplyDamage(msg);
                         Debug.Log("damage by thirst!!");
                         timer = 10f;
            }
            
        }
    }
}
