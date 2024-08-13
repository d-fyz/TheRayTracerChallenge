using NUnit.Framework;
using Tuples;

namespace SpecFlowTuples.Steps;

[Binding]
public class PointsAndVectorsSteps
{
    private RTCTuple _p;
    private RTCTuple _v;
    private RTCTuple _vZero;
    private RTCTuple _vNorm;
    
    [Given(@"p ← point\((.*), (.*), (.*)\)")]
    public void GivenPPoint(float x, float y, float z)
    {
        _p = RTCTuple.Point(x, y, z);
    }

    [Then(@"p = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenPTuple(float x, float y, float z, float w)
    {
        Assert.AreEqual(_p.x, x);
        Assert.AreEqual(_p.y, y);
        Assert.AreEqual(_p.z, z);
        Assert.AreEqual(_p.w, w);
    }

    [Given(@"v ← vector\((.*), (.*), (.*)\)")]
    public void GivenVVector(float x, float y, float z)
    {
        _v = RTCTuple.Vector(x, y, z);
    }

    [Then(@"v = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenVTuple(float x, float y, float z, float w)
    {
        Assert.AreEqual(_v.x, x);
        Assert.AreEqual(_v.y, y);
        Assert.AreEqual(_v.z, z);
        Assert.AreEqual(_v.w, w);
    }

    [Then(@"p - v = point\((.*), (.*), (.*)\)")]
    public void ThenPVPoint(float x, float y, float z)
    {
        var d = _p - _v;
        var p = RTCTuple.Point(x, y, z);
        Assert.AreEqual(d.x, p.x);
        Assert.AreEqual(d.y, p.y);
        Assert.AreEqual(d.z, p.z);
        Assert.AreEqual(d.w, p.w);
    }

    [Given(@"zero ← vector\((.*), (.*), (.*)\)")]
    public void GivenZeroVector(float x, float y, float z)
    {
        _vZero = RTCTuple.Vector(x, y, z);
    }

    [Then(@"zero - v = vector\((.*), (.*), (.*)\)")]
    public void ThenZeroVVector(float x, float y, float z)
    {
        var d = _vZero - _v;
        var r = RTCTuple.Vector(x, y, z);
        Assert.AreEqual(d.x, r.x);
        Assert.AreEqual(d.y, r.y);
        Assert.AreEqual(d.z, r.z);
        Assert.AreEqual(d.w, r.w);
    }
    
    [Then(@"magnitude\(v\) = ([^√]*)")]
    public void ThenMagnitudeV(float value)
    {
        var len = _v.Magnitude();
        Assert.AreEqual(len, value);
    }
    
    [Then(@"magnitude\(v\) = √(.*)")]
    public void ThenMagnitudeSqrtV(float value)
    {
        var len = _v.Magnitude();
        Assert.AreEqual(len, MathF.Sqrt(value));
    }

    [Then(@"normalize\(v\) = vector\((.*), (.*), (.*)\)")]
    public void ThenNormalizeVVector(float x, float y, float z)
    {
        var n = _v.Normalize();
        Assert.AreEqual(n.x, x);
        Assert.AreEqual(n.y, y);
        Assert.AreEqual(n.z, z);
    }

    [Then(@"normalize\(v\) = approximately vector\((.*), (.*), (.*)\)")]
    public void ThenNormalizeVApproximatelyVector(float x, float y, float z)
    {
        var norm = _v.Normalize();
        Assert.IsTrue(MathUtils.Approximately(norm.x, x));
        Assert.IsTrue(MathUtils.Approximately(norm.y, y));
        Assert.IsTrue(MathUtils.Approximately(norm.z, z));
    }

    [When(@"norm ← normalize\(v\)")]
    public void WhenNormNormalizeV()
    {
        _vNorm = _v.Normalize();
    }

    [Then(@"magnitude\(norm\) = (.*)")]
    public void ThenMagnitudeNorm(float value)
    {
        Assert.IsTrue(MathUtils.Approximately(_vNorm.Magnitude(), value));
    }
}