using UnityEngine;

namespace Script.Runtime.Pawn
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        [SerializeField] private float playerSpeed = 3.0f;
        [SerializeField] private float jumpHeight = 2.0f;
        [SerializeField] private float gravityValue = -9.81f;

        [SerializeField]
        private bool _isControlled;
        [SerializeField]
        private bool _isInfected;
        [SerializeField]
        private CharacterType _type;
        

        private CharacterController GetCharacterController()
        {
            return gameObject.GetComponent<CharacterController>();
        }

        private void Update()
        {
            GetInput();
        }

        private void InfectChar()
        {
            _isInfected = true;
        }

        private void ControlChar(bool isControlled)
        {
            _isControlled = isControlled;
        }

        private void GetInput()
        {
            if (!_isControlled && !_isInfected) return;
            _groundedPlayer = GetCharacterController().isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0) _playerVelocity.y = 0f;

            // var move = _type == CharacterType.Beetle
            //     ? new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)
            //     : new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            var move = new Vector3();
            if (_type == CharacterType.Beetle && GetCharacterController().isGrounded)
            {
                move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            }
            else if (GetCharacterController().isGrounded)
            {
                move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            }

            GetCharacterController().Move(move * (Time.deltaTime * playerSpeed));

            if (move != Vector3.zero) gameObject.transform.position = move;

            // Changes the height position of the player..
            if (Input.GetButtonDown("Jump") && _groundedPlayer && _type == CharacterType.GrassHopper)
                _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            _playerVelocity.y += gravityValue * Time.deltaTime;
            GetCharacterController().Move(_playerVelocity * Time.deltaTime);
        }
    }

    public enum CharacterType
    {
        Ant,
        GrassHopper,
        Beetle
    }
}