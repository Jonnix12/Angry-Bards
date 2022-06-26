using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    public void SimulateArc(Vector2 direction, float forceMultiplier,BirdCollision birdCollision)
    {
        float maxDuration = 15f;
        float timeStemp = 0.1f;
        int maxStep = (int) (maxDuration / timeStemp);

        _lineRenderer.positionCount = maxStep;

        Vector3[] points = new Vector3[maxStep];
            
        Vector2 directionVector = direction;
        Vector2 launchPosition = birdCollision.transform.position;

        float velocity = forceMultiplier / birdCollision.rb.mass * Time.fixedDeltaTime;

        for (int i = 0; i < maxStep; i++)
        {
            Vector2 calculatedPosition = launchPosition + directionVector * velocity * i * timeStemp;
            calculatedPosition.y += Physics2D.gravity.y / 2 * Mathf.Pow(i * timeStemp, 2);
            
            points[i] = calculatedPosition;
        }
        
        _lineRenderer.SetPositions(points);
    }

    public void ReSetLine()
    {
        _lineRenderer.positionCount = 0;
    }
}
