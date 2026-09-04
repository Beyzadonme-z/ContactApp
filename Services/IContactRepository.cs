using ContactApp.Models; //Models klasörüne bağlanma 
    namespace ContactApp.Services;


public interface IContactRepository
    {
    IEnumerable<Contact> GetAll();// Birbirlerini görsünler
    Contact? GetById(int id);
    Contact Add(Contact contact);
    bool Update(Contact contact);
    bool Delete(int id);

    }

