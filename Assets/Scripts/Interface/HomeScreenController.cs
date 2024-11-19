using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class HomeScreenController : MonoBehaviour
{
    [SerializeField] private InputAction tap;
    [SerializeField] private string sceneToLoad = "PlacementScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tap = InputSystem.actions.FindAction("Spawn Object");
        tap.Enable();
        tap.performed += OnClick;
        
        //tap.canceled += OnClick;
    }
    void OnDestroy()
    {
        tap.performed -= OnClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        //if (tap.ReadValue<bool>())
        if(context.phase == InputActionPhase.Performed)
        {
            tap.Disable();
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Click!");
        }
    }
}
