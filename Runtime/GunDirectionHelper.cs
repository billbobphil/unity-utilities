using System;
using UnityEngine;

public class GunDirectionHelper : MonoBehaviour
{
    public static void PointGunAtTarget(Vector2 targetPosition, Vector2 shooterPosition, GameObject gun, float distanceBetweenGunAndShooter)
    {
        double x = targetPosition.x - shooterPosition.x;
        double y = targetPosition.y - shooterPosition.y;
        
        double angleInRadians = Math.Atan2(x, y);
        double angleInDegrees = angleInRadians * (180 / Mathf.PI);
        
        double smallX = distanceBetweenGunAndShooter * Math.Sin(angleInRadians);
        double smallY = distanceBetweenGunAndShooter * Math.Cos(angleInRadians);
        
        Vector3 newGunPosition = new Vector3((float)smallX, (float)smallY, 0);
        
        Vector3 newGunAngle = new Vector3(0, 0, (float)-angleInDegrees);
        
        gun.transform.localPosition = newGunPosition;
        gun.transform.eulerAngles = newGunAngle;
    }
    
}
