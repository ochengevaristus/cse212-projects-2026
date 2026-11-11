
using System.Text.Json;

public static class SetsAndMaps
{

public static string[] FindPairs(string[] words)
{
    var wordSet = new HashSet<string>(words);
    var pairs = new HashSet<string>();

    foreach (string word in words)
    {
        string reverse = new string(word.Reverse().ToArray());

        if (word != reverse &&
            string.CompareOrdinal(word, reverse) < 0 &&
            wordSet.Contains(reverse))
        {
            pairs.Add($"{word}&{reverse}");
        }
    }

    return pairs.ToArray();
}


    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (string line in File.ReadLines(filename))
        {
            string[] fields = line.Split(',');

            if (fields.Length > 3)
            {
                string degree = fields[3].Trim();

                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees.Add(degree, 1);
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var letterCounts = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (char.IsWhiteSpace(letter))
                continue;

            char normalized = char.ToUpperInvariant(letter);

            if (letterCounts.ContainsKey(normalized))
                letterCounts[normalized]++;
            else
                letterCounts[normalized] = 1;
        }

        foreach (char letter in word2)
        {
            if (char.IsWhiteSpace(letter))
                continue;

            char normalized = char.ToUpperInvariant(letter);

            if (!letterCounts.ContainsKey(normalized))
                return false;

            letterCounts[normalized]--;

            if (letterCounts[normalized] < 0)
                return false;
        }

        return letterCounts.Values.All(count => count == 0);
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        string json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                if (feature.Properties != null &&
                    feature.Properties.Place != null &&
                    feature.Properties.Magnitude.HasValue)
                {
                    string summary =
                        $"{feature.Properties.Place} - Mag {feature.Properties.Magnitude.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}";

                    summaries.Add(summary);
                }
            }
        }

        return summaries.ToArray();
    }
}
