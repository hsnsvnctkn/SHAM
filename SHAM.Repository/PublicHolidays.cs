using Newtonsoft.Json;
using System;
using System.Net;

namespace SHAM.Repository
{
    public static class PublicHolidays
    {
        public static Holidays Holidays;
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public static void loadPublicHolidays()
        {
            var url = "https://www.googleapis.com/calendar/v3/calendars/turkish__tr%40holiday.calendar.google.com/events?key=AIzaSyD1rK3TChqmNdL8C8m9qqGCqERuazM0Dmw";
            Holidays = _download_serialized_json_data<Holidays>(url);
        }
        public static string IsPublicHoliday(DateTime date)
        {
            if (Holidays == null)
                loadPublicHolidays();

            foreach (var item in Holidays.items)
            {
                var holidayDate = DateTime.Parse(item.start.date);

                if (date.Date == holidayDate)
                    return item.summary;
            }

            return null;
        }

    }
}
