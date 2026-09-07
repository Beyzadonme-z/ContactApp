using ContactApp.Models;

namespace ContactApp.Services;

public class InMemoryContactRepository : IContactRepository
{
    private readonly List<Contact> _contacts;
    private int _nextId = 1;
    public InMemoryContactRepository()  //Yapıcı metot
    {
        _contacts = new List<Contact>(); //Nesne tanımlandı

        //seed data(çekirdek)
        var seed = new List<Contact>()
        {  
            //nesne Tanımları veriyorum. Çekirdek datalar
            new Contact(){FirstName="Ahmet",LastName="Yılmaz",Email="ahmetyilmaz@example.com",Phone="+90565225552", Company="BTK Akademi",Title="Yazılım Geliştirme Uzmanı", Notes=".NET"},
            new (){FirstName="Beyza",LastName="Dönmez",Email="beyzadonmez@example.com",Phone="+90554222252", Company="BTK Akademi",Title="Yazılımcı", Notes="C#"},
            new (){FirstName="Ali",LastName="Yıl",Email="aliyil@example.com",Phone="+90565227772", Company="BTK Akademi",Title="Bilgisayar programcısı", Notes="Donanım"},
            new (){FirstName="Mehmet",LastName="Az",Email="mehmetaz@example.com",Phone="+905651111552", Company="BTK Akademi",Title="Yazılım mühendisi", Notes="Kodlama"},
            new (){FirstName="Ayşe",LastName="Var",Email="aysevar@example.com",Phone="+905651118852", Company="BTK Akademi",Title="Muhasebeci", Notes="Hesaplama"},
            new (){FirstName="Talat",LastName="Aydın",Email="talataydin@example.com",Phone="+905999111552", Company="BTK Akademi",Title="Saha sorumlusu", Notes="Analiz"},
            new (){FirstName="Mahmut",LastName="Demir",Email="mahmutdemir@example.com",Phone="+90565115552", Company="BTK Akademi",Title="Mühendis", Notes="Makine"},
            new (){FirstName="Sevil",LastName="Yalnız",Email="sevilyalniz@example.com",Phone="+9056511144452", Company="BTK Akademi",Title="İnsan Kaynakları", Notes="İletişim"}
        };
        foreach(var c in seed) //Hepsine id verdim
        {
            c.Id = _nextId++;
            _contacts.Add(c);
        }
    }
    public Contact Add(Contact contact) //Ekleme işlemi
    {
        contact.Id = _nextId++;
        _contacts.Add(contact);
        return contact;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id); //Var olan kaydı sorgulama
        if (existing is null) //Böyle bir şey var ise bunu silmemiz mümkün değil
            return false;
        _contacts.Remove(existing); //O yoksa var olan silinir
            return true;
    }

    public IEnumerable<Contact> GetAll() => // Bu işaretin anlamı:Metot gövdesi yerine kısa yazım olacak.

        _contacts //Contact a git
            .OrderBy(c => c.LastName) //Soyada göre sırala
            .ThenBy(c => c.FirstName); //Aynı olanları isme göre sırala



    public Contact? GetById(int id) =>

        _contacts.FirstOrDefault(c => c.Id.Equals(id)); //Contact daki her c elemanının id özelliğini- 
    // parametre olarak gelen id özelliğiyle karşılaştırıyor. Koşulu sağlayan ilk elemanı döndürür.


    public bool Update(Contact contact)//Güncelleme 
    {
        var existing = GetById(contact.Id); //Kaydı sorgulama
        if (existing is null)
            return false;
        existing.FirstName = contact.FirstName;
        existing.LastName = contact.LastName;
        existing.Email = contact.Email;
        existing.Phone = contact.Phone;
        existing.Title = contact.Title;
        existing.Company = contact.Company;
        existing.Notes = contact.Notes;
        return true;

    }
}

