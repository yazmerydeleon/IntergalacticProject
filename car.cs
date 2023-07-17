using System;

public class Car
{
	private string carModel;
	private date carYear;
	private float milesDriven;
	private float gasUsed;

	private enum gasType
	{
		regular = 1,
		midGrade = 2,
		premium = 3,
		diesel = 4,
		flexFuel = 5,
		electric = 6
	}

	public virtual void MilesGalon()
	{

	}

	public virtual void Electric() 
	{
		gasUsed = gasType.electric;
	}

	public Car()
	{
	}
}
