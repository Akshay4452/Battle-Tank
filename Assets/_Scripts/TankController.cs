using UnityEngine;

public class TankController
{
    private TankModel m_tankModel;
    private TankView m_tankView;

    private Rigidbody m_rb;

    public TankController(TankModel model, TankView view)
    {
        m_tankModel = model;
        m_tankView = GameObject.Instantiate<TankView>(view); // Taking instance from Instantiated GameObject
        m_rb = m_tankView.GetRigidbody();

        m_tankModel.SetTankController(this);
        m_tankView.SetTankController(this);

        m_tankView.ChangeColor(m_tankModel.m_color);
    }

    public void Move(float movement, float movementSpeed)
    {
        if(m_rb != null)
        {
            m_rb.velocity = m_tankView.transform.forward * movement * movementSpeed;

            if (!AudioManager.Instance.IsSoundPlaying(SoundType.TankMovement))
            {
                AudioManager.Instance.Play(SoundType.TankMovement);
            }
        }
    }

    public void Rotate(float rotation, float rotationSpeed)
    {
        if(m_rb != null)
        {
            Vector3 vector = new Vector3(0f, rotation * rotationSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
            m_rb.MoveRotation(m_rb.rotation * deltaRotation);
        }
    }

    public void FireShell()
    {
        if(m_tankView.GetShellSpawnTransform() != null)
        {
            Transform shellSpawn = m_tankView.GetShellSpawnTransform();
            GameObject shellInstance = GameObject.Instantiate(m_tankView.shellPrefab.gameObject, shellSpawn.position, shellSpawn.rotation);

            // Ignore collision between shell and tank
            Physics.IgnoreCollision(shellInstance.GetComponent<Collider>(), m_tankView.GetComponent<Collider>());

            float forceMagnitude = GetTankModel().m_shellForce;
            Rigidbody shellRb = shellInstance.GetComponent<Rigidbody>();

            shellRb.AddForce(shellSpawn.transform.forward * forceMagnitude, ForceMode.Impulse);

            AudioManager.Instance.Play(SoundType.TankFire);
        } 
        else
        {
            Debug.LogError("Shell Spawn Transform Missing in TankView!");
            return;
        }
    }

    public TankModel GetTankModel()
    {
        return m_tankModel;
    }
}
