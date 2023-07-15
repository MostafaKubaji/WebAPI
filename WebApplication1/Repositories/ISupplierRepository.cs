namespace AutoPartsStore
{
    public interface ISupplierRepository
    {
        void AddSupplier(Supplier supplier);
        void DeleteSupplier(int supplierId);
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int supplierId);
        void UpdateSupplier(Supplier supplier);
    }
}