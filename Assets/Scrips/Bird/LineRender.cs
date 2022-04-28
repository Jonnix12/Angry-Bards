using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    public Vector3[] SimulateArc(Vector2 direction, float forceMultiplier,Bird bird)
    {
        float maxDuration = 15f;
        float timeStepInterval = 0.1f;
        int maxStep = (int) (maxDuration / timeStepInterval);

        Vector3[] points = new Vector3[maxStep];
            
        Vector2 directionVector = direction;
        Vector2 launchPosition = bird.transform.position;

        float vel = forceMultiplier / bird.rb.mass * Time.fixedDeltaTime;

        for (int i = 0; i < maxStep; i++)
        {
            Vector2 calculatedPosition = launchPosition + directionVector * vel * i * timeStepInterval;
            calculatedPosition.y += Physics2D.gravity.y / 2 * Mathf.Pow(i * timeStepInterval, 2);
            
            points[i] = calculatedPosition;
        }
        
        _lineRenderer.SetPositions(points);
        return points;
    }
}
