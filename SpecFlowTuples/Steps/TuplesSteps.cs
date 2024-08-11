using NUnit.Framework;
using Tuples;

namespace SpecFlowTuples.Steps;

[Binding]
public class TuplesSteps
{
    private RTCTuple _a;
    
    [Given(@"a ← tuple\((.*), (.*), (.*), (.*)\)")]
    public void GivenATuple(float x, float y, float z, float w)
    {
        _a = new RTCTuple(x, y, z, w);
    }

    [Then(@"a\.x = (.*)")] public void ThenAx(float x) => Assert.AreEqual(_a.x, x);

    [Then(@"a\.y = (.*)")] public void ThenAy(float y) => Assert.AreEqual(_a.y, y);

    [Then(@"a\.z = (.*)")] public void ThenAz(float z) => Assert.AreEqual(_a.z, z);
    
    [Then(@"a\.w = (.*)")] public void ThenAw(float w) => Assert.AreEqual(_a.w, w);

    [Then(@"a is a point")] public void ThenAIsAPoint() => Assert.IsTrue(RTCTuple.IsPoint(_a));
    
    [Then(@"a is a vector")] public void ThenAIsAVector() => Assert.IsTrue(RTCTuple.IsVector(_a));

    [Then(@"a is not a vector")] public void ThenAIsNotAVector() => Assert.IsFalse(RTCTuple.IsVector(_a));

    [Then(@"a is not a point")] public void ThenAIsNotAPoint() => Assert.IsFalse(RTCTuple.IsPoint(_a));

    [Then(@"-a = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenATuple(float x, float y, float z, float w)
    {
        var na = -_a;
        Assert.AreEqual(na.x, x);
        Assert.AreEqual(na.y, y);
        Assert.AreEqual(na.z, z);
        Assert.AreEqual(na.w, w);
    }

    [Then(@"a \* (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenAmTuple(float mul, float x, float y, float z, float w)
    {
        var aMul = _a * mul;
        Assert.AreEqual(aMul.x, x);
        Assert.AreEqual(aMul.y, y);
        Assert.AreEqual(aMul.z, z);
        Assert.AreEqual(aMul.w, w);
    }

    [Then(@"a / (.*) = tuple\((.*), (.*), (.*), (.*)\)")]
    public void ThenAdTuple(float div, float x, float y, float z, float w)
    {
        var aDiv = _a / div;
        Assert.AreEqual(aDiv.x, x);
        Assert.AreEqual(aDiv.y, y);
        Assert.AreEqual(aDiv.z, z);
        Assert.AreEqual(aDiv.w, w);
    }
}