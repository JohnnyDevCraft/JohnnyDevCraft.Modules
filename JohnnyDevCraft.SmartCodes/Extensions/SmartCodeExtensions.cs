using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using JohnnyDevCraft.SmartCodes.BusinessObjects;
using JohnnyDevCraft.SmartCodes.Constants;

namespace JohnnyDevCraft.SmartCodes.Extensions;

public static class SmartCodeExtensions
{
    public static (IObjectSpace, SmartType) EnsureSmartType(this IObjectSpace space, string name, string description = "")
    {
        var smartType = space.FindObject<SmartType>(CriteriaOperator.Parse("Name = ?", name));
        if (smartType == null)
        {
            smartType = space.CreateObject<SmartType>();
            smartType.Name = name;
            smartType.Description = description;
        }

        return (space, smartType);
    }
    
    public static (IObjectSpace, SmartType) EnsureSmartCode(this (IObjectSpace, SmartType) input, string label, string code)
    {
        var (space, smartType) = input;
        var smartCode = space.FindObject<SmartCode>(CriteriaOperator.Parse("SmartTypeId = ? and Code = ?", input.Item2.ID, code));
        if (smartCode == null)
        {
            smartCode = space.CreateObject<SmartCode>();
            smartCode.Label = label;
            smartCode.Code = code;
            smartCode.SmartTypeId = smartType.ID;
        }

        return (space, smartType);
    }
    
    public static void EnsureUsStates(this IObjectSpace space)
    {
        space.EnsureSmartType(SmartTypes.UsStates, "States from the USA")
            .EnsureSmartCode("Alabama", "AL")
            .EnsureSmartCode("Alaska", "AK")
            .EnsureSmartCode("Arizona", "AZ")
            .EnsureSmartCode("Arkansas", "AR")
            .EnsureSmartCode("California", "CA")
            .EnsureSmartCode("Colorado", "CO")
            .EnsureSmartCode("Connecticut", "CT")
            .EnsureSmartCode("Delaware", "DE")
            .EnsureSmartCode("Florida", "FL")
            .EnsureSmartCode("Georgia", "GA")
            .EnsureSmartCode("Hawaii", "HI")
            .EnsureSmartCode("Idaho", "ID")
            .EnsureSmartCode("Illinois", "IL")
            .EnsureSmartCode("Indiana", "IN")
            .EnsureSmartCode("Iowa", "IA")
            .EnsureSmartCode("Kansas", "KS")
            .EnsureSmartCode("Kentucky", "KY")
            .EnsureSmartCode("Louisiana", "LA")
            .EnsureSmartCode("Maine", "ME")
            .EnsureSmartCode("Maryland", "MD")
            .EnsureSmartCode("Massachusetts", "MA")
            .EnsureSmartCode("Michigan", "MI")
            .EnsureSmartCode("Minnesota", "MN")
            .EnsureSmartCode("Mississippi", "MS")
            .EnsureSmartCode("Missouri", "MO")
            .EnsureSmartCode("Montana", "MT")
            .EnsureSmartCode("Nebraska", "NE")
            .EnsureSmartCode("Nevada", "NV")
            .EnsureSmartCode("New Hampshire", "NH")
            .EnsureSmartCode("New Jersey", "NJ")
            .EnsureSmartCode("New Mexico", "NM")
            .EnsureSmartCode("New York", "NY")
            .EnsureSmartCode("North Carolina", "NC")
            .EnsureSmartCode("North Dakota", "ND")
            .EnsureSmartCode("Ohio", "OH")
            .EnsureSmartCode("Oklahoma", "OK")
            .EnsureSmartCode("Oregon", "OR")
            .EnsureSmartCode("Pennsylvania", "PA")
            .EnsureSmartCode("Rhode Island", "RI")
            .EnsureSmartCode("South Carolina", "SC")
            .EnsureSmartCode("South Dakota", "SD")
            .EnsureSmartCode("Tennessee", "TN")
            .EnsureSmartCode("Texas", "TX")
            .EnsureSmartCode("Utah", "UT")
            .EnsureSmartCode("Vermont", "VT")
            .EnsureSmartCode("Virginia", "VA")
            .EnsureSmartCode("Washington", "WA")
            .EnsureSmartCode("West Virginia", "WV")
            .EnsureSmartCode("Wisconsin", "WI")
            .EnsureSmartCode("Wyoming", "WY")
            .EnsureSmartCode("District of Columbia", "DC")
            .EnsureSmartCode("American Samoa", "AS")
            .EnsureSmartCode("Guam", "GU")
            .EnsureSmartCode("Northern Mariana Islands", "MP")
            .EnsureSmartCode("Puerto Rico", "PR")
            .EnsureSmartCode("United States Minor Outlying Islands", "UM")
            .EnsureSmartCode("U.S. Virgin Islands", "VI");
    }

    public static void EnsureMajorIndustries(this IObjectSpace space)
    {
        space.EnsureSmartType(SmartTypes.MajorIndustries, "Major Industries in the world")
            .EnsureSmartCode("Agriculture", "AG")
            .EnsureSmartCode("Mining", "MN")
            .EnsureSmartCode("Construction", "CN")
            .EnsureSmartCode("Manufacturing", "MF")
            .EnsureSmartCode("Transportation", "TR")
            .EnsureSmartCode("Wholesale Trade", "WT")
            .EnsureSmartCode("Retail Trade", "RT")
            .EnsureSmartCode("Finance", "FN")
            .EnsureSmartCode("Real Estate", "RE")
            .EnsureSmartCode("Professional Services", "PS")
            .EnsureSmartCode("Education", "ED")
            .EnsureSmartCode("Health Care", "HC")
            .EnsureSmartCode("Arts", "AR")
            .EnsureSmartCode("Entertainment", "ET")
            .EnsureSmartCode("Accommodation", "AC")
            .EnsureSmartCode("Food Services", "FS")
            .EnsureSmartCode("Public Administration", "PA")
            .EnsureSmartCode("Other", "OT");
    }
}