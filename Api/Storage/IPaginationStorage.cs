public interface IPaginationStorage : IStorage
{
    (List<Contact>, int TotalCount) GetContactsPaged(int pageNumber, int pageSize);
}
