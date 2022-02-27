namespace NewFeatures;

public struct WeatherObservation
{
    public DateTime RecordedAt { get; init; }
    public decimal TempC { get; init; }
    public decimal PressureMB { get; init; }

    public override string ToString() =>
        $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: Temp = {TempC} Celsius, with {PressureMB} millibar pressure";
}