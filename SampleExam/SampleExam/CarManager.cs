using System.Collections.Generic;
using System.Linq;

public class CarManager
{
	private Dictionary<int, Car> cars;
	private Dictionary<int, Race> races;
	private Garage garage;

	public CarManager()
	{
		this.cars = new Dictionary<int, Car>();
		this.races = new Dictionary<int, Race>();
		this.garage = new Garage();
	}
    //register car
    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
	{
		Car car = null;
		switch (type)
		{
			case "Performance": car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
			case "Show": car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
		}

		if (!cars.ContainsKey(id))
		{
			cars.Add(id, car);
		}
	}
	//read data for car
	public string Check(int id)
	{
		Car car = cars[id];
		return car.ToString();
	}
	//register race
	public void Open(int id, string type, int length, string route, int prizePool)
	{
		Race race = null;
		switch (type)
		{
			case "Casual": race = new CasualRace(length, route, prizePool); break;
			case "Drag": race = new DragRace(length, route, prizePool); break;
			case "Drift": race = new DriftRace(length, route, prizePool); break;
		}

		if (!races.ContainsKey(id))
		{
			races.Add(id, race);
		}
	}

	public void Open(int id, string type, int length, string route, int prizePool, int lapOrGoldTime)
	{
		Race race = null;
		switch (type)
		{
			case "TimeLimit": race = new TimeLimitRace(length, route, prizePool, lapOrGoldTime); break;
			case "Circuit": race = new CircuitRace(length, route, prizePool, lapOrGoldTime); break;
		}

		if (!races.ContainsKey(id))
		{
			races.Add(id, race);
		}
	}

	public void Participate(int carId, int raceId)
	{
		Car car = cars[carId];
		Race race = races[raceId];

		if (!garage.ParkedCars.Contains(car))
		{
			if ((race.GetType().Name == "TimeLimitRace" && !races[raceId].Participants.Any()) || race.GetType().Name != "TimeLimitRace")
			{
				race.Participants.Add(car);
			}
		}
	}

	public string Start(int id)
	{
		Race race = races[id];

		if (race.Participants.Count == 0)
		{
			return "Cannot start the race with zero participants.";
		}
		
		if (race.GetType().Name == "CircuitRace")
		{
			var circRace = race as CircuitRace;
			circRace.Participants.ForEach(p => p.Durability -= circRace.Length * circRace.Length * circRace.Laps);
		}
	    var result = race.ToString();
	    races.Remove(id);

		return result;
	}

	public void Park(int id)
	{
		Car car = cars[id];

		if (!IsParticipate(car))
		{
			if (!garage.ParkedCars.Contains(car))
			{
				garage.ParkedCars.Add(car);
			}
		}
	}

	public void Unpark(int id)
	{
		Car car = cars[id];
		if (garage.ParkedCars.Contains(car))
		{
			garage.ParkedCars.Remove(car);
		}
	}

	public void Tune(int tuneIndex, string addOn)
	{
		if (garage.ParkedCars.Count > 0)
		{
			foreach (var car in garage.ParkedCars)
			{
				car.TuneCar(tuneIndex,addOn);
			}
		}
	}

    private bool IsParticipate(Car car)
    {
        foreach (Race race in races.Values)
        {
            if (race.Participants.Contains(car))
            {
                return true;
            };
        }
        return false;
    }
}