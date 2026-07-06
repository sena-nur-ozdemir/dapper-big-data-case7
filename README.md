# 📦 LogiFlow — Dapper ile Büyük Veri Lojistik Analitik Sistemi

Dapper ORM kullanılarak geliştirilmiş, **1.000.000 (Bir Milyon)** veri kaydı ile çalışan gerçek zamanlı kargo operasyon merkezi, analitik dashboard ve lojistik yönetim sistemi.

### 📌 Proje Hakkında ve Amacı
Bu proje, **M&Y Yazılım Eğitim Akademi .NET Full Stack Bootcamp** kapsamında geliştirilen **Case #7** çalışmasıdır. 

**Projenin Temel Hedefleri:**
* **Dapper ORM**'in gücünü kullanarak yüksek hacimli verilerde (Big Data) maksimum okuma/yazma performansı elde etmek.
* **1.000.000+** tutarlı kargo/sevkiyat verisini tarayıcıyı yormadan Server-Side Paging (Sunucu Taraflı Sayfalama) ile yönetmek.
* Karmaşık SQL sorguları ve `QueryMultiple` yapıları ile gerçek zamanlı lojistik analizleri (ciro, rotalar, risk durumları) oluşturmak.

---

### 📊 Sistem Özeti ve Mimari

LogiFlow, operasyonel verileri hem görselleştiren hem de yönetilmesini sağlayan iki ana bacaktan oluşur. Sistem genelinde **ViewComponent mimarisi** kullanılmış olup, ağır veriler sayfanın yüklenmesini beklemeden asenkron olarak parçalar halinde render edilir.

#### 🚀 Öne Çıkan Özellikler ve Dashboard Bileşenleri

* **Özet KPI Kartları:** 1 milyon kargonun toplam hacmi, üretilen toplam ciro, teslimat başarı oranı ve anlık transfer akışı tek sorguda (`QueryMultiple` benzeri optimize SQL ile) hesaplanır.
* **Günlük Operasyon Hacmi (Line Chart):** Operasyonun son 7 günlük paket çıkış trendi gün bazında gruplanarak çizgi grafikte gösterilir.
* **Kargo Statü Dağılımı (Doughnut Chart):** Hazırlanıyor, Yolda, Dağıtımda, Teslim Edildi ve İade durumlarının oransal pasta grafiği.
* **En Yoğun Rotalar & Çıkış Şehirleri:** İller arası kargo trafiği, en çok ciro getiren hatlar ve çıkış yükünü çeken merkezler custom progress barlarla listelenir.
* **İade & Risk Analizi:** En çok "İade" alan kritik varış illeri kırmızı risk kartlarıyla tespit edilir.
* **Son İşlemler Canlı Akışı:** 1 milyonluk veritabanına düşen son 5 kargo hareketinin anlık tablosu.

#### 🗺️ Leaflet.js ile Canlı Türkiye Haritası
Türkiye haritası üzerinde gerçek zamanlı kargo varış noktaları gösterilmektedir. Hangi şehre ne kadar kargo iniyorsa, Leaflet.js üzerindeki dinamik çemberlerin yarıçapı veritabanından gelen bu hacme göre otomatik olarak büyüyüp küçülmektedir.

#### 📦 Kargo Yönetimi (CRUD ve Sayfalama)
* 1 Milyon satırlık ana tablo.
* Tarayıcıyı dondurmayan Server-Side Paging (Sayfalama) altyapısı.
* Takip Numarasına (Tracking Number) göre anında getirme, durum güncelleme ve iptal (silme) işlemleri.

---

### 🛠️ Kullanılan Teknolojiler

| Katman | Teknoloji |
| :--- | :--- |
| **Backend** | ASP.NET Core 8.0 MVC, C# |
| **ORM & Veri Erişimi** | Dapper (Mikro ORM), Task Asynchronous Programming |
| **Veritabanı** | Microsoft SQL Server (MSSQL) |
| **Frontend Mimari** | Razor Views, ViewComponents |
| **Görselleştirme** | Chart.js (Grafikler), Leaflet.js (Harita) |
| **Tasarım & İkonlar** | Bootstrap 5, FontAwesome 6, Google Fonts |
| **Yapay Zeka** | Google Gemini AI |

---

### 🗃️ 1 Milyonluk Veri Seti ve Performans Optimizasyonu

Bu proje sembolik verilerle değil, lojistik senaryosuna uygun matematiksel dağılımla üretilmiş **1.000.000 satırlık** gerçek bir test veritabanı üzerinde çalışmaktadır.
* Veritabanı şişmelerini (Timeout) önlemek adına Dapper sorgularında `commandTimeout: 120` güvenlik bariyerleri kullanılmıştır.
* Ağır tarih bazlı gruplamalar (`GROUP BY`) için SQL Server üzerinde **Non-Clustered Index** optimizasyonları (örn: `IX_Shipments_CreatedAt`) yapılmış ve sorgu süreleri saniyelerin altına indirilmiştir.

---

### 🤖 Yapay Zeka Entegrasyonu

Bu proje, modern yazılım mühendisliği pratiklerine uygun olarak yapay zeka destekli geliştirme yaklaşımıyla inşa edilmiştir. Projenin mimari kurgusu, Dapper sorgu optimizasyonları, SQL indeksleme stratejileri ve UI/UX tasarım süreçlerinde Google Gemini AI'dan aktif olarak analitik ve kodlama desteği alınmıştır.

---

### 📸 Ekran Görüntüleri

<details>
  <summary><b>🌍 1. Genel Bakış (Dashboard)</b></summary>
  <br>
  <i>LogiFlow'un kalbi: 1 milyon verinin anlık olarak Leaflet.js haritası, Chart.js grafikleri ve özet kartlarla görselleştirildiği ana operasyon merkezi.</i>
  <br><br>
  <img width="1920" height="1905" alt="screencapture-localhost-7221-Dashboard-Index-2026-07-07-01_44_06" src="https://github.com/user-attachments/assets/f025f87b-5e9d-4153-a40e-d807f2c25ae2" />
  
  <img width="1917" height="862" alt="dapper1" src="https://github.com/user-attachments/assets/4e68f005-96e2-4420-afb4-429b9842f79e" />

</details>

<details>
  <summary><b>📦 2. Operasyon Yönetimi (Kargo Listesi & Yeni Kayıt)</b></summary>
  <br>
  <i>Server-Side Paging (Sunucu taraflı sayfalama) ile 1.000.000 verinin tarayıcıyı dondurmadan listelendiği, anlık CRUD ve arama işlemlerinin yapıldığı ekranlar.</i>
  <br><br>
  <img width="1920" height="1098" alt="screencapture-localhost-7221-Shipment-Index-2026-07-07-02_38_27" src="https://github.com/user-attachments/assets/c5dfd4b9-30b5-4364-a472-c1356d00f9ef" />

  <img width="1917" height="867" alt="dapper2" src="https://github.com/user-attachments/assets/c970abc9-4e61-4276-b335-0c4f5a5506e2" />

  <br>
  <img width="1917" height="862" alt="dapper3" src="https://github.com/user-attachments/assets/293d0e3f-af1c-4cff-87e8-9ffcf4da3ed3" />

</details>

<details>
  <summary><b>🗺️ 3. Lojistik Ağımız ve Analitik (Transfer, Şehir ve Risk Analizi)</b></summary>
  <br>
  <i>Türkiye genelindeki transfer merkezlerinin yoğunluğu, şehirlere göre dağılım istatistikleri ve operasyonel iade/risk raporlamalarını barındıran analitik paneller.</i>
  <br><br>
  <img width="1917" height="862" alt="dapper4" src="https://github.com/user-attachments/assets/a56a04bd-a506-4d2d-89b6-180f208afae1" />
  <br>
  <img width="1911" height="860" alt="dapper5" src="https://github.com/user-attachments/assets/68c9e2fe-94f8-4555-9126-66c4a02a63c3" />
  <br>
  <img width="1917" height="861" alt="dapper6" src="https://github.com/user-attachments/assets/9d1233ab-25ba-42bb-873a-f346cf75faea" />

</details>

---
**👩‍💻 Developer:** Sena Nur Özdemir — [GitHub Profilim](https://github.com/sena-nur-ozdemir)
