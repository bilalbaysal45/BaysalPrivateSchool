# BaysalPrivateSchool
MVC Project 

Kullanılan Veri Tabanı: SQLITE

Kullanılan Teknolojiler: EntityFramework, .NET Core, .NET MVC, .NET API

Kullanılan Pattern: Generic Repository Pattern

Katmanlı Mimari yapısı kullanılmıştır.

 MVC Uygulama API dan dataları elde eder. API çalışmaz ise veriler gelmez. Üst menü den anasayfa, hakkında, iletişim, öğrenci klublerini 
ve personelleri göre bilirsiniz.
 Menünün üst tarafında açılır kapanır öğretmen ve öğrenci loginleri bulunmaktadır.
 Anasayfa da En altta öğrenci kluplerinin haberlerini görebilirsiniz.
 Arealarda ADMINLTE'nin datatable yapısı kullanılmıştır.
 Ögrenci giriş yaparken kendi oluşturduğum basit bir login mantığı ile email ve password kontrol edilir(SQLITE da email şifre alarak deneyebilirsiniz),
doğru ise öğrenci area'ya yönlendirilip giriş sağlanır. Burada öğrenci kendi bilgilerini görür. Öğrenci klübüne katılabilir, ders notlarını
görebilir.
 Öğretmen giriş yaparken aynı login mantığını kullanır. Bilgiler doğru ise Öğretmen area'ya yönlendirilip giriş sağlanır. Girişte tüm
personeller ve bunların bilgileri gözükür. Personeller için CRUD işlemleri burada yapılabilir. StudentHome kısmında aynı işlemler öğrenciler
için de yapılabilir. Note girme kısmında her personel kendi notunu girer ya da güncelleme yapar. StudentClubNews kısmında ise her personel
bulunduğu klübü görür. isterse ona ait haberlere bakıp Haber ekleme güncelleme yapabilir.
