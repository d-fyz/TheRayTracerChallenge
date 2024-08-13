using NUnit.Framework;
using Tuples;

namespace SpecFlowTuples.Steps;

[Binding]
public class TuplesSteps
{
    private RTCTuple _a;
    private RTCTuple _c;
    
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

    [Given(@"c ← color\((.*), (.*), (.*)\)")]
    public void GivenCColor(float r, float g, float b)
    {
        _c = RTCTuple.Color(r, g, b);
    }

    [Then(@"c\.red = (.*)")]
    public void ThenCRed(float r)
    {
        Assert.AreEqual(_c.r, r);
    }
    
    [Then(@"c\.green = (.*)")]
    public void ThenCGreen(float g)
    {
        Assert.AreEqual(_c.g, g);
    }
    
    [Then(@"c\.blue = (.*)")]
    public void ThenCBlue(float b)
    {
        Assert.AreEqual(_c.b, b);
    }
    
    [Then(@"c \* (.*) = color\((.*), (.*), (.*)\)")]
    public void ThenCColor(float mul, float r, float g, float b)
    {
        var cMul = _c * mul;
        Assert.IsTrue(MathUtils.Approximately(cMul.r, r));
        Assert.IsTrue(MathUtils.Approximately(cMul.g, g));
        Assert.IsTrue(MathUtils.Approximately(cMul.b, b));
    }
}