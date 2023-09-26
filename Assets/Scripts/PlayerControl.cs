using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5;
    public float camera_speed = 2;

    public int suelo = -1;

    public List<GameObject> music_tiles;
    float music_max_distance = 15;

    float steps_cd_max = 0.5f;
    float steps_cd_current = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float movement_vertical = Input.GetAxis("Vertical");
        float movement_horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = (transform.forward * movement_vertical) + (transform.right * movement_horizontal);
        transform.position = transform.position + direction * Time.deltaTime * speed;

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * camera_speed);

        //Step sounds
        if(movement_vertical != 0 || movement_horizontal != 0)
        {
            steps_cd_current += Time.deltaTime;

            if(steps_cd_current >= steps_cd_max)
            {
                steps_cd_current = 0;
                PlaySteps();
            }
        }
        else
        {
            steps_cd_current = 0;
        }

        //Music volumes
        ModifyMusicVolume();
    }

    Vector3 IgnoreHeight(Vector3 v)
    {
        v.y = 0;

        return v;
    }

    void ModifyMusicVolume()
    {
        
    }

    void PlaySteps()
    {
        if(suelo > -1)
        {
            Debug.Log("Play pasos " + suelo);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Untagged":
                suelo = -1;
                break;
            case "Piedra":
                suelo = 0;
                break;
            case "Madera":
                suelo = 1;
                break;
            case "Hierba":
                suelo = 2;
                break;
        }
    }
}
