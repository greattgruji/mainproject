using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum ProductType : byte
    {
        None = 0,
        Flight = 1,
        Hotel = 2
    }

    public enum TripType : byte
    {
        NONE = 0,
        [Description("One way")]
        OneWay = 1,
        [Description("Round trip")]
        RoundTrip = 2,
        [Description("Multi job")]
        MultiCity = 3,
        [Description("All")]
        ALL = 4,
        OpenJow = 5
    }
    public enum ClientType : int
    {
        None = 0,
        Web = 1,
        Mobile = 2,
        CRM = 3,
        Meta = 4
    }
    public enum CabinType : int
    {
        None = 0,
        Economy = 1,
        PremiumEconomy = 2,
        Business = 3,
        First = 4,
        ALL = 5
    }
    public enum GdsType : int
    {
        None = 0,
        Sabre = 1,
        FixFare = 2,
        Amadeus = 3
    }
    public enum HotelSupplier : int
    {
        None = 0,
        All = 1,
        Ean = 2,
        HotelBed = 3,
        Tourico = 4
    }
    public enum TransactionStatus : int
    {
        Error = 0,
        Success = 1,
    }
    public enum FareType : int
    {
        None = 0,
        All = 1,
        RP = 2,
        RA = 3,
        COM = 4
    }
    public enum AmountType : byte
    {
        None = 0,
        Amount = 1,
        Percentage = 2
    }
    public enum MarkupCalculationBasedOn : int
    {
        TotalBaseFare = 0,
        TotalTax = 1,
        TotalAmount = 2
    }
    public enum RuleType : int
    {
        None = 0,
        Discount = 1,
        Markup = 2
    }
    public enum PassengerType : int
    {
        None = 0,
        Adult = 1,
        Child = 2,
        Infant = 3,
        InfantWs = 4
    }
    public enum Gender : int
    {
        None = 0,
        Male = 1,
        Female = 2,
    }
    public enum TravelType : int
    {
        None = 0,
        Domestic = 1,
        International = 2,
        TransBorder = 3
    }
    public enum SiteId : int
    {
        NONE = 0,
        Truairfare = 8,
        fareforall = 9
    }
    public enum Stops : int
    {
        None = 0,
        NonStop = 1,
        OneStop = 2,
        TwoStop = 3,
        Morethan2 = 4,
    }
    public enum ProductId : int
    {
        NONE = 0,
        ALL = 1,
        Flight = 2,
        Hotel = 3,
        Car = 4,
    }

    public enum BookingStatus : byte
    {
        NONE = 0,
        Pending = 1,
        Confirmed = 2,
        Duplicate = 3,
        Ticketed = 4,
        Cancelled = 5,
        Void = 6,
        Incomplete = 7
    }
    public enum PaymentStatus : byte
    {
        NONE = 0,
        NewBooking = 1,
        CCVInProgress = 2,
        CCVPending = 3,
        CCVDecline = 4,
        CCVFraud = 5,
        CCVDone = 6,
        PaymentPending = 7,
        PaymentDeclineForMainBooking = 8,
        PaymentDeclineForMCO = 9,
        PaymentDone = 10,
        TicketPending = 11,
        CardDecline = 12,
        TicketDone = 13,
        RefundRequested = 14,
        Refund = 15,
        Cancelled = 16,
        Void = 17,
        ChargeBack = 18,
        Incomplete = 19
    }

    public enum WebsiteDeal : int
    {
        NONE = 0,
        DestinationDeal = 1,
        AirlineDeal = 2,
        AFF_AdventureTravel = 3,
        AFF_BeachTravel = 4,
        AFF_BFCM = 5,
        AFF_Boxing = 6,
        AFF_ColumbusDaySale = 7,
        AFF_FlightsToSydney = 9,
        AFF_HalloweenTravel = 10,
        AFF_Honeymoon = 11,
        AFF_MedicalTravel = 12,
        AFF_Oktoberfest = 13,
        AFNGoodFriday = 14,
        AFNGroupTravel = 15,
        AFNTropicalGetaway = 16,
        AirlineDealMisc = 17,
        backToSchoolDeal = 18,
        BlackFridayDeal = 19,
        BusinessClassDeals = 20,
        CheapFlightsDeals = 21,
        Christmas = 22,
        CoachellaDeal = 23,
        ColumbusDaySale = 24,
        CyberMondayDeal = 25,
        DomesticFlightDeals = 26,
        DomesticLabourDay = 27,
        DubaiShoppingFestival = 28,
        EasterTravelOffers = 29,
        EuropeTravel = 30,
        FallTravel = 31,
        FamilyDeal = 32,
        FathersDayTravel = 33,
        FirstClassDeals = 34,
        GoodFridayDeal = 35,
        greeceDeal = 36,
        Halloween = 37,
        HolidayTravel = 38,
        IHeartRadioMusicFestival = 39,
        IndependenceDayDeals = 40,
        InternationalFlightDeals = 41,
        LabourDay = 42,
        LastMinuteDeals = 43,
        LGBT = 44,
        LowCostAirlineTickets = 45,
        HomePageDeal = 46,
        MarchMadness = 47,
        MemorialDaySale = 48,
        MemorialDayTravel = 49,
        MilitaryDeal = 50,
        MothersDayTravel = 51,
        NewsLetterPage199 = 52,
        NewsLetterPage99 = 53,
        NewYearDeal = 54,
        OneWayDeal = 55,
        ParisFashionWeek = 56,
        PetsTravel = 57,
        PremiumEconomyDeal = 58,
        PresidentDay = 59,
        RomanticDeal = 60,
        RoundTripDeal = 61,
        SeniorDeal = 62,
        SMM_Christmas = 63,
        SMM_NewYear = 64,
        SouthBySouthwest = 65,
        SpringBreakTravelOffers = 66,
        SpringTravelOffers = 67,
        stpatrickdaytravel = 68,
        StudentTravelOffers = 69,
        SummerDeal = 70,
        ThanksGiving = 71,
        TopAirlineDeal = 72,
        Under199Deal = 73,
        Under39Deal = 74,
        Under49Deal = 75,
        Under99Deal = 76,
        USOpenDeals = 77,
        UsToCanadaDeal = 78,
        ValentinesTravelOffers = 79,
        VeteransDayDeal = 80,
        WeekendTravel = 81,
        WinterTravel = 82,
        WomensDay = 83,
        OriginDestination = 84,
    }
    public enum BookingType : byte
    {
        NONE = 0,
        WebBooking = 1,
        PnrImport = 2
    }
    public enum CardType
    {
        None = 0,
        Visa = 1,
        MasterCard = 2,
        AmericanExpress = 3,
        DinersClub = 4,
        Discover = 5,
        CarteBlanche = 6,
        Maestro = 7,
        BCCard = 8,
        JapanCreditBureau = 9,
        CartaSi = 10,
        CarteBleue = 11,
        VisaElectron = 12
    }
    public enum ChargeID
    {
        None = 0,
        BaseFare = 1,
        Tax = 2,
        Markup = 3,
        Insurance = 4,
        TravelAssistance = 5,
        CancellaionPolicy = 6,
        FlexibleTicket = 7,
        Coupon = 8,
        AgentMarkup = 9,
        SeatsAssignCharges = 10,
        Macp = 11,
        TripMate = 12,
    }
    public enum ChargeFor
    {
        None = 0,
        Adult = 1,
        Child = 2,
        Infant = 3,
        InfantWS = 4,
        AllPax = 5,
        NA = 6,
    }
    public enum airlineBlockActionType : int
    {
        None = 0,
        CallCentreFare = 1,
        Masking = 2,
        Block = 3
    }
    public enum CheckOperatedBy : int
    {
        None = 0,
        Match = 1
    }
    public enum AirlineMatchType : int
    {
        None = 0,
        ConatinsAny = 1,
        ExactMatch = 2,
        DoesNotContain = 3
    }
    public enum AirlineClassMatchType : int
    {
        None = 0,
        ContainsAny = 1,
        ExactMatch = 2
    }
    public enum CustomerType : int
    {
        None = 0,
        B2B = 1,
        B2C = 2
    }
    public enum ServiceUseType : int
    {
        None = 0,
        Yes = 1,
        No = 2
    }
    public enum WeekDays : int
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
    public enum CurrencyType : int
    {
        None = 0,
        USD = 1,
        CAD = 2,
    }
    public enum BookingAction : int
    {
        None = 0,
        MakePNR = 1,
        WithoutPNRConfirm = 2,
        Failed = 4,
        InProgress = 5
    }
    public enum CurrentBookingStatus : int
    {
        None = 0,
        Success = 1,
        Fail = 2,
        InProgress = 3
    }
}
