using System.Collections;
using System.Globalization;
using System.Text;
using Tuples;

namespace Canvas;

public class RTCCanvas : IEnumerable<RTCTuple>
{
    private readonly RTCTuple[,] _canvas;

    public RTCTuple this[int x, int y]
    {   
        get => _canvas[x, y];
        set => _canvas[x, y] = value;
    } 
    
    public int Width => _canvas?.GetLength(0) ?? 0;
    public int Height => _canvas?.GetLength(1) ?? 0;
    
    public RTCCanvas(int width, int height)
    {
        _canvas = new RTCTuple[width, height];
    }

    public RTCTuple GetPixel(int x, int y) => this[x, y];
    public RTCTuple SetPixel(int x, int y, RTCTuple color) => this[x, y] = color;

    IEnumerator<RTCTuple> IEnumerable<RTCTuple>.GetEnumerator()
    {
        foreach (var color in _canvas)
            yield return color;
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var color in _canvas)
            yield return color;
    }

    private StringBuilder _ppmBuilder;
    public string ToPPM()
    {
        if (_ppmBuilder == null)
        { 
            _ppmBuilder = new StringBuilder();
        }
        _ppmBuilder.Clear();
        _ppmBuilder
            .AppendLine("P3")
            .AppendLine($"{Width} {Height}")
            .AppendLine("255");

        for (var y = 0; y < _canvas.GetLength(1); y++)
        {
            var len = 0;
            for (var x = 0; x < _canvas.GetLength(0); x++)
            {
                var color = _canvas[x, y];
                var channels = new int[]
                {
                    Math.Clamp((int)(Math.Round(color.r * 255f)), 0, 255),
                    Math.Clamp((int)(Math.Round(color.g * 255f)), 0, 255),
                    Math.Clamp((int)(Math.Round(color.b * 255f)), 0, 255)
                };

                foreach (var c in channels)
                {
                    var str = c.ToString(CultureInfo.InvariantCulture);
                    if (len + str.Length + 1 > 70)
                    {
                        _ppmBuilder.AppendLine();
                        len = 0;
                    }
                    
                    if (len > 0)
                    {
                        _ppmBuilder.Append(' ');
                        len++;
                    }

                    _ppmBuilder.Append(str);
                    len += str.Length;
                }
            }

            _ppmBuilder.AppendLine();
        }

        return _ppmBuilder.ToString();
    }
}