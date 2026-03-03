public class ContactStorage
{

    public ContactStorage()
    {
        this.Contacts = new List<Contact>();

        for (int i = 1; i <= 5; i++)
        {
            this.Contacts.Add(new Contact()
            {
                Id = i,
                Name = $"Full name {i}",
                Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{i}@gmail.com"
            });
        }
    }

    public List<Contact> Contacts { get; set; }
}