namespace AutoPartsStore
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        void DeleteSale(int saleId);
        List<Sale> GetAllSales();
        Sale GetSaleById(int saleId);
        void UpdateSale(Sale sale);
    }
}