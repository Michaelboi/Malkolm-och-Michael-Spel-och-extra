using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bil_mechanics : MonoBehaviour
{
    // anv�nds f�r att styra �t olika riktningar och brommsa
    public float horizontalInput;
    public float verticalInput;
    public bool BilBromms;
    // V = v�nster H = h�ger
    [SerializeField] public WheelCollider framVhjulCollide;
    
    public void bil_movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        BilBromms = Input.GetKey(KeyCode.LeftShift);
        Bil_motor();
        
    }
    void Bil_motor()
    {
        
    }

}
