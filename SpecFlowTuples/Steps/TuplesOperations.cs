using NUnit.Framework;
using Tuples;

namespace SpecFlowTuples.Steps;

[Binding]
public class TuplesOperations
{
    private Dictionary<int, RTCTuple> _tuples= new ();
    private RTCTuple _a;
    private RTCTuple _b;
    
    [Given(@"a(.*) ← tuple\((.*), (.*), (.*), (.*)\)")]
    public void GivenATuple(int n, float x, float y, float z, float w)
    {
        _tuples[n] = new RTCTuple(x, y, z, w);
    }

    [Then(@"a(.*) \+ a(.*) = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenAaTuple(int n1, int n2, float x, float y, float z, float w)
    {
        var sum = _tuples[n1] + _tuples[n2];
        
        Assert.AreEqual(sum.x, x);
        Assert.AreEqual(sum.y, y);
        Assert.AreEqual(sum.z, z);
        Assert.AreEqual(sum.w, w);
    }

    [Given(@"p(.*) ← point\((.*), (.*), (.*)\)")]
    public void GivenPPoint(int n, float x, float y, float z)
    {
        _tuples[n] = RTCTuple.Point(x, y, z);
    }

    [Then(@"p(.*) - p(.*) = vector\((.*), (.*), (.*)\)")]
    public void ThenPPVector(int n1, int n2, float x, float y, float z)
    {
        var r = _tuples[n1] - _tuples[n2];
        var v = RTCTuple.Vector(x, y, z);
        
        Assert.AreEqual(r.x, v.x);
        Assert.AreEqual(r.y, v.y);
        Assert.AreEqual(r.z, v.z);
        Assert.AreEqual(r.w, v.w);
    }

    [Given(@"v(.*) ← vector\((.*), (.*), (.*)\)")]
    public void GivenVVector(int n, float x, float y, float z)
    {
        _tuples[n] = RTCTuple.Vector(x, y, z);
    }

    [Then(@"v(.*) - v(.*) = vector\((.*), (.*), (.*)\)")]
    public void ThenVVVector(int n1, int n2, float x, float y, float z)
    {
        var d = _tuples[n1] - _tuples[n2];
        var v = RTCTuple.Vector(x, y, z);
        Assert.AreEqual(d.x, v.x);
        Assert.AreEqual(d.y, v.y);
        Assert.AreEqual(d.z, v.z);
        Assert.AreEqual(d.w, v.w);
    }

    [Given(@"a ← vector\((.*), (.*), (.*)\)")]
    public void GivenAVector(float x, float y, float z)
    {
        _a = RTCTuple.Vector(x, y, z);
    }

    [Given(@"b ← vector\((.*), (.*), (.*)\)")]
    public void GivenBVector(float x, float y, float z)
    {
        _b = RTCTuple.Vector(x, y, z);
        
    }

    [Then(@"dot\(a, b\) = (.*)")]
    public void ThenDotAb(float value)
    {
        Assert.AreEqual(RTCTuple.Dot(_a, _b), value);
    }

    [Then(@"cross\(a, b\) = vector\((.*), (.*), (.*)\)")]
    public void ThenCrossAbVector(float x, float y, float z)
    {
        var cross = RTCTuple.Cross(_a, _b);
        Assert.AreEqual(cross.x, x);
        Assert.AreEqual(cross.y, y);
        Assert.AreEqual(cross.z, z);
    }

    [Then(@"cross\(b, a\) = vector\((.*), (.*), (.*)\)")]
    public void ThenCrossBaVector(float x, float y, float z)
    {
        var cross = RTCTuple.Cross(_b, _a);
        Assert.AreEqual(cross.x, x);
        Assert.AreEqual(cross.y, y);
        Assert.AreEqual(cross.z, z);
    }

    [Given(@"c(.*) ← color\((.*), (.*), (.*)\)")]
    public void GivenCColor(int n, float r, float g, float b)
    {
        _tuples[n] = RTCTuple.Color(r, g, b);
    }

    [Then(@"c(.*) \+ c(.*) = color\((.*), (.*), (.*)\)")]
    public void ThenCPlusCColor(int n1, int n2, float r, float g, float b)
    {
        var sum = _tuples[n1] + _tuples[n2];
        Assert.IsTrue(MathUtils.Approximately(sum.r, r));
        Assert.IsTrue(MathUtils.Approximately(sum.g, g));
        Assert.IsTrue(MathUtils.Approximately(sum.b, b));
    }

    [Then(@"c(.*) - c(.*) = color\((.*), (.*), (.*)\)")]
    public void ThenCMinusCColor(int n1, int n2, float r, float g, float b)
    {
        var diff = _tuples[n1] - _tuples[n2];
        Assert.IsTrue(MathUtils.Approximately(diff.r, r));
        Assert.IsTrue(MathUtils.Approximately(diff.g, g));
        Assert.IsTrue(MathUtils.Approximately(diff.b, b));
    }

    [Then(@"c(.*) \* c(.*) = color\((.*), (.*), (.*)\)")]
    public void ThenCMulCColor(int n1, int n2, float r, float g, float b)
    {
        var prod = _tuples[n1] * _tuples[n2];
        Assert.IsTrue(MathUtils.Approximately(prod.r, r));
        Assert.IsTrue(MathUtils.Approximately(prod.g, g));
        Assert.IsTrue(MathUtils.Approximately(prod.b, b));
    }
}