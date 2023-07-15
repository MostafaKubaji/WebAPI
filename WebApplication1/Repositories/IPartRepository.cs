namespace AutoPartsStore
{
    public interface IPartRepository
    {
        void AddPart(Part part);
        void DeletePart(int partId);
        List<Part> GetAllParts();
        Part GetPartById(int partId);
        void UpdatePart(Part part);
    }
}