using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent( typeof( Rigidbody2D ) , typeof( Collider2D ) )]
public class PlayerController : MonoBehaviour {

    //#region old
    //[SerializeField] private float moveSpeed = 7.5f;
    //[SerializeField] private float smoothMoveTime = 0.1f;
    //[SerializeField] private float turnSpeed = 8;
    //RaycastHit2D ray;
    //private Vector3 moveInput;
    //private float angle;
    //private float smoothInputMagnitude;
    //private float smoothMoveVelocity;
    //#endregion

    private Rigidbody2D m_rigidbody2D;
    private Collider2D m_collider2D;
    private Vector2 moveInput;
    private float velocity = 1000;

    private void Start() {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_collider2D = GetComponent<Collider2D>();
    }

    public void OnMovement(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        m_rigidbody2D.velocity = transform.up * velocity * Time.deltaTime * moveInput.y;
        m_rigidbody2D.AddTorque( moveInput.x * m_rigidbody2D.velocity.y );
    }

    #region old

    //void Start() {
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void Update() {

    //    ray = Physics2D.Raycast( transform.position , Vector2.down );

    //    if(ray.collider.tag == "Track") {
    //        Debug.DrawRay( transform.position , transform.TransformDirection( Vector3.down ) * ray.distance , Color.green );
    //        print( "hit" + ray.collider.name );
    //    }

    //    if(ray.collider.tag == "Boost") {
    //        Debug.DrawRay( transform.position , transform.TransformDirection( Vector3.down ) * ray.distance , Color.blue );
    //        print( "hit" + ray.collider.name );
    //    }

    //    if(ray.collider.tag == "Slow") {
    //        Debug.DrawRay( transform.position , transform.TransformDirection( Vector3.down ) * ray.distance , Color.red );
    //        print( "hit" + ray.collider.name );
    //    } else {
    //        print( "hit nothing" );
    //    }
    //}

    //#region Movement
    //private void FixedUpdate() {
    //    Move();
    //}

    //public void OnMovement(InputAction.CallbackContext context) {
    //    moveInput = context.ReadValue<Vector2>();
    //}

    //private void Move() {

    //    float _inputMagnitude = moveInput.magnitude;
    //    smoothInputMagnitude = Mathf.SmoothDamp( smoothInputMagnitude , _inputMagnitude , ref smoothMoveVelocity , smoothMoveTime );

    //    float _targetAngle = Mathf.Atan2( moveInput.x , moveInput.z ) * Mathf.Rad2Deg;
    //    angle = Mathf.LerpAngle( angle , _targetAngle , Time.deltaTime * turnSpeed * _inputMagnitude );

    //    rb.MoveRotation( Quaternion.Euler( Vector3.forward * angle ) );

    //    Vector3 velocity = transform.right * moveSpeed * smoothInputMagnitude;

    //    rb.MovePosition( (Vector3)rb.position + velocity * Time.deltaTime );



    //    //Vector3 _inputDirection = new Vector3( moveInput.x , 0 , moveInput.z );

    //    //float _inputMagnitude = _inputDirection.magnitude;
    //    //smoothInputMagnitude = Mathf.SmoothDamp( smoothInputMagnitude , _inputMagnitude , ref smoothMoveVelocity , smoothMoveTime );

    //    //float _targetAngle = Mathf.Atan2( _inputDirection.x , _inputDirection.y ) * Mathf.Rad2Deg;
    //    //angle = Mathf.LerpAngle( angle , _targetAngle , Time.deltaTime * turnSpeed * _inputMagnitude );

    //    //Vector3 velocity = transform.up * moveSpeed * smoothInputMagnitude;
    //    //rb.MovePosition((Vector3) rb.position + velocity * Time.deltaTime );
    //}
    //#endregion

    #endregion
}
