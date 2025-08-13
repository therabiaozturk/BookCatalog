Controller > Services > Repo > DB

Controller = API yada WebAPI
Service = Business Layer
Repository, DBcontext = DataAccess
Tüm tanımlamalar = Model



HttpDelete, HttpPatch, HttpPut bunları httpPosta çevir
HttpGetleri ise HttpPosta çevir.
Her Create isteğinde oluşan kullanıcnın idsini dön 
Tüm isteklerde dbye giden yerlerde await kullan 
Guidlerin kullanımını değiştir. Guidler artık string olarak tanımlı. Sıfırdan oluşturmak için ise Guid.NewGuid().ToString()

Bunu araştır: "await _context.SaveChangesAsync()" bu ile             "_context.SaveChanges()" bu arasındaki fark ne yapmaya gerek var mı?

guid düzeltince migration InitialCreate i baştan çalıştır.