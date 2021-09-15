public static class DataManager
{
    private static int Data1 = 28;
    private static int Data2 = 24;
    private static int Data3 = 22;
    private static int Data4 = 20;
    public static List<ChartModel> GetData()
    {
        var r = new Random();

        Data1 = Check(Data1 + r.Next(-3, 5));
        Data2 = Check(Data2 + r.Next(-3, 5));
        Data3 = Check(Data3 + r.Next(-3, 5));
        Data4 = Check(Data4 + r.Next(-3, 5));




        return new List<ChartModel>()
        {
           new ChartModel { Data = new List<int> { Data1 }, Label = "Akcje Kamila" },
           new ChartModel { Data = new List<int> { Data2  }, Label = "Akcje Czarka" },
           new ChartModel { Data = new List<int> { Data3 }, Label = "Akcje Anny" },
           new ChartModel { Data = new List<int> { Data4  }, Label = "Akcje Franka" }
        };
    }

    public static int Check(int number)
    {
        if (number > 100)
            return 100;
        else if (number <0)
            return 0;
        else
        {
            return number;
        }
    }
}