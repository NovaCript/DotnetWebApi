public record PagedResponse
(
    List<Contact> Contacts,
    int TotalCount,
    int CurrentPage,
    int PageSize
);