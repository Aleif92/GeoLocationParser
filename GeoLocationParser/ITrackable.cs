namespace GeoLocationParser;

public interface ITrackable
{
    string Name { get; set; }
    Point Location { get; set; }
}