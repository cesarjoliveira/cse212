using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed) && word != reversed)
            {
                result.Add($"{word} & {reversed}");
            }
            seen.Add(word);
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees.Add(degree, 1);
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
{
    word1 = word1.Replace(" ", "").ToLower();
    word2 = word2.Replace(" ", "").ToLower();

    if (word1.Length != word2.Length)
        return false;

    var sortedWord1 = word1.OrderBy(c => c).ToArray();
    var sortedWord2 = word2.OrderBy(c => c).ToArray();

    return sortedWord1.SequenceEqual(sortedWord2);
}

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return featureCollection.Features
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Magnitude}")
            .ToArray();
    }
}
