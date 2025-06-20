namespace BankingSystem.API.Common;

public static class Helper
{
	public static string GetSafeTimestampedFileName(string prefix, string extension)
	{
		var userCulture = CultureInfo.CurrentCulture;
		var formattedDate = DateTime.Now
			.ToString(userCulture.DateTimeFormat.ShortDatePattern + "_" + userCulture.DateTimeFormat.LongTimePattern)
			.Replace("/", "-").Replace(":", "-").Replace(" ", "_");
		return $"{prefix}_{formattedDate}.{extension}";
	}
}
