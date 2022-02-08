using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private int desiredLine = 1; //0 = left, 1 = middle, 2 = right
    private float basePosition = 0f;
    private float modifPosition = 5.6f;
    private int nbTire = 0;
    private float oil;
    public Text TireIndicator;
    public Text OilIndicator;
    private float fowardSpeed = 5f;
    private float lastPosZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        oil = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        SpeedIncrement();
        OilManagement();
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (desiredLine < 2)
                desiredLine++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLine > 0)
                desiredLine--;
        }
        Vector3 targetPosition = (transform.position.z * transform.forward) + (transform.position.y * transform.up);
        if (desiredLine == 0)
            targetPosition.x = basePosition - modifPosition;
        else if (desiredLine == 1)
            targetPosition.x = basePosition;
        else if (desiredLine == 2)
            targetPosition.x = basePosition + modifPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);
        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Lunch Menu");
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "OilAdd")
        {
            if ((oil + 20f) <= 100)
                oil = oil + 20f;
            else
                oil = 100f;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "TireCollectible")
        {
            nbTire = nbTire + 1;
            TireIndicator.text = "Nombre d'anneaux: " + nbTire;
            Destroy(collider.gameObject);
        }
    }
    private void SpeedIncrement()
    {
        if (transform.position.z >= (lastPosZ + 15))
        {
            fowardSpeed += 1.5f;
            lastPosZ = transform.position.z;
        }
    }

    private void OilManagement()
    {
        oil = oil - 0.05f;
        if (oil > 0)
            direction.z = fowardSpeed;
        else if (direction.z < 4)
            direction.z = 0;
        else
            direction.z = direction.z - 0.2f;
        OilIndicator.text = "Radioactivité : " + Mathf.Round(oil) + " %";
    }
}
