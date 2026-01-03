using ObserverPattern;

public readonly record struct BaggageInfo
    (int FlightNumber,
    string From,
    int Carousel);

public sealed class BaggageHandler : IObservable<BaggageInfo>
{
    private readonly HashSet<IObserver<BaggageInfo>> _observers = new();
    private readonly HashSet<BaggageInfo> _flights = new();

    public IDisposable Subscribe(IObserver<BaggageInfo> observer)
    {
        // Check if observer is already registered. If not, add it
        if (_observers.Add(observer))
        {
            // Provide observer with existing data
            foreach (var item in _flights)
            {
                observer.OnNext(item);
            }
        }

        return new Unsubscriber<BaggageInfo>(_observers, observer);
    }

    public void BaggageStatus(int flightNumber) =>
        BaggageStatus(flightNumber, string.Empty, 0);

    public void BaggageStatus(int flightNumber, string from, int carousel)
    {
        var info = new BaggageInfo(flightNumber, from, carousel);

        if (carousel > 0 && _flights.Add(info))
        {
            foreach (IObserver<BaggageInfo> observer in _observers)
            {
                observer.OnNext(info);
            }
        }
        else if (carousel is 0)
        {
            if (_flights.RemoveWhere(
                flight => flight.FlightNumber == info.FlightNumber) > 0)
            {
                foreach (IObserver<BaggageInfo> observer in _observers)
                {
                    observer.OnNext(info);
                }
            }
        }
    }

    public void LastBaggageClaimed()
    {
        foreach (IObserver<BaggageInfo> observer in _observers)
        {
            observer.OnCompleted();
        }
        _observers.Clear();
    }
}