
namespace DEV_7
{
    interface ICollectionInfo
    {
        double GetAveragePrice();
        double GetAverageTypePrice(string brand);
        int CountAll();
        int CountTypes();
    }
}
