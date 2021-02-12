using System;
using System.Collections.Generic;
using CsvHelper.Configuration;

public class RocketInfoClassMap : ClassMap<RocketInfo>
{
    public RocketInfoClassMap()
    {
        Map(r => r.RocketName).Name("rocket_name");
        Map(r => r.Organisation).Name("organisation");
        Map(r => r.PayloadCapacity).Name("payload_capacity").Convert(rocket =>
        {
            return rocket.PayloadCapacity.HasValue ? $"{rocket.PayloadCapacity} kg" : String.Empty;
        });
        Map(r => r.FirstLaunchDate).Name("first_launch_date").TypeConverterOption.Format("s");
    }
}

public class RocketInfo
{
    public string RocketName { get; set; }
    public string Organisation { get; set; }
    public int? PayloadCapacity { get; set; }
    public DateTime FirstLaunchDate { get; set; }


    public static List<RocketInfo> GetRockets()
    {
        return new List<RocketInfo>
        {
            new RocketInfo
            {
                RocketName = "Saturn V",
                Organisation = "NASA",
                PayloadCapacity = 140000,
                FirstLaunchDate = new DateTime(1967, 11, 09)
            },
            new RocketInfo
            {
                RocketName = "Falcon 9",
                Organisation = "SpaceX",
                PayloadCapacity = 22000,
                FirstLaunchDate = new DateTime(2013, 09, 29)
            },
            new RocketInfo
            {
                RocketName = "Falcon Heavy",
                Organisation = "SpaceX",
                PayloadCapacity = 64000,
                FirstLaunchDate = new DateTime(2018, 02, 06)
            },
            new RocketInfo
            {
                RocketName = "Starship",
                Organisation = "SpaceX",
                PayloadCapacity = 150000,
                FirstLaunchDate = new DateTime(2020, 12, 09)
            },
            new RocketInfo
            {
                RocketName = "SLS",
                Organisation = "NASA",
                PayloadCapacity = 70000,
                FirstLaunchDate = new DateTime(2049, 01, 12)
            },
            new RocketInfo
            {
                RocketName = "Phoenix",
                Organisation = "Private",
                FirstLaunchDate = new DateTime(2063, 04, 05)
            }
        };
    }
}