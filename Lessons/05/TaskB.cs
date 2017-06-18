using System;

namespace Lessons._05
{
    /// <summary>
    /// * Declare an flagged enum type OpeningDays with all days in week. 
    /// * Declare an extension method GetTodayOpening() for the type OpeningDays.
    /// It returns Opened if a value contains today, otherwise Closed.
    /// * Opened and Closed are values of an another custom enum type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
			Console.WriteLine(Enum.GetName(typeof(OpeningDays), OpeningDays.Monday));
			OpeningDays day;

			Enum.TryParse<OpeningDays>("Monday", out day);
			Console.WriteLine((int)day);

			Console.WriteLine($"Never open: {OpeningDays.None.GetTodayOpening()}");
			Console.WriteLine($"Only Mondays: {OpeningDays.Monday.GetTodayOpening()}");
			Console.WriteLine($"From Monday to Wednesday: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday).GetTodayOpening()}");
			Console.WriteLine($"All weekdays: {(OpeningDays.Monday | OpeningDays.Tuesday | OpeningDays.Wednesday | OpeningDays.Thursday | OpeningDays.Friday).GetTodayOpening()}");
			Console.WriteLine($"Only weekends: {(OpeningDays.Saturday | OpeningDays.Sunday).GetTodayOpening()}");
		}
    }

	public static class EnumExtension {
		public static TodayStatus GetTodayOpening(this OpeningDays openingDaysFlags)
		{
			var dayOfWeek = Enum.GetName(typeof(DayOfWeek), DateTime.Now.DayOfWeek);
			
			Enum.TryParse<OpeningDays>(dayOfWeek, out OpeningDays day);
			
			return (day & openingDaysFlags) > 0 ? TodayStatus.Opened : TodayStatus.Closed;
		}
	}

	public enum TodayStatus {
		Opened,
		Closed
	}

	[Flags]
	public enum OpeningDays {
		None = 0,
		Monday = 1,
		Tuesday = 2,
		Wednesday = 4,
		Thursday = 8,
		Friday = 16,
		Saturday = 32,
		Sunday = 64
	}

}