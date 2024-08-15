using Canvas;
using NUnit.Framework;
using Tuples;

namespace CanvasSpecFlow;

[Binding]
public class CanvasSteps
{
    private RTCCanvas _canvas;
    private RTCTuple _c;
    private string _ppm;
    private Dictionary<int, RTCTuple> _colors = new Dictionary<int, RTCTuple>();
    
    [Given(@"c ← canvas\((.*), (.*)\)")]
    public void GivenCCanvas(int width, int height)
    {
        _canvas = new RTCCanvas(width, height);
    }

    [Then(@"c\.width = (.*)")]
    public void ThenCWidth(int width)
    {
        Assert.AreEqual(_canvas.Width, width);
    }

    [Then(@"c\.height = (.*)")]
    public void ThenCHeight(int height)
    {
        Assert.AreEqual(_canvas.Height, height);
    }

    [Then(@"every pixel of c is color\((.*), (.*), (.*)\)")]
    public void ThenEveryPixelOfCIsColor(float r, float g, float b)
    {
        var color = RTCTuple.Color(r, g, b);
        foreach (RTCTuple c in _canvas)
        {
            Assert.AreEqual(color.r, c.r);
            Assert.AreEqual(color.g, c.g);
            Assert.AreEqual(color.b, c.b);
        }
    }

    [Given(@"red ← color\((.*), (.*), (.*)\)")]
    public void GivenRedColor(float r, float g, float b)
    {
        _c = RTCTuple.Color(r, g, b);
    }

    [When(@"write_pixel\(c, (.*), (.*), red\)")]
    public void WhenWritePixelCRed(int x, int y)
    {
        _canvas[x, y] = _c;
    }

    [Then(@"pixel_at\(c, (.*), (.*)\) = red")]
    public void ThenPixelAtCRed(int x, int y)
    {
        var pixel = _canvas[x, y];
        Assert.AreEqual(pixel.r, _c.r);
        Assert.AreEqual(pixel.g, _c.g);
        Assert.AreEqual(pixel.b, _c.b);
    }

    [When(@"ppm ← canvas_to_ppm\(c\)")]
    public void WhenPpmCanvasToPpmC()
    {
        _ppm = _canvas.ToPPM();
    }

    [Then(@"lines (.*)-(.*) of ppm are")]
    public void ThenLinesOfPpmAre(int from, int to, string multilineText)
    {
        var ca = _ppm.Split(Environment.NewLine);
        var mt = multilineText.Split(Environment.NewLine);
        var diff = to - from + 1;
        for (var i = 0; i < diff; i++)
        {
            Assert.AreEqual(ca[i + from - 1], mt[i]);
        }
    }

    [Given(@"c(.*) ← color\((.*), (.*), (.*)\)")]
    public void GivenCColor(int n, float r, float g, float b)
    {
        _colors[n] = RTCTuple.Color(r, g, b);
    }

    [When(@"write_pixel\(c, (.*), (.*), c(.*)\)")]
    public void WhenWritePixelCc(int x, int y, int n)
    {
        _canvas[x, y] = _colors[n];
    }

    [When(@"every pixel of c is set to color\((.*), (.*), (.*)\)")]
    public void WhenEveryPixelOfCIsSetToColor(float r, float g, float b)
    {
        var w = _canvas.Width;
        var h = _canvas.Height;
        var color = RTCTuple.Color(r, g, b);
        
        for (var y = 0; y < h; y++)
        {
            for (var x = 0; x < w; x++)
            {
                _canvas[x, y] = color;
            }
        }
    }

    [Then(@"ppm ends with a newline character")]
    public void ThenPpmEndsWithANewlineCharacter()
    {
        Assert.AreEqual(_ppm[^1], '\n');
    }
}