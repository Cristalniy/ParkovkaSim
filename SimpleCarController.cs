using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            // Knopki V Igre
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Smena lvla
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        // Menu
        if (this.CompareTag("Player") && other.CompareTag("Settings"))
        {
            SceneManager.LoadScene("Settings");
        }
        if (this.CompareTag("Player") && other.CompareTag("Level"))
        {
            SceneManager.LoadScene("Level");
        }

        // Levels 1-5
        if (this.CompareTag("Player") && other.CompareTag("Level 1"))
        {
            SceneManager.LoadScene("Lvl1");
        }
        if (this.CompareTag("Player") && other.CompareTag("Level 2"))
        {
            SceneManager.LoadScene("Lvl2");
        }
        if (this.CompareTag("Player") && other.CompareTag("Level 3"))
        {
            SceneManager.LoadScene("Lvl3");
        }
        if (this.CompareTag("Player") && other.CompareTag("Level 4"))
        {
            SceneManager.LoadScene("Lvl4");
        }
        if (this.CompareTag("Player") && other.CompareTag("Level 5"))
        {
            SceneManager.LoadScene("Lvl5");
        }

        // End of the game
        if (this.CompareTag("Player") && other.CompareTag("End Of Game"))
        {
            SceneManager.LoadScene("Cong");
        }

        // Settings
        if (this.CompareTag("Player") && other.CompareTag("Low"))
        {
            QualitySettings.SetQualityLevel(0);
        }
        if (this.CompareTag("Player") && other.CompareTag("Medium"))
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (this.CompareTag("Player") && other.CompareTag("High"))
        {
            QualitySettings.SetQualityLevel(2);
        }

        // Exit
        if (this.CompareTag("Player") && other.CompareTag("Exit"))
        {
            Application.Quit();
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}