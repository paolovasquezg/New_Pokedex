using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearAndFallOnClick : MonoBehaviour
{
    public GameObject fallingObjectPrefab;  // Prefab del objeto que aparecerá y caerá
    public Transform spawnPoint;            // Ubicación donde el objeto aparecerá
    public Vector3 customRotation;          // Rotación personalizada para el objeto
    private GameObject fallingObjectInstance; // Instancia del objeto que caerá
    private Rigidbody rb;

    // Este método será llamado por el evento OnClick del botón
    public void AppearAndStartFalling()
    {
        // Crear una nueva rotación a partir de la rotación personalizada (ángulos de Euler)
        Quaternion rotation = Quaternion.Euler(customRotation);

        // Comprobar si el objeto ya existe para manejar la activación/desactivación
        if (fallingObjectInstance == null)
        {
            // Instanciar el objeto con la rotación personalizada en el punto de aparición
            fallingObjectInstance = Instantiate(fallingObjectPrefab, spawnPoint.position, rotation);
            Debug.Log("Objeto apareció en el punto de aparición con rotación personalizada.");
        }
        else if (fallingObjectInstance.activeSelf)
        {
            // Si el objeto está activo, desactivarlo
            fallingObjectInstance.SetActive(false);
            Debug.Log("Objeto desactivado.");
            return; // Salir del método si se desactivó el objeto
        }
        else
        {
            // Si el objeto está inactivo, volver a activarlo y moverlo al punto de aparición
            fallingObjectInstance.SetActive(true);
            fallingObjectInstance.transform.position = spawnPoint.position;
            fallingObjectInstance.transform.rotation = rotation;
            Debug.Log("Objeto reactivado en el punto de aparición con rotación personalizada.");
        }

        // Obtener el componente Rigidbody y hacer que el objeto caiga
        rb = fallingObjectInstance.GetComponent<Rigidbody>();
        rb.useGravity = true;  // Habilitar la gravedad para hacer que el objeto caiga
        Debug.Log("Objeto comenzó a caer.");
    }
}
